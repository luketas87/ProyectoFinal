using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;

namespace ProyectoFinal
{
    public partial class ConectionString : Form
    {
        public ConectionString()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Cadena = "Data Source=" + txtInitialCatalog.Text + ";User ID=" + txtUsuario.Text + ";Password=" + txtPassword.Text;
                NuevaCadena nConexionBD = new NuevaCadena();

                nConexionBD.CrearCadena(Cadena);
                MessageBox.Show("Se crea la cadena de conexion");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
