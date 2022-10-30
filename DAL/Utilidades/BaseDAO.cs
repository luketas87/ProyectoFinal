using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Dapper;
using DAL.Utilidades;


namespace DAL.Utilidades
{
    public abstract class BaseDAO
    {
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Exec(string query, object param = null)
        {
            using (var connection = SqlUtilidades.Connection())
            {
                connection.Open();
                if (param == null)
                {
                    connection.Execute(query);
                }
                else
                {
                    connection.Execute(query, param);
                }

                return true;
            }
        }

        public List<T> Exec<T>(string query, object param = null)
        {
            using (var connection = SqlUtilidades.Connection())
            {
                connection.Open();

                var result = param == null ? (List<T>)connection.Query<T>(query) : (List<T>)connection.Query<T>(query, param);

                return result;
            }
        }

        protected void CatchException(Action func)
        {
            CatchException(() =>
            {
                func();
                return true;
            });
        }

        protected T CatchException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Log4netExtensions.Alta(log, ex.Message);
                throw;
            }
        }
    }
}

