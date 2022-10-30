using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Interfaces;
using BE.Implementacion;

namespace BLL.Interfaces
{
    public interface BLLIVenta : ICrud<BEVenta>
    {
        int ObtenerUltimoIdVenta();

        string ObtenerEstadoVenta(int IdEstado);

        string ObtenerTipoVenta(int IdTipoVta);

        int ObtenerEstadoVentaConString(string estado);

        int ObtenerTipoVentaConString(string tipoVta);

        void CargarDVHVenta();
    }
}
