using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;

namespace BLL.implementacion
{
    public class BLLVenta : ICrud<BEVenta>, BLLIVenta
    {
        private readonly DALIVenta ventaDAL;
        private readonly IDigitoVerificador digitoVerificador;

        public BLLVenta(DALIVenta ventaDAL, IDigitoVerificador digitoVerificador)
        {
            this.ventaDAL = ventaDAL;
            this.digitoVerificador = digitoVerificador;
        }

        public bool Actualizar(BEVenta objUpd)
        {
            return ventaDAL.Actualizar(objUpd);
        }

        public bool Borrar(BEVenta objDel)
        {
            return ventaDAL.Borrar(objDel);
        }

        public List<BEVenta> Cargar()
        {
            return ventaDAL.Cargar();
        }

        public void CargarDVHVenta()
        {
            ventaDAL.CargarDVHVenta();
        }

        public bool Crear(BEVenta objAlta)
        {
            var result = ventaDAL.Crear(objAlta);
            digitoVerificador.ActualizarDVVertical("Venta");
            return result;
        }

        public string ObtenerEstadoVenta(int IdEstado)
        {
            return ventaDAL.ObtenerEstadoVentaConId(IdEstado);
        }

        public int ObtenerEstadoVentaConString(string estado)
        {
            return ventaDAL.ObtenerEstadoVentaConString(estado);
        }

        public string ObtenerTipoVenta(int IdTipoVta)
        {
            return ventaDAL.ObtenerTipoVentaConId(IdTipoVta);
        }

        public int ObtenerTipoVentaConString(string tipoVta)
        {
            return ventaDAL.ObtenerTipoVentaConString(tipoVta);
        }

        public int ObtenerUltimoIdVenta()
        {
            return ventaDAL.ObtenerUltimoIdVenta();
        }
    }
}
