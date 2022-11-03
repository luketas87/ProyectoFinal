using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoFinal.Clases
{
    public class Bitacora
    {
        public string Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Funcionalidad { get; set; }

        public string Descripcion { get; set; }

        public static DataSet ListadoBitacora = new DataSet();
    }
}
