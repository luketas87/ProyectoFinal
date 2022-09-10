using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;


namespace DAL
{
    /*  private static cuentaUario _instancia;
      public static cuentaUsuario GetInstancia()
      {
          if(_instancia == null)
          {
              _instancia = new CuentaUsuario();
          }
      }
    */
    public class CuentaUsuarioDAL
    {
        public static int mId;
        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO.DAOCuentaUsuario mDAObject = new DAO.DAOCuentaUsuario();
                mId = mDAObject.ObtenerId("CuentaUsuario");
            }
            mId += 1;
            return mId;
        }

        public static BECuentaUsuario Obtener(string mUser)
        {
            DAO.DAOCuentaUsuario mDAObject = new DAO.DAOCuentaUsuario();
            DataSet mDs = mDAObject.ExecuteDataSet("select Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_password, Cuenta_usuario_intentos_login, year(Cuenta_fecha_alta) as anio, month(Cuenta_fecha_alta) as mes, day(Cuenta_fecha_alta) as dia, Cuenta_cliente, Cuenta_usuario_empleado_id, Cuenta_usuario_cliente_id, cuenta_usuario_activa from Usuarios where Usuario = '" + mUser + "' ");
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                int pId = int.Parse(mDs.Tables[0].Rows[0]["cuenta_usuario_id"].ToString());
                BECuentaUsuario mCuentaUsuario = new BECuentaUsuario(pId);
                mCuentaUsuario.cuenta_usuario_activa = int.Parse(mDs.Tables[0].Rows[0]["cuenta_usuario_activa"].ToString());
                ValorizarEntidad(mCuentaUsuario, mDs.Tables[0].Rows[0]);
                return mCuentaUsuario;
            }
            else return null;
        }

        public static void ValorizarEntidad(BECuentaUsuario pCuentaUsuario, DataRow pDr)
        {
            pCuentaUsuario.Cuenta_usuario_id = int.Parse(pDr["Cuenta_usuario_id"].ToString());
            pCuentaUsuario.Cuenta_usuario_username = pDr["Cuenta_usuario_username"].ToString();
            pCuentaUsuario.Cuenta_usuario_password = pDr["Cuenta_usuario_password"].ToString();
            pCuentaUsuario.Cuenta_usuario_intentos_login = int.Parse(pDr["Cuenta_usuario_intentos_login"].ToString());
            pCuentaUsuario.SetFechaAlta(int.Parse(pDr["dia"].ToString()), int.Parse(pDr["mes"].ToString()), int.Parse(pDr["anio"].ToString()));
            if (pDr["Cuenta_cliente"].ToString() == "1")
            {
                pCuentaUsuario.Cuenta_cliente = true;
            }
            else { pCuentaUsuario.Cuenta_cliente = false; }
            if (pDr["Cuenta_usuario_empleado_id"].ToString() != "") { pCuentaUsuario.Cuenta_usuario_empleado_id = int.Parse(pDr["Cuenta_usuario_empleado_id"].ToString()); }
            else { pCuentaUsuario.Cuenta_usuario_empleado_id = 0; }
            if (pDr["Cuenta_usuario_cliente_id"].ToString() != "") { pCuentaUsuario.Cuenta_usuario_cliente_id = int.Parse(pDr["Cuenta_usuario_cliente_id"].ToString()); }
            else { pCuentaUsuario.Cuenta_usuario_cliente_id = 0; }

        }

        public static int Guardar(BECuentaUsuario pCuentaUsuario)
        {
            DAO.DAOCuentaUsuario mDAObject = new DAO.DAOCuentaUsuario();
            string pCadenaComando;
            if (pCuentaUsuario.Cuenta_usuario_id == 0)
            {
                pCuentaUsuario.Cuenta_usuario_id = ProximoId();
                pCadenaComando = "insert into cuenta_usuario(Cuenta_usuario_id, Cuenta_usuario_username, Cuenta_usuario_password, Cuenta_usuario_intentos_login, cuenta_cliente, cuenta_usuario_activa, cuenta_fecha_alta, cuenta_usuario_empleado_id, cuenta_usuario_cliente_id) values (" + pCuentaUsuario.Cuenta_usuario_id + ", '" + pCuentaUsuario.Cuenta_usuario_username + "', '" + pCuentaUsuario.Cuenta_usuario_password + "', " + pCuentaUsuario.Cuenta_usuario_intentos_login + ", " + pCuentaUsuario.GetCuentaCliente() + ", " + pCuentaUsuario.cuenta_usuario_activa + ", '" + pCuentaUsuario.GetFechaAltaToString() + "', " + pCuentaUsuario.Cuenta_usuario_empleado_id + ", " + pCuentaUsuario.Cuenta_usuario_cliente_id + ")";
            }
            else pCadenaComando = "update Cuenta_Usuario set Cuenta_usuario_username = '" + pCuentaUsuario.Cuenta_usuario_username + "', Cuenta_usuario_password = '" + pCuentaUsuario.Cuenta_usuario_password + "', Cuenta_usuario_intentos_login = " + pCuentaUsuario.Cuenta_usuario_intentos_login + ", Cuenta_fecha_alta = '" + pCuentaUsuario.GetFechaAltaToString() + "', Cuenta_cliente = " + pCuentaUsuario.GetCuentaCliente() + ", cuenta_usuario_activa = " + pCuentaUsuario.cuenta_usuario_activa + ", Cuenta_usuario_empleado_id = " + pCuentaUsuario.Cuenta_usuario_empleado_id + ", Cuenta_usuario_cliente_id = " + pCuentaUsuario.Cuenta_usuario_cliente_id + " where Cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
        public static int Eliminar(BECuentaUsuario pCuentaUsuario)
        {
            DAO.DAOCuentaUsuario mDAObject = new DAO.DAOCuentaUsuario();
            string pCadenaComando = "update Cuenta_Usuario set cuenta_usuario_activa = 0 where cuenta_usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            return mDAObject.ExecuteNonQuery(pCadenaComando);
        }
    }
}

