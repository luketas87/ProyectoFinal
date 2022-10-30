using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Implementacion;
using BE.Interfaces;

namespace DAL.DAO.Interfaces
{
    public interface DALIFamilia : ICrud<BEFamilia>
    {
        List<BEPatente> ObtenerPatentesFamilia(int IdFamilia);

        List<BEPatente> ObtenerPatentesDeFamilias(List<int> IdFamilia);

        void GuardarFamiliasUsuario(List<int> IdFamilia, int IdUsuario);

        int ObtenerIdFamiliaPorDescripcion(string Descripcion);

        int ObtenerIdFamiliaPorUsuario(int IdUsuario);

        string ObtenerDescripcionFamiliaPorId(int IdFamilia);

        bool ComprobarUsoFamilia(int IdFamilia);

        BEFamilia ObtenerFamiliaConDescripcion(string Descripcion);

        List<int> ObtenerIdsFamiliasPorUsuario(int IdUsuario);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> IdFamilia);

        void BorrarFamiliaDeFamiliaPatente(int IdFamilia);

        void BorrarFamiliasUsuario(List<BEFamilia> Familias, int IdUsuario);

        List<BEFamilia> ObtenerFamiliasUsuario(int IdUsuario);

        List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int IdFamilia);

        List<BEUsuarioFamilia> ObtenerTodasLasFamiliasYUsuarios();
    }
}
