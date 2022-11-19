
namespace ProyectoFinal.Formularios
{
    partial class AdminFamiliaUsuario
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FamUsuario = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FamSistema = new System.Windows.Forms.ListBox();
            this.btnQuitar = new CustomControls.RJControls.RJButton();
            this.btnAsignar = new CustomControls.RJControls.RJButton();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(129, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 13);
            this.lblUsuario.TabIndex = 66;
            this.lblUsuario.Text = "USUARIO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FamUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 200);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FAMILIAS USUARIO";
            // 
            // FamUsuario
            // 
            this.FamUsuario.FormattingEnabled = true;
            this.FamUsuario.Location = new System.Drawing.Point(7, 19);
            this.FamUsuario.Name = "FamUsuario";
            this.FamUsuario.Size = new System.Drawing.Size(163, 173);
            this.FamUsuario.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FamSistema);
            this.groupBox2.Location = new System.Drawing.Point(219, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 200);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FAMILIAS SISTEMA";
            // 
            // FamSistema
            // 
            this.FamSistema.FormattingEnabled = true;
            this.FamSistema.Location = new System.Drawing.Point(7, 20);
            this.FamSistema.Name = "FamSistema";
            this.FamSistema.Size = new System.Drawing.Size(163, 173);
            this.FamSistema.TabIndex = 1;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnQuitar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitar.BorderRadius = 20;
            this.btnQuitar.BorderSize = 1;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitar.Location = new System.Drawing.Point(19, 262);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(95, 41);
            this.btnQuitar.TabIndex = 71;
            this.btnQuitar.Text = "Quitar Familia";
            this.btnQuitar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAsignar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnAsignar.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnAsignar.BorderRadius = 20;
            this.btnAsignar.BorderSize = 1;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnAsignar.Location = new System.Drawing.Point(294, 263);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(95, 41);
            this.btnAsignar.TabIndex = 72;
            this.btnAsignar.Text = "Asignar Familia";
            this.btnAsignar.TextColor = System.Drawing.Color.ForestGreen;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.BorderRadius = 20;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.Gray;
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(62, 24);
            this.btnVolver.TabIndex = 73;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Gray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // AdminFamiliaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 327);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AdminFamiliaUsuario";
            this.Text = "Administrar Familias";
            this.Load += new System.EventHandler(this.AdminFamiliaUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox FamUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox FamSistema;
        private CustomControls.RJControls.RJButton btnQuitar;
        private CustomControls.RJControls.RJButton btnAsignar;
        private CustomControls.RJControls.RJButton btnVolver;
    }
}