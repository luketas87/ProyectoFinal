using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO.Interfaces;
using DAL.Utilidades;

namespace DAL.DAO.Implementacion
{
    public class DALDigitoVerificador : BaseDAO, DALIDigitoVerificador
    {
        public List<string>  Entidades { get; set; } = SqlUtilidades.GetTables();

        public void ActualizarDVVertical(string entidad)
        {
            var digito = CalcularDVVertical(entidad);

            var queryString = "UPDATE DigitoVerificadorVertical SET ValorDigitoVerificador = @digito WHERE Entidad = @entidad";

            CatchException(() =>
            {
                Exec(queryString, new { @entidad = entidad, @digito = digito });
            });
        }

        public int CalcularDVHorizontal(List<string> columnasString)
        {
            var digito = 0;

            foreach (var str in columnasString)
            {
                foreach (var ch in str)
                {
                    digito += (int)ch;
                }
            }

            return digito;
        }

        public int CalcularDVVertical(string entidad)
        {
            var queryString = string.Format("SELECT SUM(DVH) FROM {0}", entidad);

            if (entidad == "Bitacora")
            {
                queryString = string.Format("SELECT SUM(CAST(DVH AS INT)) FROM {0}", entidad);
            }

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public bool ComprobarIntegridad()
        {
            var returnValue = true;

            var resultadoUsuario = CalcularDVVertical(Entidades.Find(x => x == "Usuario"));

            var dvverticalUsuario = ConsultarDVVertical(Entidades.Find(x => x == "Usuario"));

            var resultadoBitacora = CalcularDVVertical(Entidades.Find(x => x == "Bitacora"));

            var dvverticalBitacora = ConsultarDVVertical(Entidades.Find(x => x == "Bitacora"));

            var resultadoPatente = CalcularDVVertical(Entidades.Find(x => x == "Patente"));

            var dvverticalPatente = ConsultarDVVertical(Entidades.Find(x => x == "Patente"));

            var resultadoVenta = CalcularDVVertical(Entidades.Find(x => x == "Venta"));

            var dvverticalVenta = ConsultarDVVertical(Entidades.Find(x => x == "Venta"));

            if (resultadoUsuario != dvverticalUsuario["Usuario"])
            {
                returnValue = false;
            }

            if (resultadoBitacora != dvverticalBitacora["Bitacora"])
            {
                returnValue = false;
            }

            if (resultadoPatente != dvverticalPatente["Patente"])
            {
                returnValue = false;
            }

            if (resultadoVenta != dvverticalVenta["Venta"])
            {
                returnValue = false;
            }

            return returnValue;
        }

        public bool ComprobarPrimerDigito(string entidad)
        {
            var queryString = "SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = @entidad";
            var digito = new List<int>();
            CatchException(() =>
            {
                digito = Exec<int>(queryString, new { @entidad = entidad });
            });

            if (digito.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InsertarDVVertical(string entidad)
        {
            var digito = CalcularDVVertical(entidad);

            var queryString = "INSERT INTO DigitoVerificadorVertical(Entidad, ValorDigitoVerificador) VALUES(@entidad, @digito)";

            CatchException(() =>
            {
                Exec(queryString, new { @entidad = entidad, @digito = digito });
            });
        }
        public Dictionary<string, int> ConsultarDVVertical(string entidades)
        {
            var entidadesdic = new Dictionary<string, int>();

            var queryString = string.Format("SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = '{0}'", entidades);

            CatchException(() =>
            {
                entidadesdic.Add(entidades, Exec<int>(queryString)[0]);
            });

            return entidadesdic;
        }
    }
}
