using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BECuentaUsuario 
    {
 
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contraseña { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }

        public string Domicilio { get; set; }

        public int ContadorIngresosIncorrectos { get; set; }

        public bool Activo { get; set; }

        public int IdCanalVenta { get; set; }

        public int DVH { get; set; }

        public int IdIdioma { get; set; }

        public bool PrimerLogin { get; set; }

        public List<BEFamilia> Familia { get; set; }

        public List<BEPatente> Patentes { get; set; }
    }
}
