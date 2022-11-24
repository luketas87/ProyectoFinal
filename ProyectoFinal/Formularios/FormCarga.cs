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
    public partial class FormCarga : Form
    {
        public Action worker { get; set; }

        public FormCarga(Action worker)
        {
            if (worker == null)
            {
                throw new ArgumentNullException();
            }

            this.worker = worker;
            InitializeComponent();
        }

        private void FormCarga_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
