﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;
using EasyEncryption;
using log4net;

namespace BLL.implementacion
{
    public class BLLBitacora : BLLIBitacora
    {
        private const string Key = "bZr2URKx";
        private const string Iv = "HNtgQw0w";
        private readonly DALIBitacora bitacoraDAL;
        private readonly IDigitoVerificador digitoVerificador;

        public BLLBitacora(DALIBitacora bitacoraDAL, IDigitoVerificador digitoVerificador)
        {
            this.bitacoraDAL = bitacoraDAL;
            this.digitoVerificador = digitoVerificador;
        }

        public void CargarDVHBitacora()
        {
            bitacoraDAL.CargarDVHBitacora();
        }

        public List<string> CargarUsuarios()
        {
            return bitacoraDAL.CargarUsuarios();
        }

        public BEBitacora FiltrarBitacora(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<BEBitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta)
        {
            return bitacoraDAL.LeerBitacoraPorUsuarioCriticidadYFecha(usuarios, criticidades, desde, hasta);
        }

        public void RegistarEnBitactoraTabla(string mensaje, string logLevel, string logger)
        {
            bitacoraDAL.RegistarEnBitactora(mensaje, logLevel, logger);
        }

        public void RegistrarEnBitacora(BECuentaUsuario usuario)
        {
            if (usuario.Email != null)
            {
                MDC.Set("usuario", DES.Decrypt(usuario.Email, Key, Iv));
            }
            else
            {
                MDC.Set("usuario", "Sistema");
            }

            /////var digitoVH = bitacoraDAL.GenerarDVH();

           //// GlobalContext.Properties["dvh"] = digitoVH;

            digitoVerificador.ActualizarDVVertical("Bitacora");
        }
    }
}
