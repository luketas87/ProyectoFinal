using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BE.Interfaces
{
    public interface IDatosUsuario
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
