using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using BE.Interfaces;
using DAL.Utilidades;
using DAL.DAO.Interfaces;

namespace DAL.DAO.Implementacion
{
    public class DALProducto : BaseDAO, ICrud<BEProducto>, DALIProducto
    {
        public bool ActivarProducto(string IdProducto)
        {
            var queryString = $"UPDATE Producto SET Activo = 1 WHERE IdProducto = {IdProducto} ;";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Actualizar(BEProducto objUpd)
        {
            var queryString = $"UPDATE Producto SET Descripcion = @descripcion, PUnitario = @pUnitario, PVenta = @pVenta, Stock = @stock, MinStock = @minStock WHERE IdProducto = @codigo";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @descripcion = objUpd.Descripcion,
                        @pUnitario = objUpd.PUnitario,
                        @pVenta = objUpd.PVenta,
                        @stock = objUpd.Stock,
                        @minStock = objUpd.MinStock,
                        @codigo = objUpd.IdProducto
                    });
            });
        }

        public bool Borrar(BEProducto objDel)
        {
            var queryString = $"UPDATE Producto SET Activo = 0 WHERE IdProducto = @codigo";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @codigo = objDel.IdProducto
                    });
            });
        }

        public List<BEProducto> Cargar()
        {
            var queryString = "SELECT * FROM Producto WHERE Activo = 1;";

            return CatchException(() =>
            {
                return Exec<BEProducto>(queryString);
            });
        }

        public List<BEProducto> CargarInactivos()
        {
            var queryString = "SELECT * FROM Producto WHERE Activo = 0;";

            return CatchException(() =>
            {
                return Exec<BEProducto>(queryString);
            });
        }

        public bool Crear(BEProducto objAlta)
        {
            var queryString = "INSERT INTO Producto(Descripcion ,PUnitario, PVenta ,Stock ,MinStock, Activo) VALUES( @descripcion, @pUnitario,  @pVenta,  @stock, @minStock, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @descripcion = objAlta.Descripcion,
                        @pUnitario = objAlta.PUnitario,
                        @pVenta = objAlta.PVenta,
                        @stock = objAlta.Stock,
                        @minStock = objAlta.MinStock,
                        @activo = 1
                    });
            });
        }

        public bool DesactivarProducto(string descripcion)
        {
            throw new NotImplementedException();
        }

        public BEProducto ObtenerProductoPorCodigo(string codigo)
        {
            var queryString = $"SELECT * FROM Producto WHERE IdProducto = @codigo";

            return CatchException(() =>
            {
                return Exec<BEProducto>(queryString, new { @codigo = codigo }).FirstOrDefault();
            });
        }
    }
}
