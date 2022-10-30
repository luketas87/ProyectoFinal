using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BECliente
    {
        public int IdCliente { get; set; }

        public string Telefono { get; set; }

        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string Domicilio { get; set; }

        public float Saldo { get; set; }

        public bool Activo { get; set; }
    }
}
