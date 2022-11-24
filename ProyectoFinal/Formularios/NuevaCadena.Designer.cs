
namespace ProyectoFinal
{
    partial class NuevaCadena
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
            this.txtDatasource = new System.Windows.Forms.TextBox();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new CustomControls.RJControls.RJButton();
            this.btnCancelar = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // txtDatasource
            // 
            this.txtDatasource.Location = new System.Drawing.Point(86, 52);
            this.txtDatasource.Name = "txtDatasource";
            this.txtDatasource.Size = new System.Drawing.Size(159, 20);
            this.txtDatasource.TabIndex = 0;
            this.txtDatasource.Text = "LUKETAS";
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(86, 91);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(159, 20);
            this.txtInitialCatalog.TabIndex = 1;
            this.txtInitialCatalog.Text = "VeterinariaPatitas";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(86, 132);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(159, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "sa";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(159, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Patitas2022";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datsource:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "InitialCatalog:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnAceptar.BorderRadius = 24;
            this.btnAceptar.BorderSize = 1;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnAceptar.Location = new System.Drawing.Point(167, 236);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 30);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextColor = System.Drawing.Color.LimeGreen;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BorderColor = System.Drawing.Color.Crimson;
            this.btnCancelar.BorderRadius = 24;
            this.btnCancelar.BorderSize = 1;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Crimson;
            this.btnCancelar.Location = new System.Drawing.Point(16, 236);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 30);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.Crimson;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // NuevaCadena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 295);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtInitialCatalog);
            this.Controls.Add(this.txtDatasource);
            this.Name = "NuevaCadena";
            this.Text = "Nueva Caadena de conexion";
            this.Load += new System.EventHandler(this.NuevaCadena_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDatasource;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.RJControls.RJButton btnCancelar;
        private CustomControls.RJControls.RJButton btnAceptar;
    }
}