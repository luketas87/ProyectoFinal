using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class Patente
    {
        public int IdPatente { get; set; }
        public string Descripcion { get; set; }
        public bool Negada { get; set; }
        public int DVH { get; set; }
    }
}
