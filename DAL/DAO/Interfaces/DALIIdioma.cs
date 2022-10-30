using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIIdioma
    {
        List<BEIdioma> ObtenerTodosLosIdiomas();


        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idIdioma, string nombreForm);
    }

}

