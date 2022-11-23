using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace ProyectoFinal.Formularios
{
    public partial class Familias : Form, IFamilias
    {
        public BEFamilia familiaSeleccionada = null;
        private readonly BLLIFamilia familiaBLL;
        private readonly IAdminPatFamilia adminPatFamilia;
        private readonly BLLIPatente patenteBLL;
        private BLLICuentaUsuario usuarioBLL;

        public Familias(BLLIFamilia familiaBLL, BLLICuentaUsuario usuarioBLL, IAdminPatFamilia adminPatFamilia, BLLIPatente patenteBLL)
        {
            this.familiaBLL = familiaBLL;
            this.adminPatFamilia = adminPatFamilia;
            this.patenteBLL = patenteBLL;
            InitializeComponent();
        }

        public BEFamilia ObtenerFamiliaSeleccionada()
        {
            return familiaSeleccionada;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Familias_Load(object sender, EventArgs e)
        {
            CargarFamilias();
            usuarioBLL = IoCContainer.Resolve<BLLICuentaUsuario>();
        }

        private void CargarFamilias()
        {
            var descripciones = new List<string>();

            foreach (var familia in familiaBLL.Cargar())
            {
                descripciones.Add(familia.Descripcion);
            }
            chklstFamilias.DataSource = descripciones;
        }

        //boton para nueva familia.
        private void btnNueva_Click(object sender, EventArgs e)
        {
            var nombreFamilia = "";

            var items = InputBox.fillItems("NombreFamilia", nombreFamilia);

            InputBox input = InputBox.Show("Ingrese el nombre para la nueva familia", items, InputBoxButtons.OKCancel);

            if (input.Result == InputBoxResult.OK)
            {
                nombreFamilia = input.Items["NombreFamilia"];
            }

            var familias = familiaBLL.Cargar();

            if (!familias.Select(x => x.Descripcion).Contains(nombreFamilia))
            {
                var creada = familiaBLL.Crear(new BEFamilia() { Descripcion = nombreFamilia });
                var creadaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(nombreFamilia);

                familiaSeleccionada = new BEFamilia() { IdFamilia = creadaId, Descripcion = nombreFamilia };

                if (creada)
                {
                    adminPatFamilia.FamiliaNueva = true;

                    var resultado = adminPatFamilia.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        MessageBox.Show("Familia y Patentes registradas");
                    }
                }

                CargarFamilias();
                chklstFamilias.Refresh();
            }
            else
            {
                MessageBox.Show("La familia ya existe");
            }
        }



        //BOTON PARA DAR DE BAJA PATENTE Y FAMILIA.
        private void btnBajaPatente_Click(object sender, EventArgs e)
        {
            var desc = chklstFamilias.SelectedItem.ToString();
            var familia = familiaBLL.ObtenerFamiliaConDescripcion(desc);
            var returnValue = false;

            if (patenteBLL.CheckeoFamiliaParaBorrar(familia, usuarioBLL.TraerUsuariosConPatentesYFamilias()))
            {
                returnValue = true;
            }
            else
            {
                MessageBox.Show("La familia actualmente esta en uso");
            }

            if (returnValue)
            {
                var exitoso = familiaBLL.Borrar(new BEFamilia() { Descripcion = desc, IdFamilia = familiaBLL.ObtenerIdFamiliaPorDescripcion(desc) });
            }

            CargarFamilias();
            chklstFamilias.Refresh();
        }

        //BOTON MODIFICAR FAMILIAS
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var desc = chklstFamilias.SelectedItem.ToString();
            var nuevoNombre = "";

            var items = InputBox.fillItems("Familia", nuevoNombre);
            InputBox input = InputBox.Show("Ingrese un nuevo nombre", items, InputBoxButtons.OKCancel);

            if (input.Result == InputBoxResult.OK)
            {
                nuevoNombre = input.Items["Familia"];
            }

            var familias = familiaBLL.Cargar();

            if (nuevoNombre != string.Empty)
            {
                if (!familias.Select(x => x.Descripcion).Contains(nuevoNombre))
                {
                    var exitoso = familiaBLL.Actualizar(new BEFamilia() { Descripcion = nuevoNombre, IdFamilia = familiaBLL.ObtenerIdFamiliaPorDescripcion(desc) });
                    var creadaId = familiaBLL.ObtenerIdFamiliaPorDescripcion(nuevoNombre);

                    familiaSeleccionada = new BEFamilia() { IdFamilia = creadaId, Descripcion = nuevoNombre };

                    if (exitoso)
                    {
                        MessageBox.Show("Nombre Actualizado");
                    }

                    CargarFamilias();
                    chklstFamilias.Refresh();
                }
                else
                {
                    MessageBox.Show("La familia ya existe");
                }
                CargarFamilias();
                chklstFamilias.Refresh();
            }
        }

        private void Familias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnModificarTodo_Click(object sender, EventArgs e)
        {
            adminPatFamilia.ShowDialog();

            MessageBox.Show("Familia y Patentes Actualizadas");

            CargarFamilias();
            chklstFamilias.Refresh();
        }

        private void chklstFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            familiaSeleccionada = new BEFamilia() { Descripcion = chklstFamilias.SelectedItem.ToString(), IdFamilia = familiaBLL.ObtenerIdFamiliaPorDescripcion(chklstFamilias.SelectedItem.ToString()) };

        }
    }
}
