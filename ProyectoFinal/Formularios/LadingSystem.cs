using System;
using System.Windows.Forms;
using ProyectoFinal.Formularios;
using BLL.Interfaces;
using UI.Interfaces;
using DAL.DAO.Interfaces;
using DAL.DAO.Implementacion;
using BE.Interfaces;

namespace ProyectoFinal.Formularios
{
    public partial class LadingSystem : Form
    {
        public LadingSystem()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Acciones cerrar

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion

        #region Mover Formulario sin bordes
        //PASO 1: se declaran variables globales
        public int xClick = 0, yClick = 0;

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TituloBar_Paint(object sender, PaintEventArgs e)
        {

        }

        //PASO 2: en el evento MouseMove del Form
        private void TituloBar_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion


        private void btnConfigBD_Click(object sender, EventArgs e)
        {
            ConectionString aConctionString = new ConectionString();
            aConctionString.Show();
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Login mLogin = new Login(
                IoCContainer.Resolve<BLLIIdioma>(),
                IoCContainer.Resolve<IDigitoVerificador>(),
                IoCContainer.Resolve<ITraductor>());
            mLogin.Show();
        }
    }
}
