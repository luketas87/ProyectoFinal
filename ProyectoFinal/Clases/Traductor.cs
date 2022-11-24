using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Resources;



namespace ProyectoFinal.Clases
{
    public class Traductor : ITraductor
    {
        private readonly IFormControl formControl;
        private readonly BLLIIdioma idiomaBLL;

        public Traductor(IFormControl formControl, BLLIIdioma idiomaBLL)
        {
            this.formControl = formControl;
            this.idiomaBLL = idiomaBLL;
        }

        public string ObtenerPathRecursos()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Recursos\\Español.resx";
        }

        public void Traduccir(Control control, string nombreForm)
        {
            BorrarRecursos();
            formControl.Traducciones.Clear();
            formControl.Traducciones = GetTraducciones(nombreForm);
            idiomaBLL.LlenarRecursos(formControl.Traducciones, formControl.LenguajeSeleccionado.IdIdioma, nombreForm);
            idiomaBLL.LeerRecursos(control.Controls);
        }

        private void BorrarRecursos()
        {
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ObtenerPathRecursos()))
            {
                resxWriter.Dispose();
            }
        }

        private IDictionary<string, string> GetTraducciones(string nombreForm)
        {
            formControl.Traducciones = idiomaBLL.ObtenerTraduccionesFormulario(formControl.LenguajeSeleccionado.IdIdioma, nombreForm).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);

            return formControl.Traducciones;
        }
    }
}
