using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE.Implementacion;

namespace BE.Interfaces
{
    public interface IABMUsuario
    {
        Form MdiParent { get; set; }

        void Show();

        BECuentaUsuario ObtenerUsuarioSeleccionado();

        List<BECuentaUsuario> ObtenerUsuariosBd();
    }
}
