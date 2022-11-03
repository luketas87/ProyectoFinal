using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;
using DAL;
using Servicios;
using Seguridad;
using Servicios.Excepciones;

namespace BLL
{
    public class BLCuentaUsuario
    {
        #region metodos

        ControlArchivos mcontrolarchivos = new ControlArchivos();
        public static BECuentaUsuario Obtener(string mUser)
        {
            BECuentaUsuario mCuentaUsuario = CuentaUsuarioDAL.Obtener(mUser);
            if (mCuentaUsuario is null) 
            { 
                mCuentaUsuario = new BECuentaUsuario(); 
            }
            return mCuentaUsuario;
        }

        public static bool ValidarPassword(BECuentaUsuario pCuentaUsuario, string pPass)
        {
            bool aux;
            if (pCuentaUsuario.Cuenta_usuario_password == pPass) { aux = true; }
            else
            {
                aux = false;
            }
            return aux;
        }

        public static string GenerarClaveAleatoria()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }


        public static int Guardar(BECuentaUsuario pCuentaUsuario)
        {
            int a = CuentaUsuarioDAL.Guardar(pCuentaUsuario);
            return a;
        }

        public BECuentaUsuario ValidarUsuario(string mUser, string mPassword)
        {
            Encriptador mEncriptador = new Encriptador();
            BECuentaUsuario mCuentaUsuario = Obtener(mUser);
            if (mCuentaUsuario.Cuenta_usuario_id == 0 | mCuentaUsuario.cuenta_usuario_activa == 0)
            {
                throw new UsuarioInexistenteException();
            }

            bool aux = ValidarPassword(mCuentaUsuario, mEncriptador.EncriptarIrreversible(mPassword));
            if (aux == false)
            {
                mCuentaUsuario.Cuenta_usuario_intentos_login += 1;
                if (mCuentaUsuario.Cuenta_usuario_intentos_login == 3)
                {
                    string mNuevaClave = GenerarClaveAleatoria();
                    mCuentaUsuario.Cuenta_usuario_password = mEncriptador.EncriptarIrreversible(mNuevaClave);
                    mcontrolarchivos.EscribirArchivo("NuevaClave.txt", mNuevaClave);
                    mCuentaUsuario.Cuenta_usuario_intentos_login = 0;
                    Guardar(mCuentaUsuario);
                   // throw new CuentaBloqueadaException(mCuentaUsuario);
                }
                Guardar(mCuentaUsuario);
                //throw new ContraseniaIncorrectaException(mCuentaUsuario);
            }
            else mCuentaUsuario.Cuenta_usuario_intentos_login = 0;
            Guardar(mCuentaUsuario);
            return mCuentaUsuario;
        }




       /* public static CuentaUsuario ValidarUsuario()
        {
            throw new NotImplementedException();
        }*/
        #endregion
    }
}
