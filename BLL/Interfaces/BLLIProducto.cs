using BE.Implementacion;
using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface BLLIProducto : ICrud<BEProducto>
    {
        BEProducto ObtenerProductoPorCodigo(string codigo);

        List<BEProducto> CargarInactivos();

        bool ActivarProducto(string descripcion);

        bool DesactivarProducto(string descripcion);
    }
}
