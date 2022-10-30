using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BEFamilia
    {
        public int FamiliaId { get; set; }

        public string Descripcion { get; set; }

        public List<BEPatente> Patentes { get; set; }
    }
}
