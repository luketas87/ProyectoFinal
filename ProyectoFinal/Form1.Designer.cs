namespace ProyectoFinal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TituloBar = new System.Windows.Forms.Panel();
            this.PicCerrar = new System.Windows.Forms.PictureBox();
            this.PicMinimizar = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtContraseña = new System.Windows.Forms.TextBox();
            this.lblRecordar = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TituloBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TituloBar
            // 
            this.TituloBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.TituloBar.Controls.Add(this.PicCerrar);
            this.TituloBar.Controls.Add(this.PicMinimizar);
            this.TituloBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TituloBar.Location = new System.Drawing.Point(0, 0);
            this.TituloBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TituloBar.Name = "TituloBar";
            this.TituloBar.Size = new System.Drawing.Size(494, 37);
            this.TituloBar.TabIndex = 0;
            this.TituloBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TituloBar_MouseMove);
            // 
            // PicCerrar
            // 
            this.PicCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicCerrar.Image = global::ProyectoFinal.Properties.Resources.icons8_close_window_16;
            this.PicCerrar.Location = new System.Drawing.Point(463, 0);
            this.PicCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicCerrar.Name = "PicCerrar";
            this.PicCerrar.Size = new System.Drawing.Size(16, 16);
            this.PicCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicCerrar.TabIndex = 1;
            this.PicCerrar.TabStop = false;
            this.PicCerrar.Click += new System.EventHandler(this.PicCerrar_Click);
            // 
            // PicMinimizar
            // 
            this.PicMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicMinimizar.Image = global::ProyectoFinal.Properties.Resources.icons8_subtract_16;
            this.PicMinimizar.Location = new System.Drawing.Point(437, 0);
            this.PicMinimizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicMinimizar.Name = "PicMinimizar";
            this.PicMinimizar.Size = new System.Drawing.Size(16, 16);
            this.PicMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicMinimizar.TabIndex = 0;
            this.PicMinimizar.TabStop = false;
            this.PicMinimizar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 758);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(494, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseMove);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.White;
            this.TxtUsuario.Location = new System.Drawing.Point(16, 235);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(467, 25);
            this.TxtUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(11, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(13, 304);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.TxtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtContraseña.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseña.ForeColor = System.Drawing.Color.White;
            this.TxtContraseña.Location = new System.Drawing.Point(19, 334);
            this.TxtContraseña.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.PasswordChar = '*';
            this.TxtContraseña.Size = new System.Drawing.Size(467, 25);
            this.TxtContraseña.TabIndex = 3;
            // 
            // lblRecordar
            // 
            this.lblRecordar.AutoSize = true;
            this.lblRecordar.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblRecordar.ForeColor = System.Drawing.Color.DarkGray;
            this.lblRecordar.Location = new System.Drawing.Point(21, 384);
            this.lblRecordar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRecordar.Name = "lblRecordar";
            this.lblRecordar.Size = new System.Drawing.Size(172, 25);
            this.lblRecordar.TabIndex = 5;
            this.lblRecordar.Text = "Recordar usuario";
            this.lblRecordar.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(87, 436);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(336, 44);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(105, 688);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "No recuerda la contraseña?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoFinal.Properties.Resources.portada__3_;
            this.pictureBox1.Location = new System.Drawing.Point(161, 58);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(494, 783);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblRecordar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.TituloBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.Text = "Form1";
            this.TituloBar.ResumeLayout(false);
            this.TituloBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TituloBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox PicMinimizar;
        private System.Windows.Forms.PictureBox PicCerrar;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtContraseña;
        private System.Windows.Forms.CheckBox lblRecordar;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

