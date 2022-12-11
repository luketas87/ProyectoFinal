using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Implementacion;
using DAL.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Formularios
{
    public partial class DetalleVenta : Form, IDetalleVenta
    {
        private const string nombreForm = "Venta";
        private const string nomEntidad = "DetalleVenta";
        private const string campoId = "IdDetalle";

        private readonly BLLIVenta ventaBLL;
        private readonly BLLIDetalleVenta detalleVentaBLL;
        private readonly BLLIProducto productoBLL;
        private readonly IProductos productos;
        private readonly BLLICliente clienteBLL;
        private readonly IClientes cliente;
        private readonly IFormControl formControl;
        private readonly ITraductor traductor;
        private readonly SqlUtilidades sqlUtils = new SqlUtilidades();

        public BECliente ClienteSeleccionado { get; set; } = new BECliente();
        public BEProducto ProductoSeleccionado { get; set; } = new BEProducto();
        public BECuentaUsuario UsuarioActivo { get; set; } = new BECuentaUsuario();
        public BELineaDetalle LineaDetalleSeleccionada { get; set; } = new BELineaDetalle();
        private List<BELineaDetalle> ListGrid { get; set; } = new List<BELineaDetalle>();
        private BEDetalleVenta DetalleEnGrid { get; set; }


        public DetalleVenta(BLLIVenta ventaBLL,
            BLLIDetalleVenta detalleVentaBLL,
            BLLIProducto productoBLL,
            IProductos productos,
            BLLICliente clienteBLL,
            IClientes cliente,
            IFormControl formControl,
            ITraductor traductor)
        {
            this.ventaBLL = ventaBLL;
            this.detalleVentaBLL = detalleVentaBLL;
            this.productoBLL = productoBLL;
            this.productos = productos;
            this.cliente = cliente;
            this.clienteBLL = clienteBLL;
            this.formControl = formControl;
            this.traductor = traductor;
            InitializeComponent();
            dgDetalleVta.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DetalleVenta_Load(object sender, EventArgs e)
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            traductor.Traduccir(this, nomEntidad);
        }

        //Se crea una nueva linea de detalle
        private BELineaDetalle CrearNuevaLinea()
        {
            return new BELineaDetalle()
            {
                Producto = ProductoSeleccionado,
                DescProducto = ProductoSeleccionado.Descripcion,
                Cantidad = int.Parse(txtCant.Text),
                Importe = ProductoSeleccionado.PVenta * int.Parse(txtCant.Text)
            };
        }

        //Listar Datagrid
        private void RecargarDatagrid()
        {
            dgDetalleVta.DataSource = null;
            dgDetalleVta.DataSource = ListGrid;
        }

        //Limpiar Controles
        private void LimpiarControles()
        {
            txtCant.Text = string.Empty;
            txtCodProd.Text = string.Empty;

        }

        //Agregar Productos
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if(ProductoSeleccionado.IdProducto != 0 && !string.IsNullOrEmpty(txtCant.Text))
            {
                ListGrid.Add(CrearNuevaLinea());

                RecargarDatagrid();

                LimpiarControles();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCodProd.Text) && !string.IsNullOrEmpty(txtCant.Text))
                {
                    ProductoSeleccionado = productoBLL.ObtenerProductoPorCodigo(txtCodProd.Text);

                    if (ProductoSeleccionado != null)
                    {
                        ListGrid.Add(CrearNuevaLinea());

                        RecargarDatagrid();

                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("El codigo de producto no existe", "Seleccionar Codigo Producto");

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos un producto y la cantidad", "Seleccionar producto");

                }
            }
        }

        private BEVenta CrearNuevaVenta(int estadoId, DateTime fecha, float monto, int tipoVta, int usuarioId, int clienteId)
        {
            return new BEVenta()
            {
                IdCliente = clienteId,
                IdEstado = estadoId,
                Fecha = fecha,
                Monto = monto,
                IdTipoVenta = tipoVta,
                IdUsuario = usuarioId,
            };
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            var resultado = cliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ClienteSeleccionado = cliente.ObtenerClienteSeleccionado();
                lblCliente.Text = $"CLIENTE: {ClienteSeleccionado.NombreCompleto}";
                radioVtaCC.Enabled = true;
                radioVtaCC.Checked = true;
            }
            else
            {
                radioVtaCC.Enabled = false;
            }
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            var resultado = productos.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                ProductoSeleccionado = productos.ObtenerProductoSeleccionado();
            }

            txtCodProd.Text = ProductoSeleccionado.IdProducto.ToString();
        }

        private void VtaProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void VaciarListGrid()
        {
            ListGrid = null;
            ListGrid = new List<BELineaDetalle>();
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("       ¿Desea Cancelar la venta?", "Cancelar Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VaciarListGrid();

                RecargarDatagrid();

                ClienteSeleccionado = null;
                ProductoSeleccionado = null;
                txtCant.Text = "";
                txtCodProd.Text = "";
                radioVtaCC.Enabled = true;
                radioVtaSimple.Enabled = true;
                rbSe.Enabled = true;

                //this.Close();
            }
        }

        private float CalcularMontoTotal()
        {
            var total = 0.0F;

            foreach (var linea in ListGrid)
            {
                total += linea.Importe;
            }

            return total;
        }

        private void VaciaListGrid()
        {
            ListGrid = null;
            ListGrid = new List<BELineaDetalle>();
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado.IdCliente != 0)
            {
                if (radioVtaSimple.Checked)
                {

                    ventaBLL.Crear(CrearNuevaVenta(DALVenta.EstadoVenta.Aprobada.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), DALVenta.TipoVenta.VentaSimple.GetHashCode(), UsuarioActivo.IdUsuario, ClienteSeleccionado.IdCliente));
                }

                if (radioVtaCC.Checked)
                {
                    ventaBLL.Crear(CrearNuevaVenta(DALVenta.EstadoVenta.Pendiente.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), DALVenta.TipoVenta.Cliente.GetHashCode(), UsuarioActivo.IdUsuario, ClienteSeleccionado.IdCliente));
                }

                if (rbSe.Checked)
                {
                    ventaBLL.Crear(CrearNuevaVenta(DALVenta.EstadoVenta.Pendiente.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), DALVenta.TipoVenta.Seña.GetHashCode(), UsuarioActivo.IdUsuario, ClienteSeleccionado.IdCliente));
                }

                if (ProductoSeleccionado.IdProducto != 0 && ProductoSeleccionado.Stock != 0)
                {
                    ClienteSeleccionado = null;
                    ProductoSeleccionado = null;
                    txtCant.Text = "";
                    txtCodProd.Text = "";
                    radioVtaCC.Enabled = true;
                    radioVtaSimple.Enabled = true;
                    rbSe.Enabled = true;
                    lblCliente.Text = "";





                    foreach (var linea in ListGrid)
                    {
                        DetalleEnGrid = new BEDetalleVenta() { IdDetalle = sqlUtils.GenerarId(campoId, nomEntidad), IdVenta = ventaBLL.ObtenerUltimoIdVenta() };

                        DetalleEnGrid.LineasDetalle.Add(linea);

                        detalleVentaBLL.Crear(DetalleEnGrid);


                    }
                    VaciaListGrid();

                    RecargarDatagrid();

                    MessageBox.Show("       Venta Realiza con exito", "Finalizar Venta");

                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un producto y su codigo para continuar con la venta", "Generar Venta");
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Cliente para Proceder con la Venta", "Aprobar Venta");
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            ListGrid.Remove(LineaDetalleSeleccionada);
            RecargarDatagrid();
        }

        private void dgDetalleVta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LineaDetalleSeleccionada = (BELineaDetalle)dgDetalleVta.CurrentRow.DataBoundItem;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
