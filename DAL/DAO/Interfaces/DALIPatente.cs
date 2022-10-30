using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALIPatente
    {
        void GuardarPatentesUsuario(List<int> IdPatente, int IdUsuario);

        bool NegarPatenteUsuario(int IdPatentes, int IdUsuario);

        bool HabilitarPatenteUsuario(int IdPatente, int IdUsuario);

        List<BEPatente> Cargar();

        int ObtenerIdPatentePorDescripcion(string descripcion);

        BEPatente ObtenerPatentePorDescripcion(string descripcion, int Idusuario);

        bool BorrarPatente(int IdFamilia, int IdPatente);

        bool AsignarPatente(int IdFamilia, int IdPatente);

        bool ComprobarPatentesUsuario(int Idusuario);

        List<BEFamiliaPatente> ConsultarPatenteFamilia(int IdFamilia);

        List<BEUsuarioPatente> ConsultarPatenteUsuario(int IdUsuario);

        void BorrarPatentesUsuario(List<int> ids, int IdUsuario);

        bool CheckeoDePatentesParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int Idquitar = 0);

        List<BEPatente> ObtenerPatentesUsuario(int IdUsuario);

        bool CheckeoUsuarioParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales);

        bool CheckeoFamiliaParaBorrar(BEFamilia familia, List<BECuentaUsuario> usuariosGlobales);

        bool CheckeoPatenteParaBorrar(BEPatente patente, BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool paraNegarOquitarDeFamilia = false);

        void CargarDVHPatentes();
    }
}
