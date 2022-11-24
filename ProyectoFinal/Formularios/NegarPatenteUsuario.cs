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
    public partial class NegarPatenteUsuario : Form, INegarPat
    {
        private const string lblUsu = "Usuario: ";
        private readonly BLLIPatente patenteBLL;
        private readonly BLLICuentaUsuario usuarioBLL;
        private readonly BLLIFamilia familiaBLL;
        private IABMUsuario aBMUsuario;

        public BECuentaUsuario UsuarioSeleccionado { get; set; } = new BECuentaUsuario();

        public BEPatente PatenteNegadaSeleccionada { get; set; } = new BEPatente();
        public BEPatente PatenteHabilitadaSeleccionada { get; set; } = new BEPatente();

        public List<BEPatente> patentesHabilitadas { get; set; } = new List<BEPatente>();
        public List<BEPatente> patentesNegadas { get; set; } = new List<BEPatente>();
        public NegarPatenteUsuario(BLLIPatente patenteBLL, BLLICuentaUsuario usuarioBLL, BLLIFamilia familiaBLL)
        {
            this.patenteBLL = patenteBLL;
            this.usuarioBLL = usuarioBLL;
            this.familiaBLL = familiaBLL;
            InitializeComponent();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            if (PatenteNegadaSeleccionada != null)
            {
                if (UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteNegadaSeleccionada.IdPatente))
                {
                    UsuarioSeleccionado.Patentes.Where(pat => pat.IdPatente == PatenteNegadaSeleccionada.IdPatente).FirstOrDefault().Negada = false;

                    patenteBLL.HabilitarPatente(PatenteNegadaSeleccionada.IdPatente, UsuarioSeleccionado.IdUsuario);
                }

                ActualizarUsuarioSeleccionado();

                CargarListas();
            }
        }

        private void btnNegar_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            if (PatenteHabilitadaSeleccionada != null)
            {
                if (UsuarioSeleccionado.Patentes.Any(patUsu => patUsu.IdPatente == PatenteHabilitadaSeleccionada.IdPatente))
                {
                    UsuarioSeleccionado.Patentes.Where(pat => pat.IdPatente == PatenteHabilitadaSeleccionada.IdPatente).FirstOrDefault().Negada = true;
                }

                var permitido = patenteBLL.CheckeoPatenteParaBorrar(PatenteHabilitadaSeleccionada, UsuarioSeleccionado, aBMUsuario.ObtenerUsuariosBd(), true);

                if (permitido)
                {
                    patenteBLL.NegarPatente(PatenteHabilitadaSeleccionada.IdPatente, UsuarioSeleccionado.IdUsuario);
                }
                else
                {
                    MessageBox.Show("Imposible Negar esta patente");
                }

                ActualizarUsuarioSeleccionado();

                CargarListas();
            }
        }

        private void ActualizarUsuarioSeleccionado()
        {
            UsuarioSeleccionado.Patentes = null;
            UsuarioSeleccionado.Patentes = new List<BEPatente>();
            UsuarioSeleccionado.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioSeleccionado.IdUsuario));

            UsuarioSeleccionado.Familia = null;
            UsuarioSeleccionado.Familia = new List<BEFamilia>();
            UsuarioSeleccionado.Familia = familiaBLL.ObtenerFamiliasUsuario(UsuarioSeleccionado.IdUsuario);
            foreach (var familia in UsuarioSeleccionado.Familia)
            {
                familia.Patentes = familiaBLL.ObtenerPatentesFamilia(familia.IdFamilia);
            }
        }

        private void CargarLbl()
        {
            lblUsuario.Text = string.Empty;
            lblUsuario.Text = lblUsu + UsuarioSeleccionado.Email;
        }

        private void ActualizarSeleccionado()
        {
            var descPatenteNegada = PatNegadas.GetItemText(PatNegadas.SelectedItem);
            var descPatenteHabilitada = PatHabilitadas.GetItemText(PatHabilitadas.SelectedItem);

            PatenteNegadaSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteNegada, UsuarioSeleccionado.IdUsuario);
            PatenteHabilitadaSeleccionada = patenteBLL.ObtenerPatentePorDescripcion(descPatenteHabilitada, UsuarioSeleccionado.IdUsuario);
        }

        private void CargarListas()
        {
            CargarPatentes();

            LimpiarListas();

            PatHabilitadas.DataSource = patentesHabilitadas.Select(patH => patH.Descripcion).ToList();
            PatNegadas.DataSource = patentesNegadas.Select(patN => patN.Descripcion).ToList();
        }

        private void LimpiarListas()
        {
            PatHabilitadas.ClearSelected();
            PatNegadas.ClearSelected();
            PatHabilitadas.SelectedItem = null;
            PatNegadas.SelectedItem = null;
            PatHabilitadas.DataSource = null;
            PatNegadas.DataSource = null;
        }

        private void CargarPatentes()
        {
            var patentesBd = patenteBLL.Cargar();

            patentesNegadas = UsuarioSeleccionado.Patentes.Where(patN => patN.Negada == true).ToList();

            foreach (var patenteNegada in patentesNegadas)
            {
                patentesBd.RemoveAll(patBd => patBd.IdPatente == patenteNegada.IdPatente);
            }

            patentesHabilitadas = patentesBd;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            LimpiarListas();

            this.Hide();
        }

        private void PatHabilitadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }

        private void PatNegadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSeleccionado();
        }

        private void NegarPatenteUsuario_Load(object sender, EventArgs e)
        {
            aBMUsuario = IoCContainer.Resolve<IABMUsuario>();

            UsuarioSeleccionado = aBMUsuario.ObtenerUsuarioSeleccionado();

            CargarListas();

            ActualizarSeleccionado();

            CargarLbl();
        }
    }
}
