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
        List<BEPatente> ObtenerPatentesFamilia(List<int> familiaId);

        List<BEPatente> ObtenerPatentesFamilia(int familiaId);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        void GuardarFamiliasUsuario(List<int> familiaId, int usuarioId);

        int ObtenerIdFamiliaPorUsuario(int usuarioId);

        List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId);

        BEFamilia ObtenerFamiliaConDescripcion(string descripcion);

        string ObtenerDescripcionFamiliaPorId(int familiaId);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId);

        bool ComprobarUsoFamilia(int familiaId);

        void BorrarFamiliasUsuario(List<BEFamilia> familias, int usuarioId);

        List<BEFamilia> ObtenerFamiliasUsuario(int usuarioId);

        List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int familiaId);
    }
}
