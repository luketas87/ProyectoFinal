using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguridad;
using Servicios.Excepciones;

namespace Servicios
{
    public class ConexionBD
    {
        public string CadenaConexion { get; set; }


        public void ObtenerCadena()
        {
            try
            {
                ControlArchivos mControl = new ControlArchivos();
                string CadenaConexionAux = mControl.LeerArchivo(@"CadenaConexion.txt");
                CadenaConexion = new Encriptador().Desencriptar(CadenaConexionAux);
            }
            catch (Exception)
            {

                throw new ConectionStringFaltanteException();
            }

        }

        public ConexionBD()
        {
            ObtenerCadena();
        }



    }
}
