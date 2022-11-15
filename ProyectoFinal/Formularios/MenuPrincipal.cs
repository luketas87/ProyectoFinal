using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
using DAL.DAO.Interfaces;

namespace ProyectoFinal.Formularios
{
    public partial class MenuPrincipal : Form, IPrincipal
    {
        private readonly IFormControl formControl;
        private readonly DALICuentaUsuario usuarioDAL;
        private readonly IDetalleVenta ventaDeProductos;
        private readonly IABMUsuario abmUsuario;
        private readonly IBitacora bitacora;
        private readonly IFamilias familias;
        private readonly BLLIFamilia familiaBLL;
        private readonly IDatosUsuario datosUsuario;
        private readonly IBackup backup;
        private readonly IRestore restore;
        private readonly IProductos productos;
        private readonly IVenta venta;


        public MenuPrincipal(DALICuentaUsuario usuarioDAL,
            IDetalleVenta ventaDeProductos,
            IABMUsuario abmUsuario,
            IBitacora bitacora,
            IFormControl formControl,
            IFamilias familias,
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

            if (panelAdmVet.Visible == true)
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
             if (!patUsu.Patentes.Any(x => x.Descripcion == "AMBFamilia"))
             {
                btnFamilias.Enabled = false;
                familias.MdiParent = this;
                familias.Show();

            }
             if (!patUsu.Patentes.Any(x => x.Descripcion == "AMBUsuario"))
             {
                 btnAdministrarUsuarios.Enabled = false;

             }
             if (!patUsu.Patentes.Any(x => x.Descripcion == "MenuBitacora"))
             {
                 btnBitacora.Enabled = false;

             }
             if (!patUsu.Patentes.Any(x => x.Descripcion == "MenuBkpRestore"))
             {
                 btnBackupRestore.Enabled = false;

             }

             if (!patUsu.Patentes.Any(x => x.Descripcion == "RealizarVentas"))
             {
                 btnRealizarVentas.Enabled = false;

             }
             if (!patUsu.Patentes.Any(x => x.Descripcion == "VerVentas"))
             {
                btnVentas.Enabled = false;

             }
             if (!patUsu.Patentes.Any(x => x.Descripcion == "MenuVentas"))
             {
                 btnAdmVentas.Enabled = false;

             }
        } 

        #region MostrarPanels
        public void ComprobarPrimerLogin(string usuario)
        {
            throw new NotImplementedException();
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmVentas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubmenuVentas);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            venta.HacerLoad();
            venta.MdiParent = this;
        }

        private void btnRealizarVentas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ventaDeProductos.MdiParent = this;
            ventaDeProductos.Show();
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
            abmUsuario.MdiParent = this;
            abmUsuario.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            bitacora.MdiParent = this;
            bitacora.Show();
        }

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            hideSubMenu();
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
            Help.ShowHelp(this, "file://C:\\Users\\lucas\\source\\repos\\ProyectoFinal\\ProyectoFinal\\ProyectoFinal\\Manual\\VeterinariaPatitasManualdeUsuario.chm");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            var confirmation = MessageBox.Show("¿Esta seguro que desea salir del sistema?", "Salir del sistema", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
            }

            return;
        }
        #endregion

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            productos.MdiParent = this;
            productos.Show();
        }
    }
}
