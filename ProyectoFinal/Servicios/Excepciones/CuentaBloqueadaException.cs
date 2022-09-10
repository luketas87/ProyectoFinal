using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios.Excepciones
{
    public class CuentaBloqueadaException : Exception
    {
        public BECuentaUsuario mCuentaUsuario;
        public CuentaBloqueadaException(BECuentaUsuario pCuentaUsuario)
        {
            mCuentaUsuario = pCuentaUsuario;
        }
    }
}