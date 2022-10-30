using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BEVenta
    {
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }

        public int IdEstado { get; set; }

        public int IdTipoVenta { get; set; }

        public int? IdCliente { get; set; }

        public float Monto { get; set; }
    }
}
