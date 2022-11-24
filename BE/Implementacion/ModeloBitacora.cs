using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class ModeloBitacora
    {
        public string Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Funcionalidad { get; set; }

        public string Descripcion { get; set; }

        public static DataSet ListadoBitacora = new DataSet();
    }
}
