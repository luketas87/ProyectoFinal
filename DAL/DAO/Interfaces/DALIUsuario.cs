using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIUsuario : ICrud<BECuentaUsuario>
    {
        bool LogIn(string email, string contraseña);

        bool CambiarContraseña(BECuentaUsuario usuario, string nuevaContraseña, bool primerLogin);

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
