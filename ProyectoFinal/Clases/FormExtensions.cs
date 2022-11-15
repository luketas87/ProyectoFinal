using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces;
using BE.Interfaces;


namespace UI.Clases
{
   public static class FormExtensions
    {
        public static void CatchException(this Form form, Action func, Action<Exception> onError = null)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
        }

        public static void ShowMessageError(this Form frm, string msg)
        {
            MessageBox.Show(frm, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static BLLIIdioma AplicarTraducciones()
        {
            var provIdioma = IoCContainer.Resolve<BLLIIdioma>();
            var formControl = IoCContainer.Resolve<IFormControl>();
            var idiomaBLL = IoCContainer.Resolve<BLLIIdioma>();
            var traducciones = formControl.ObtenerTraducciones();
            var idioma = formControl.ObtenerIdioma();
            formControl.ObtenerTraducciones().Clear();
            traducciones = idiomaBLL.ObtenerTraduccionesFormulario(idioma.IdIdioma, Application.OpenForms[0].Name).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);
            provIdioma.LlenarRecursos(traducciones, idioma.IdIdioma, Application.OpenForms[0].Name);
            return provIdioma;
        }
    }
} 

