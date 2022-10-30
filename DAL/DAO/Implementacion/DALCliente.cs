using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Utilidades;
using DAL.DAO.Interfaces;
using BE.Implementacion;

namespace DAL.DAO.Implementacion
{
    public class DALCliente : BaseDAO, DALICliente
    {
        public bool Actualizar(BECliente objUpd)
        {
            var queryString = $"UPDATE Cliente SET NombreCompleto = @nombre, Email = @email, Telefono = @telefono, Domicilio = @domicilio WHERE IdCliente = @IdClientex";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objUpd.NombreCompleto,
                        @email = objUpd.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @IdCliente = objUpd.IdCliente
                    });
            });
        }

        public void ActualizarSaldo(float saldo)
        {
        }

        public bool Borrar(BECliente objDel)
        {
            var queryString = string.Format("UPDATE Cliente SET Activo = 0 WHERE ClienteId = {0}", objDel.IdCliente);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<BECliente> Cargar()
        {
            var queryString = "SELECT * FROM Cliente INNER JOIN CuentaCorriente ON Cliente.CuentaCorrienteId = CuentaCorriente.CuentaId WHERE Activo = 1";

            return CatchException(() =>
            {
                return Exec<BECliente>(queryString);
            });
        }

        public bool Crear(BECliente objAlta)
        {
            var cuentaQueryString = "INSERT INTO CuentaCorriente (Saldo) Values (5000)";
            var cuentaId = 0;
            CatchException(() =>
            {
                Exec(cuentaQueryString);
            });

            var lastIndexString = "SELECT IDENT_CURRENT ('[dbo].[CuentaCorriente]') AS Current_Identity;";

            CatchException(() =>
            {
                cuentaId = Exec<int>(lastIndexString)[0];
            });

            var queryString = "INSERT INTO Cliente(CuentaCorrienteId, NombreCompleto, Email, Telefono, Domicilio, Activo) VALUES (" + cuentaId + ", @nombre, @email, @telefono," +
                " @domicilio, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objAlta.NombreCompleto,
                        @email = objAlta.Email,
                        @telefono = objAlta.Telefono,
                        @domicilio = objAlta.Domicilio,
                        @activo = 1
                    });
            });
        }

        public string ObtenerClienteConId(int? IdCliente)
        {
            if (IdCliente != null)
            {
                return Cargar()
                    .Where(x => x.IdCliente == IdCliente)
                    .Select(x => x.IdCliente + " - " + x.NombreCompleto)
                    .FirstOrDefault();
            }

            return " - ";
        }
    }
}
