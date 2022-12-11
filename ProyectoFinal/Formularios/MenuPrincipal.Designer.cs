
namespace ProyectoFinal.Formularios
{
    partial class MenuPrincipal
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
            this.panelLogo = new System.Windows.Forms.Panel();
            this.PictureLogo = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.panelAdministradores = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnVisualizarUsuarios = new System.Windows.Forms.Button();
            this.btnFamilias = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnAdministrarUsuarios = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.panelAdmVet = new System.Windows.Forms.Panel();
            this.btnRegistrarDiagnostico = new System.Windows.Forms.Button();
            this.btnVerSolicitudes = new System.Windows.Forms.Button();
            this.btnAdmVet = new System.Windows.Forms.Button();
            this.panelSubmenuVentas = new System.Windows.Forms.Panel();
            this.btnRealizarVentas = new System.Windows.Forms.Button();
            this.btnVerVentas = new System.Windows.Forms.Button();
            this.btnAdmVentas = new System.Windows.Forms.Button();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).BeginInit();
            this.panelSideMenu.SuspendLayout();
            this.panelAdministradores.SuspendLayout();
            this.panelAdmVet.SuspendLayout();
            this.panelSubmenuVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.PictureLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 92);
            this.panelLogo.TabIndex = 0;
            // 
            // PictureLogo
            // 
            this.PictureLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureLogo.Image = global::ProyectoFinal.Properties.Resources.portada__3_;
            this.PictureLogo.Location = new System.Drawing.Point(0, 0);
            this.PictureLogo.Name = "PictureLogo";
            this.PictureLogo.Size = new System.Drawing.Size(233, 92);
            this.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureLogo.TabIndex = 0;
            this.PictureLogo.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(684, 551);
            this.panelChildForm.TabIndex = 5;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btnSalir);
            this.panelSideMenu.Controls.Add(this.btnAyuda);
            this.panelSideMenu.Controls.Add(this.panelAdministradores);
            this.panelSideMenu.Controls.Add(this.btnAdministrador);
            this.panelSideMenu.Controls.Add(this.panelAdmVet);
            this.panelSideMenu.Controls.Add(this.btnAdmVet);
            this.panelSideMenu.Controls.Add(this.panelSubmenuVentas);
            this.panelSideMenu.Controls.Add(this.btnAdmVentas);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 551);
            this.panelSideMenu.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSalir.Location = new System.Drawing.Point(0, 735);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(233, 45);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAyuda.Location = new System.Drawing.Point(0, 690);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAyuda.Size = new System.Drawing.Size(233, 45);
            this.btnAyuda.TabIndex = 7;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // panelAdministradores
            // 
            this.panelAdministradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelAdministradores.Controls.Add(this.btnActualizar);
            this.panelAdministradores.Controls.Add(this.btnRestore);
            this.panelAdministradores.Controls.Add(this.btnBackup);
            this.panelAdministradores.Controls.Add(this.btnVisualizarUsuarios);
            this.panelAdministradores.Controls.Add(this.btnFamilias);
            this.panelAdministradores.Controls.Add(this.btnBitacora);
            this.panelAdministradores.Controls.Add(this.btnAdministrarUsuarios);
            this.panelAdministradores.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdministradores.Location = new System.Drawing.Point(0, 402);
            this.panelAdministradores.Name = "panelAdministradores";
            this.panelAdministradores.Size = new System.Drawing.Size(233, 288);
            this.panelAdministradores.TabIndex = 6;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnActualizar.Location = new System.Drawing.Point(0, 240);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnActualizar.Size = new System.Drawing.Size(233, 40);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRestore.Location = new System.Drawing.Point(0, 200);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Padding = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.btnRestore.Size = new System.Drawing.Size(233, 40);
            this.btnRestore.TabIndex = 10;
            this.btnRestore.Text = "Restore";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBackup.Location = new System.Drawing.Point(0, 160);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(233, 40);
            this.btnBackup.TabIndex = 9;
            this.btnBackup.Text = "Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnVisualizarUsuarios
            // 
            this.btnVisualizarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVisualizarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnVisualizarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizarUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVisualizarUsuarios.Location = new System.Drawing.Point(0, 120);
            this.btnVisualizarUsuarios.Name = "btnVisualizarUsuarios";
            this.btnVisualizarUsuarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnVisualizarUsuarios.Size = new System.Drawing.Size(233, 40);
            this.btnVisualizarUsuarios.TabIndex = 7;
            this.btnVisualizarUsuarios.Text = "Mis Datos";
            this.btnVisualizarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualizarUsuarios.UseVisualStyleBackColor = true;
            this.btnVisualizarUsuarios.Click += new System.EventHandler(this.btnVisualizarUsuarios_Click);
            // 
            // btnFamilias
            // 
            this.btnFamilias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFamilias.FlatAppearance.BorderSize = 0;
            this.btnFamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamilias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFamilias.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFamilias.Location = new System.Drawing.Point(0, 80);
            this.btnFamilias.Name = "btnFamilias";
            this.btnFamilias.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnFamilias.Size = new System.Drawing.Size(233, 40);
            this.btnFamilias.TabIndex = 4;
            this.btnFamilias.Text = "Familias";
            this.btnFamilias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFamilias.UseVisualStyleBackColor = true;
            this.btnFamilias.Click += new System.EventHandler(this.btnFamilia_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBitacora.FlatAppearance.BorderSize = 0;
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacora.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBitacora.Location = new System.Drawing.Point(0, 40);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBitacora.Size = new System.Drawing.Size(233, 40);
            this.btnBitacora.TabIndex = 3;
            this.btnBitacora.Text = "Bitácora";
            this.btnBitacora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnAdministrarUsuarios
            // 
            this.btnAdministrarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministrarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnAdministrarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdministrarUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            this.btnAdministrarUsuarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAdministrarUsuarios.Size = new System.Drawing.Size(233, 40);
            this.btnAdministrarUsuarios.TabIndex = 2;
            this.btnAdministrarUsuarios.Text = "Administrar Usuarios";
            this.btnAdministrarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            this.btnAdministrarUsuarios.Click += new System.EventHandler(this.btnAdministrarUsuarios_Click);
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministrador.FlatAppearance.BorderSize = 0;
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrador.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdministrador.Location = new System.Drawing.Point(0, 357);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdministrador.Size = new System.Drawing.Size(233, 45);
            this.btnAdministrador.TabIndex = 5;
            this.btnAdministrador.Text = "Administradores";
            this.btnAdministrador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrador.UseVisualStyleBackColor = true;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // panelAdmVet
            // 
            this.panelAdmVet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelAdmVet.Controls.Add(this.btnRegistrarDiagnostico);
            this.panelAdmVet.Controls.Add(this.btnVerSolicitudes);
            this.panelAdmVet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdmVet.Location = new System.Drawing.Point(0, 267);
            this.panelAdmVet.Name = "panelAdmVet";
            this.panelAdmVet.Size = new System.Drawing.Size(233, 90);
            this.panelAdmVet.TabIndex = 4;
            // 
            // btnRegistrarDiagnostico
            // 
            this.btnRegistrarDiagnostico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistrarDiagnostico.FlatAppearance.BorderSize = 0;
            this.btnRegistrarDiagnostico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDiagnostico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarDiagnostico.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRegistrarDiagnostico.Location = new System.Drawing.Point(0, 40);
            this.btnRegistrarDiagnostico.Name = "btnRegistrarDiagnostico";
            this.btnRegistrarDiagnostico.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRegistrarDiagnostico.Size = new System.Drawing.Size(233, 40);
            this.btnRegistrarDiagnostico.TabIndex = 3;
            this.btnRegistrarDiagnostico.Text = "Registrar Diagnóstico";
            this.btnRegistrarDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarDiagnostico.UseVisualStyleBackColor = true;
            this.btnRegistrarDiagnostico.Click += new System.EventHandler(this.btnRegistrarDiagnostico_Click);
            // 
            // btnVerSolicitudes
            // 
            this.btnVerSolicitudes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerSolicitudes.FlatAppearance.BorderSize = 0;
            this.btnVerSolicitudes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerSolicitudes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerSolicitudes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerSolicitudes.Location = new System.Drawing.Point(0, 0);
            this.btnVerSolicitudes.Name = "btnVerSolicitudes";
            this.btnVerSolicitudes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnVerSolicitudes.Size = new System.Drawing.Size(233, 40);
            this.btnVerSolicitudes.TabIndex = 2;
            this.btnVerSolicitudes.Text = "Ver Solicitudes";
            this.btnVerSolicitudes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerSolicitudes.UseVisualStyleBackColor = true;
            this.btnVerSolicitudes.Click += new System.EventHandler(this.btnVerSolicitudes_Click);
            // 
            // btnAdmVet
            // 
            this.btnAdmVet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdmVet.FlatAppearance.BorderSize = 0;
            this.btnAdmVet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmVet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmVet.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdmVet.Location = new System.Drawing.Point(0, 222);
            this.btnAdmVet.Name = "btnAdmVet";
            this.btnAdmVet.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdmVet.Size = new System.Drawing.Size(233, 45);
            this.btnAdmVet.TabIndex = 3;
            this.btnAdmVet.Text = "Adm Veterinarios";
            this.btnAdmVet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmVet.UseVisualStyleBackColor = true;
            this.btnAdmVet.Click += new System.EventHandler(this.btnAdmVet_Click);
            // 
            // panelSubmenuVentas
            // 
            this.panelSubmenuVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelSubmenuVentas.Controls.Add(this.btnRealizarVentas);
            this.panelSubmenuVentas.Controls.Add(this.btnVerVentas);
            this.panelSubmenuVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenuVentas.Location = new System.Drawing.Point(0, 137);
            this.panelSubmenuVentas.Name = "panelSubmenuVentas";
            this.panelSubmenuVentas.Size = new System.Drawing.Size(233, 85);
            this.panelSubmenuVentas.TabIndex = 2;
            // 
            // btnRealizarVentas
            // 
            this.btnRealizarVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRealizarVentas.FlatAppearance.BorderSize = 0;
            this.btnRealizarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRealizarVentas.Location = new System.Drawing.Point(0, 40);
            this.btnRealizarVentas.Name = "btnRealizarVentas";
            this.btnRealizarVentas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnRealizarVentas.Size = new System.Drawing.Size(233, 40);
            this.btnRealizarVentas.TabIndex = 1;
            this.btnRealizarVentas.Text = "Realizar Ventas";
            this.btnRealizarVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealizarVentas.UseVisualStyleBackColor = true;
            this.btnRealizarVentas.Click += new System.EventHandler(this.btnRealizarVentas_Click);
            // 
            // btnVerVentas
            // 
            this.btnVerVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerVentas.FlatAppearance.BorderSize = 0;
            this.btnVerVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerVentas.Location = new System.Drawing.Point(0, 0);
            this.btnVerVentas.Name = "btnVerVentas";
            this.btnVerVentas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnVerVentas.Size = new System.Drawing.Size(233, 40);
            this.btnVerVentas.TabIndex = 0;
            this.btnVerVentas.Text = "Ver Ventas";
            this.btnVerVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerVentas.UseVisualStyleBackColor = true;
            this.btnVerVentas.Click += new System.EventHandler(this.btnVerVentas_Click);
            // 
            // btnAdmVentas
            // 
            this.btnAdmVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdmVentas.FlatAppearance.BorderSize = 0;
            this.btnAdmVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdmVentas.Location = new System.Drawing.Point(0, 92);
            this.btnAdmVentas.Name = "btnAdmVentas";
            this.btnAdmVentas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdmVentas.Size = new System.Drawing.Size(233, 45);
            this.btnAdmVentas.TabIndex = 1;
            this.btnAdmVentas.Text = "Ventas";
            this.btnAdmVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmVentas.UseVisualStyleBackColor = true;
            this.btnAdmVentas.Click += new System.EventHandler(this.btnAdmVentas_Click);
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(0, 551);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(934, 10);
            this.panelPlayer.TabIndex = 4;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelPlayer);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ayuda_KeyDown);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).EndInit();
            this.panelSideMenu.ResumeLayout(false);
            this.panelAdministradores.ResumeLayout(false);
            this.panelAdmVet.ResumeLayout(false);
            this.panelSubmenuVentas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureLogo;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelSubmenuVentas;
        private System.Windows.Forms.Button btnRealizarVentas;
        private System.Windows.Forms.Button btnVerVentas;
        private System.Windows.Forms.Button btnAdmVentas;
        private System.Windows.Forms.Panel panelAdmVet;
        private System.Windows.Forms.Button btnRegistrarDiagnostico;
        private System.Windows.Forms.Button btnVerSolicitudes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Panel panelAdministradores;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnAdministrarUsuarios;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Button btnAdmVet;
        private System.Windows.Forms.Button btnVisualizarUsuarios;
        private System.Windows.Forms.Button btnFamilias;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnActualizar;
    }
}