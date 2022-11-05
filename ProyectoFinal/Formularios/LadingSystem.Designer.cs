
namespace ProyectoFinal.Formularios
{
    partial class LadingSystem
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIniciar = new CustomControls.RJControls.RJButton();
            this.btnSalir = new CustomControls.RJControls.RJButton();
            this.btnConfigBD = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoFinal.Properties.Resources.veterinariaPatitas;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.SystemColors.Control;
            this.btnIniciar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnIniciar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciar.BorderRadius = 20;
            this.btnIniciar.BorderSize = 1;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciar.Location = new System.Drawing.Point(12, 23);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(61, 22);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BorderColor = System.Drawing.Color.Crimson;
            this.btnSalir.BorderRadius = 20;
            this.btnSalir.BorderSize = 1;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Crimson;
            this.btnSalir.Location = new System.Drawing.Point(364, 182);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(61, 22);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextColor = System.Drawing.Color.Crimson;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConfigBD
            // 
            this.btnConfigBD.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfigBD.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnConfigBD.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConfigBD.BorderRadius = 20;
            this.btnConfigBD.BorderSize = 1;
            this.btnConfigBD.FlatAppearance.BorderSize = 0;
            this.btnConfigBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigBD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnConfigBD.Location = new System.Drawing.Point(358, 23);
            this.btnConfigBD.Name = "btnConfigBD";
            this.btnConfigBD.Size = new System.Drawing.Size(67, 22);
            this.btnConfigBD.TabIndex = 2;
            this.btnConfigBD.Text = "Config. BD";
            this.btnConfigBD.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnConfigBD.UseVisualStyleBackColor = false;
            this.btnConfigBD.Click += new System.EventHandler(this.btnConfigBD_Click);
            // 
            // LadingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 216);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfigBD);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LadingSystem";
            this.Text = ":::INICIO:::";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton btnIniciar;
        private CustomControls.RJControls.RJButton btnSalir;
        private CustomControls.RJControls.RJButton btnConfigBD;
    }
}