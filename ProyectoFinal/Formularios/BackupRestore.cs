using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Formularios
{
    public partial class BackupRestore : Form
    {
        public BackupRestore()
        {
            InitializeComponent();
        }

        private void pictureBoxBackup_Click(object sender, EventArgs e)
        {
            Backup aBackup= new Backup();
            aBackup.MdiParent = this;
            aBackup.Show();
        }

        private void pictureBoxRestore_Click(object sender, EventArgs e)
        {
            Restore aRestore = new Restore();
            aRestore.MdiParent = this;
            aRestore.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
