using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Seguridad;


namespace Servicios
{
    public class ControlArchivos
    {
        public static string ruta = @"..\..\..\";
        Encriptador encriptador = new Encriptador();

        public string LeerArchivo(string pDireccion)
        {

            string text;
            try
            {
                text = File.ReadAllText(ruta + pDireccion);
                text = encriptador.Desencriptar(text);
                return text;
            }
            catch (Exception)
            {


                return text = ""; 
            }

        }

        public void EscribirArchivo(string pNombreArchivo, string pCadena)
        {
            string pRuta = ruta + "/" + pNombreArchivo;
            pCadena = encriptador.EncriptarReversible(pCadena);
            File.WriteAllText(pRuta, pCadena);
        }

        public static void EscribirArchivo(string pRuta, string pNombreArchivo, string pCadena)
        {
            string mRuta = pNombreArchivo;
            File.WriteAllText(mRuta, pCadena);
        }
    }
}

