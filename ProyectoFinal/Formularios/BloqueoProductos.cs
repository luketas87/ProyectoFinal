using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinal.Formularios
{
    public partial class BloqueoProductos : Form, IBloqueoProductos
    {
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly BLLIProducto productoBLL;

        public BloqueoProductos(BLLIProducto productoBLL)
        {
            this.productoBLL = productoBLL;
            CargarProductos();
            InitializeComponent();
        }

        //ACTIVAR PRODUCTOS INACTIVOS.
        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (lstInactivos.Items.Count > 0)
            {
                var activado = productoBLL.ActivarProducto(lstInactivos.SelectedValue.ToString());

                if (activado)
                {
                    CargarProductos();
                }
            }
        }

        private void CargarProductos()
        {
            lstActivos.DataSource = productoBLL.Cargar().Select(x => x.IdProducto + " - " + x.Descripcion).ToList();
            lstInactivos.DataSource = productoBLL.CargarInactivos().Select(x => x.IdProducto + " - " + x.Descripcion).ToList(); ;
        }

        //INHABILITAR PRODUCTOS SIN STOCK.
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (lstActivos.Items.Count > 0)
            {
                var desactivado = productoBLL.DesactivarProducto(lstActivos.SelectedValue.ToString());
                if (desactivado)
                {
                    CargarProductos();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BloqueoProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            DialogResult = DialogResult.OK;
            e.Cancel = true;
        }
    }
}
