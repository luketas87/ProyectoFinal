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
using System.Linq;
using UI;
using Servicios.Excepciones;
using DAL.DAO.Interfaces;
using UI.Clases;

namespace ProyectoFinal.Formularios
{
    public partial class Login : Form
    {
        private const string nombreFormulario = "Login";

        
        /// <summary>
        /// No lo re conoce
        /// </summary>
        private log4net.ILog log;
        BELog logueo;
        private IPrincipal PrincipalForm;
        private IPrimcipal PrimcipalForm;
        private BLLICuentaUsuario usuarioBLL;
        private IFormControl formControl;
        private readonly BLLIIdioma idiomaBLL;
        private readonly IDigitoVerificador digitoVerificador;
        private readonly ITraductor traductor;
        private BLLIPatente patenteBLL;
        private BLLIVenta ventaBLL;
        private BLLIBitacora bitacoraBLL;

        public Login(BLLIIdioma idiomaBLL, IDigitoVerificador digitoVerificador, ITraductor traductor)
        {
            this.digitoVerificador = digitoVerificador;
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

        //BLLCuentaUsuario ncuentaUsuario = new BLLCuentaUsuario();

        public Encriptador mEncriptador = new Encriptador();
        private BLLIIdioma bLLIIdioma; 
        private IDigitoVerificador digitoVerificador1;


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
            this.AcceptButton = btnLogin;
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            PrincipalForm = IoCContainer.Resolve<IPrincipal>();
            PrimcipalForm = IoCContainer.Resolve<IPrimcipal>();
            usuarioBLL = IoCContainer.Resolve<BLLICuentaUsuario>();
            patenteBLL = IoCContainer.Resolve<BLLIPatente>();
            ventaBLL = IoCContainer.Resolve<BLLIVenta>();
            bitacoraBLL = IoCContainer.Resolve<BLLIBitacora>();
            formControl = IoCContainer.Resolve<IFormControl>();
            CargarCombo();
            formControl.LenguajeSeleccionado = (BEIdioma)cmbIdioma.SelectedItem;
            Traduccir();
            ComprobarBD();
            ComprobarConexion();
        }

        /*COMPROBACION DE INTEGRIDAD
        SI DIGITO VERIFICADOR ES DISTINTO AL ASIGNADO EN LA BASE ARROJA CARTEL DE PROBLEMA DE INTEGRIDAD.*/
        private void ComprobarBD()
        {
            if(!digitoVerificador.ComprobarIntegridad())
            {
                Alert.ShowSimpleAlert("Problema integridad base de datos, contacte al administrador", "MSJ000");

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
                    
                    if (usuario.Patentes.Any(x => x.Descripcion == "RecalcularDV"))
                    {
                        if (usuarioBLL.Login(input.Items["Usuario"], input.Items["Contrasenia"]))
                        {
                            //Esto solo recalcula el DVVertical en caso de que borren una row
                            digitoVerificador.ActualizarDVVertical("Usuario");
                            digitoVerificador.ActualizarDVVertical("Bitacora");
                            digitoVerificador.ActualizarDVVertical("Patente");
                            digitoVerificador.ActualizarDVVertical("Venta");
                            usuarioBLL.CargarDVHPatentes();
                            patenteBLL.CargarDVHPatentes();
                            bitacoraBLL.CargarDVHBitacora();
                            ventaBLL.CargarDVHVenta();
                        }
                    }
                    else
                    {
                        Alert.ShowSimpleAlert("Usted no es un usuario administrador", "MSJ070");
                        this.Close();
                    }
                }
                else
                {
                    Alert.ShowSimpleAlert("Usted no es un usuario administrador", "MSJ070");
                    this.Close();
                }

            }

        }
            
        //Combo para seleccionar el idioma
        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lenguajeSeleccionado = (BEIdioma)cmbIdioma.SelectedItem;
            formControl.LenguajeSeleccionado = lenguajeSeleccionado;

            Traduccir();
        }

        private void ComprobarConexion()
        {
            
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.CatchException(() =>
            {
                var usuario = TxtUsuario.Text;
                var contrasenia = TxtContrasenia.Text;
                //lucastoffolon@gmail. pass: Lt2022+
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasenia))
                {
                    MessageBox.Show("Revise los datos");
                }

                if (usuarioBLL.ObtenerUsuarioConEmail(usuario).Activo)
                {
                    var ingresa = usuarioBLL.Login(usuario, contrasenia);

                    if (ingresa)
                    {
                        this.Hide();
                        formControl.GuardarDatosSesionUsuario(usuarioBLL.ObtenerUsuarioConEmail(usuario));                        
                        if(formControl.LenguajeSeleccionado.IdIdioma == 1)
                        {
                            PrimcipalForm.ComprobarPrimerLogin(usuario);
                            PrimcipalForm.Show();
                        }
                        else
                        {
                            PrincipalForm.ComprobarPrimerLogin(usuario);
                            PrincipalForm.Show();
                        }

                      
                    }

                    else if (usuarioBLL.ObtenerUsuarioConEmail(usuario).ContadorIngresosIncorrectos < 3)
                    {
                        MessageBox.Show("Login Incorrecto", "Ingresar al Sistema");
                    }
                    else
                    {
                        MessageBox.Show("Cuenta bloqueada contacte a su administrador", "Ingresar al Sistema");
                    }
                }
                else
                {
                    MessageBox.Show("Coloque Usuario y Contraseña", "Ingresar al Sistema");
                }
            },
            
            (ex) => MessageBox.Show($"Ocurrio un error por lo siguiente {ex.Message}"));
        }

    }
}
