using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BELineaDetalle
    {
        public BEProducto Producto { get; set; }

        public string DescProducto { get; set; }

        public int Cantidad { get; set; }

        public float Importe { get; set; }
    }
}
