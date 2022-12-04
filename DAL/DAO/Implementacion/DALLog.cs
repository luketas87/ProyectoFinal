using BE.Implementacion;
using BE.Interfaces;
using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO.Implementacion
{
   /* public class DALLog : ICrud<BELog>
    {
        List<string> _digitos = new List<string>();

        #region Singleton
        private DALLog()
        {

        }

        private static DALLog instance;

        public static DALLog GetInstance()
        {
            if (instance == null)
            {
                instance = new DALLog();
            }
            return instance;
        }
        #endregion

        public bool Actualizar(BELog objUpd)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(BELog objDel) => LogDAO.GetInstance().Borrar(objDel);
       

        public List<BELog> Cargar()
        {
            throw new NotImplementedException();
        }

        public bool Crear(BELog objAlta)
        {
            objAlta.Dvh = CalcularDVH(objAlta);
            return LogDAO.GetInstance().Crear(objAlta);
        }


        public int CalcularDVH(BELog log)
        {
            _digitos.Clear();
            _digitos.Add(log.Criticidad);
            return DALDigitoVerificador.GetInstance().CalcularDVVertical(_digitos);
        }
    }*/
}
