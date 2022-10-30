using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;
using DAL.Utilidades;
using DAL.DAO.Interfaces;

namespace DAL.DAO
{
    public class DALIdioma : BaseDAO, DALIIdioma
    {
        public List<BEIdioma> ObtenerTodosLosIdiomas()
        {
            var query = "Select * from Idioma";

            return CatchException(() =>
            {
                return Exec<BEIdioma>(query);
            });
        }

        public List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idIdioma, string nombreForm)
        {
            var query = string.Format(
               "SELECT trad.* FROM Traduccion trad " +
                "INNER JOIN Formularios ON Formularios.IdFormulario = trad.IdFormulario " +
                "INNER JOIN Idioma ON Idioma.IdIdioma = trad.IdIdioma " +
                "WHERE Idioma.IdIdioma = {0} AND Formularios.NombreFormulario = '{1}'",
               idIdioma,
               nombreForm);

            return CatchException(() =>
            {
                return Exec<TraduccionFormulario>(query);
            });
        }
    }
}
