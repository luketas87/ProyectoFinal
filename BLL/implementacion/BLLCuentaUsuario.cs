using System;
using BE;
using BE.Interfaces;
using BE.Implementacion;
using BLL.Interfaces;
using DAL;
using DAL.DAO;
using log4net;
using System.Collections.Generic;
using DAL.Utilidades;
using DAL.DAO.Interfaces;

namespace BLL.implementacion
{
    public class BLLCuentaUsuario : ICrud<BECuentaUsuario>, BLLICuentaUsuario
    {
        private readonly DALICuentaUsuario DALCuentaUsuario;
        private readonly BLLIBitacora bitacoraBLL;
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLLCuentaUsuario(DALICuentaUsuario DALCuentaUsuario, BLLIBitacora bitacoraBLL)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.DALCuentaUsuario = DALCuentaUsuario;
        }

        public bool Login(string email, string contrasenia)
        {
            var ingresa = DALCuentaUsuario.Login(email, contrasenia);
            var usu = DALCuentaUsuario.ObtenerUsuarioConEmail(email);
            bitacoraBLL.RegistrarEnBitacora(usu);

            if (ingresa)
            {
                bitacoraBLL.RegistarEnBitactoraTabla("Usuario logueado correctamente","BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
                return ingresa;
            }

            if (usu.ContadorIngresosIncorrectos < 3)
            {
                Log4netExtensions.Baja(log, "Login Incorrecto");
                bitacoraBLL.RegistarEnBitactoraTabla("Login Incorrecto", "BAJA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());

            }
            else
            {
                Log4netExtensions.Media(log, "Login Incorrecto, Cuenta bloqueada");
                bitacoraBLL.RegistarEnBitactoraTabla("Login Incorrecto, Cuenta bloqueada", "MEDIA", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }

            return ingresa;
        }

        public bool Crear(BECuentaUsuario objAlta)
        {
            return DALCuentaUsuario.Crear(objAlta);
        }

        public List<BECuentaUsuario> Cargar()
        {
            return DALCuentaUsuario.Cargar();
        }

        public bool Borrar(BECuentaUsuario objDel)
        {
            return DALCuentaUsuario.Borrar(objDel);
        }

        public bool Actualizar(BECuentaUsuario objUpd)
        {
            return DALCuentaUsuario.Actualizar(objUpd);
        }

        public BECuentaUsuario ObtenerUsuarioConEmail(string email)
        {
            return DALCuentaUsuario.ObtenerUsuarioConEmail(email);
        }

        public List<BEPatente> ObtenerPatentesDeUsuario(int IdUsuario)
        {
            return DALCuentaUsuario.ObtenerPatentesDeUsuario(IdUsuario);
        }


        public List<BECuentaUsuario> CargarInactivos()
        {
            return DALCuentaUsuario.CargarInactivos();
        }

        public bool ActivarUsuario(string email)
        {
            return DALCuentaUsuario.ActivarUsuario(email);
        }

        public bool DesactivarUsuario(string email)
        {
            return DALCuentaUsuario.DesactivarUsuario(email);
        }


        public BECuentaUsuario ObtenerUsuarioConId(int IdUsuario)
        {
            return DALCuentaUsuario.ObtenerUsuarioConId(IdUsuario);
        }

        public List<BECuentaUsuario> TraerUsuariosConPatentesYFamilias()
        {
            return DALCuentaUsuario.TraerUsuariosConPatentesYFamilias();
        }

        public void CargarDVHPatentes()
        {
            DALCuentaUsuario.CargarDVHPatentes();
        }
        
    }
}
