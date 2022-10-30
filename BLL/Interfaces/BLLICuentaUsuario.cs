using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;
using BE.Interfaces;

namespace BLL.Interfaces
{
    public interface BLLICuentaUsuario : ICrud<BECuentaUsuario>
    {
        bool Login(string email, string contrasenia);

        BECuentaUsuario ObtenerUsuarioConEmail(string email);

        List<BEPatente> ObtenerPatentesDeUsuario(int IdUsuario);

        List<BECuentaUsuario> CargarInactivos();

        bool ActivarUsuario(string email);

        bool DesactivarUsuario(string email);

        List<BECuentaUsuario> TraerUsuariosConPatentesYFamilias();

        void CargarDVHPatentes();
    }
}
