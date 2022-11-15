using System;
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

