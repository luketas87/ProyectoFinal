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
        Encriptador encriptadora = new Encriptador();

        public ConexionBD()
        {
            ObtenerCadena();
        }


        public void ObtenerCadena()
        {
           // try
            //{
            ControlArchivos mControl = new ControlArchivos();
            string CadenaConexionAux = mControl.LeerArchivo(@"CadenaConexion.txt");
            string cadenaEncriptada = encriptadora.EncriptarReversible(CadenaConexionAux);
            string cadenaDesencriptada = encriptadora.Desencriptar(CadenaConexionAux);
            CadenaConexion = CadenaConexionAux;
                
               // CadenaConexion = new Encriptador().Desencriptar(CadenaConexionAux);
           // }
         /*   catch (Exception)
            {

                throw new ConectionStringFaltanteException();
            }*/

        }

    }
}
