using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using BLL.Interfaces;
using DAL.DAO.Interfaces;

namespace BLL.implementacion
{
    public class BLLFormControl : BLLIFormControl
    {
        private readonly DALIFormControl formControlDAL;

        public BLLFormControl(DALIFormControl formControlDAL)
        {
            this.formControlDAL = formControlDAL;
        }

        public IDictionary<string, string> Traducciones { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BEIdioma LenguajeSeleccionado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GuardarDatosSesionUsuario(BECuentaUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public BEIdioma ObtenerIdioma()
        {
            throw new NotImplementedException();
        }

        public BECuentaUsuario ObtenerInfoUsuario()
        {
            throw new NotImplementedException();
        }

        public List<BEPatente> ObtenerPermisosFormulario(int formId)
        {
            return formControlDAL.ObtenerPermisosFormulario(formId);
        }

        public List<BEPatente> ObtenerPermisosFormularios()
        {
            return formControlDAL.ObtenerPermisosFormularios();
        }

        public BECuentaUsuario ObtenerPermisosUsuario()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> ObtenerTraducciones()
        {
            throw new NotImplementedException();
        }
    }
}
