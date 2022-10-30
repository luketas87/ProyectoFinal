using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIVentas
    {
        int ObtenerUltimoIdVenta();

        string ObtenerEstadoVentaConId(int Idsstado);

        string ObtenerTipoVentaConId(int IdtipoVta);

        int ObtenerEstadoVentaConString(string Estado);

        int ObtenerTipoVentaConString(string TipoVta);

        void CargarDVHVenta();
    }
}
