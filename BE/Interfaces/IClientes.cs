using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE.Implementacion;

namespace BE.Interfaces
{
    public interface IClientes
    {
        DialogResult ShowDialog();

        BECliente ObtenerClienteSeleccionado();
    }
}
