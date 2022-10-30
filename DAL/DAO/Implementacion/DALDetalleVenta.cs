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
    public class DALDetalleVenta : BaseDAO, DALIDetalleVenta, ICrud<BEDetalleVenta>
    {
        private readonly DALIProducto ProductoDAL;
        public bool Actualizar(BEDetalleVenta objUpd)
        {
            var queryString = string.Format("UPDATE  FROM DetalleVenta WHERE DetalleId = {0}", objUpd.IdVenta);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }
        public DALDetalleVenta(DALIProducto ProductoDAL)
        {
            this.ProductoDAL = ProductoDAL;
        }

        public bool Borrar(BEDetalleVenta objDel)
        {
            var queryString = $"DELETE FROM DetalleVenta WHERE VentaId = {objDel.IdVenta}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<BEDetalleVenta> Cargar()
        {
            var detalleVenta = new List<BEDetalleVenta>();

            var queryString = "SELECT * FROM DetalleVenta;";

            var detalleBd = CatchException(() => Exec<BEDetalleVentaBD>(queryString));

            foreach (var detalle in detalleBd)
            {
                var producto = ProductoDAL.ObtenerProductoPorCodigo(detalle.IdProducto.ToString());

                detalleVenta.Add(
                    new BEDetalleVenta()
                    {
                        IdVenta = detalle.IdVenta,
                        IdDetalle = detalle.IdDetalle,

                        LineasDetalle = new List<BELineaDetalle>()
                        {
                            new BELineaDetalle()
                            {
                                Cantidad = detalle.Cantidad,
                                Importe = detalle.Importe,
                                Producto = producto ,
                                DescProducto = producto.Descripcion
                            }
                        }
                    });
            };

            return detalleVenta;
        }

        public bool Crear(BEDetalleVenta objAlta)
        {
            var queryString = "INSERT INTO DetalleVenta ([IdVenta] ,[ProductoId] ,[Importe] ,[Cantidad]) VALUES (@Idventa, @IdProducto, @Importe, @Cantidad)";

            CatchException(() =>
            {
                foreach (var linea in objAlta.LineasDetalle)
                {
                    Exec(
                        queryString,
                        new
                        {
                            @ventaId = objAlta.IdVenta,
                            @productoId = linea.Producto.IdProducto,
                            @importe = linea.Importe,
                            @cantidad = linea.Cantidad
                        });
                }
            });

            return true;
        }
    }
}

