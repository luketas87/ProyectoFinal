using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguridad;

namespace Servicios
{
    public class ConexionBD
    {
        public string CadenaConexion { get; set; }


        public void ObtenerCadena()
        {
            ControlArchivos mControl = new ControlArchivos();
            string CadenaConexionAux = mControl.LeerArchivo(@"CadenaConexion.txt");
            CadenaConexion = new Encriptador().Desencriptar(CadenaConexionAux);
        }

        public ConexionBD()
        {
            ObtenerCadena();
        }


        public void ActualizarCadena(string pCadena)
        {
            string CadenaConexionAux = new Encriptador().EncriptarReversible(pCadena);
            ControlArchivos.EscribirArchivo("", "CadenaConexion.txt", CadenaConexionAux);
        }
    }
}
