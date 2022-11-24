using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.Utilidades;
using DAL.DAO.Interfaces;

namespace DAL.DAO.Implementacion
{
    public class DALFormControl : BaseDAO, DALIFormControl
    {
        public List<BEPatente> ObtenerPermisosFormulario(int IdForm)
        {
            var query = "SELECT IdPatente FROM FormularioPatente WHERE IdFormulario = @Idform";

            return CatchException(() =>
            {
                return Exec<BEPatente>(query, new { @Idform = IdForm });
            });
        }

        public List<BEPatente> ObtenerPermisosFormularios()
        {
            var query = "SELECT fp.IdPatente,p.descripcion FROM FormularioPatente fp INNER JOIN Patente p ON p.IdPatente=fp.IdPatente";

            return CatchException(() =>
            {
                return Exec<BEPatente>(query);
            });
        }
    }
}
