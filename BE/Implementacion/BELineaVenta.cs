using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BELineaVenta
    {
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }

        public string Vendedor { get; set; }

        public string Estado { get; set; }

        public string TipoVenta { get; set; }

        public string Cliente { get; set; }

        public float Monto { get; set; }
    }
}
