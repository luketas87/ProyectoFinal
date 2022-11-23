
namespace ProyectoFinal.Formularios
{
    partial class Familias
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
            this.chklstFamilias = new System.Windows.Forms.CheckedListBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnVolver = new CustomControls.RJControls.RJButton();
            this.btnModificarTodo = new CustomControls.RJControls.RJButton();
            this.btnModificar = new CustomControls.RJControls.RJButton();
            this.btnNueva = new CustomControls.RJControls.RJButton();
            this.btnBajaPatente = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // chklstFamilias
            // 
            this.chklstFamilias.FormattingEnabled = true;
            this.chklstFamilias.Location = new System.Drawing.Point(11, 55);
            this.chklstFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.chklstFamilias.Name = "chklstFamilias";
            this.chklstFamilias.Size = new System.Drawing.Size(141, 169);
            this.chklstFamilias.TabIndex = 11;
            this.chklstFamilias.SelectedIndexChanged += new System.EventHandler(this.chklstFamilias_SelectedIndexChanged);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(25, 149);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 40);
            this.btnBaja.TabIndex = 10;
            this.btnBaja.Text = "BAJAS";
            this.btnBaja.UseVisualStyleBackColor = true;
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
            this.btnVolver.TabIndex = 74;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.LightSlateGray;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificarTodo
            // 
            this.btnModificarTodo.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificarTodo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnModificarTodo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificarTodo.BorderRadius = 20;
            this.btnModificarTodo.BorderSize = 1;
            this.btnModificarTodo.FlatAppearance.BorderSize = 0;
            this.btnModificarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificarTodo.Location = new System.Drawing.Point(176, 144);
            this.btnModificarTodo.Name = "btnModificarTodo";
            this.btnModificarTodo.Size = new System.Drawing.Size(129, 35);
            this.btnModificarTodo.TabIndex = 77;
            this.btnModificarTodo.Text = "Modificar Patentes";
            this.btnModificarTodo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificarTodo.UseVisualStyleBackColor = false;
            this.btnModificarTodo.Click += new System.EventHandler(this.btnModificarTodo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnModificar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.BorderRadius = 20;
            this.btnModificar.BorderSize = 1;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.Location = new System.Drawing.Point(176, 101);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(129, 35);
            this.btnModificar.TabIndex = 76;
            this.btnModificar.Text = "Modificar Nombre";
            this.btnModificar.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.BackColor = System.Drawing.SystemColors.Control;
            this.btnNueva.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnNueva.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnNueva.BorderRadius = 20;
            this.btnNueva.BorderSize = 1;
            this.btnNueva.FlatAppearance.BorderSize = 0;
            this.btnNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueva.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnNueva.Location = new System.Drawing.Point(176, 58);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(129, 35);
            this.btnNueva.TabIndex = 75;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.TextColor = System.Drawing.Color.ForestGreen;
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnBajaPatente
            // 
            this.btnBajaPatente.BackColor = System.Drawing.SystemColors.Control;
            this.btnBajaPatente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnBajaPatente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajaPatente.BorderRadius = 20;
            this.btnBajaPatente.BorderSize = 1;
            this.btnBajaPatente.FlatAppearance.BorderSize = 0;
            this.btnBajaPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaPatente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajaPatente.Location = new System.Drawing.Point(176, 187);
            this.btnBajaPatente.Name = "btnBajaPatente";
            this.btnBajaPatente.Size = new System.Drawing.Size(129, 35);
            this.btnBajaPatente.TabIndex = 78;
            this.btnBajaPatente.Text = "Baja";
            this.btnBajaPatente.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajaPatente.UseVisualStyleBackColor = false;
            this.btnBajaPatente.Click += new System.EventHandler(this.btnBajaPatente_Click);
            // 
            // Familias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 236);
            this.Controls.Add(this.btnBajaPatente);
            this.Controls.Add(this.btnModificarTodo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.chklstFamilias);
            this.Controls.Add(this.btnBaja);
            this.Name = "Familias";
            this.Text = "Familias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Familias_FormClosing);
            this.Load += new System.EventHandler(this.Familias_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chklstFamilias;
        private System.Windows.Forms.Button btnBaja;
        private CustomControls.RJControls.RJButton btnVolver;
        private CustomControls.RJControls.RJButton btnModificarTodo;
        private CustomControls.RJControls.RJButton btnModificar;
        private CustomControls.RJControls.RJButton btnNueva;
        private CustomControls.RJControls.RJButton btnBajaPatente;
    }
}