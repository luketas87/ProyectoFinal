using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BE.Interfaces
{
    public interface IBackup
    {
        Form MdiParent { get; set; }
        void Show();
    }
}
