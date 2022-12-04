using BE.Implementacion;
using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Utilidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO.Interfaces
{
    public class LogDAO : ICrud<BELog>
    {
        private string spLogs_Add = "spLogs_Add";
        private string spLogs_GetAll = "spLogs_GetAll";
        private string spLogs_Update = "spLogs_Update"; // DO NOT IMPLEMENT!
        private string spLogs_Delete = "spLogs_Delete";
        private string spLogs_Filtrar = "spLogs_Filtrar";

        private string conectionString =  SqlUtilidades.Connection().ConnectionString;


        #region Inicializadores
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand command;
        SqlDataReader reader;
        SqlParameter parameter;
        SqlConnection connection;
        #endregion


        #region Singleton
        private LogDAO()
        {

        }

        private static LogDAO instance;

        public static LogDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new LogDAO();
            }
            return instance;
        }

        internal bool Add(BELog objAlta)
        {
            throw new NotImplementedException();
        }
        #endregion
        public bool Actualizar(BELog objUpd)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(BELog objDel)
        {
            try
            {
                using (connection = new SqlConnection(conectionString))
                {
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = spLogs_Delete;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@logID", objDel.IDLog);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();
                    reader.Close();
                }

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<BELog> Cargar()
        {
            throw new NotImplementedException();
        }

        public bool Crear(BELog objAlta)
        {

            try
            {
                using (connection = new SqlConnection(conectionString))
                {
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = spLogs_Add;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dvh", objAlta.Dvh);
                    command.Parameters.AddWithValue("@fecha", objAlta.Fecha);
                    command.Parameters.AddWithValue("@accion", objAlta.Actividad);
                    command.Parameters.AddWithValue("@usuarioID", objAlta.UsuarioID);
                    command.Parameters.AddWithValue("@criticidad", objAlta.Criticidad);
                    command.Parameters.AddWithValue("@InformacionAsociada", objAlta.informacionAsociada);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();
                    reader.Close();
                }

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        
    }
}

