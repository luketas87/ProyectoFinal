using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProyectoFinal.Formularios;
using BLL.Interfaces;
using UI.Interfaces;
using DAL.DAO.Interfaces;
using DAL.DAO.Implementacion;
using BE.Interfaces;
//using IDigitoVerificador = DAL.DAO.Interfaces.IDigitoVerificador;

namespace ProyectoFinal
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.Core.Level nivelAlto = new log4net.Core.Level(50000, "ALTA");
            log4net.LogManager.GetRepository().LevelMap.Add(nivelAlto);
            log4net.Core.Level nivelMedio = new log4net.Core.Level(40000, "MEDIA");
            log4net.LogManager.GetRepository().LevelMap.Add(nivelAlto);
            log4net.Core.Level nivelBajo = new log4net.Core.Level(30000, "BAJA");
            log4net.LogManager.GetRepository().LevelMap.Add(nivelBajo);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run (new LadingSystem());

                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Usuario");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Bitacora");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Patente");
                    IoCContainer.Resolve<IDigitoVerificador>().ActualizarDVVertical("Venta");
        }
    }
}
