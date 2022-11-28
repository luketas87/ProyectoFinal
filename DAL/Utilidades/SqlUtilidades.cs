using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using EasyEncryption;
using DAL.Utilidades;
using Servicios.Excepciones;

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
            string readText;

            readText = File.ReadAllText(path); //Leo el archivo
            var connString = DES.Decrypt(readText, Key, Iv); ///Desencripto
            
            var conn = new SqlConnection(connString);
            if (!string.IsNullOrEmpty(newDatabaseName))
            {
                var newEncrypted = DES.Encrypt($"Data Source=localhost;Initial Catalog={newDatabaseName};Integrated Security=True", Key, Iv); //Encripto el nuevo string
                File.WriteAllText(path, newEncrypted);//escribo el archivo
                conn = new SqlConnection(DES.Decrypt(newEncrypted, Key, Iv));
            }

            return conn;
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

        #region Singleton
        public bool ValidarConexion(string Cadena)
        {

            SqlConnection conn;
            using (conn = new SqlConnection(Cadena))
            {
                try
                {
                    conn.Open();
                    conn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
        #endregion

    }
}
