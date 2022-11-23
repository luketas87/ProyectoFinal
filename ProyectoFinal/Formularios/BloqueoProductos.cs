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
            InitializeComponent();
            this.productoBLL = productoBLL;
            CargarProductos();

        }

        //ACTIVAR PRODUCTOS INACTIVOS.
        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (lstInactivos.Items.Count >= 0)
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
            var listaActivos = productoBLL.Cargar().Select(x => x.IdProducto + " - " + x.Descripcion).ToList();
            foreach (var item in listaActivos)
            {
                lstActivos.Items.Add(item);
            }

            var listaInactivos = productoBLL.CargarInactivos().Select(x => x.IdProducto + " - " + x.Descripcion).ToList();
            foreach (var item in listaInactivos)
            {
                lstInactivos.Items.Add(item);
            }
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

        private void lstActivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BloqueoProductos_Load(object sender, EventArgs e)
        {
            //CargarProductos();
        }
    }
}
