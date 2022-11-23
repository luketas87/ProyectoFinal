
namespace ProyectoFinal.Formularios
{
    partial class Bitacora
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkListCriticidad = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkListUsuarios = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnFiltrar = new CustomControls.RJControls.RJButton();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkListCriticidad);
            this.groupBox2.Location = new System.Drawing.Point(269, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 94);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CRITICIDAD";
            // 
            // checkListCriticidad
            // 
            this.checkListCriticidad.FormattingEnabled = true;
            this.checkListCriticidad.Items.AddRange(new object[] {
            "Baja",
            "Media",
            "Alta"});
            this.checkListCriticidad.Location = new System.Drawing.Point(12, 17);
            this.checkListCriticidad.Name = "checkListCriticidad";
            this.checkListCriticidad.Size = new System.Drawing.Size(230, 64);
            this.checkListCriticidad.TabIndex = 44;
            this.checkListCriticidad.SelectedIndexChanged += new System.EventHandler(this.checkListCriticidad_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkListUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(6, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 219);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USUARIOS";
            // 
            // checkListUsuarios
            // 
            this.checkListUsuarios.FormattingEnabled = true;
            this.checkListUsuarios.Location = new System.Drawing.Point(6, 31);
            this.checkListUsuarios.Name = "checkListUsuarios";
            this.checkListUsuarios.Size = new System.Drawing.Size(200, 169);
            this.checkListUsuarios.TabIndex = 43;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Location = new System.Drawing.Point(319, 256);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(198, 20);
            this.dateTimePicker2.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "HASTA:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(319, 216);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(198, 20);
            this.dateTimePicker1.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "DESDE:";
            // 
            // BitacoraBindingSource
            // 
            this.BitacoraBindingSource.CurrentChanged += new System.EventHandler(this.BitacoraBindingSource_CurrentChanged);
            // 
            // rpv1
            // 
            this.rpv1.AutoSize = true;
            reportDataSource1.Name = "DS_Bitacora";
            reportDataSource1.Value = null;
            this.rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv1.LocalReport.ReportEmbeddedResource = "UI.Reporte.Bitacora.rdlc";
            this.rpv1.Location = new System.Drawing.Point(6, 300);
            this.rpv1.Name = "rpv1";
            this.rpv1.ServerReport.BearerToken = null;
            this.rpv1.Size = new System.Drawing.Size(637, 311);
            this.rpv1.TabIndex = 74;
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
            this.btnVolver.Location = new System.Drawing.Point(556, 22);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(87, 36);
            this.btnVolver.TabIndex = 76;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.Gray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnFiltrar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnFiltrar.BorderColor = System.Drawing.Color.Gray;
            this.btnFiltrar.BorderRadius = 20;
            this.btnFiltrar.BorderSize = 1;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.Gray;
            this.btnFiltrar.Location = new System.Drawing.Point(171, 617);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(320, 41);
            this.btnFiltrar.TabIndex = 77;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextColor = System.Drawing.Color.Gray;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(12, 27);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(142, 17);
            this.chkTodos.TabIndex = 78;
            this.chkTodos.Text = "SELECCIONAR TODOS";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.Location = new System.Drawing.Point(269, 27);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(141, 17);
            this.chkTodas.TabIndex = 79;
            this.chkTodas.Text = "SELECCIONAR TODAS";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.chkTodas_CheckedChanged);
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 668);
            this.Controls.Add(this.chkTodas);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.rpv1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "Bitacora";
            this.Text = "Bitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bitacora_FormClosing);
            this.Load += new System.EventHandler(this.Bitacora_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkListCriticidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkListUsuarios;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource BitacoraBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rpv1;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnFiltrar;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkTodas;
    }
}