using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BE.Interfaces
{
    interface IBitacora
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
