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
    public partial class AdminFamiliaUsuario : Form, IAdminFam
    {
        private const string lblUsu = "Usuario: ";
        private readonly BLLIPatente patenteBLL;
        private readonly BLLIFamilia familiaBLL;
        private IABMUsuario aBMUsuario;

        public BECuentaUsuario UsuarioSeleccionado { get; set; } = new BECuentaUsuario();

        public BEFamilia FamiliaUsuarioSeleccionada { get; set; } = new BEFamilia();

        public BEFamilia FamiliaSistemaSeleccionada { get; set; } = new BEFamilia();

        public AdminFamiliaUsuario(BLLIFamilia familiaBLL, BLLIPatente patenteBLL)
        {
            this.familiaBLL = familiaBLL;
            this.patenteBLL = patenteBLL;
            InitializeComponent();
        }

        private void AdminFamiliaUsuario_Load(object sender, EventArgs e)
        {
            aBMUsuario = IoCContainer.Resolve<IABMUsuario>();

            UsuarioSeleccionado = aBMUsuario.ObtenerUsuarioSeleccionado();

            CargarListas();

            ActualizarSeleccionado();

            CargarLbl();
        }

        private void CargarLbl()
        {
            lblUsuario.Text = string.Empty;
            lblUsuario.Text = lblUsu + UsuarioSeleccionado.Email;
        }

        private void ActualizarSeleccionado()
        {
            var descFamiliaSistema = FamSistema.GetItemText(FamSistema.SelectedItem);
            var descFamiliaUsuario = FamUsuario.GetItemText(FamUsuario.SelectedItem);

            if (!(descFamiliaSistema == string.Empty))
            {
                FamiliaSistemaSeleccionada = familiaBLL.ObtenerFamiliaConDescripcion(descFamiliaSistema);
            }

            if (!(descFamiliaUsuario == string.Empty))
            {
                FamiliaUsuarioSeleccionada = familiaBLL.ObtenerFamiliaConDescripcion(descFamiliaUsuario);
            }
        }

        private void CargarListas()
        {
            LimpiarListas();

            CargarFamiliaSistema();
            CargarFamiliaUsuario();
        }

        private void LimpiarListas()
        {
            FamUsuario.ClearSelected();
            FamSistema.ClearSelected();
            FamUsuario.SelectedItem = null;
            FamSistema.DataSource = null;
            FamUsuario.DataSource = null;
        }

        private void CargarFamiliaUsuario()
        {
            var familiasUsuario = UsuarioSeleccionado.Familia.Select(fam => fam.Descripcion).ToList();

            if (familiasUsuario.Count > 0)
            {
                FamUsuario.DataSource = UsuarioSeleccionado.Familia.Select(fam => fam.Descripcion).ToList();
            }
            else
            {
                FamUsuario.DataSource = null;
            }
        }

        private void CargarFamiliaSistema()
        {
            var familiasBd = familiaBLL.Cargar().Select(fam => fam.Descripcion).ToList();

            if (familiasBd.Count > 0)
            {
                FamSistema.DataSource = familiaBLL.Cargar().Select(fam => fam.Descripcion).ToList();
            }
            else
            {
                FamSistema.DataSource = null;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            LimpiarListas();

            this.Hide();
        }

        //boton para quitar familia a un usuario.
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            var permitir = patenteBLL.CheckeoFamiliaParaBorrar(FamiliaUsuarioSeleccionada, aBMUsuario.ObtenerUsuariosBd());

            if (permitir)
            {

                if (UsuarioSeleccionado.Familia.Any(famUsu => famUsu.IdFamilia == FamiliaUsuarioSeleccionada.IdFamilia))
                {
                    UsuarioSeleccionado.Familia.RemoveAll(famUsu => famUsu.IdFamilia == FamiliaUsuarioSeleccionada.IdFamilia);
                }

                familiaBLL.BorrarFamiliasUsuario(new List<BEFamilia>() { FamiliaUsuarioSeleccionada }, UsuarioSeleccionado.IdUsuario);

            }
            else
            {
                Alert.ShowSimpleAlert("No puede quitar esta familia", "MSJ035");
            }

            CargarListas();
        }

        //boton para asignar familia al usuario.
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            if (!UsuarioSeleccionado.Familia.Any(famUsu => famUsu.IdFamilia == FamiliaUsuarioSeleccionada.IdFamilia))
            {
                UsuarioSeleccionado.Familia.Add(FamiliaSistemaSeleccionada);
            }

            familiaBLL.GuardarFamiliasUsuario(new List<int>() { FamiliaSistemaSeleccionada.IdFamilia }, UsuarioSeleccionado.IdUsuario);

            CargarListas();
        }
    }
}
