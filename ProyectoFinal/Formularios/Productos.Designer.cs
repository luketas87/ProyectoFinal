
namespace ProyectoFinal.Formularios
{
    partial class Productos
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
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProd = new System.Windows.Forms.DataGridView();
            this.MinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.txtMinStock = new System.Windows.Forms.TextBox();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblPecioVenta = new System.Windows.Forms.Label();
            this.lblPreUnitario = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtPcosto = new System.Windows.Forms.TextBox();
            this.txtPunitario = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnNuevo = new CustomControls.RJControls.RJButton();
            this.btnModificar = new CustomControls.RJControls.RJButton();
            this.btnBorrar = new CustomControls.RJControls.RJButton();
            this.btnSelVta = new CustomControls.RJControls.RJButton();
            this.btnInactivos = new CustomControls.RJControls.RJButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNroProd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Cantidad";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 74;
            // 
            // PVenta
            // 
            this.PVenta.DataPropertyName = "PVenta";
            this.PVenta.HeaderText = "Precio Venta";
            this.PVenta.Name = "PVenta";
            this.PVenta.ReadOnly = true;
            this.PVenta.Width = 93;
            // 
            // PUnitario
            // 
            this.PUnitario.DataPropertyName = "PUnitario";
            this.PUnitario.HeaderText = "Precio Unitario";
            this.PUnitario.Name = "PUnitario";
            this.PUnitario.ReadOnly = true;
            this.PUnitario.Width = 101;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 88;
            // 
            // dgProd
            // 
            this.dgProd.AllowUserToAddRows = false;
            this.dgProd.AllowUserToDeleteRows = false;
            this.dgProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.PUnitario,
            this.PVenta,
            this.Stock,
            this.MinStock});
            this.dgProd.Location = new System.Drawing.Point(7, 235);
            this.dgProd.Name = "dgProd";
            this.dgProd.ReadOnly = true;
            this.dgProd.Size = new System.Drawing.Size(525, 200);
            this.dgProd.TabIndex = 49;
            this.dgProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProd_CellClick);
            // 
            // MinStock
            // 
            this.MinStock.DataPropertyName = "MinStock";
            this.MinStock.HeaderText = "Stock Minimo";
            this.MinStock.Name = "MinStock";
            this.MinStock.ReadOnly = true;
            this.MinStock.Width = 96;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCant);
            this.groupBox1.Controls.Add(this.txtMinStock);
            this.groupBox1.Controls.Add(this.lblMinStock);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Location = new System.Drawing.Point(464, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(258, 133);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INVENTARIO";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(15, 43);
            this.lblCant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(65, 13);
            this.lblCant.TabIndex = 30;
            this.lblCant.Text = "CANTIDAD:";
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(116, 95);
            this.txtMinStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(125, 20);
            this.txtMinStock.TabIndex = 20;
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(6, 102);
            this.lblMinStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(89, 13);
            this.lblMinStock.TabIndex = 32;
            this.lblMinStock.Text = "STOCK MINIMO:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(116, 40);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(125, 20);
            this.txtCantidad.TabIndex = 19;
            // 
            // lblPecioVenta
            // 
            this.lblPecioVenta.AutoSize = true;
            this.lblPecioVenta.Location = new System.Drawing.Point(18, 94);
            this.lblPecioVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPecioVenta.Name = "lblPecioVenta";
            this.lblPecioVenta.Size = new System.Drawing.Size(107, 13);
            this.lblPecioVenta.TabIndex = 46;
            this.lblPecioVenta.Text = "PRECIO DE VENTA:";
            // 
            // lblPreUnitario
            // 
            this.lblPreUnitario.AutoSize = true;
            this.lblPreUnitario.Location = new System.Drawing.Point(18, 64);
            this.lblPreUnitario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreUnitario.Name = "lblPreUnitario";
            this.lblPreUnitario.Size = new System.Drawing.Size(105, 13);
            this.lblPreUnitario.TabIndex = 45;
            this.lblPreUnitario.Text = "PRECIO UNITARIO:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(17, 33);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(83, 13);
            this.lblDesc.TabIndex = 44;
            this.lblDesc.Text = "DESCRIPCION:";
            // 
            // txtPcosto
            // 
            this.txtPcosto.Location = new System.Drawing.Point(125, 91);
            this.txtPcosto.Margin = new System.Windows.Forms.Padding(2);
            this.txtPcosto.Name = "txtPcosto";
            this.txtPcosto.Size = new System.Drawing.Size(292, 20);
            this.txtPcosto.TabIndex = 43;
            this.txtPcosto.TextChanged += new System.EventHandler(this.txtPcosto_TextChanged);
            // 
            // txtPunitario
            // 
            this.txtPunitario.Location = new System.Drawing.Point(125, 61);
            this.txtPunitario.Margin = new System.Windows.Forms.Padding(2);
            this.txtPunitario.Name = "txtPunitario";
            this.txtPunitario.Size = new System.Drawing.Size(292, 20);
            this.txtPunitario.TabIndex = 42;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(125, 30);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(292, 20);
            this.txtDescripcion.TabIndex = 41;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.BorderRadius = 40;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.Location = new System.Drawing.Point(7, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(79, 40);
            this.btnVolver.TabIndex = 60;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNuevo.BorderRadius = 40;
            this.btnNuevo.BorderSize = 1;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.Green;
            this.btnNuevo.Location = new System.Drawing.Point(564, 246);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(118, 40);
            this.btnNuevo.TabIndex = 61;
            this.btnNuevo.Text = "Nuevo Producto";
            this.btnNuevo.TextColor = System.Drawing.Color.Green;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModificar.BorderRadius = 40;
            this.btnModificar.BorderSize = 1;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.Teal;
            this.btnModificar.Location = new System.Drawing.Point(564, 292);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 40);
            this.btnModificar.TabIndex = 62;
            this.btnModificar.Text = "Modificar Producto";
            this.btnModificar.TextColor = System.Drawing.Color.Teal;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBorrar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnBorrar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBorrar.BorderRadius = 40;
            this.btnBorrar.BorderSize = 1;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBorrar.Location = new System.Drawing.Point(564, 338);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(118, 40);
            this.btnBorrar.TabIndex = 63;
            this.btnBorrar.Text = "Borrar Producto";
            this.btnBorrar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSelVta
            // 
            this.btnSelVta.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelVta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSelVta.BorderColor = System.Drawing.Color.Orange;
            this.btnSelVta.BorderRadius = 40;
            this.btnSelVta.BorderSize = 1;
            this.btnSelVta.FlatAppearance.BorderSize = 0;
            this.btnSelVta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelVta.ForeColor = System.Drawing.Color.Orange;
            this.btnSelVta.Location = new System.Drawing.Point(12, 446);
            this.btnSelVta.Name = "btnSelVta";
            this.btnSelVta.Size = new System.Drawing.Size(118, 40);
            this.btnSelVta.TabIndex = 64;
            this.btnSelVta.Text = "Seleccional Venta";
            this.btnSelVta.TextColor = System.Drawing.Color.Orange;
            this.btnSelVta.UseVisualStyleBackColor = false;
            this.btnSelVta.Click += new System.EventHandler(this.btnSelVta_Click);
            // 
            // btnInactivos
            // 
            this.btnInactivos.BackColor = System.Drawing.SystemColors.Control;
            this.btnInactivos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnInactivos.BorderColor = System.Drawing.Color.Gray;
            this.btnInactivos.BorderRadius = 40;
            this.btnInactivos.BorderSize = 1;
            this.btnInactivos.FlatAppearance.BorderSize = 0;
            this.btnInactivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivos.ForeColor = System.Drawing.Color.Gray;
            this.btnInactivos.Location = new System.Drawing.Point(564, 384);
            this.btnInactivos.Name = "btnInactivos";
            this.btnInactivos.Size = new System.Drawing.Size(118, 40);
            this.btnInactivos.TabIndex = 65;
            this.btnInactivos.Text = "Productos Inactivos";
            this.btnInactivos.TextColor = System.Drawing.Color.Gray;
            this.btnInactivos.UseVisualStyleBackColor = false;
            this.btnInactivos.Click += new System.EventHandler(this.btnInactivos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPcosto);
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.txtPunitario);
            this.groupBox2.Controls.Add(this.lblDesc);
            this.groupBox2.Controls.Add(this.lblPreUnitario);
            this.groupBox2.Controls.Add(this.lblPecioVenta);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(430, 133);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PRODUCTO";
            // 
            // lblNroProd
            // 
            this.lblNroProd.AutoSize = true;
            this.lblNroProd.Location = new System.Drawing.Point(134, 52);
            this.lblNroProd.Name = "lblNroProd";
            this.lblNroProd.Size = new System.Drawing.Size(71, 13);
            this.lblNroProd.TabIndex = 66;
            this.lblNroProd.Text = "PRODUCTO:";
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 498);
            this.Controls.Add(this.lblNroProd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnInactivos);
            this.Controls.Add(this.btnSelVta);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgProd);
            this.Controls.Add(this.groupBox1);
            this.Name = "Productos";
            this.Text = "Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Productos_FormClosing);
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridView dgProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblPecioVenta;
        private System.Windows.Forms.Label lblPreUnitario;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtPcosto;
        private System.Windows.Forms.TextBox txtPunitario;
        private System.Windows.Forms.TextBox txtDescripcion;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnNuevo;
        private CustomControls.RJControls.RJButton btnModificar;
        private CustomControls.RJControls.RJButton btnBorrar;
        private CustomControls.RJControls.RJButton btnSelVta;
        private CustomControls.RJControls.RJButton btnInactivos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNroProd;
    }
}