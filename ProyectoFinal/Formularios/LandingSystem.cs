using System;
using System.Windows.Forms;
using ProyectoFinal.Formularios;
using BLL.Interfaces;
using UI;
using DAL.DAO.Interfaces;
using DAL.DAO.Implementacion;
using BE.Interfaces;
using Servicios.Excepciones;
using System.IO;

namespace ProyectoFinal.Formularios
{
    public partial class LandingSystem : Form
    {
        Login mLogin;

        public LandingSystem()
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
            NuevaCadena aConctionString = new NuevaCadena();
            aConctionString.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LadingSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
      
            Hide();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            try
            {
                var path = "C:\\Users\\Usuario\\source\\repos\\luketas87\\ProyectoFinal\\secret.txt";
                bool fileExist = File.Exists(path);

                if (fileExist)
                {
                    
                    mLogin = new Login(
                    IoCContainer.Resolve<BLLIIdioma>(),
                    IoCContainer.Resolve<IDigitoVerificador>(),
                    IoCContainer.Resolve<ITraductor>());


                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Usuario");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Bitacora");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Patente");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Venta");
                    mLogin.Show();
                } 
                
            }
            catch (ConectionStringFaltanteException)
            {
                //throw new ConectionStringFaltanteException();
                NuevaCadena mconexion = new NuevaCadena();
                mconexion.Show();
            }


        }
    }
}
