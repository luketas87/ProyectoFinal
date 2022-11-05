using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using EasyEncryption;
using DAL.Utilidades;

namespace DAL.Utilidades
{
    //conexion a la base de datos
    public class SqlUtilidades : BaseDAO
    {
        public const string Key = "aZr2URKx";
        public const string Iv = "HNtgQw0w";

        public SqlUtilidades()
        {
        }

        public static SqlConnection Connection(string newDatabaseName = null)
        {
            var path = "C:\\Users\\lucas\\source\\repos\\ProyectoFinal\\ProyectoFinal\\secret.txt";
            var readText = File.ReadAllText(path); //Leo el archivo
            var connString = DES.Decrypt(readText, Key, Iv); //Desencripto

            var conn = new SqlConnection(connString);

            if (!string.IsNullOrEmpty(newDatabaseName))
            {
                var newEncrypted = DES.Encrypt($"Data Source=.\\SQLEXPRESS;Initial Catalog={newDatabaseName};Integrated Security=True", Key, Iv); //Encripto el nuevo string
                File.WriteAllText(path, newEncrypted);//escribo el archivo
                conn = new SqlConnection(DES.Decrypt(newEncrypted, Key, Iv));
            }

            return conn;

            ////SetearConfiguracion();
            //var conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]);
            //return conn;
        }

        public static List<string> GetTables()
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> tableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }

                return tableNames;
            }
        }
        public int GenerarId(string campoId, string entidad)
        {
            var ultimoId = CatchException(() => Exec<int>($"SELECT {campoId} FROM {entidad}"));

            if (ultimoId.Count > 0)
            {
                return ultimoId.Last() + 1;
            }
            else
            {
                return 1;
            }
        }
        #region OLD
        /*
       private static void SetearConfiguracion()
       {
           ////log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
           var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           var connectionString = config
               .AppSettings.Settings["connString"]
               .Value;
           var startIndex = connectionString.IndexOf('=');
           var endIndex = connectionString.IndexOf('\\');
           var cambiarNombre = connectionString.Substring(startIndex + 1, endIndex - startIndex - 1);
           var nuevoConnectionString = connectionString.Replace(cambiarNombre, Environment.MachineName);
           config.AppSettings.Settings["connString"].Value = nuevoConnectionString;
           ////log.Logger.Repository.GetAppenders().OfType<AdoNetAppender>().SingleOrDefault().ConnectionString = nuevoConnectionString;
           config.Save(ConfigurationSaveMode.Modified, true);
       }

       private static string GetStringsFromRegister(string table, string connectionString)
       {
           string returnValue = "not implemented";

           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               var queryString = "SELECT * FROM Usuario;";

               SqlCommand command = new SqlCommand(queryString, connection);
               DataTable dt = new DataTable();

               var da = new SqlDataAdapter(command);

               try
               {
                   connection.Open();

                   da.Fill(dt);

                   foreach (DataRow dr in dt.Rows)
                   {
                   }
               }
               catch (Exception)
               {
                   throw;
               }
           }
           return returnValue;
       }*/
        #endregion

    }
}
