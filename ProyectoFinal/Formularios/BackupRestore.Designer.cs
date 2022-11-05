
namespace ProyectoFinal.Formularios
{
    partial class BackupRestore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxRestore = new System.Windows.Forms.PictureBox();
            this.pictureBoxBackup = new System.Windows.Forms.PictureBox();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 20);
            this.panel1.TabIndex = 3;
            // 
            // pictureBoxRestore
            // 
            this.pictureBoxRestore.Image = global::ProyectoFinal.Properties.Resources.icons8_database_daily_import_80;
            this.pictureBoxRestore.Location = new System.Drawing.Point(222, 12);
            this.pictureBoxRestore.Name = "pictureBoxRestore";
            this.pictureBoxRestore.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxRestore.TabIndex = 5;
            this.pictureBoxRestore.TabStop = false;
            this.pictureBoxRestore.Click += new System.EventHandler(this.pictureBoxRestore_Click);
            // 
            // pictureBoxBackup
            // 
            this.pictureBoxBackup.Image = global::ProyectoFinal.Properties.Resources.icons8_exportación_de_base_de_datos_80;
            this.pictureBoxBackup.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxBackup.Name = "pictureBoxBackup";
            this.pictureBoxBackup.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxBackup.TabIndex = 4;
            this.pictureBoxBackup.TabStop = false;
            this.pictureBoxBackup.Click += new System.EventHandler(this.pictureBoxBackup_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnVolver.BorderColor = System.Drawing.Color.Red;
            this.btnVolver.BorderRadius = 21;
            this.btnVolver.BorderSize = 1;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Red;
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolver.Location = new System.Drawing.Point(116, 120);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(81, 37);
            this.btnVolver.TabIndex = 59;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Red;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // BackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(328, 183);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.pictureBoxRestore);
            this.Controls.Add(this.pictureBoxBackup);
            this.Controls.Add(this.panel1);
            this.Name = "BackupRestore";
            this.Text = "BackupRestore";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxBackup;
        private System.Windows.Forms.PictureBox pictureBoxRestore;
        private CustomControls.RJControls.RJButton btnVolver;
    }
}