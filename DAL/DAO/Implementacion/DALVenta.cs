using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Interfaces;
using DAL.DAO;
using DAL.Utilidades;
using DAL.DAO.Interfaces;
using BE.Implementacion;
//using IDigitoVerificador = DAL.DAO.Interfaces.IDigitoVerificador;

namespace DAL.DAO.Implementacion
{
    public class DALVenta : BaseDAO, ICrud<BEVenta>, DALIVenta
    {
        private readonly IDigitoVerificador digitoVerificador;

        public DALVenta(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Actualizar(BEVenta objUpd)
        {
            var queryString = $@"UPDATE Venta  SET  IdUsuario = {objUpd.IdUsuario}, IdEstado = {objUpd.IdEstado}, IdTipoVenta = {objUpd.IdTipoVenta}, IdCliente = {objUpd.IdCliente}  WHERE IdVenta = {objUpd.IdVenta}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Borrar(BEVenta objDel)
        {
            var queryString = $"DELETE FROM Venta WHERE IdVenta = {objDel.IdVenta}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<BEVenta> Cargar()
        {
            var queryString = "SELECT * FROM Venta;";

            return CatchException(() =>
            {
                return Exec<BEVenta>(queryString);
            });
        }

        public void CargarDVHVenta()
        {
            var query = "SELECT * FROM Venta";
            var listalistaVentas = new List<BEVenta>();


            CatchException(() =>
            {
                listalistaVentas = Exec<BEVenta>(query);
            });

            foreach (var venta in listalistaVentas)
            {
                var digito = digitoVerificador.CalcularDVHorizontal(new List<string>() { venta.Fecha.ToString() });

                //HACER update

                var q = $"UPDATE Venta SET DVH = {digito} WHERE IdVenta = @Id";

                CatchException(() =>
                {
                    Exec(
                        q,
                        new
                        {
                            @Id = venta.IdVenta
                        });
                });
            }
        }

        public bool Crear(BEVenta objAlta)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string>() { objAlta.Fecha.ToString() });

            var queryString = "INSERT INTO Venta(Fecha, IdUsuario, IdEstado, IdTipoVenta, IdCliente ,Monto,dvh) VALUES (@fecha, @Idusuario, @estado, @tipoVenta, @cliente, @monto, @dvh)";
            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {

                        @fecha = objAlta.Fecha,
                        @estado = objAlta.IdEstado,
                        @Idusuario = objAlta.IdUsuario,
                        @tipoVenta = objAlta.IdTipoVenta,
                        @cliente = objAlta.IdCliente,
                        @monto = objAlta.Monto,
                        @dvh = digitoVH
                    });
            });
        }
        public enum EstadoVenta
        {
            Pendiente = 1,
            Aprobada,
            Rechazada,
            Cancelada,
        }
        public string ObtenerEstadoVentaConId(int IdEstado)
        {
            switch (IdEstado)
            {
                case 1: return EstadoVenta.Pendiente.ToString();
                case 2: return EstadoVenta.Aprobada.ToString();
                case 3: return EstadoVenta.Rechazada.ToString();
                case 4: return EstadoVenta.Cancelada.ToString();
            }

            return "Estado inexistente";
        }

        public int ObtenerEstadoVentaConString(string Estado)
        {
            switch (Estado)
            {
                case "Pendiente": return 1;
                case "Aprobada": return 2;
                case "Rechazada": return 3;
                case "Cancelada": return 4;
            }

            return 0;
        }

        public enum TipoVenta
        {
            Seña = 1,
            VentaSimple,
            Cliente,
            Devolucion,
        }

        public string ObtenerTipoVentaConId(int IdtipoVta)
        {
            switch (IdtipoVta)
            {
                case 1: return TipoVenta.Seña.ToString();
                case 2: return TipoVenta.VentaSimple.ToString();
                case 3: return TipoVenta.Cliente.ToString();
                case 4: return TipoVenta.Devolucion.ToString();
            }

            return "Tipo inexistente";
        }

        public int ObtenerTipoVentaConString(string TipoVta)
        {
            switch (TipoVta)
            {
                case "Seña": return 1;
                case "VentaSimple": return 2;
                case "Cliente": return 3;
                case "Devolucion": return 4;
            }

            return 0;
        }

        public int ObtenerUltimoIdVenta()
        {
            var queryString = "SELECT ISNULL(IDENT_CURRENT ('[dbo].[Venta]'), 0) as current_identity";

            var id = CatchException(() => Exec<int>(queryString.ToString()).FirstOrDefault());

            return (id != 0) ? id : 1;
        }
    }
}
