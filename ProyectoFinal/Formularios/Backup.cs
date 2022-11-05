using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using CustomControls.RJControls;
using System.Data.SqlClient;
using BE.Interfaces;
using BLL.implementacion;

namespace ProyectoFinal
{
    public partial class Backup : Form 
    {
        public Backup()
        {
            //btnAceptar.Enabled = false;
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerDialog = new FolderBrowserDialog();
            if (explorerDialog.ShowDialog() == DialogResult.OK)
            {
                txtDirectorio.Text = explorerDialog.SelectedPath;
                Environment.SpecialFolder root = explorerDialog.RootFolder;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BLLBackup bLLBackup = new BLLBackup();
            bLLBackup.Backup(int.Parse(cboCantidad.Text), txtDirectorio.Text);

        }


        //Porcentaje de progreso del backup
        private void DbPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });

            lblProgreso.Invoke((MethodInvoker)delegate
            {

                lblProgreso.Text = $"{e.Percent}%";
            });
        }


        private void chkDividir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDividir.Checked)
            {
                cboCantidad.Enabled = true;
            }
            else
            {
                cboCantidad.Enabled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
