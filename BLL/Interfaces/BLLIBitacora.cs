using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

//interfaz permite injeccion de dependencias.
//La inyección de dependencias consiste de manera resumida en evitar el acoplamiento entre clases
//utilizando interfaces. conseguimos que cada clase tenga una función única,
//facilitando así el mantenimiento y el soporte de nuestro código.
namespace BLL.Interfaces
{
    public interface BLLIBitacora
    {
        void RegistrarEnBitacora(BECuentaUsuario usuario);

        BEBitacora FiltrarBitacora(DateTime from, DateTime to);

        List<BEBitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta);

        List<string> CargarUsuarios();

        void CargarDVHBitacora();
    }
}
