using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BECuentaUsuario 
    {
        #region VIEJO
        /*
        private int IdCuentaUsuario { get; set; }

        private string Usuario { get; set; }

        private string Password { get; set; }

        public int Cuenta_usuario_id { get; set; }

        public bool UsuarioActivo { get; set; }
        //public int cuenta_usuario_activa { get; set; } = 1;
        public string Cuenta_usuario_username
        {
            get; set;
        }
        public string Cuenta_usuario_password
        {
            get; set;
        }
        public int Cuenta_usuario_intentos_login
        {
            get; set;
        }
        public BECuentaUsuario() { }
        public DateTime Cuenta_fecha_alta
        {
            get; set;
        }
        public void SetFechaAlta(int dia, int mes, int anio)
        {
            Cuenta_fecha_alta = new DateTime(anio, mes, dia);
        }
        public bool Cuenta_cliente
        {
            get; set;
        }
        public int Cuenta_usuario_empleado_id
        {
            get; set;
        }
        public int Cuenta_usuario_cliente_id
        {
            get; set;
        }
        public BECuentaUsuario(int pId)
        {
            Cuenta_usuario_id = pId;
        }

        public int GetCuentaCliente()
        {
            int aux;
            if (Cuenta_cliente == true) { aux = 1; }
            else { aux = 0; }
            return aux;
        }

        public string GetFechaAltaToString()
        {
            string aux = Cuenta_fecha_alta.Year + "-" + Cuenta_fecha_alta.Month + "-" + Cuenta_fecha_alta.Day;
            return aux;
        }

        // private bool IsAdmin { get; set; }
        */
        #endregion
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contraseña { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }

        public string Domicilio { get; set; }

        public int ContadorIngresosIncorrectos { get; set; }

        public bool Activo { get; set; }

        public int IdCanalVenta { get; set; }

        public int DVH { get; set; }

        public int IdIdioma { get; set; }

        public bool PrimerLogin { get; set; }

        public List<BEFamilia> Familia { get; set; }

        public List<BEPatente> Patentes { get; set; }
    }
}
