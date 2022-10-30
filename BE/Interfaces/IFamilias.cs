using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

using System.Windows.Forms;
namespace BE.Interfaces
{
    public interface IFamilias
    {
        Form MdiParent { get; set; }

        void Show();

        BEFamilia ObtenerFamiliaSeleccionada();
    }
}
