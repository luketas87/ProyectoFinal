using BE.Interfaces;
using BE.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using BLL.Interfaces;
using UI;
using UI.Clases;

namespace ProyectoFinal.Formularios
{
    public partial class Bitacora : Form, IBitacora
    {
        private readonly BLLICuentaUsuario usuarionBll;
        private readonly BLLIBitacora bitacoraBLL;

        private List<string> usuarios { get; set; }

        public Bitacora(BLLIBitacora bitacoraBLL)
        {
            usuarionBll = IoCContainer.Resolve<BLLICuentaUsuario>();
            this.bitacoraBLL = bitacoraBLL;
            InitializeComponent();
        }

        private void BitacoraBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            FillCheckedList();
            this.reportViewer1.RefreshReport();
            // this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FillCheckedList()
        {
            usuarios = bitacoraBLL.CargarUsuarios();

            foreach (var usu in usuarios)
            {
                if (usu != null)
                {
                    checkListUsuarios.Items.Add(usu);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var fechaDesde = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var fechaHasta = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
            var usuariosSeleccionados = new List<string>();
            var criticidadesSeleccionadas = new List<string>();

            for (int i = 0; i < checkListUsuarios.CheckedItems.Count; i++)
            {
                var usuarioToAdd = bitacoraBLL.CargarUsuarios().FirstOrDefault(u => u == (string)checkListUsuarios.CheckedItems[i]);

                if (usuarioToAdd.Contains("'"))
                {
                    usuarioToAdd = usuarioToAdd.Replace("'", "''");
                }

                usuariosSeleccionados.Add(usuarioToAdd);
            }

            for (int i = 0; i < checkListCriticidad.CheckedItems.Count; i++)
            {
                criticidadesSeleccionadas.Add((string)checkListCriticidad.CheckedItems[i]);
            }

            var emailUsuarios = usuariosSeleccionados.Select(u => u).ToList();

            var listaBitacora = ListarBitacora(emailUsuarios, criticidadesSeleccionadas, fechaDesde, fechaHasta);

            try
            {
                if (listaBitacora != null)
                {
                    ModeloBitacora.ListadoBitacora = CrearDataTable(listaBitacora);
                    //Cargamos info en el reporte
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Bitacora", ModeloBitacora.ListadoBitacora.Tables[0]));
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                }
                else
                {
                    //VER PORQUE NO LO LIMPIA CUANDO NO HAY DATOS
                    //lo de abajo es temporal hasta encontrar una mejor solucion
                    ModeloBitacora.ListadoBitacora.Clear();
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Bitacora", ModeloBitacora.ListadoBitacora.Tables[0]));
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                    //Alert.ShowAlterWithButtonAndIcon("MSJ004", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<BEBitacora> ListarBitacora(List<string> usuarios, List<string> prueba, string fechaDesde, string fechaHasta)
        {
            var listaBitacora = bitacoraBLL.LeerBitacoraPorUsuarioCriticidadYFecha(usuarios, prueba, fechaDesde, fechaHasta);

            return listaBitacora;
        }

        public DataSet CrearDataTable(List<BEBitacora> listaBitacora)
        {
            var table = new DataTable();
            var dsBitacora = new DataSet();
            table.Columns.Add("Fecha");
            table.Columns.Add("Usuario");
            table.Columns.Add("Funcionalidad");
            table.Columns.Add("Descripcion");
            table.Columns.Add("Criticidad");

            if (listaBitacora != null)
            {
                foreach (var item in listaBitacora)
                {
                    //var email = usuarios.FirstOrDefault(_ => _.UsuarioId == item.UsuarioId)?.Email;
                    DataRow row = table.NewRow();
                    row["Fecha"] = item.Fecha.Value.ToString("dd/MM/yyyy");
                    row["Usuario"] = item.Usuario;
                    row["Funcionalidad"] = item.Actividad;
                    row["Descripcion"] = item.InformacionAsociada;
                    row["Criticidad"] = item.Criticidad;
                    table.Rows.Add(row);
                }
                dsBitacora.Tables.Add(table);
            }

            return dsBitacora;
        }

        private void Bitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void checkListCriticidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkListUsuarios.Items.Count; i++)
            {
                checkListUsuarios.SetItemChecked(i, chkTodos.Checked);
            }
        }

        private void chkTodas_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkListCriticidad.Items.Count; i++)
            {
                checkListCriticidad.SetItemChecked(i, chkTodas.Checked);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void rpv1_Load(object sender, EventArgs e)
        {

        }
    }
}
