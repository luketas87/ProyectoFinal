using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class TraduccionFormulario
    {
        public int IdTraduccion { get; set; }

        public int IdIdioma { get; set; }

        public int IdFormulario { get; set; }

        public string ControlName { get; set; }

        public string MensajeCodigo { get; set; }

        public string Traduccion { get; set; }
    }
}
