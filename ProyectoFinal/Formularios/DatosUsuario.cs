using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using EasyEncryption;
using System.Windows.Forms;
using log4net;
using BE.Implementacion;
using DAL.Utilidades;
using System.Text.RegularExpressions;
using UI;

namespace ProyectoFinal.Formularios
{
    public partial class DatosUsuario : Form, IDatosUsuario
    {
        private readonly IFormControl formControl;
        private readonly BLLICuentaUsuario usuarioBLL;
        private readonly IDigitoVerificador digitoVerificador;
        private readonly DALICuentaUsuario usuarioDAL;
        private readonly BLLIBitacora bitacoraBLL;
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";
        private const string entidad = "Usuario";


        public BECuentaUsuario UsuarioActivo { get; set; }
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public DatosUsuario(IFormControl formControl, BLLICuentaUsuario usuarioBLL, IDigitoVerificador digitoVerificador, DALICuentaUsuario usuarioDAL, BLLIBitacora bitacoraBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.formControl = formControl;
            this.digitoVerificador = digitoVerificador;
            this.usuarioDAL = usuarioDAL;
            this.bitacoraBLL = bitacoraBLL;
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //CARGAMOS LA INFO DEL USUARIO.
        private void DatosUsuario_Load(object sender, EventArgs e)
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            lblNombre.Text = lblNombre.Text + UsuarioActivo.Nombre;
            lblApellido.Text = lblApellido.Text + UsuarioActivo.Apellido;
            lblDireccion.Text = lblDireccion.Text + UsuarioActivo.Domicilio;
            lblEmail.Text = lblEmail.Text + DES.Decrypt(UsuarioActivo.Email, key, iv);
            lblTelefono.Text = lblTelefono.Text + UsuarioActivo.Telefono;
            chkCont.Enabled = false;
        }


        private bool VerificarDatos()
        {
            var returnValue = true;

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Todos los datos deben estar completos", "Actualizacion de Contraseña");
                    Log4netExtensions.Baja(log, "Todos los datos deben estar completos");
                    bitacoraBLL.RegistarEnBitactoraTabla("Todos los datos deben estar completos", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                    returnValue = false;
                    break;
                }

                if (tb.Name == "txtNombre")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo nombre no acepta numeros", "Actualizacion Datos Personales");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtApellido")
                {
                    if (!Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo apellido no acepta numeros", "Actualizacion Datos Personales");
                        returnValue = false;
                    }
                }

                if (tb.Name == "txtTel")
                {
                    if (Regex.IsMatch(tb.Text, @"[a-zA-Z]"))
                    {
                        MessageBox.Show("no puede ingresar letras", "Actualizacion Datos Personales");
                        returnValue = false;
                    }
                }
            }

            return returnValue;
        }

        private void DatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        //CAMBIAR DATOS DE USUARIO
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            lblNombre.Text = "Nombre: ";
            lblApellido.Text = "Apellido: ";
            lblDireccion.Text = "Direccion: ";
            lblTelefono.Text = "Telefono: ";

            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtDireccion.Visible = true;
            txtTel.Visible = true;


            txtNombre.Text = UsuarioActivo.Nombre;
            txtApellido.Text = UsuarioActivo.Apellido;
            txtDireccion.Text = UsuarioActivo.Domicilio;
            txtTel.Text = UsuarioActivo.Telefono.ToString();

            chkCont.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                if (chkCont.Checked)
                {
                    var nuevaContraseña = "";

                    var items = InputBox.fillItems("Contraseña", nuevaContraseña);

                    InputBox input = InputBox.Show("Ingrese nueva contraseña", items, InputBoxButtons.OK);

                    if (input.Result == InputBoxResult.OK)
                    {
                        nuevaContraseña = input.Items["Contraseña"];
                        var cambioExitoso = usuarioDAL.CambiarContraseña(UsuarioActivo, nuevaContraseña, true);
                        if (cambioExitoso)
                        {
                            //Log.Info("Password Actualizado");
                            MessageBox.Show("Su contraseña fue actualizada", "Actualizacion de Contraseña");
                        }
                        else
                        {
                            //Log.Info("Fallo la actualizacion del password");
                            MessageBox.Show("Error contraseña no actualizada", "Actualizacion de Contraseña");
                        }
                    }

                    usuarioBLL.Actualizar(new BECuentaUsuario() { Nombre = txtNombre.Text, Telefono = int.Parse(txtTel.Text), Apellido = txtApellido.Text, Domicilio = txtDireccion.Text, Email = DES.Decrypt(UsuarioActivo.Email, key, iv) });
                }
                else
                {
                    usuarioBLL.Actualizar(new BECuentaUsuario() { Nombre = txtNombre.Text, Telefono = int.Parse(txtTel.Text), Apellido = txtApellido.Text, Domicilio = txtDireccion.Text, Email = DES.Decrypt(UsuarioActivo.Email, key, iv) });
                }

                digitoVerificador.ActualizarDVVertical(digitoVerificador.Entidades.Find(x => x == entidad));

                MessageBox.Show("Usuario actualizado", "Actualizacion de Contraseña");
                lblNombre.Text = lblNombre.Text + UsuarioActivo.Nombre;
                lblApellido.Text = lblApellido.Text + UsuarioActivo.Apellido;
                lblDireccion.Text = lblDireccion.Text + UsuarioActivo.Domicilio;
                lblTelefono.Text = lblTelefono.Text + UsuarioActivo.Telefono;

                txtNombre.Visible = false;
                txtApellido.Visible = false;
                txtDireccion.Visible = false;
                txtTel.Visible = false;

                this.Close();
            }
        }
    }
}
