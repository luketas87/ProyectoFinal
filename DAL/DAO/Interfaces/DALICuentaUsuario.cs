﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Servicios;
using BE.Interfaces;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    #region Old
    /*public class DAOCuentaUsuario
    {
        public SqlConnection mCon = new SqlConnection(new ConexionBD().CadenaConexion);

        public DataSet ExecuteDataSet(string pCadenaComando)
        {
            //Inserto filas en la base de datos
            DataSet mDs = new DataSet();
            SqlDataAdapter mDa = new SqlDataAdapter(pCadenaComando, mCon);
            mDa.Fill(mDs);
            if (mCon.State != ConnectionState.Closed) mCon.Close();
            return mDs;
        }

        public int ExecuteNonQuery(string pCommandText)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                int resultado = mCom.ExecuteNonQuery();
                mCon = new SqlConnection(new ConexionBD().CadenaConexion);
                return resultado;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText, string pDataBase)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                mCon.ChangeDatabase(pDataBase);
                return mCom.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ObtenerId(string pTabla)
        {
            try
            {
                SqlCommand mCom = new SqlCommand("SELECT ISNULL(MAX(" + pTabla + "_Id),0) FROM " + pTabla, mCon);
                mCon.Open();
                return int.Parse(mCom.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }
    }*/
    #endregion
    public interface DALICuentaUsuario : ICrud<BECuentaUsuario>
    {
        bool Login(string email, string contrasenia);

        bool CambiarContraseña(BECuentaUsuario usuario, string nuevaContrasenia, bool primerLogin);

        BECuentaUsuario ObtenerUsuarioConEmail(string email);

        List<BEPatente> ObtenerPatentesDeUsuario(int usuarioId);

        List<BECuentaUsuario> CargarInactivos();

        bool ActivarUsuario(string email);

        bool DesactivarUsuario(string email);

        BECuentaUsuario ObtenerUsuarioConId(int usuarioId);

        List<BECuentaUsuario> TraerUsuariosConPatentesYFamilias();

        void CargarDVHPatentes();
    }



}

