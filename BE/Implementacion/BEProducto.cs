using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BEProducto
    {
        public int IdProducto { get; set; }

        public string Descripcion { get; set; }

        public float PUnitario { get; set; }

        public float PVenta { get; set; }

        public int Stock { get; set; }

        public int MinStock { get; set; }

        public bool Activo { get; set; }
    }
}
