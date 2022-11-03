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
    public interface BLLIUsuario : ICrud<BECuentaUsuario>
    {
        bool Login(string email, string contraseña);

        BECuentaUsuario ObtenerUsuarioConEmail(string email);

        List<Patente> ObtenerPatentesDeUsuario(int usuarioId);

        List<BECuentaUsuario> CargarInactivos();

        bool ActivarUsuario(string email);

        bool DesactivarUsuario(string email);

        List<BECuentaUsuario> TraerUsuariosConPatentesYFamilias();

        void CargarDVHPatentes();
    }
}
