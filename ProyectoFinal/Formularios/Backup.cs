using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using CustomControls.RJControls;
using System.Data.SqlClient;
using BE.Interfaces;
using BLL.implementacion;
using DAL.Utilidades;

namespace ProyectoFinal
{
    public partial class Backup : Form, IBackup
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
            #region OLD
            // BLLBackup bLLBackup = new BLLBackup();
            //bLLBackup.Backup(int.Parse(cboCantidad.Text), txtDirectorio.Text);
            #endregion
            progressBar1.Value = 0;
            var cantVolumenes = Convert.ToInt32(cboCantidad.SelectedItem);

            if (cantVolumenes == 0)
            {
                cantVolumenes = 1;
            }

            try
            {
                if (txtDirectorio.Text.Trim() != String.Empty && txtNombre.Text.Trim() != String.Empty)
                {
                    var conn = new ServerConnection(SqlUtilidades.Connection());
                    var dbServer = new Server(conn);
                    var dbBackUp = new Microsoft.SqlServer.Management.Smo.Backup() 
                    {
                       Action = BackupActionType.Database, Database = conn.DatabaseName
                    };

                    for (int i = 0; i < cantVolumenes; i++)
                    {
                        dbBackUp.Devices.AddDevice(txtDirectorio.Text.Trim() + "\\" + txtNombre.Text.Trim() + i + ".bak", DeviceType.File);
                    }

                    dbBackUp.Initialize = true;
                    dbBackUp.PercentComplete += DbPercentComplete;
                    dbBackUp.Complete += DbBackUp_Complete;
                    dbBackUp.SqlBackupAsync(dbServer);
                }
                else
                {
                    MessageBox.Show("Ingresar descripción y seleccionar una ruta para Realizar la copia de seguridad.", "Realizar Copia de Seguridad");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("La copia de seguridad ha finalizado con Exito", "Copia de Seguridad");

        }

        private void DbBackUp_Complete(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = e.Error.Message;
                });
            }
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
