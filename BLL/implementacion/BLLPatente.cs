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
    public class BLLPatente : BLLIPatente
    {
        private readonly DALIPatente patenteDAL;

        public BLLPatente(DALIPatente patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }


        public bool AsignarPatente(int IdFamilia, int IdPatente)
        {
            return patenteDAL.AsignarPatente(IdFamilia, IdPatente);
        }

        public bool BorrarPatente(int IdFamilia, int IdPatente)
        {
            return patenteDAL.BorrarPatente(IdFamilia, IdPatente);
        }

        public void BorrarPatentesUsuario(List<int> ids, int IdUsuario)
        {
            patenteDAL.BorrarPatentesUsuario(ids, IdUsuario);
        }

        public List<BEPatente> Cargar()
        {
            return patenteDAL.Cargar();
        }

        public void CargarDVHPatentes()
        {
            patenteDAL.CargarDVHPatentes();
        }

        public bool CheckeoDePatentesParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int familiaAQuitarId = 0)
        {
            return patenteDAL.CheckeoDePatentesParaBorrar(usuario, usuariosGlobales, requestFamilia, requestFamiliaUsuario, borrado, familiaAQuitarId);

        }

        public bool CheckeoFamiliaParaBorrar(BEFamilia familia, List<BECuentaUsuario> usuariosGlobales)
        {
            return patenteDAL.CheckeoFamiliaParaBorrar(familia, usuariosGlobales);
        }

        public bool CheckeoPatenteParaBorrar(BEPatente patente, BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool paraNegar = false)
        {
            return patenteDAL.CheckeoPatenteParaBorrar(patente, usuario, usuariosGlobales, paraNegar);
        }

        public bool CheckeoUsuarioParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales)
        {
            return patenteDAL.CheckeoUsuarioParaBorrar(usuario, usuariosGlobales);
        }

        public bool ComprobarPatentesUsuario(int IdUsuario)
        {
            return patenteDAL.ComprobarPatentesUsuario(IdUsuario);
        }

        public List<BEFamiliaPatente> ConsultarPatenteFamilia(int IdFamilia)
        {
            return patenteDAL.ConsultarPatenteFamilia(IdFamilia);
        }

        public List<BEUsuarioPatente> ConsultarPatenteUsuario(int IdUsuario)
        {
            return patenteDAL.ConsultarPatenteUsuario(IdUsuario);
        }

        public void GuardarPatentesUsuario(List<int> IdPatente, int IdUsuario)
        {
            patenteDAL.GuardarPatentesUsuario(IdPatente, IdUsuario);
        }

        public bool HabilitarPatente(int IdPatente, int IdUsuario)
        {
            return patenteDAL.HabilitarPatenteUsuario(IdPatente, IdUsuario);
        }

        public bool NegarPatente(int IdPatente, int IdUsuario)
        {
            return patenteDAL.NegarPatenteUsuario(IdPatente, IdUsuario);
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return patenteDAL.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public BEPatente ObtenerPatentePorDescripcion(string descripcion, int IdUsuario)
        {
            return patenteDAL.ObtenerPatentePorDescripcion(descripcion, IdUsuario);
        }
    }
}
