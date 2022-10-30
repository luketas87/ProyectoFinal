using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace BLL.Interfaces
{
    public interface BLLIPatente
    {
        void GuardarPatentesUsuario(List<int> IdPatente, int IdUsuario);

        int ObtenerIdPatentePorDescripcion(string descripcion);

        BEPatente ObtenerPatentePorDescripcion(string descripcion, int IdUsuario);

        List<BEPatente> Cargar();

        bool AsignarPatente(int IdFamilia, int IdPatente);

        bool BorrarPatente(int IdFamilia, int IdPatente);

        bool ComprobarPatentesUsuario(int IdUsuario);

        List<BEFamiliaPatente> ConsultarPatenteFamilia(int IdFamilia);

        bool NegarPatente(int IdPatente, int IdUsuario);

        bool HabilitarPatente(int IdPatente, int IdUsuario);

        List<BEUsuarioPatente> ConsultarPatenteUsuario(int IdUsuario);

        void BorrarPatentesUsuario(List<int> ids, int IdUsuario);

        bool CheckeoDePatentesParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int familiaAQuitarId = 0);

        bool CheckeoUsuarioParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales);

        bool CheckeoFamiliaParaBorrar(BEFamilia familia, List<BECuentaUsuario> usuariosGlobales);

        bool CheckeoPatenteParaBorrar(BEPatente patente, BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool paraNegar = false);

        void CargarDVHPatentes();
    }
}
