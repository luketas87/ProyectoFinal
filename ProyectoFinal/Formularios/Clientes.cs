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
    public partial class Clientes : Form, IClientes
    {
        private readonly BLLICliente clienteBLL;

        public List<BECliente> ClientesBd { get; set; } = new List<BECliente>();

        public BECliente ClienteSeleccionado { get; set; } = new BECliente();

        public bool formUserClose = true;
        public Clientes(BLLICliente clienteBLL)
        {
            this.clienteBLL = clienteBLL;
            InitializeComponent();
        }

        //DAR DE ALTA A UN CLIENTE.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var exito = clienteBLL.Crear(new BECliente() { NombreCompleto = txtNombre.Text, Domicilio = txtDomicilio.Text, Email = txtEmail.Text, Telefono = txtTelefono.Text, Activo = true });
            CargarClientes();
            LimpiarControles();

            if (exito)
            {
                MessageBox.Show("Cliente Creado");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ClienteSeleccionado = null;
            dgClientes.AutoGenerateColumns = false;
            CargarClientes();
        }

        private void CargarClientes()
        {
            ClientesBd = clienteBLL.Cargar();
            dgClientes.DataSource = null;
            dgClientes.DataSource = ClientesBd;
        }

        public BECliente ObtenerClienteSeleccionado()
        {
            //DialogResult = DialogResult.OK;
            return (ClienteSeleccionado != null)
                ? ClienteSeleccionado
                : ClienteSeleccionado = (BECliente)dgClientes.CurrentRow.DataBoundItem;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        // MODIFICAR UN CLIENTE
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var exito = clienteBLL.Actualizar(new BECliente() { IdCliente = ClienteSeleccionado.IdCliente, NombreCompleto = txtNombre.Text, Domicilio = txtDomicilio.Text, Email = txtEmail.Text, Telefono = txtTelefono.Text, Activo = true });
            CargarClientes();
            LimpiarControles();

            if (exito)
            {
                MessageBox.Show("Cliente Actualizado");
            }
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClienteSeleccionado = null;
            ObtenerClienteSeleccionado();
            CargaControles();
        }

        //BORRAR UN CLIENTE.
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var exito = clienteBLL.Borrar(ClienteSeleccionado);
            CargarClientes();
            LimpiarControles();

            if (exito)
            {
                MessageBox.Show("Cliente borrado");
            }
        }

        private void CargaControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtNombre.Text = ClienteSeleccionado.NombreCompleto;
                txtEmail.Text = ClienteSeleccionado.Email;
                txtDomicilio.Text = ClienteSeleccionado.Domicilio;
                txtTelefono.Text = ClienteSeleccionado.Telefono.ToString();
            });
        }

        private void LimpiarControles()
        {
            FormExtensions.CatchException(this, () =>
            {
                txtNombre.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDomicilio.Text = string.Empty;
                txtTelefono.Text = string.Empty;
            });
        }
    }
}
