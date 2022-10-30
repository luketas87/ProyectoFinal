using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface IPrincipal
    {
        void Show();
        void ComprobarPrimerLogin(string usuario);
    }
}
