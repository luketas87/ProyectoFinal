
namespace ProyectoFinal.Formularios
{
    partial class Restore
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtBackFiles = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.btnRestaurar = new CustomControls.RJControls.RJButton();
            this.btnExaminar = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 177);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 13);
            this.lblStatus.TabIndex = 65;
            this.lblStatus.Text = "ESTADO:";
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Location = new System.Drawing.Point(304, 179);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(21, 13);
            this.lblProgreso.TabIndex = 64;
            this.lblProgreso.Text = "0%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(63, 171);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 26);
            this.progressBar1.TabIndex = 63;
            // 
            // txtBackFiles
            // 
            this.txtBackFiles.Enabled = false;
            this.txtBackFiles.Location = new System.Drawing.Point(12, 65);
            this.txtBackFiles.Multiline = true;
            this.txtBackFiles.Name = "txtBackFiles";
            this.txtBackFiles.Size = new System.Drawing.Size(291, 95);
            this.txtBackFiles.TabIndex = 62;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(197, 13);
            this.Label1.TabIndex = 59;
            this.Label1.Text = "SELECCIONE COPIA DE SEGURIDAD:";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.SystemColors.Control;
            this.rjButton1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rjButton1.BorderColor = System.Drawing.Color.Red;
            this.rjButton1.BorderRadius = 40;
            this.rjButton1.BorderSize = 1;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.Red;
            this.rjButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rjButton1.Location = new System.Drawing.Point(3, 210);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(118, 40);
            this.rjButton1.TabIndex = 67;
            this.rjButton1.Text = "Volver";
            this.rjButton1.TextColor = System.Drawing.Color.Red;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.SystemColors.Control;
            this.btnRestaurar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnRestaurar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRestaurar.BorderRadius = 40;
            this.btnRestaurar.BorderSize = 1;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRestaurar.Location = new System.Drawing.Point(161, 210);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(118, 40);
            this.btnRestaurar.TabIndex = 68;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExaminar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnExaminar.BorderColor = System.Drawing.Color.Navy;
            this.btnExaminar.BorderRadius = 32;
            this.btnExaminar.BorderSize = 1;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExaminar.Location = new System.Drawing.Point(236, 21);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(67, 32);
            this.btnExaminar.TabIndex = 69;
            this.btnExaminar.Text = "...";
            this.btnExaminar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 273);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtBackFiles);
            this.Controls.Add(this.Label1);
            this.Name = "Restore";
            this.Text = "Restore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtBackFiles;
        internal System.Windows.Forms.Label Label1;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJButton btnRestaurar;
        private CustomControls.RJControls.RJButton btnExaminar;
    }
}