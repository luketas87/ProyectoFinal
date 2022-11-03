using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using BE.Interfaces;

namespace DAL.DAO.Interfaces
{
    public interface DALIVenta : ICrud<BEVenta>
    {
        int ObtenerUltimoIdVenta();

        string ObtenerEstadoVentaConId(int Idsstado);

        string ObtenerTipoVentaConId(int IdtipoVta);

        int ObtenerEstadoVentaConString(string Estado);

        int ObtenerTipoVentaConString(string TipoVta);

        void CargarDVHVenta();
    }
}
