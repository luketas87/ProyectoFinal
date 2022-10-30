using System;
using System.Collections;
using System.Windows.Forms;
using System.Resources;
using log4net;
using System.IO;


namespace ProyectoFinal
{
    public class Alert
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Alert));

        public static void ShowSimpleAlert(string msj, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje);
        }

        public static void ShowAlterWithButtonAndIcon(string msj, string title, MessageBoxButtons buttons, MessageBoxIcon icon, string messageNumber = null)
        {
            var mensaje = ProcessMessage(messageNumber);
            MessageBox.Show(mensaje, title, buttons, icon);
        }

        public static DialogResult ConfirmationMessage(string messageCode, string title, MessageBoxButtons buttons, string msj = null)
        {
            var mensaje = ProcessMessage(messageCode);

            if (!string.IsNullOrEmpty(mensaje))
            {
                msj = string.Empty;
                msj = mensaje;
            }

            return MessageBox.Show(msj, title, buttons);
        }

        private static string ProcessMessage(string messageNumber)
        {
            try
            {
                var path = ObtenerPath();
                using (ResXResourceSet resxSet = new ResXResourceSet(path))
                {
                    foreach (DictionaryEntry item in resxSet)
                    {
                        if (item.Key != null && (string)item.Key == messageNumber)
                        {
                            return item.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Ocurrio un error al leer el idioma del archivo de recursos. Error: {0}", ex.Message);
            }

            return null;
        }

        private static string ObtenerPath()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Recursos\\Español.resx";
        }
    }
}

