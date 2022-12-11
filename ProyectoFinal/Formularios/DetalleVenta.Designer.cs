
namespace ProyectoFinal.Formularios
{
    partial class DetalleVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDetalleVta = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSe = new System.Windows.Forms.RadioButton();
            this.radioVtaSimple = new System.Windows.Forms.RadioButton();
            this.radioVtaCC = new System.Windows.Forms.RadioButton();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnSeleccionarCliente = new CustomControls.RJControls.RJButton();
            this.btnAgregarProducto = new CustomControls.RJControls.RJButton();
            this.btnFinalizarVenta = new CustomControls.RJControls.RJButton();
            this.btnCancelarVenta = new CustomControls.RJControls.RJButton();
            this.btnQuitarProducto = new CustomControls.RJControls.RJButton();
            this.btnListarProductos = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVta)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "CODIGO DE PRODUCTO";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(359, 143);
            this.txtCodProd.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(132, 20);
            this.txtCodProd.TabIndex = 24;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "CANTIDAD:";
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "DescProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 75;
            // 
            // dgDetalleVta
            // 
            this.dgDetalleVta.AllowUserToAddRows = false;
            this.dgDetalleVta.AllowUserToDeleteRows = false;
            this.dgDetalleVta.AllowUserToResizeColumns = false;
            this.dgDetalleVta.AllowUserToResizeRows = false;
            this.dgDetalleVta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDetalleVta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgDetalleVta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleVta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Importe,
            this.Cantidad});
            this.dgDetalleVta.Location = new System.Drawing.Point(11, 227);
            this.dgDetalleVta.Margin = new System.Windows.Forms.Padding(2);
            this.dgDetalleVta.MultiSelect = false;
            this.dgDetalleVta.Name = "dgDetalleVta";
            this.dgDetalleVta.ReadOnly = true;
            this.dgDetalleVta.RowTemplate.Height = 24;
            this.dgDetalleVta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetalleVta.Size = new System.Drawing.Size(573, 196);
            this.dgDetalleVta.TabIndex = 33;
            this.dgDetalleVta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalleVta_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSe);
            this.groupBox1.Controls.Add(this.radioVtaSimple);
            this.groupBox1.Controls.Add(this.radioVtaCC);
            this.groupBox1.Location = new System.Drawing.Point(13, 125);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(168, 98);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione Tipo de Venta";
            // 
            // rbSe
            // 
            this.rbSe.AutoSize = true;
            this.rbSe.Location = new System.Drawing.Point(4, 42);
            this.rbSe.Margin = new System.Windows.Forms.Padding(2);
            this.rbSe.Name = "rbSe";
            this.rbSe.Size = new System.Drawing.Size(50, 17);
            this.rbSe.TabIndex = 15;
            this.rbSe.Text = "Seña";
            this.rbSe.UseVisualStyleBackColor = true;
            // 
            // radioVtaSimple
            // 
            this.radioVtaSimple.AutoSize = true;
            this.radioVtaSimple.Checked = true;
            this.radioVtaSimple.Location = new System.Drawing.Point(4, 22);
            this.radioVtaSimple.Margin = new System.Windows.Forms.Padding(2);
            this.radioVtaSimple.Name = "radioVtaSimple";
            this.radioVtaSimple.Size = new System.Drawing.Size(87, 17);
            this.radioVtaSimple.TabIndex = 6;
            this.radioVtaSimple.TabStop = true;
            this.radioVtaSimple.Text = "Venta Simple";
            this.radioVtaSimple.UseVisualStyleBackColor = true;
            // 
            // radioVtaCC
            // 
            this.radioVtaCC.AutoSize = true;
            this.radioVtaCC.Location = new System.Drawing.Point(4, 63);
            this.radioVtaCC.Margin = new System.Windows.Forms.Padding(2);
            this.radioVtaCC.Name = "radioVtaCC";
            this.radioVtaCC.Size = new System.Drawing.Size(135, 17);
            this.radioVtaCC.TabIndex = 7;
            this.radioVtaCC.Text = "Venta Cuenta Corriente";
            this.radioVtaCC.UseVisualStyleBackColor = true;
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(359, 185);
            this.txtCant.Margin = new System.Windows.Forms.Padding(2);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(132, 20);
            this.txtCant.TabIndex = 26;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(224, 102);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(55, 13);
            this.lblCliente.TabIndex = 21;
            this.lblCliente.Text = "CLIENTE:";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.Gray;
            this.btnVolver.BorderRadius = 32;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Gray;
            this.btnVolver.Location = new System.Drawing.Point(11, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(68, 42);
            this.btnVolver.TabIndex = 60;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Gray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionarCliente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionarCliente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSeleccionarCliente.BorderRadius = 40;
            this.btnSeleccionarCliente.BorderSize = 1;
            this.btnSeleccionarCliente.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(11, 75);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(118, 40);
            this.btnSeleccionarCliente.TabIndex = 61;
            this.btnSeleccionarCliente.Text = "Seleccionar Cliente";
            this.btnSeleccionarCliente.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSeleccionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.btnSeleccionarCliente_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarProducto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnAgregarProducto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAgregarProducto.BorderRadius = 40;
            this.btnAgregarProducto.BorderSize = 1;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAgregarProducto.Location = new System.Drawing.Point(17, 427);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(118, 40);
            this.btnAgregarProducto.TabIndex = 62;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnFinalizarVenta
            // 
            this.btnFinalizarVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarVenta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarVenta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFinalizarVenta.BorderRadius = 40;
            this.btnFinalizarVenta.BorderSize = 1;
            this.btnFinalizarVenta.FlatAppearance.BorderSize = 0;
            this.btnFinalizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFinalizarVenta.Location = new System.Drawing.Point(110, 496);
            this.btnFinalizarVenta.Name = "btnFinalizarVenta";
            this.btnFinalizarVenta.Size = new System.Drawing.Size(118, 40);
            this.btnFinalizarVenta.TabIndex = 63;
            this.btnFinalizarVenta.Text = "Finalizar Venta";
            this.btnFinalizarVenta.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFinalizarVenta.UseVisualStyleBackColor = false;
            this.btnFinalizarVenta.Click += new System.EventHandler(this.btnFinalizarVenta_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelarVenta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnCancelarVenta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarVenta.BorderRadius = 40;
            this.btnCancelarVenta.BorderSize = 1;
            this.btnCancelarVenta.FlatAppearance.BorderSize = 0;
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarVenta.Location = new System.Drawing.Point(359, 496);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(118, 40);
            this.btnCancelarVenta.TabIndex = 64;
            this.btnCancelarVenta.Text = "Cancelar Venta";
            this.btnCancelarVenta.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarVenta.UseVisualStyleBackColor = false;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitarProducto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnQuitarProducto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuitarProducto.BorderRadius = 40;
            this.btnQuitarProducto.BorderSize = 1;
            this.btnQuitarProducto.FlatAppearance.BorderSize = 0;
            this.btnQuitarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuitarProducto.Location = new System.Drawing.Point(466, 428);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.Size = new System.Drawing.Size(118, 40);
            this.btnQuitarProducto.TabIndex = 65;
            this.btnQuitarProducto.Text = "Quitar Producto";
            this.btnQuitarProducto.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnQuitarProducto.UseVisualStyleBackColor = false;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // btnListarProductos
            // 
            this.btnListarProductos.BackColor = System.Drawing.SystemColors.Control;
            this.btnListarProductos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnListarProductos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnListarProductos.BorderRadius = 40;
            this.btnListarProductos.BorderSize = 1;
            this.btnListarProductos.FlatAppearance.BorderSize = 0;
            this.btnListarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnListarProductos.Location = new System.Drawing.Point(503, 140);
            this.btnListarProductos.Name = "btnListarProductos";
            this.btnListarProductos.Size = new System.Drawing.Size(81, 70);
            this.btnListarProductos.TabIndex = 66;
            this.btnListarProductos.Text = "Listar Productos";
            this.btnListarProductos.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnListarProductos.UseVisualStyleBackColor = false;
            this.btnListarProductos.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // DetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 546);
            this.Controls.Add(this.btnListarProductos);
            this.Controls.Add(this.btnQuitarProducto);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.btnFinalizarVenta);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgDetalleVta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblCliente);
            this.Name = "DetalleVenta";
            this.Text = "DetalleVenta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VtaProd_FormClosing);
            this.Load += new System.EventHandler(this.DetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleVta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridView dgDetalleVta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSe;
        private System.Windows.Forms.RadioButton radioVtaSimple;
        private System.Windows.Forms.RadioButton radioVtaCC;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblCliente;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnSeleccionarCliente;
        private CustomControls.RJControls.RJButton btnAgregarProducto;
        private CustomControls.RJControls.RJButton btnFinalizarVenta;
        private CustomControls.RJControls.RJButton btnCancelarVenta;
        private CustomControls.RJControls.RJButton btnQuitarProducto;
        private CustomControls.RJControls.RJButton btnListarProductos;
    }
}