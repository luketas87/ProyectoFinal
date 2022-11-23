using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Interfaces;
using BE.Implementacion;

namespace BLL.Interfaces
{
    public interface BLLIFamilia : ICrud<BEFamilia>
    {
        List<BEPatente> ObtenerPatentesFamilia(List<int> Idfamilia);

        List<BEPatente> ObtenerPatentesFamilia(int Idfamilia);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        void GuardarFamiliasUsuario(List<int> Idfamilia, int Idusuario);

        int ObtenerIdFamiliaPorUsuario(int Idusuario);

        List<int> ObtenerIdsFamiliasPorUsuario(int Idusuario);

        BEFamilia ObtenerFamiliaConDescripcion(string descripcion);

        string ObtenerDescripcionFamiliaPorId(int Idfamilia);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> Idfamilia);

        bool ComprobarUsoFamilia(int Idfamilia);

        void BorrarFamiliasUsuario(List<BEFamilia> familias, int Idusuario);

        List<BEFamilia> ObtenerFamiliasUsuario(int Idusuario);

        List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int Idfamilia);
    }
}
