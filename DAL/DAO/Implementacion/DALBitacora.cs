using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.DAO;
using DAL.Utilidades;
using DAL.DAO.Interfaces;

namespace DAL.DAO.Implementacion
{
    public class DALBitacora : BaseDAO, DALIBitacora
    {
        public const string Key = "bZr2URKx";
        public const string Code = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;


        public DALBitacora(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public void CargarDVHBitacora()
        {
            throw new NotImplementedException();
        }

        public List<string> CargarUsuarios()
        {
            throw new NotImplementedException();
        }

        public void FiltrarBitacora(BEFBitacora filtros)
        {
            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND UsuarioId IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            CatchException(() =>
            {
                return Exec(queryString.ToString());
            });
        }

        public int GenerarDVH()
        {
            throw new NotImplementedException();
        }

        public BEBitacora LeerBitacoraConId(int IdBitacora)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {IdBitacora}";

            return CatchException(() =>
            {
                return Exec<BEBitacora>(queryString)[0];
            });
        }

        public List<BEBitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString).FirstOrDefault();
            });
        }
    }
}
