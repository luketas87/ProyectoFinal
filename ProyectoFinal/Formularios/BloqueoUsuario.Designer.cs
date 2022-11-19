
namespace ProyectoFinal.Formularios
{
    partial class BloqueoUsuario
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
            this.btnDesactivar = new CustomControls.RJControls.RJButton();
            this.btnActivar = new CustomControls.RJControls.RJButton();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.lstInactivos = new System.Windows.Forms.ListBox();
            this.lstActivos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnDesactivar.Location = new System.Drawing.Point(334, 266);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(95, 41);
            this.btnDesactivar.TabIndex = 86;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.TextColor = System.Drawing.Color.Crimson;
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
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
            this.btnActivar.Location = new System.Drawing.Point(334, 82);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(95, 41);
            this.btnActivar.TabIndex = 85;
            this.btnActivar.Text = "Activar";
            this.btnActivar.TextColor = System.Drawing.Color.ForestGreen;
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
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
            this.btnVolver.Location = new System.Drawing.Point(12, 11);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(62, 26);
            this.btnVolver.TabIndex = 84;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Gray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lstInactivos
            // 
            this.lstInactivos.FormattingEnabled = true;
            this.lstInactivos.Location = new System.Drawing.Point(447, 82);
            this.lstInactivos.Name = "lstInactivos";
            this.lstInactivos.Size = new System.Drawing.Size(305, 225);
            this.lstInactivos.TabIndex = 83;
            // 
            // lstActivos
            // 
            this.lstActivos.FormattingEnabled = true;
            this.lstActivos.Location = new System.Drawing.Point(12, 82);
            this.lstActivos.Name = "lstActivos";
            this.lstActivos.Size = new System.Drawing.Size(305, 225);
            this.lstActivos.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "USUARIOS INACTIVOS:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActivos
            // 
            this.lblActivos.AutoSize = true;
            this.lblActivos.Location = new System.Drawing.Point(73, 62);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(115, 13);
            this.lblActivos.TabIndex = 80;
            this.lblActivos.Text = "USUARIOS ACTIVOS:";
            this.lblActivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BloqueoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 329);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lstInactivos);
            this.Controls.Add(this.lstActivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblActivos);
            this.Name = "BloqueoUsuario";
            this.Text = "BloqueoUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BloqueoUsuario_FormClosing);
            this.Load += new System.EventHandler(this.BloqueoUsuario_Load);
            this.Enter += new System.EventHandler(this.BloqueoUsuario_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJButton btnDesactivar;
        private CustomControls.RJControls.RJButton btnActivar;
        private CustomControls.RJControls.RJButton btnVolver;
        private System.Windows.Forms.ListBox lstInactivos;
        private System.Windows.Forms.ListBox lstActivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActivos;
    }
}