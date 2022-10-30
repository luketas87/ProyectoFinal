using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;

namespace Servicios.Excepciones
{
    public class ContraseniaIncorrectaException : Exception
    {
        public BECuentaUsuario mCuentaUsuario;

        public ContraseniaIncorrectaException(BECuentaUsuario pCuentaUsuario)
        {
            mCuentaUsuario = pCuentaUsuario;
        }
    }
}
