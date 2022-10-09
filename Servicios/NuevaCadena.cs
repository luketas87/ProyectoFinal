using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguridad;
using Servicios.Excepciones;
using BE;

namespace Servicios
{
    public class NuevaCadena
    {
       // NuevaCadena nConexionBD = new NuevaCadena();

  
        public void CrearCadena(string mConexion)
        {
            string CadenaConexionAux = new Encriptador().EncriptarReversible(mConexion);
            ControlArchivos.EscribirArchivo("", "CadenaConexion.txt", CadenaConexionAux);
        }
    }
}
