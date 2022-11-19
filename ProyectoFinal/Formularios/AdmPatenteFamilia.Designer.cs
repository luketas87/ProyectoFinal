
namespace ProyectoFinal.Formularios
{
    partial class AdmPatenteFamilia
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
            this.lblFamilia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPatentes = new System.Windows.Forms.CheckedListBox();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnModificar = new CustomControls.RJControls.RJButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(117, 24);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(51, 13);
            this.lblFamilia.TabIndex = 61;
            this.lblFamilia.Text = "FAMILIA:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPatentes);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 152);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PATENTES";
            // 
            // lstPatentes
            // 
            this.lstPatentes.FormattingEnabled = true;
            this.lstPatentes.Location = new System.Drawing.Point(15, 19);
            this.lstPatentes.Name = "lstPatentes";
            this.lstPatentes.Size = new System.Drawing.Size(252, 124);
            this.lstPatentes.TabIndex = 55;
            this.lstPatentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstPatentes_ItemCheck);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.BorderRadius = 32;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(74, 32);
            this.btnVolver.TabIndex = 64;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificar.BorderRadius = 32;
            this.btnModificar.BorderSize = 1;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificar.Location = new System.Drawing.Point(120, 209);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(74, 32);
            this.btnModificar.TabIndex = 65;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnModificar.Enter += new System.EventHandler(this.btnModificar_Enter);
            // 
            // AdmPatenteFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 255);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdmPatenteFamilia";
            this.Text = "AdmPatenteFamilia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdmPatenteFamilia_FormClosing);
            this.Load += new System.EventHandler(this.AdmPatenteFamilia_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstPatentes;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnModificar;
    }
}