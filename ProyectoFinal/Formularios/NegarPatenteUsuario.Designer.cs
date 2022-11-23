
namespace ProyectoFinal.Formularios
{
    partial class NegarPatenteUsuario
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
            this.PatHabilitadas = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PatNegadas = new System.Windows.Forms.ListBox();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnNegar = new CustomControls.RJControls.RJButton();
            this.btnHabilitar = new CustomControls.RJControls.RJButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(22, 57);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 13);
            this.lblUsuario.TabIndex = 66;
            this.lblUsuario.Text = "USUARIO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatHabilitadas);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 200);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patentes Habilitadas";
            // 
            // PatHabilitadas
            // 
            this.PatHabilitadas.FormattingEnabled = true;
            this.PatHabilitadas.Location = new System.Drawing.Point(7, 19);
            this.PatHabilitadas.Name = "PatHabilitadas";
            this.PatHabilitadas.Size = new System.Drawing.Size(163, 173);
            this.PatHabilitadas.TabIndex = 0;
            this.PatHabilitadas.SelectedIndexChanged += new System.EventHandler(this.PatHabilitadas_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PatNegadas);
            this.groupBox2.Location = new System.Drawing.Point(211, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 200);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patentes Negadas";
            // 
            // PatNegadas
            // 
            this.PatNegadas.FormattingEnabled = true;
            this.PatNegadas.Location = new System.Drawing.Point(6, 21);
            this.PatNegadas.Name = "PatNegadas";
            this.PatNegadas.Size = new System.Drawing.Size(163, 173);
            this.PatNegadas.TabIndex = 1;
            this.PatNegadas.SelectedIndexChanged += new System.EventHandler(this.PatNegadas_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnVolver.BorderRadius = 20;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.LightSlateGray;
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(64, 30);
            this.btnVolver.TabIndex = 75;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.LightSlateGray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnNegar
            // 
            this.btnNegar.BackColor = System.Drawing.SystemColors.Control;
            this.btnNegar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnNegar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNegar.BorderRadius = 20;
            this.btnNegar.BorderSize = 1;
            this.btnNegar.FlatAppearance.BorderSize = 0;
            this.btnNegar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNegar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNegar.Location = new System.Drawing.Point(233, 289);
            this.btnNegar.Name = "btnNegar";
            this.btnNegar.Size = new System.Drawing.Size(129, 35);
            this.btnNegar.TabIndex = 80;
            this.btnNegar.Text = "Negar Patente";
            this.btnNegar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNegar.UseVisualStyleBackColor = false;
            this.btnNegar.Click += new System.EventHandler(this.btnNegar_Click);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackColor = System.Drawing.SystemColors.Control;
            this.btnHabilitar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnHabilitar.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnHabilitar.BorderRadius = 20;
            this.btnHabilitar.BorderSize = 1;
            this.btnHabilitar.FlatAppearance.BorderSize = 0;
            this.btnHabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnHabilitar.Location = new System.Drawing.Point(25, 289);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(129, 35);
            this.btnHabilitar.TabIndex = 79;
            this.btnHabilitar.Text = "Habilitar Patente";
            this.btnHabilitar.TextColor = System.Drawing.Color.ForestGreen;
            this.btnHabilitar.UseVisualStyleBackColor = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // NegarPatenteUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 342);
            this.Controls.Add(this.btnNegar);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "NegarPatenteUsuario";
            this.Text = "NegarPatenteUsuario";
            this.Load += new System.EventHandler(this.NegarPatenteUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox PatHabilitadas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox PatNegadas;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnNegar;
        private CustomControls.RJControls.RJButton btnHabilitar;
    }
}