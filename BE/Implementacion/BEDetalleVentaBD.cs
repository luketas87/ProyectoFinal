using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BEDetalleVentaBD
    {
        public int IdDetalle { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public float Importe { get; set; }

        public int Cantidad { get; set; }
    }
}
