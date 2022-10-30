using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIProducto
    {
        bool Actualizar(BEProducto objUpd);

        bool Borrar(BEProducto objDel);

        List<BEProducto> Cargar();

        bool Crear(BEProducto objAlta);

        BEProducto ObtenerProductoPorCodigo(string codigo);

        List<BEProducto> CargarInactivos();

        bool ActivarProducto(string descripcion);

        bool DesactivarProducto(string descripcion);
    }
}
