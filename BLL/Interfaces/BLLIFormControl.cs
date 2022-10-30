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
        IDictionary<string, string> Traducciones { get; set; }

        BEIdioma LenguajeSeleccionado { get; set; }

        List<BEPatente> ObtenerPermisosFormularios();

        List<BEPatente> ObtenerPermisosFormulario(int formId);

        void GuardarDatosSesionUsuario(BECuentaUsuario usuario);
        BECuentaUsuario ObtenerInfoUsuario();
        BECuentaUsuario ObtenerPermisosUsuario();

        IDictionary<string, string> ObtenerTraducciones();
        BEIdioma ObtenerIdioma();
    }
}
