using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Interfaces;
using BE.Implementacion;
using BLL.Interfaces;
using DAL.DAO.Interfaces;

namespace BLL.implementacion
{
    public class BLLFamilia : ICrud<BEFamilia>, BLLIFamilia
    {
        private readonly DALIFamilia familiaDAL;

        public BLLFamilia(DALIFamilia familiaDAL)
        {
            this.familiaDAL = familiaDAL;
        }

        public bool Actualizar(BEFamilia objUpd)
        {
            return familiaDAL.Actualizar(objUpd);

        }

        public bool Borrar(BEFamilia objDel)
        {
            familiaDAL.BorrarFamiliaDeFamiliaPatente(objDel.FamiliaId);

            return familiaDAL.Borrar(objDel);
        }

        public void BorrarFamiliasUsuario(List<BEFamilia> familias, int usuarioId)
        {
            familiaDAL.BorrarFamiliasUsuario(familias, usuarioId);
        }

        public List<BEFamilia> Cargar()
        {
            return familiaDAL.Cargar();
        }

        public bool ComprobarUsoFamilia(int familiaId)
        {
            return familiaDAL.ComprobarUsoFamilia(familiaId);
        }

        public bool Crear(BEFamilia objAlta)
        {
            return familiaDAL.Crear(objAlta);
        }

        public void GuardarFamiliasUsuario(List<int> familiaId, int usuarioId)
        {
            familiaDAL.GuardarFamiliasUsuario(familiaId, usuarioId);

        }

        public string ObtenerDescripcionFamiliaPorId(int familiaId)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(familiaId);
        }

        public BEFamilia ObtenerFamiliaConDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerFamiliaConDescripcion(descripcion);
        }

        public List<BEFamilia> ObtenerFamiliasUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerFamiliasUsuario(usuarioId);
        }

        public int ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerIdFamiliaPorDescripcion(descripcion);
        }

        public int ObtenerIdFamiliaPorUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerIdFamiliaPorUsuario(usuarioId);
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId)
        {
            return familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioId);
        }

        public List<BEPatente> ObtenerPatentesFamilia(List<int> familiaId)
        {
            return familiaDAL.ObtenerPatentesDeFamilias(familiaId);
        }

        public List<BEPatente> ObtenerPatentesFamilia(int familiaId)
        {
            return familiaDAL.ObtenerPatentesFamilia(familiaId);

        }

        public List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int familiaId)
        {
            return familiaDAL.ObtenerUsuariosPorFamilia(familiaId);
        }
    }
}
