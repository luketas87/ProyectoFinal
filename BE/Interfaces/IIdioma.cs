﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;
using System.Windows.Forms;


namespace BE.Interfaces
{
    public interface BEIIdioma //no va
    {
        List<BEIdioma> ObtenerTodosLosIdiomas();

        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idIdioma, string nombreForm);

        void LlenarRecursos(IDictionary<string, string> traducciones, int idIomaSeleccionado, string nombreFormulario);

        void LeerRecursos(Control.ControlCollection controls);

        string ObtenerDirectorioRecursos();
    }
}
