using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace BE.Implementacion
{
   public class BEBitacora
    {
        public int IdLog { get; set; }

        public SqlDateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Actividad { get; set; }

        public string InformacionAsociada { get; set; }

        public string Usuario { get; set; }

        public int DVH { get; set; }
    }
}
