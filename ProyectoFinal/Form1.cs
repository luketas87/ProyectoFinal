using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
        #region Acciones minimizar y cerrar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void PicCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion

        #region Mover Formulario sin bordes
        //PASO 1: se declaran variables globales
        public int xClick = 0, yClick = 0;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //PASO 2: en el evento MouseMove del Form
        private void TituloBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { 
                xClick = e.X; yClick = e.Y; 
            }
            else
            {
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

    }
}
