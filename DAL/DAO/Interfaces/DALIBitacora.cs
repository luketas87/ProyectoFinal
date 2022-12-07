using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIBitacora
    {
        void FiltrarBitacora(BEFiltroBitacora filtros);

        BEBitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH();

        int ObtenerUltimoIdBitacora();

        List<BEBitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta);

        List<string> CargarUsuarios();

        void CargarDVHBitacora();

        void RegistarEnBitactora(string mensaje, string logLevel, string logger);
    }
}
