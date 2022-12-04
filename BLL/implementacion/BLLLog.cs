using BE.Implementacion;
using BE.Interfaces;
using DAL.DAO.Implementacion;
using EasyEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.implementacion
{
   /* public class BLLLog : ICrud<BELog>
    {
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        List<string> _caracteres;   
        
        #region Singleton
        private BLLLog()
        {

        }

        private static BLLLog instance;

        public static BLLLog GetInstance()
        {
            if (instance == null)
            {
                instance = new BLLLog();
            }
            return instance;
        }
        #endregion


        public bool Actualizar(BELog objUpd)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(BELog objDel) => DALLog.GetInstance().Borrar(objDel);
 

        public List<BELog> Cargar()
        {
            throw new NotImplementedException();
        }

       /* public bool Crear(BELog objAlta)
        {
            objAlta.Dvh = CalcularDVH(objAlta);
            bool response = DALLog.GetInstance().Crear(objAlta);
            if (response)
            {
               // RecalcularDVV("logs");
                return response;
            }
            return response;
        }*/

        //public void RecalcularDVV(string tabla)
        //{
        //    DALDigitoVerificador.GetInstance().ActualizarDVVertical(tabla);
        //}


       /* public int CalcularDVH(BELog log)
        {
      
            _caracteres = new List<string>();
            _caracteres.Add(log.Criticidad);
            _caracteres.Add(log.Actividad);
            _caracteres.Add(log.UsuarioID);
          //  return DALDigitoVerificador.GetInstance().CalcularDVHorizontal(_caracteres);
        }
       */
            

        
 //   }
}
