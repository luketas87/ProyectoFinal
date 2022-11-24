using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BE.Implementacion;
using BLL.Interfaces;
using DAL.DAO.Interfaces;

namespace BLL.implementacion
{
    public class BLLProducto : ICrud<BEProducto>, BLLIProducto
    {
        private readonly DALIProducto productoDAL;

        private Regex obtenerInt = new Regex("\\d+");

        public BLLProducto(DALIProducto productoDAL)
        {
            this.productoDAL = productoDAL;
        }
        public bool ActivarProducto(string descripcion)
        {
            var Idproducto = obtenerInt.Match(descripcion).Value;

            return productoDAL.ActivarProducto(Idproducto);
        }

        public bool Actualizar(BEProducto objUpd)
        {
            return productoDAL.Actualizar(objUpd);
        }

        public bool Borrar(BEProducto objDel)
        {
            return productoDAL.Borrar(objDel);
        }

        public List<BEProducto> Cargar()
        {
            return productoDAL.Cargar();
        }

        public List<BEProducto> CargarInactivos()
        {
            return productoDAL.CargarInactivos();
        }

        public bool Crear(BEProducto objAlta)
        {
            return productoDAL.Crear(objAlta);
        }

        public bool DesactivarProducto(string descripcion)
        {
            var productoId = obtenerInt.Match(descripcion).Value;

            return productoDAL.DesactivarProducto(productoId);
        }

        public BEProducto ObtenerProductoPorCodigo(string codigo)
        {
            return productoDAL.ObtenerProductoPorCodigo(codigo);
        }
    }
}
