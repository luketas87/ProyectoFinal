
namespace ProyectoFinal.Formularios
{
    partial class BloqueoProductos
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
            this.lstInactivos = new System.Windows.Forms.ListBox();
            this.lstActivos = new System.Windows.Forms.ListBox();
            this.lblInactivos = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnActivar = new CustomControls.RJControls.RJButton();
            this.btnDesactivar = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // lstInactivos
            // 
            this.lstInactivos.FormattingEnabled = true;
            this.lstInactivos.Location = new System.Drawing.Point(447, 83);
            this.lstInactivos.Name = "lstInactivos";
            this.lstInactivos.Size = new System.Drawing.Size(305, 225);
            this.lstInactivos.TabIndex = 11;
            // 
            // lstActivos
            // 
            this.lstActivos.FormattingEnabled = true;
            this.lstActivos.Location = new System.Drawing.Point(12, 83);
            this.lstActivos.Name = "lstActivos";
            this.lstActivos.Size = new System.Drawing.Size(305, 225);
            this.lstActivos.TabIndex = 10;
            this.lstActivos.SelectedIndexChanged += new System.EventHandler(this.lstActivos_SelectedIndexChanged);
            // 
            // lblInactivos
            // 
            this.lblInactivos.AutoSize = true;
            this.lblInactivos.Location = new System.Drawing.Point(524, 63);
            this.lblInactivos.Name = "lblInactivos";
            this.lblInactivos.Size = new System.Drawing.Size(138, 13);
            this.lblInactivos.TabIndex = 9;
            this.lblInactivos.Text = "PRODUCTOS INACTIVOS:";
            this.lblInactivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActivos
            // 
            this.lblActivos.AutoSize = true;
            this.lblActivos.Location = new System.Drawing.Point(73, 63);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(127, 13);
            this.lblActivos.TabIndex = 8;
            this.lblActivos.Text = "PRODUCTOS ACTIVOS:";
            this.lblActivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.Gray;
            this.btnVolver.BorderRadius = 20;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.Gray;
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(62, 26);
            this.btnVolver.TabIndex = 77;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Gray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActivar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnActivar.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnActivar.BorderRadius = 20;
            this.btnActivar.BorderSize = 1;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnActivar.Location = new System.Drawing.Point(334, 83);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(95, 41);
            this.btnActivar.TabIndex = 78;
            this.btnActivar.Text = "Activar";
            this.btnActivar.TextColor = System.Drawing.Color.ForestGreen;
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackColor = System.Drawing.SystemColors.Control;
            this.btnDesactivar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnDesactivar.BorderColor = System.Drawing.Color.Crimson;
            this.btnDesactivar.BorderRadius = 20;
            this.btnDesactivar.BorderSize = 1;
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesactivar.ForeColor = System.Drawing.Color.Crimson;
            this.btnDesactivar.Location = new System.Drawing.Point(334, 267);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(95, 41);
            this.btnDesactivar.TabIndex = 79;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.TextColor = System.Drawing.Color.Crimson;
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // BloqueoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 331);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstInactivos);
            this.Controls.Add(this.lstActivos);
            this.Controls.Add(this.lblInactivos);
            this.Controls.Add(this.lblActivos);
            this.Name = "BloqueoProductos";
            this.Text = "BloqueoProductos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BloqueoProductos_FormClosing);
            this.Load += new System.EventHandler(this.BloqueoProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstInactivos;
        private System.Windows.Forms.ListBox lstActivos;
        private System.Windows.Forms.Label lblInactivos;
        private System.Windows.Forms.Label lblActivos;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnActivar;
        private CustomControls.RJControls.RJButton btnDesactivar;
    }
}