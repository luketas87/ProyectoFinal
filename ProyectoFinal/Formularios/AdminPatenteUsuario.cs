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
    public partial class AdminPatenteUsuario : Form, IAdminFam
    {
        private const string lblUsu = "Usuario: ";
        private readonly BLLIPatente patenteBLL;
        private IABMUsuario aBMUsuario;

        public BECuentaUsuario UsuarioSeleccionado { get; set; } = new BECuentaUsuario();

        public BEPatente PatenteUsuarioSeleccionada { get; set; } = new BEPatente();

        public BEPatente PatenteSistemaSeleccionada { get; set; } = new BEPatente();

        public AdminPatenteUsuario(BLLIPatente patenteBLL)
        {
            this.patenteBLL = patenteBLL;
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            LimpiarListas();

            this.Hide();
        }

        private void AdminPatenteUsuario_Load(object sender, EventArgs e)
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

        private void CargarListas()
        {
            LimpiarListas();

            PatSistema.DataSource = patenteBLL.Cargar().Select(pat => pat.Descripcion).ToList();
            PatUsuario.DataSource = UsuarioSeleccionado.Patentes.Select(pat => pat.Descripcion).ToList();
        }

        private void LimpiarListas()
        {
            PatSistema.ClearSelected();
            PatUsuario.ClearSelected();
            PatUsuario.SelectedItem = null;
            PatSistema.DataSource = null;
            PatUsuario.DataSource = null;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            if (!UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteSistemaSeleccionada.IdPatente))
            {
                UsuarioSeleccionado.Patentes.Add(PatenteSistemaSeleccionada);
            }

            patenteBLL.GuardarPatentesUsuario(new List<int>() { PatenteSistemaSeleccionada.IdPatente }, UsuarioSeleccionado.IdUsuario);

            CargarListas();
        }

        private void ActualizarSeleccionado()
        {
            var descPatenteSistema = PatSistema.GetItemText(PatSistema.SelectedItem);
            var descPatenteUsuario = PatUsuario.GetItemText(PatUsuario.SelectedItem);

            PatenteSistemaSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteSistema, UsuarioSeleccionado.IdUsuario);
            PatenteUsuarioSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteUsuario, UsuarioSeleccionado.IdUsuario);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            var permitir = patenteBLL.CheckeoPatenteParaBorrar(PatenteUsuarioSeleccionada, UsuarioSeleccionado, aBMUsuario.ObtenerUsuariosBd());

            if (permitir)
            {
                if (UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteUsuarioSeleccionada.IdPatente))
                {
                    UsuarioSeleccionado.Patentes.RemoveAll(PatUsu => PatUsu.IdPatente == PatenteUsuarioSeleccionada.IdPatente);
                }

                patenteBLL.BorrarPatentesUsuario(new List<int>() { PatenteUsuarioSeleccionada.IdPatente }, UsuarioSeleccionado.IdUsuario);

                PatUsuario.ClearSelected();
            }
            else
            {
                Alert.ShowSimpleAlert("Al menos un usuario debe tener asignada esta patente", "MSJ015");
            }

            CargarListas();
        }

        private void PatUsuario_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }

        private void PatSistema_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }
    }
}
