using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace BLL.Interfaces
{
    public interface BLLIFormControl
    {
        List<BEPatente> ObtenerPermisosFormularios();

        List<BEPatente> ObtenerPermisosFormulario(int formId);
    }
}
