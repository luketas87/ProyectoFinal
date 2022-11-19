using BE.Implementacion;
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
using UI.Clases;

namespace ProyectoFinal.Formularios
{
    public partial class Productos : Form, IProductos
    {
        private const string nombreForm = "Productos";
        private readonly BLLIProducto productoBLL;
        private readonly IBloqueoProductos bloqueoProductos;

        private BEProducto productoSeleccionado = new BEProducto();

        public bool formUserClose = true;

        public Productos(BLLIProducto productoBLL, IBloqueoProductos bloqueoProductos)
        {
            this.productoBLL = productoBLL;
            this.bloqueoProductos = bloqueoProductos;
            InitializeComponent();
        }
        public Productos()
        {
            InitializeComponent();
        }

        public BEProducto ObtenerProductoSeleccionado()
        {
            return productoSeleccionado;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            dgProd.AutoGenerateColumns = false;
            productoSeleccionado = null;
            CargarProductos();
        }

        //Cargo un nuevo producto
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var exito = productoBLL.Crear(new BEProducto() { Descripcion = txtDescripcion.Text, PVenta = float.Parse(txtPcosto.Text), PUnitario = float.Parse(txtPunitario.Text), Stock = int.Parse(txtCantidad.Text), MinStock = int.Parse(txtMinStock.Text) });

            if (exito)
            {
                MessageBox.Show("Producto Creado");
                CargarProductos();
                LimpiarControles();
            }
        }

        //Cargo un modificar producto
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var exito = productoBLL.Actualizar(new BEProducto() { IdProducto = productoSeleccionado.IdProducto, Descripcion = txtDescripcion.Text, PVenta = float.Parse(txtPcosto.Text), PUnitario = float.Parse(txtPunitario.Text), Stock = int.Parse(txtCantidad.Text), MinStock = int.Parse(txtMinStock.Text) });

            if (exito)
            {
                MessageBox.Show("Producto Actualizado");
                CargarProductos();
                LimpiarControles();
            }
        }

        //Cargo un borrar producto
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var exito = productoBLL.Borrar(productoSeleccionado);

            if (exito)
            {
                MessageBox.Show("Producto Borrado");
                CargarProductos();
                LimpiarControles();
            }
        }

        //LIMPIAMOS LOS ITEMS PARA GENERAR UNA NUEVA VENTA.
        private void LimpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            txtPunitario.Text = string.Empty;
            txtPcosto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtMinStock.Text = string.Empty;
            lblNroProd.Text = "Codigo de Producto:";
        }

        //BOTON PARA SELECCIONAR EL PRODUCTO UNA VEZ BUSCADO.
        private void btnSelVta_Click(object sender, EventArgs e)
        {
            ActualizarSeleccionado();

            formUserClose = false;
            DialogResult = DialogResult.OK;
        }

        private void Productos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formUserClose)
            {
                e.Cancel = true;
            }
            Hide();
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            bloqueoProductos.ShowDialog();
        }

        private void dgProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarSeleccionado();
            LimpiarControles();
            CargaControles();
        }

        private void ActualizarSeleccionado()
        {
            productoSeleccionado = (BEProducto)dgProd.CurrentRow.DataBoundItem;
        }

        private void CargaControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtDescripcion.Text = productoSeleccionado.Descripcion;
                txtPunitario.Text = productoSeleccionado.PUnitario.ToString();
                txtPcosto.Text = productoSeleccionado.PVenta.ToString();
                txtCantidad.Text = productoSeleccionado.Stock.ToString();
                txtMinStock.Text = productoSeleccionado.MinStock.ToString();
                CambiarNroProducto();
            });
        }

        private void CambiarNroProducto()
        {
            lblNroProd.Text += productoSeleccionado.IdProducto;
        }

        private void CargarProductos()
        {
            dgProd.DataSource = null;
            dgProd.DataSource = productoBLL.Cargar();
        }
    }
}
