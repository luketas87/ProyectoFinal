using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using BE;
using BLL.Interfaces;
using BE.Implementacion;
using DAL.DAO.Interfaces;
using System.Resources;
using System.Windows.Forms;
using System.Linq;

namespace BLL.implementacion
{
    public class BLLIdioma : BLLIIdioma
    {
        private readonly string RutaRecursos = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Recursos\\Español.resx";

        private readonly DALIIdioma DALidioma;


        public BLLIdioma(DALIIdioma DALidioma)
        {
            this.DALidioma = DALidioma;
        }
        public List<BEIdioma> ObtenerTodosLosIdiomas()
        {
            return DALidioma.ObtenerTodosLosIdiomas();
        }

        public List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idIdioma, string nombreForm)
        {
            return DALidioma.ObtenerTraduccionesFormulario(idIdioma, nombreForm);
        }

        public void LeerRecursos(Control.ControlCollection controls)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(ObtenerDirectorioRecursos()))
            {
                foreach (DictionaryEntry item in resxSet)
                {
                    if (controls.ContainsKey(item.Key.ToString()))
                    {
                        controls[item.Key.ToString()].Text = item.Value.ToString();
                    }
                }
            }
        }

        public void LlenarRecursos(IDictionary<string, string> traducciones, int idIomaSeleccionado, string nombreFormulario)
        {
            using (ResXResourceWriter resxWriter = new ResXResourceWriter(ObtenerDirectorioRecursos()))
            {
                if (traducciones.Any())
                {
                    foreach (var item in traducciones)
                    {
                        resxWriter.AddResource(item.Key, item.Value);
                    }
                }
            }
        }

        public string ObtenerDirectorioRecursos()
        {
            return RutaRecursos;
        }



    }
}
