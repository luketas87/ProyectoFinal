using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BE.Implementacion
{
    public class BEDetalleVenta
    {
        public int IdDetalle { get; set; }

        public int IdVenta { get; set; }

        public List<BELineaDetalle> LineasDetalle { get; set; } = new List<BELineaDetalle>();
       
    }
}
