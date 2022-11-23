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
            familiaDAL.BorrarFamiliaDeFamiliaPatente(objDel.IdFamilia);

            return familiaDAL.Borrar(objDel);
        }

        public void BorrarFamiliasUsuario(List<BEFamilia> familias, int IdUsuario)
        {
            familiaDAL.BorrarFamiliasUsuario(familias, IdUsuario);
        }

        public List<BEFamilia> Cargar()
        {
            return familiaDAL.Cargar();
        }

        public bool ComprobarUsoFamilia(int Idfamilia)
        {
            return familiaDAL.ComprobarUsoFamilia(Idfamilia);
        }

        public bool Crear(BEFamilia objAlta)
        {
            return familiaDAL.Crear(objAlta);
        }

        public void GuardarFamiliasUsuario(List<int> Idfamilia, int Idusuario)
        {
            familiaDAL.GuardarFamiliasUsuario(Idfamilia, Idusuario);

        }

        public string ObtenerDescripcionFamiliaPorId(int Idfamilia)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(Idfamilia);
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> Idfamilia)
        {
            return familiaDAL.ObtenerDescripcionFamiliaPorId(Idfamilia);
        }

        public BEFamilia ObtenerFamiliaConDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerFamiliaConDescripcion(descripcion);
        }

        public List<BEFamilia> ObtenerFamiliasUsuario(int Idusuario)
        {
            return familiaDAL.ObtenerFamiliasUsuario(Idusuario);
        }

        public int ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            return familiaDAL.ObtenerIdFamiliaPorDescripcion(descripcion);
        }

        public int ObtenerIdFamiliaPorUsuario(int Idusuario)
        {
            return familiaDAL.ObtenerIdFamiliaPorUsuario(Idusuario);
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int Idusuario)
        {
            return familiaDAL.ObtenerIdsFamiliasPorUsuario(Idusuario);
        }

        public List<BEPatente> ObtenerPatentesFamilia(List<int> Idfamilia)
        {
            return familiaDAL.ObtenerPatentesDeFamilias(Idfamilia);
        }

        public List<BEPatente> ObtenerPatentesFamilia(int Idfamilia)
        {
            return familiaDAL.ObtenerPatentesFamilia(Idfamilia);

        }

        public List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int Idfamilia)
        {
            return familiaDAL.ObtenerUsuariosPorFamilia(Idfamilia);
        }
    }
}
