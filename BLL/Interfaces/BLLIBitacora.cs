using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

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
