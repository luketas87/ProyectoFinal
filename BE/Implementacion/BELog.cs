using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Implementacion
{
    public class BELog
    {
        private int IdLog;

        private string criticidad;

        private string IdUsuario;


        private DateTime fecha;

        private string InformacionAsociada;

        private int dvh;

        private string actividad;


        public string UsuarioID
        {
            get { return IdUsuario; }
            set { IdUsuario = value; }
        }


        public int Dvh
        {
            get { return dvh; }
            set { dvh = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }


        public string Criticidad
        {
            get { return criticidad; }
            set { criticidad = value; }
        }


        public int IDLog
        {
            get { return IdLog; }
            set { IdLog = value; }
        }

        public string informacionAsociada
        {
            get { return InformacionAsociada; }
            set { InformacionAsociada = value; }
        }

    }
}

