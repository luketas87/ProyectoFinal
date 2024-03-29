﻿using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace ProyectoFinal.Formularios
{
    public partial class MenuPrimcipal : Form, IPrimcipal
    {
        private readonly IFormControl formControl;
        private readonly DALICuentaUsuario usuarioDAL;
        private readonly IDetalleVenta ventaDeProductos;
        private readonly IABMUsers abmUsuario;
        private readonly IBitacora bitacora;
        private readonly IFamilias familias;
        private readonly BLLIFamilia familiaBLL;
        private readonly IDatosUsuario datosUsuario;
        private readonly IBackup backup;
        private readonly IRestore restore;
        private readonly IProductos productos;
        private readonly IVenta venta;
        private readonly BLLIIdioma idiomaBLL;

        public MenuPrimcipal(DALICuentaUsuario usuarioDAL,
            IDetalleVenta ventaDeProductos,
            IABMUsers abmUsuario,
            IBitacora bitacora,
            IFormControl formControl,
            IFamilias familias,
            BLLIIdioma idiomaBLL,
            BLLIFamilia familiaBLL,
            IDatosUsuario datosUsuario,
            IBackup backup,
            IRestore restore,
            IProductos productos,
            IVenta venta)
        {
            InitializeComponent();
            this.formControl = formControl;
            this.usuarioDAL = usuarioDAL;
            this.ventaDeProductos = ventaDeProductos;
            this.abmUsuario = abmUsuario;
            this.bitacora = bitacora;
            this.familias = familias;
            this.familiaBLL = familiaBLL;
            this.datosUsuario = datosUsuario;
            this.backup = backup;
            this.restore = restore;
            this.productos = productos;
            this.venta = venta;

            custimizeDesign();
        }

        private void custimizeDesign()
        {
            panelSubmenuVentas.Visible = false;
            panelAdmVet.Visible = false;
            panelAdministradores.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelSubmenuVentas.Visible == true)
            {
                panelSubmenuVentas.Visible = false;
            }

            if (panelAdmVet.Visible == false)
            {
                panelAdmVet.Visible = false;
            }

            if (panelAdministradores.Visible == true)
            {
                panelAdministradores.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }

        public BECuentaUsuario mCuentausuario;
        public int mIdioma;

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //lista de permisos formularios y usuario
            var patForm = formControl.ObtenerPermisosFormularios();

            var patUsu = formControl.ObtenerPermisosUsuario();

            //Bloquear Toolstrip por patente.
            if (!patUsu.Patentes.Any(x => x.Descripcion == "ABMFamilia"))
            {
                btnFamilias.Enabled = false;
                familias.MdiParent = this;
                familias.Show();

            }
            if (!patUsu.Patentes.Any(x => x.Descripcion == "ABMusuario"))
            {
                btnAdministrarUsuarios.Enabled = false;

            }
            if (!patUsu.Patentes.Any(x => x.Descripcion == "Bitacora"))
            {
                btnBitacora.Enabled = false;

            }
            if (!patUsu.Patentes.Any(x => x.Descripcion == "Backup"))
            {
                btnBackup.Enabled = false;

            }

            if (!patUsu.Patentes.Any(x => x.Descripcion == "Restore"))
            {
                btnRestore.Enabled = false;

            }

            if (!patUsu.Patentes.Any(x => x.Descripcion == "RealizarVentas"))
            {
                btnRealizarVentas.Enabled = false;

            }
            if (!patUsu.Patentes.Any(x => x.Descripcion == "VerVentas"))
            {
                btnVerVentas.Enabled = false;

            }
            if (!patUsu.Patentes.Any(x => x.Descripcion == "MenuVentas"))
            {
                btnAdmVentas.Enabled = false;

            }
        }

        #region MostrarPanels
        public void ComprobarPrimerLogin(string usuario)
        {
            var usu = formControl.ObtenerInfoUsuario();
            if (usu.PrimerLogin)
            {
                var nuevaContraseña = "";

                var items = InputBox.fillItems("Contraseña", nuevaContraseña);

                InputBox input = InputBox.Show("Ingrese nueva contraseña", items, InputBoxButtons.OK);

                if (input.Result == InputBoxResult.OK)
                {
                    nuevaContraseña = input.Items["Contraseña"];
                    var cambioExitoso = usuarioDAL.CambiarContraseña(usu, nuevaContraseña, true);
                    if (cambioExitoso)
                    {
                        //Log.Info("Password Actualizado");
                        MessageBox.Show("Su contraseña fue actualizada");
                    }
                    else
                    {
                        //Log.Info("Fallo la actualizacion del password");
                        MessageBox.Show("Error contraseña no actualizada");
                    }
                }
            }
        }

        //no implementado
        private void btnAdmVet_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAdmVet);
        }

        //no implementado
        private void btnVerSolicitudes_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnRegistrarDiagnostico_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAdministradores);
        }

        private void btnAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //abmUsuario.MdiParent = this;
            abmUsuario.Show();

        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //bitacora.MdiParent = this;
            bitacora.Show();
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            familias.Show();
        }

        //cambiar
        private void btnBackupRestore_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            backup.MdiParent = this;
            backup.Show();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            FormAyuda mayuda = new FormAyuda();
            mayuda.Show();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            var confirmation = MessageBox.Show("Are you sure you want to log out?", "Get out of the system", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }

            return;
        }
        #endregion

        //no implementado en el form principal
        private void btnProductos_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //productos.MdiParent = this;
            productos.Show();
        }

        private void btnVisualizarUsuarios_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            datosUsuario.Show();
        }


        //no implementado
        private void btnAdmPatenteFamilia_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            datosUsuario.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            backup.Show();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            restore.Show();
        }

        private void btnAdmVentas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubmenuVentas);
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            venta.HacerLoad();
            //venta.MdiParent = this;
            venta.Show();
        }

        private void btnRealizarVentas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ventaDeProductos.MdiParent = this;
            ventaDeProductos.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "update modifications", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.MenuPrincipal_Load(sender, e);
                //this.Close();
            }
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPrimcipal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdmPatenteFamilia(object sender, EventArgs e)
        {

        }
    }
}
