using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using DAL.Utilidades;
using System.IO;
using EasyEncryption;
using ProyectoFinal.Formularios;

namespace ProyectoFinal
{
    public partial class NuevaCadena : Form
    {
        public const string Key = "aZr2URKx";
        public const string Iv = "HNtgQw0w";

        public NuevaCadena()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string Cadena = "Data Source=" + txtDatasource.Text + ";Initial Catalog=" + txtInitialCatalog.Text + ";User ID=" + txtUsuario.Text + ";Password=" + txtPassword.Text;
                bool compare = ValidarConexion(Cadena);
                if (compare)
                {
                    CrearConexion(Cadena);
                    MessageBox.Show("Se crea la cadena de conexion");
                    LadingSystem mLandingSystem = new LadingSystem();
                    mLandingSystem.Show();


                }
                else
                {
                    MessageBox.Show("La cadena de conexion no es exitosa, compruebe nuevamente");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool ValidarConexion(string Cadena)
        {

            SqlConnection conn;
            using (conn = new SqlConnection(Cadena))
            {
                try
                {
                    conn.Open();
                    conn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }


        public bool CrearConexion(string Cadena)
        {
            try
            {
                var path = "C:\\Users\\lucas\\source\\repos\\ProyectoFinal\\ProyectoFinal\\secret.txt";
                var newCadenaEncrypted = DES.Encrypt(Cadena, Key, Iv);
                File.WriteAllText(path, newCadenaEncrypted);//escribo el archivo
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void NuevaCadena_Load(object sender, EventArgs e)
        {

        }

    }
}

