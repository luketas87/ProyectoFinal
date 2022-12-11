using BE.Implementacion;
using BE.Interfaces;
using BLL.Interfaces;
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
    public partial class AdmPatenteFamilia : Form, IAdminPatFamilia
    {
        public List<BEPatente> PatentesBd = new List<BEPatente>();
        private BEFamilia familia = null;

        private readonly BLLIPatente patenteBLL;
        private readonly BLLIFamilia familiaBLL;
        private IFamilias familias;
        private BLLICuentaUsuario usuarioBLL;

        private bool familiaNueva;
        private bool checkeadapat = false;

        public bool FamiliaNueva
        {
            get { return familiaNueva; }
            set { familiaNueva = value; }
        }

        public AdmPatenteFamilia(BLLIPatente patenteBLL, BLLIFamilia familiaBLL)
        {
            this.patenteBLL = patenteBLL;
            this.familiaBLL = familiaBLL;
            InitializeComponent();
        }


        public void AsignarPatente(int IdFamilia, int IdPatente)
        {
            var asignadas = patenteBLL.AsignarPatente(IdFamilia, IdPatente);
        }

        public void BorrarPatente(int Idfamilia, int Idpatente)
        {
            var negadas = patenteBLL.BorrarPatente(Idfamilia, Idpatente);
        }

        //boton para modificar Patente-Familia
        private void btnModificar_Click(object sender, EventArgs e)
        {
            checkeadapat = false;
            lstPatentes.Enabled = true;
        }

        private void AdmPatenteFamilia_Load(object sender, EventArgs e)
        {
            usuarioBLL = IoCContainer.Resolve<BLLICuentaUsuario>();
            familias = IoCContainer.Resolve<IFamilias>();
            familia = familias.ObtenerFamiliaSeleccionada();
            lblFamilia.Text = "";
            lblFamilia.Text = lblFamilia.Text + " " + familia.Descripcion;
            PatentesBd = patenteBLL.Cargar();
            lstPatentes.DataSource = null;
            lstPatentes.DataSource = PatentesBd;
            lstPatentes.DisplayMember = "Descripcion";
            lstPatentes.ValueMember = "IdPatente";
            lstPatentes.Enabled = false;
            CargarChecks();
        }

        private void CargarChecks()
        {
            checkeadapat = true;
            var patentes = familiaBLL.ObtenerPatentesFamilia(familia.IdFamilia);

            foreach (var pat in patentes)
            {
                var descPatente = PatentesBd.Where(x => x.IdPatente == pat.IdPatente).Select(x => x.Descripcion).FirstOrDefault();
                var index = lstPatentes.FindString(descPatente);

                if (index == -1)
                {
                    index = 0;
                }

                lstPatentes.SetItemChecked(index, true);
            }
        }

        public void RecargarGrilla()
        {
            lstPatentes.DataSource = null;
            lstPatentes.DataSource = PatentesBd;
            lstPatentes.DisplayMember = "Descripcion";
            lstPatentes.ValueMember = "IdPatente";
        }

        private void lstPatentes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!checkeadapat)
            {
                var patenteSel = new BEPatente();

                if (FamiliaNueva)
                {
                    FamiliaNueva = false;

                    patenteSel = (BEPatente)lstPatentes.SelectedItem;

                    AsignarPatente(familia.IdFamilia, patenteSel.IdPatente);
                }
                else
                {
                    patenteSel = (BEPatente)lstPatentes.SelectedItem;

                    var patentes = patenteBLL.ConsultarPatenteFamilia(familia.IdFamilia);

                    if (patentes.Exists(x => x.IdPatente == patenteSel.IdPatente))
                    {
                        var usuarios = familiaBLL.ObtenerUsuariosPorFamilia(familia.IdFamilia);

                        if (usuarios.Count > 0)
                        {
                            foreach (var usuario in usuarios)
                            {
                                usuario.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(usuario.IdUsuario));

                                foreach (var familia in usuario.Familia)
                                {
                                    familia.Patentes = familiaBLL.ObtenerPatentesFamilia(familia.IdFamilia);
                                }
                                if (patenteBLL.CheckeoPatenteParaBorrar(patenteSel, usuario, usuarioBLL.TraerUsuariosConPatentesYFamilias(), true))
                                {
                                    BorrarPatente(familia.IdFamilia, patenteSel.IdPatente);
                                }
                                else
                                {
                                    MessageBox.Show("No se puede quitar esta patente a la familia");
                                    RecargarGrilla();
                                    e.NewValue = e.CurrentValue;
                                }
                            }
                        }
                        else
                        {
                            BorrarPatente(familia.IdFamilia, patenteSel.IdPatente);
                        }
                    }
                    else
                    {
                        AsignarPatente(familia.IdFamilia, patenteSel.IdPatente);
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void AdmPatenteFamilia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnModificar_Enter(object sender, EventArgs e)
        {
            CargarChecks();
        }

        private void btnCboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
