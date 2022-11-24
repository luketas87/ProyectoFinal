using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using EasyEncryption;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL.implementacion;

namespace ProyectoFinal.Formularios
{
    public partial class Venta : Form, IVenta
    {
        private readonly BLLIVenta ventaBLL;
#pragma warning disable CS0649 // El campo 'Venta.traductor' nunca se asigna y siempre tendrá el valor predeterminado null
        private readonly ITraductor traductor;
#pragma warning restore CS0649 // El campo 'Venta.traductor' nunca se asigna y siempre tendrá el valor predeterminado null
        private readonly BLLICliente clienteBLL;
        private readonly BLLICuentaUsuario usuarioBLL;
        private readonly IDetalleRefForm detalleRefForm;

        private const string nombreForm = "Venta";
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        private Regex obtenerInt = new Regex("\\d+");

        public BELineaVenta LineaSeleccionada { get; set; } = new BELineaVenta();
        public BEVenta VentaSeleccionada { get; set; } = new BEVenta();
        public List<BEVenta> VentasBd { get; set; } = new List<BEVenta>();
        public List<BELineaVenta> ListGrid { get; set; }


        public Venta(ITraductor traductor, BLLIVenta ventaBLL, BLLICliente clienteBLL, BLLICuentaUsuario usuarioBLL, IDetalleRefForm detalleRefForm)
        {
            this.ventaBLL = ventaBLL;
            this.clienteBLL = clienteBLL;
            this.usuarioBLL = usuarioBLL;
            this.detalleRefForm = detalleRefForm;
            InitializeComponent();
            dgVenta.AutoGenerateColumns = false;
            
        }

        public void HacerLoad()
        {
            CargarVentas();
            CargarGrid();
        }

        public BEVenta ObtenerVentaSeleccionada()
        {
            return VentaSeleccionada;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            traductor.Traduccir(this, nombreForm);
            HacerLoad();
        }

        private void CargarVentas()
        {
            ListGrid = null;
            ListGrid = new List<BELineaVenta>();

            VentasBd = ventaBLL.Cargar();

            foreach (var venta in VentasBd)
            {
                ListGrid.Add(
                    new BELineaVenta()
                    {
                        IdVenta = venta.IdVenta,
                        Fecha = venta.Fecha,
                        Cliente = clienteBLL.ObtenerClienteConId(venta.IdCliente),
                        Estado = ventaBLL.ObtenerEstadoVenta(venta.IdEstado),
                        TipoVenta = ventaBLL.ObtenerTipoVenta(venta.IdTipoVenta),
                        Vendedor = usuarioBLL.Cargar().Where(x => x.IdUsuario == venta.IdUsuario).Select(x => DES.Decrypt(x.Email, key, iv)).FirstOrDefault(),
                        Monto = venta.Monto
                    });
            }
        }

        private void CargarGrid()
        {
            dgVenta.DataSource = null;
            dgVenta.DataSource = ListGrid;
        }

        private void Venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void dgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LineaSeleccionada = (BELineaVenta)dgVenta.CurrentRow.DataBoundItem;

                VentaSeleccionada = CrearVenta(LineaSeleccionada.Estado);
            }
        }

        //boton para Aprobar la Operacion de la venta.
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Aprobada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        //boton para Aprobar la Operacion de la venta.
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Rechazada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        //boton para cancelar la operacion de la Venta.
        private void bntCancelar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Cancelada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        private int DeterminarCliente()
        {
            int cliente = 0;

            if (LineaSeleccionada.Cliente != " - ")
            {
                cliente = clienteBLL.Cargar()
                   .Where(x => x.IdCliente == int.Parse(obtenerInt.Match(LineaSeleccionada.Cliente).Value))
                   .Select(x => x.IdCliente).FirstOrDefault();
            }
            else
            {
                cliente = 0;
            }

            return cliente;
        }

        //boton para ver el detalle de las ventas.
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            detalleRefForm.ShowDialog();
        }

        private BEVenta CrearVenta(string estadoVenta)
        {
            int cliente = DeterminarCliente();

            var venta = new BEVenta()
            {
                IdVenta = LineaSeleccionada.IdVenta,
                IdCliente = cliente,
                IdEstado = ventaBLL.ObtenerEstadoVentaConString(estadoVenta),
                Fecha = LineaSeleccionada.Fecha,
                Monto = LineaSeleccionada.Monto,
                IdTipoVenta = ventaBLL.ObtenerTipoVentaConString(LineaSeleccionada.TipoVenta),
                IdUsuario = usuarioBLL.ObtenerUsuarioConEmail(LineaSeleccionada.Vendedor).IdUsuario
            };
            return venta;
        }
    }
}
