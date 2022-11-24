using BE.Implementacion;
using BE.Interfaces;
using BLL.implementacion;
using BLL.Interfaces;
using DAL.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinal.Clases
{
    public class FormControl : BaseDAO, IFormControl
    {
        public BEIdioma LenguajeSeleccionado
        {
            get { return lenguajeSel; }
            set { lenguajeSel = value; }
        }

        public IDictionary<string, string> Traducciones
        {
            get { return traducciones; }
            set { traducciones = value; }
        }
       public FormControl(BLLICuentaUsuario usuarioBLL, BLLIFamilia familiaBLL, BLLIFormControl formControlBLL, BLLIIdioma idiomaBLL)
        {
            this.usuarioBLL = usuarioBLL;
            this.familiaBLL = familiaBLL;
            this.formControlBLL = formControlBLL;
            this.idiomaBLL = idiomaBLL;
        }

        private BEIdioma lenguajeSel;
        private readonly BLLIIdioma idiomaBLL;
        private readonly BLLICuentaUsuario usuarioBLL;
        private readonly BLLIFamilia familiaBLL;
        private readonly BLLIFormControl formControlBLL;

        private BECuentaUsuario UsuarioActivo { get; set; }

        private IDictionary<string, string> traducciones = new Dictionary<string, string>();

        public List<BEPatente> ObtenerPermisosFormularios()
        {
            return formControlBLL.ObtenerPermisosFormularios();
        }

        public BECuentaUsuario ObtenerPermisosUsuario()
        {
            var patentes = new List<BEPatente>();

            patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(UsuarioActivo.IdUsuario));

            patentes.AddRange(familiaBLL.ObtenerPatentesFamilia(UsuarioActivo.Familia.Select(x => x.IdFamilia).ToList()));

            patentes = patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();

            UsuarioActivo.Patentes = patentes;

            return UsuarioActivo;
        }

        public void GuardarDatosSesionUsuario(BECuentaUsuario usuario)
        {
            usuario.Familia = new List<BEFamilia>();

            var famIds = familiaBLL.ObtenerIdsFamiliasPorUsuario(usuario.IdUsuario);

            foreach (var id in famIds)
            {
                usuario.Familia.Add(new BEFamilia() { IdFamilia = id, Descripcion = familiaBLL.ObtenerDescripcionFamiliaPorId(id) });
            }

            UsuarioActivo = usuario;
        }

        public BECuentaUsuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }

        public BEIdioma ObtenerIdioma()
        {
            return LenguajeSeleccionado;
        }

        public IDictionary<string, string> ObtenerTraducciones()
        {
            Traducciones = idiomaBLL.ObtenerTraduccionesFormulario(LenguajeSeleccionado.IdIdioma, Application.OpenForms[0].Name).ToDictionary(k => k.ControlName ?? k.MensajeCodigo, v => v.Traduccion);
            return Traducciones;
        }

        public List<BEPatente> ObtenerPermisosFormulario(int formId)
        {
            return formControlBLL.ObtenerPermisosFormulario(formId);
        }

    }
}
