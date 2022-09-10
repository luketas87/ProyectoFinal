﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECuentaUsuario
    {
        private int IdCuentaUsuario { get; set; }

        private string Usuario { get; set; }

        private string Password { get; set; }

        public int IdUsuario { get; set; }

        public int Usuario_activo { get; set; } = 1;
        public string Cuenta_usuario_username
        {
            get; set;
        }
        public string Cuenta_usuario_password
        {
            get; set;
        }
        public int Cuenta_usuario_intentos
        {
            get; set;
        }
        public BECuentaUsuario() { }
        public DateTime Usuario_fecha_alta
        {
            get; set;
        }
        public void SetFechaAlta(int dia, int mes, int anio)
        {
            Usuario_fecha_alta = new DateTime(anio, mes, dia);
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
            IdUsuario = pId;
        }

      

        // private bool IsAdmin { get; set; }

    }
}
