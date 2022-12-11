using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO;
using EasyEncryption;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;
using UI.Clases;
using System.Windows.Forms;
using DAL.Utilidades;

namespace ProyectoFinal.Formularios
{
    public partial class ABMusuario : Form, IABMUsuario
    {
        private readonly ITraductor traductor;
        private readonly IDigitoVerificador digitoVerificador;
        private readonly BLLIFamilia familiasBLL;
        private readonly BLLIPatente patenteBLL;
        private readonly BLLIBitacora bitacoraBLL;
        private readonly IBloqueoUsuario bloqueoUsuario;
        private readonly IAdminPatentes adminPat;
        private readonly IAdminFam adminFam;
        private readonly INegarPat negarPat;
        private readonly IFormControl formControl;
        private readonly BLLIIdioma idiomaBLL;
        private readonly IAdminPatFamilia adminPatFamilia;

        private const int formId = 3;
        private const string nombreForm = "ABMusuario";
        private const string entidad = "Usuario";
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        public BECuentaUsuario UsuarioActivo { get; set; }

        public List<BECuentaUsuario> usuariosBD { get; set; } = new List<BECuentaUsuario>() { new BECuentaUsuario() };

        public BECuentaUsuario UsuarioSeleccionado { get; set; } = new BECuentaUsuario();

        public BEPatente PatenteSeleccionada { get; set; } = new BEPatente();

        public BEFamilia FamiliaSeleccionada { get; set; } = new BEFamilia();
        //Form IABMUsuario.MdiParent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private BLLICuentaUsuario usuarioBLL;

        public ABMusuario(BLLIBitacora bitacoraBLL,
            IFormControl formControl,
            BLLIFamilia familiasBLL,
            BLLIPatente patenteBLL,
            IDigitoVerificador digitoVerificador,
            IBloqueoUsuario bloqueoUsuario,
            BLLIIdioma idiomaBLL,
            IAdminPatentes adminPat,
            IAdminFam adminFam,
            INegarPat negarPat,
            ITraductor traductor,
            IAdminPatFamilia adminPatFamilia)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.formControl = formControl;
            this.familiasBLL = familiasBLL;
            this.patenteBLL = patenteBLL;
            this.digitoVerificador = digitoVerificador;
            this.bloqueoUsuario = bloqueoUsuario;
            this.adminPatFamilia = adminPatFamilia;
            this.idiomaBLL = idiomaBLL;
            this.negarPat = negarPat;
            this.adminFam = adminFam;
            this.adminPat = adminPat;
            this.traductor = traductor;
            InitializeComponent();
            dgusuario.AutoGenerateColumns = false;
            KeyPreview = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //boton para Asignar/quitar Patentes a los usuarios.
        private void btnAsignarPat_Click(object sender, EventArgs e)
        {
            adminPat.ShowDialog();
            HacerLoad();
        }
        private void btnAsignarFam_Click(object sender, EventArgs e)
        {
            adminFam.ShowDialog();
            HacerLoad();
        }

        private void btnUsuariosInactivos_Click(object sender, EventArgs e)
        {
            bloqueoUsuario.ShowDialog();
            HacerLoad();
        }

        private void ABMusuario_Load(object sender, EventArgs e)
        {
            usuarioBLL = UI.IoCContainer.Resolve<BLLICuentaUsuario>();

            HacerLoad();

            Traduccir();
        }

        private void HacerLoad()
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            ControlPatentes();

            CargarRefrescarDatagrid();

            //SetearObjetosSeleccionados();

            CargarPatentesFamiliaUsuarioSeleccionado();

            CargaControles();
        }

        private void ControlPatentes()
        {
            var patForm = formControl.ObtenerPermisosFormulario(formId);
            var usuarioActivo = formControl.ObtenerPermisosUsuario();
            var patentesSistema = patenteBLL.Cargar();

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Alta Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnNuevo.Enabled = false;

            }
            else
            {
                btnNuevo.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Alta Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Baja Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnBorrar.Enabled = false;
            }
            else
            {
                btnBorrar.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Baja Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "Mod Usuario")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnModificar.Enabled = false;
            }
            else
            {
                btnModificar.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "Mod Usuario").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }

            if (!patForm.Exists(item => usuarioActivo.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente = patentesSistema.Where(p => (p.Descripcion == "BloqDesb")).Select(p => p.IdPatente).FirstOrDefault())))
            {
                btnUsuariosInactivos.Enabled = false;
            }
            else
            {
                btnUsuariosInactivos.Enabled = true;

                if (usuarioActivo.Patentes.FirstOrDefault(p => p.Descripcion == "BloqDesb").Negada)
                {
                    btnNuevo.Enabled = false;
                }
            }
        }

        private void CargarRefrescarDatagrid()
        {
            dgusuario.DataSource = null;

            usuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();

            foreach (var usuario in usuariosBD)
            {
                usuario.Email = DES.Decrypt(usuario.Email, key, iv);
            }

            dgusuario.DataSource = usuariosBD;
        }

        private void SetearObjetosSeleccionados()
        {
            UsuarioSeleccionado = (BECuentaUsuario)dgusuario.CurrentRow.DataBoundItem;
        }

        private void Traduccir()
        {
            traductor.Traduccir(this, nombreForm);
        }

        private void CargaControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtNombre.Text = UsuarioSeleccionado.Nombre;
                txtApellido.Text = UsuarioSeleccionado.Apellido;
                txtEmail.Text = UsuarioSeleccionado.Email;
                txtTel.Text = UsuarioSeleccionado.Telefono.ToString();
                txtDomicilio.Text = UsuarioSeleccionado.Domicilio;
            });
        }

        private void CargarPatentesFamiliaUsuarioSeleccionado()
        {
            FormExtensions.CatchException(this, () =>
            {
                UsuarioSeleccionado.Patentes = new List<BEPatente>();
                UsuarioSeleccionado.Familia = new List<BEFamilia>();
                UsuarioSeleccionado.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioSeleccionado.IdUsuario));
                UsuarioSeleccionado.Familia = familiasBLL.ObtenerFamiliasUsuario(UsuarioSeleccionado.IdUsuario);
                foreach (var familia in UsuarioSeleccionado.Familia)
                {
                    familia.Patentes = familiasBLL.ObtenerPatentesFamilia(familia.IdFamilia);
                }
            });
        }

        private void dgusuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Revisar");
                return;
            }

            if (e.RowIndex >= 0)
            {
                UsuarioSeleccionado = (BECuentaUsuario)dgusuario.CurrentRow.DataBoundItem;

                CargarPatentesFamiliaUsuarioSeleccionado();

                CargaControles();
            }
        }

        private void ABMusuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void MantenerUsuarioSeleccionado()
        {
            var indice = dgusuario.SelectedRows[0].Index;
            dgusuario.DataSource = null;

            usuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();

            foreach (var usuario in usuariosBD)
            {
                usuario.Email = DES.Decrypt(usuario.Email, key, iv);
            }

            dgusuario.DataSource = usuariosBD;
            dgusuario.Rows[0].Selected = false;
            dgusuario.Rows[indice].Selected = true;
        }

        private bool verificarDatos()
        {
            var returnValue = true;

            if (txtEmail.Text == DES.Decrypt(UsuarioActivo.Email, key, iv))
            {
                Alert.ShowSimpleAlert("No puede realizar acciones sobre el usuario activo", "MSJ031");
                Log4netExtensions.Alta(log, "Se intento eliminar o modificar al usuario activo");
                bitacoraBLL.RegistarEnBitactoraTabla("Se intento eliminar o modificar al usuario activo", "ALTA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                returnValue = false;
            }

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    Alert.ShowSimpleAlert("Todos los datos deben estar completos", "MSJ033");
                    Log4netExtensions.Baja(log, "Todos los datos deben estar completos");
                    bitacoraBLL.RegistarEnBitactoraTabla("Todos los datos deben estar completos", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                    returnValue = false;
                    break;
                }

                if (tb.Name == "txtNombre")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo nombre no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtApellido")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo apellido no acepta numeros");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtTel")
                {
                    if (Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("no puede ingresar letras");
                        returnValue = false;
                    }
                }
            }

            return returnValue;
        }

        private void LimpiarControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTel.Text = string.Empty;
                txtDomicilio.Text = string.Empty;
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!usuariosBD.Exists(usuario => usuario.Email == txtEmail.Text))
            {
                var permitir = verificarDatos();
                if (permitir)
                {
                    var creado = usuarioBLL.Crear(
                        new BECuentaUsuario()
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Telefono = int.Parse(txtTel.Text),
                            Domicilio = txtDomicilio.Text,
                            PrimerLogin = true,
                            ContadorIngresosIncorrectos = 0,
                            Activo = true
                        });

                    var usu = usuarioBLL.ObtenerUsuarioConEmail(txtEmail.Text);

                    if (creado)
                    {
                        if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                        {
                            digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }
                        else
                        {
                            digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }

                        Log4netExtensions.Media(log, "Se ha creado un nuevo usuario");
                        bitacoraBLL.RegistarEnBitactoraTabla("Se ha creado un nuevo usuario", "MEDIA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                        bitacoraBLL.RegistrarEnBitacora(usu);
                        Alert.ShowSimpleAlert("Registro exitoso", "MSJ017");
                        CargarRefrescarDatagrid();
                        LimpiarControles();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "El registro de nuevo usuario ha fallado");
                        bitacoraBLL.RegistarEnBitactoraTabla("El registro de nuevo usuario ha fallado", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                        bitacoraBLL.RegistrarEnBitacora(usu);
                        Alert.ShowSimpleAlert("El registro de nuevo usuario ha fallado", "MSJ019");
                    }
                }
            }
            else
            {

                Alert.ShowSimpleAlert("No pueden haber 2 usuarios con el mismo email", "MSJ021");
                Log4netExtensions.Alta(log, "Se intento guardar o modificar un usuario con el mismo email");
                bitacoraBLL.RegistarEnBitactoraTabla("Se intento guardar o modificar un usuario con el mismo email", "ALTA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!usuariosBD.Exists(usuario => usuario.Email == txtEmail.Text))
            {
                var permitir = verificarDatos();
                if (permitir)
                {
                    
                    var modificado = usuarioBLL.Actualizar(new BECuentaUsuario() {
                        
                        Nombre = txtNombre.Text, 
                        Apellido = txtApellido.Text, 
                        Email = DES.Encrypt(txtEmail.Text, key, iv), 
                        Telefono = int.Parse(txtTel.Text), 
                        Domicilio = txtDomicilio.Text, PrimerLogin = true, 
                        ContadorIngresosIncorrectos = 0, Activo = true });

                    if (modificado)
                    {
                        if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                        {
                            digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }
                        else
                        {
                            digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }

                        //Log4netExtensions.Baja(log, string.Format("Se ha modificado al usuario {0}", DES.Decrypt(UsuarioSeleccionado.Email, key, iv)));
                        //Email= DES.Decrypt(txtEmail.Text, key, iv);
                        bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                        Alert.ShowSimpleAlert("Modificacion exitosa", "MSJ023");
                        CargarRefrescarDatagrid();
                        LimpiarControles();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "La modificacion ha fallado");
                        bitacoraBLL.RegistarEnBitactoraTabla("La modificacion ha fallado", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                        bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                        Alert.ShowSimpleAlert("La modificacion ha fallado", "MSJ025");
                        CargarRefrescarDatagrid();
                    }
                }
            }
            else
            {
                Alert.ShowSimpleAlert("No pueden haber 2 usuarios con el mismo email", "MSJ021");
                Log4netExtensions.Alta(log, "Se intento guardar o modificar un usuario con el mismo email");
                bitacoraBLL.RegistarEnBitactoraTabla("Se intento guardar o modificar un usuario con el mismo email", "ALTA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());

            }
        }

        public bool CheckeoPatentes(BECuentaUsuario usuario)
        {
            var returnValue = true;

            if (usuariosBD.Count == 1)
            {
                return false;
            }

            if (usuario.Patentes.Count > 0 || usuario.Familia.Count > 0)
            {
                returnValue = patenteBLL.CheckeoUsuarioParaBorrar(usuario, usuariosBD);
            }

            return returnValue;

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var permitir = verificarDatos();

            if (permitir)
            {
                if (CheckeoPatentes(UsuarioSeleccionado))
                {
                    //update activo 
                    var borrado = usuarioBLL.Borrar(UsuarioSeleccionado);

                    if (borrado)
                    {
                        familiasBLL.BorrarFamiliasUsuario(UsuarioSeleccionado.Familia, UsuarioSeleccionado.IdUsuario);
                        if (digitoVerificador.ComprobarPrimerDigito(digitoVerificador.Entidades.Find(x => x == entidad)))
                        {
                            digitoVerificador.InsertarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }
                        else
                        {
                            digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));
                        }

                        Log4netExtensions.Alta(log, string.Format("Se borrado al usuario {0}", UsuarioSeleccionado.Email));
                        bitacoraBLL.RegistarEnBitactoraTabla("Se borrado al usuario {0}", "ALTA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                        bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                        Alert.ShowSimpleAlert("Borrado exitoso", "MSJ027");
                        //MessageBox.Show("Borrado exitoso", "Borrado de Usuario");
                        CargarRefrescarDatagrid();
                        LimpiarControles();
                    }
                    else
                    {
                        Log4netExtensions.Baja(log, "El borrado de usuario ha fallado");
                        bitacoraBLL.RegistarEnBitactoraTabla("El borrado de usuario ha fallado", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                        bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                        Alert.ShowSimpleAlert("El borrado de usuario ha fallado", "MSJ029");
                        CargarRefrescarDatagrid();
                    }
                }
                else
                {
                    Log4netExtensions.Media(log, "Una patente se encuentra en uso y no puede borrarse");
                    bitacoraBLL.RegistarEnBitactoraTabla("Una patente se encuentra en uso y no puede borrarse", "MEDIA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                    bitacoraBLL.RegistrarEnBitacora(UsuarioActivo);
                    Alert.ShowSimpleAlert("Una patente se encuentra en uso y no puede borrarse", "MSJ013");

                    CargarRefrescarDatagrid();
                }
            }
        }

        //private void SetearBotonNegada(List<BEPatente> patentes)
        //{
        //    if (UsuarioSeleccionado.Patentes?.Count > 0)
        //    {
        //        if (UsuarioSeleccionado.Patentes[0].Negada)
        //        {
        //            btnNegarPat.Text = "Habilitar Patente";
        //        }
        //        else
        //        {
        //            btnNegarPat.Text = "Negar Patente";
        //        }
        //    }
        //}

        #region Eventos grids
        private void dgusuario_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            CargarRefrescarDatagrid();
            this.dgusuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        #endregion       
        public BECuentaUsuario ObtenerUsuarioSeleccionado()
        {
            return UsuarioSeleccionado;
        }

        public List<BECuentaUsuario> ObtenerUsuariosBd()
        {
            return usuariosBD;
        }

        // boton para habilitar/Negar patente a los usuarios.
        private void btnNegarPat_Click(object sender, EventArgs e)
        {
            negarPat.ShowDialog();
            HacerLoad();
        }

        //boton para asignar/quitar familias a los usuarios.
        private void btnAsignarFam_Click_1(object sender, EventArgs e)
        {
            adminFam.ShowDialog();
            HacerLoad();
        }

        private void ABMusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                FormAyuda ayuda = new FormAyuda();
                ayuda.Show();
            }
        }

    }
}
