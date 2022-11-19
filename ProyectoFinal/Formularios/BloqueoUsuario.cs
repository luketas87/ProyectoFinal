using BE.Interfaces;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using EasyEncryption;
using System.Windows.Forms;

namespace ProyectoFinal.Formularios
{
    public partial class BloqueoUsuario : Form, IBloqueoUsuario
    {
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly BLLICuentaUsuario usuarioBll;
        public BloqueoUsuario(BLLICuentaUsuario usuarioBll)
        {
            this.usuarioBll = usuarioBll;
            InitializeComponent();
        }

        //ACTIVAR USUARIOS INACTIVOS.
        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (lstInactivos.Items.Count > 0)
            {
                var activado = usuarioBll.ActivarUsuario(lstInactivos.SelectedValue.ToString());
                if (activado)
                {
                    CargarUsuarios();
                }
            }
        }


        private void BloqueoUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void BloqueoUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
            e.Cancel = true;
        }

        //DESACTIVAR USUARIOS PARA PONERLOS INACTIVOS.
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (lstActivos.Items.Count > 0)
            {
                var desactivado = usuarioBll.DesactivarUsuario(lstActivos.SelectedValue.ToString());
                if (desactivado)
                {
                    CargarUsuarios();
                }
            }          
        }

        private void CargarUsuarios()
        {
            lstActivos.DataSource = usuarioBll.Cargar().Select(x => DES.Decrypt(x.Email, Key, Iv)).ToList();
            lstInactivos.DataSource = usuarioBll.CargarInactivos().Select(x => DES.Decrypt(x.Email, Key, Iv)).ToList();
        }

        private void BloqueoUsuario_Enter(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
