using log4net;
using EasyEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utilidades
{
    public static class Log4netExtensions
    {
        public const string Key = "bZr2URKx";
        public const string Code = "HNtgQw0w";

        public static readonly log4net.Core.Level NivelAlto = new log4net.Core.Level(50000, "ALTA");
        public static readonly log4net.Core.Level NivelMedio = new log4net.Core.Level(40000, "MEDIA");
        public static readonly log4net.Core.Level NivelBajo = new log4net.Core.Level(30000, "BAJA");

        public static void Alta(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelAlto, DES.Encrypt(message, Key, Code), null);
        }

        public static void AltaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelAlto, formattedMessage, null);
        }

        public static void Media(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelMedio, DES.Encrypt(message, Key, Code), null);
        }

        public static void MediaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelMedio, formattedMessage, null);
        }

        public static void Baja(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelBajo, DES.Encrypt(message, Key, Code), null);

        }

        public static void BajaFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, NivelBajo, formattedMessage, null);
        }
    
    }
}
