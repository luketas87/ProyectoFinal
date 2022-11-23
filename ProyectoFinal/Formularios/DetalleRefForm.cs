using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace ProyectoFinal.Formularios
{
    public partial class DetalleRefForm : Form, IDetalleRefForm
    {
        private readonly BLLIDetalleVenta detalleVentaBLL;
        private int VentaId { get; set; }

        public DetalleRefForm(BLLIDetalleVenta detalleVentaBLL)
        {
            this.detalleVentaBLL = detalleVentaBLL;
            InitializeComponent();
        }

        //CARGAMOS EL DETALLE DE LAS VENTAS
        private void DetalleRefForm_Load(object sender, EventArgs e)
        {
            dgDetalleVenta.AutoGenerateColumns = false;
            CargarDetalle();
        }

        private void CargarDetalle()
        {
            var ventaUI = IoCContainer.Resolve<IVenta>();
            VentaId = ventaUI.ObtenerVentaSeleccionada().IdVenta;

            dgDetalleVenta.DataSource = detalleVentaBLL.Cargar()
                                                       .Where(x => x.IdVenta == VentaId)
                                                       .SelectMany(x => x.LineasDetalle).ToList();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
