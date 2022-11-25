namespace ProyectoFinal
{
    partial class ReseteoContraseña
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
            this.TituloBar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PicCerrar = new System.Windows.Forms.PictureBox();
            this.PicMinimizar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new CustomControls.RJControls.RJButton();
            this.btnCancelar = new CustomControls.RJControls.RJButton();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TituloBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // TituloBar
            // 
            this.TituloBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.TituloBar.Controls.Add(this.label4);
            this.TituloBar.Controls.Add(this.PicCerrar);
            this.TituloBar.Controls.Add(this.PicMinimizar);
            this.TituloBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TituloBar.Location = new System.Drawing.Point(0, 0);
            this.TituloBar.Name = "TituloBar";
            this.TituloBar.Size = new System.Drawing.Size(392, 25);
            this.TituloBar.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Reseteo de contraseña..";
            // 
            // PicCerrar
            // 
            this.PicCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicCerrar.Image = global::ProyectoFinal.Properties.Resources.icons8_close_window_16;
            this.PicCerrar.Location = new System.Drawing.Point(366, 0);
            this.PicCerrar.Name = "PicCerrar";
            this.PicCerrar.Size = new System.Drawing.Size(16, 16);
            this.PicCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicCerrar.TabIndex = 1;
            this.PicCerrar.TabStop = false;
            // 
            // PicMinimizar
            // 
            this.PicMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicMinimizar.Image = global::ProyectoFinal.Properties.Resources.icons8_subtract_16;
            this.PicMinimizar.Location = new System.Drawing.Point(348, 0);
            this.PicMinimizar.Name = "PicMinimizar";
            this.PicMinimizar.Size = new System.Drawing.Size(16, 16);
            this.PicMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicMinimizar.TabIndex = 0;
            this.PicMinimizar.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ingrese su email:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAceptar.BorderRadius = 20;
            this.btnAceptar.BorderSize = 1;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAceptar.Location = new System.Drawing.Point(10, 167);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 31);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.BorderRadius = 20;
            this.btnCancelar.BorderSize = 1;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Location = new System.Drawing.Point(234, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 31);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.Color.White;
            this.TxtEmail.Location = new System.Drawing.Point(9, 108);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(350, 20);
            this.TxtEmail.TabIndex = 74;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 235);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 15);
            this.panel1.TabIndex = 75;
            // 
            // ReseteoContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(392, 250);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TituloBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReseteoContraseña";
            this.Opacity = 0.85D;
            this.Text = "ResetPassword";
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.TituloBar.ResumeLayout(false);
            this.TituloBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel TituloBar;
        private System.Windows.Forms.PictureBox PicCerrar;
        private System.Windows.Forms.PictureBox PicMinimizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private CustomControls.RJControls.RJButton btnAceptar;
        private CustomControls.RJControls.RJButton btnCancelar;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Panel panel1;
    }
}