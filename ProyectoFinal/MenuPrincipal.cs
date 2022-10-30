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
using BLL;

namespace ProyectoFinal
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public BECuentaUsuario mCuentausuario;
        public int mIdioma;

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
