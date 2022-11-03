using System;
using log4net;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;
using DAL.Utilidades;


namespace ProyectoFinal.Formularios
{
    public partial class Restore : Form
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            opFile.Filter = "Backup files(*.bak) |*.bak";
            opFile.Title = "Seleccione un archivo backup";

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                string file = opFile.FileName;
                try
                {
                    for (int i = 0; i < opFile.FileNames.Length; i++)
                    {
                        txtBackFiles.AppendText(opFile.FileNames[i] + Environment.NewLine);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Ocurrio un error revise la direccion.");
                }
            }
    }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            try
            {
                var conn = new ServerConnection(SqlUtilidades.Connection());
                string[] backupFiles = txtBackFiles.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var dbServer = new Server(new ServerConnection(new SqlConnection(conn.ConnectionString)));
                var restore = new Restore()
                {
                    Database = conn.DatabaseName,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                    NoRecovery = false
                };
                for (int i = 0; i < backupFiles.Length; i++)
                {
                    restore.Devices.AddDevice(backupFiles[i], DeviceType.File);
                }

                restore.ReplaceDatabase = true;
                restore.PercentComplete += DbPercentComplete;
                restore.Complete += DbRestore_Complete;

                dbServer.KillAllProcesses(restore.Database);

                restore.SqlRestore(dbServer);

                log4net.Config.XmlConfigurator.Configure();

                MessageBox.Show("Restore completado", "Restore Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Debe Seleccionar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
