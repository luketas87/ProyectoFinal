using System;
using System.Windows.Forms;
using BLL;
using BE;
using BE.Interfaces;
using BE.Implementacion;
using BLL.implementacion;
using BLL.Interfaces;
using Seguridad;
using Servicios;
using Servicios.Excepciones;

namespace ProyectoFinal
{
    public partial class Login : Form
    {
        private const string nombreFormulario = "Login";

        //private log4net.ILog log;
        private IPrincipal PrincipalForm;
        private BLLIUsuario usuarioBLL;
        private IFormControl formControl;
        private readonly BLLIIdioma idiomaBLL;
        private readonly IDigitoVerificador digitoVerificador;
        private readonly ITraductor traductor;
        //private IPatenteBLL patenteBLL;
        //private IVentaBLL ventaBLL;
        //private IBitacoraBLL bitacoraBLL;

        public Login(BLLIIdioma idiomaBLL, /*IDigitoVerificador digitoVerificador,*/ ITraductor traductor)
        {
            //this.digitoVerificador = digitoVerificador;
            this.idiomaBLL = idiomaBLL;
            this.traductor = traductor;
            InitializeComponent();
            TxtContrasenia.PasswordChar = '*';
        }
        #region Acciones minimizar y cerrar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void PicCerrar_Click(object sender, EventArgs e)
        {
            if (Alert.ConfirmationMessage("MSJ001", "Salir del Sistema", MessageBoxButtons.YesNo, "¿Seguro que desea salir?") == DialogResult.Yes)
            {
                this.Close();
            }
            //Application.Exit();
        }

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

        BLCuentaUsuario ncuentaUsuario = new BLCuentaUsuario();

        public Encriptador mEncriptador = new Encriptador();

        private void lblRecuperarC_Click(object sender, EventArgs e)
        {

        }
        private void Traduccir()
        {
            traductor.Traduccir(this, nombreFormulario);
        }
        //Cargo el idioma
        private void CargarCombo()
        {
            var idioma = idiomaBLL.ObtenerTodosLosIdiomas();
            cmbIdioma.DataSource = idioma;
            cmbIdioma.ValueMember = "IdIdioma";
            cmbIdioma.DisplayMember = "Descripcion";
            cmbIdioma.SelectedIndex = 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CargarCombo();
            formControl.LenguajeSeleccionado = (Idioma)cmbIdioma.SelectedItem;
            Traduccir();
            ComprobarBD();
            /* cmbIdioma.Items.Add("Seleccione un idioma");
             cmbIdioma.Items.Add("Español");
             cmbIdioma.Items.Add("Ingles");
             cmbIdioma.SelectedItem = "Seleccione un idioma";
             TxtUsuario.Text = "abc";
             TxtContrasenia.Text = "abc";*/
        }

        private void ComprobarBD()
        {
            if(!digitoVerificador.ComprobarIntegridad())
            {
                Alert.ShowSimpleAlert("Problema integridad base de datos, contacte al administrador", "ADMB000");

                var items = new Clases.InputBoxItem[2];
                items[0] = new Clases.InputBoxItem("Usuario", "", false);
                items[1] = new Clases.InputBoxItem("Contraseña", "", true);

                var input = Clases.OptionBox.Show("Ingrese credenciales de un administrador", items, Clases.InputBoxButtons.OK);
                
                if (input.Result == Clases.InputBoxResult.OK)
                {
                    var usuario = usuarioBLL.ObtenerUsuarioConEmail(input.Items["Usuario"]);
                    formControl.GuardarDatosSesionUsuario(usuario);
                    formControl.ObtenerPermisosUsuario();
                    usuario = formControl.ObtenerInfoUsuario();
                }
            }
        }


        //Combo para seleccionar el idioma
        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lenguajeSeleccionado = (Idioma)cmbIdioma.SelectedItem;
            formControl.LenguajeSeleccionado = lenguajeSeleccionado;

            Traduccir();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = TxtUsuario.Text;
            var contrasenia = TxtContrasenia.Text;

            try
            {
                if (usuarioBLL.ObtenerUsuarioConEmail(usuario).UsuarioActivo)
                {
                    var ingresa = usuarioBLL.Login(usuario, contrasenia);

                    if (ingresa)
                    {
                        this.Hide();
                        formControl.GuardarDatosSesionUsuario(usuarioBLL.ObtenerUsuarioConEmail(usuario));
                        PrincipalForm.ComprobarPrimerLogin(usuario);
                        PrincipalForm.Show();
                    }

                    else if (usuarioBLL.ObtenerUsuarioConEmail(usuario).Cuenta_usuario_intentos_login < 3)
                    {
                        MessageBox.Show("Login Incorrecto", "Ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Cuenta bloqueada contacte a su administrador", "Ingresar al Sistema", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Coloque Usuario y Contraseña", "Ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (LoginException)
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasenia))
                {
                    MessageBox.Show("Revise bien los campos ingresados", "Ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                throw;
            }

            catch (ConectionStringFaltanteException)
            {

                MessageBox.Show("No se encuentra el string de conexion, hable con el administrador del sistema", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConectionString aConctionString = new ConectionString();
                aConctionString.Show();
            }




            //VIEJO LOGIN
            //try
            //{
            //    int idioma = 1;

            //    BECuentaUsuario mCuentaUsuario = ncuentaUsuario.ValidarUsuario(TxtUsuario.Text, TxtContrasenia.Text);
            //    MessageBox.Show("Ingreso exitoso");

            //    MenuPrincipal mform = new MenuPrincipal();
            //    mform.mCuentausuario = mCuentaUsuario;

            //    if (cmbIdioma.SelectedItem.ToString() == "Español")
            //        idioma = 1;
            //    else
            //        idioma = 2;
            //}
            //catch (ConectionStringFaltanteException)
            //{

            //    MessageBox.Show("No se encuentra el string de conexion, hable con el administrador del sistema","Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ConectionString aConctionString = new ConectionString();
            //    aConctionString.Show();
            //}

            //catch (LoginException error)
            //{
            //    switch (error.Result)
            //    {
            //        case LoginResult.InvalidUsername:
            //            MessageBox.Show("Usuario incorrecto");
            //            break;
            //        case LoginResult.InvalidPassword:
            //            MessageBox.Show("Password Incorrecto");
            //            break;

            //        default:
            //            break;
            //    }
            //}
        }
    }
}
