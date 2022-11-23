using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.implementacion
{
    public class BLLDetalleVenta : BLLIDetalleVenta, ICrud<BEDetalleVenta>
    {
        private readonly DALIDetalleVenta detalleVentaDAL;

        public BLLDetalleVenta(DALIDetalleVenta detalleVentaDAL)
        {
            this.detalleVentaDAL = detalleVentaDAL;
        }

        public bool Actualizar(BEDetalleVenta objUpd)
        {
            return detalleVentaDAL.Actualizar(objUpd);
        }

        public bool Borrar(BEDetalleVenta objDel)
        {
            return detalleVentaDAL.Borrar(objDel);
        }

        public List<BEDetalleVenta> Cargar()
        {
            return detalleVentaDAL.Cargar();
        }

        public bool Crear(BEDetalleVenta objAlta)
        {
            return detalleVentaDAL.Crear(objAlta);
        }

        //List<BEDetalleVenta> ICrud<BEDetalleVenta>.Cargar()
        //{
        //    return detalleVentaDAL.Cargar();
        //}
    }
}
