using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.DAO.Interfaces;
using DAL.Utilidades;

namespace DAL.DAO.Implementacion 
{
    public class DALPatente : BaseDAO, DALIPatente
    {
        private readonly IDigitoVerificador digitoVerificador;
        private readonly DALIFamilia FamiliaDAL;

        public DALPatente(IDigitoVerificador digitoVerificador, DALIFamilia FamiliaDAL)
        {
            this.digitoVerificador = digitoVerificador;
            this.FamiliaDAL = FamiliaDAL;
        }

        public bool AsignarPatente(int IdFamilia, int IdPatente)
        {
            var asignado = false;
            CatchException(() =>
            {
                asignado = Exec($"INSERT INTO FamiliaPatente (FamiliaId, IdPatente) VALUES ({IdFamilia}, {IdPatente})");
            });

            return asignado;
        }

        public List<BEPatente> ConsultarPatenteUsuarioJOIN(int IdUsuario)
        {
            var queryString = "SELECT UsuarioPatente.IdPatente, Descripcion FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE IdUsuario = @IdUsuario";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString, new { @IdUsuario = IdUsuario });
            });
        }

        public bool BorrarPatente(int IdFamilia, int IdPatente)
        {
            var borrada = false;

            CatchException(() =>
            {
                borrada = Exec($"DELETE FROM FamiliaPatente WHERE FamiliaId = {IdFamilia} AND IdPatente = {IdPatente}");
            });

            return borrada;
        }

        public void BorrarPatentesUsuario(List<int> IdPatentes, int IdUsuario)
        {
            foreach (var id in IdPatentes)
            {
                var queryString = $"DELETE FROM UsuarioPatente WHERE IdPatente = {id} AND IdUsuario = {IdUsuario}";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }

        public List<BEPatente> Cargar()
        {
            var queryString = "SELECT * FROM Patente";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString);
            });
        }

        public void CargarDVHPatentes()
        {
            var query = "SELECT * FROM Patente";
            var listaPatentes = new List<BEPatente>();


            CatchException(() =>
            {
                listaPatentes = Exec<BEPatente>(query);
            });

            foreach (var patente in listaPatentes)
            {
                var digito = digitoVerificador.CalcularDVHorizontal(new List<string>() { patente.Descripcion });

                //HACER update

                var q = $"UPDATE Patente SET DVH = {digito} WHERE IdPatente = @Id";

                CatchException(() =>
                {
                    Exec(
                        q,
                        new
                        {
                            @Id = patente.IdPatente
                        });
                });
            };
        }

        public bool CheckeoDePatentesParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int quitarId = 0)
        {
            CheckeoUsuarioParaBorrar(usuario, usuariosGlobales);

            ///Si ningun usuario tiene patentes no se puede borrar ningun usuario
            if (!ComprobarTablaUsuarioPatente())
            {
                return false;
            }

            var diccionarioPatentes = new Dictionary<int, int>();
            List<BECuentaUsuario> usuariosGlobal = usuariosGlobales;
            List<int> familiasIds = usuario.Familia.Select(familia => familia.FamiliaId).ToList();

            CargaUsuario(usuario, requestFamiliaUsuario, quitarId, usuariosGlobal);

            CargarUsuariosGlobales(usuario, requestFamilia, usuariosGlobal);

            CargarDiccionario(usuario, diccionarioPatentes, usuariosGlobal);
            //// Uno de los problemas esta en este metodo no checkea una a una las patentes sino todo el diccionario y encima tiene un and habria que
            //// Separar las condiciones para hacer dos comprobaciones 
            if (diccionarioPatentes.Count > 0 && diccionarioPatentes.All(x => x.Value > 0))
            {
                return true;
            }

            return false;
        }

        private static void CargarDiccionario(BECuentaUsuario usuario, Dictionary<int, int> diccionarioPatentes, List<BECuentaUsuario> usuariosGlobal)
        {
            ////Si el usuario no tiene patentes no esta cargando ninguna al diccionario no deberia ser asi.
            foreach (var patenteUsuario in usuario.Patentes)
            {
                diccionarioPatentes.Add(patenteUsuario.IdPatente, 0);
                var contador = 0;

                foreach (var usuarioAComparar in usuariosGlobal)
                {
                    foreach (var patenteAComparar in usuarioAComparar.Patentes)
                    {
                        if (patenteUsuario.IdPatente == patenteAComparar.IdPatente)
                        {
                            contador++;
                            diccionarioPatentes[patenteUsuario.IdPatente] = contador;
                        }
                    }
                }
            }
        }

        private void CargarUsuariosGlobales(BECuentaUsuario usuario, bool requestFamilia, List<BECuentaUsuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var IdFamilias = FamiliaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.IdUsuario);

                usuarioAComparar.Familia = new List<BEFamilia>();
                usuarioAComparar.Patentes = new List<BEPatente>();

                foreach (var idfam in IdFamilias)
                {
                    usuarioAComparar.Familia.Add(new BEFamilia() { FamiliaId = idfam });

                    if (requestFamilia)
                    {
                        if (usuarioAComparar.Familia.Exists(a => usuario.Familia.All(x => a.FamiliaId == x.FamiliaId)))
                        {
                            usuarioAComparar.Familia.RemoveAll(x => x.FamiliaId == idfam);
                        }
                        else
                        {
                            usuarioAComparar.Patentes.AddRange(FamiliaDAL.ObtenerPatentesFamilia(idfam));
                        }
                    }
                    else
                    {
                        usuarioAComparar.Patentes.AddRange(FamiliaDAL.ObtenerPatentesFamilia(idfam));
                    }
                }
            }
        }

        private void CargaUsuario(BECuentaUsuario usuario, bool requestFamiliaUsuario, int quitarId, List<BECuentaUsuario> usuariosGlobal)
        {
            usuariosGlobal.RemoveAll(x => x.IdUsuario == usuario.IdUsuario);

            RemoverIdsFamilias(requestFamiliaUsuario, quitarId, usuario.Familia);

            SetearPatentesUsuario(usuario, usuario.Familia.Select(familia => familia.FamiliaId).ToList());
        }

        private static void RemoverIdsFamilias(bool requestFamiliaUsuario, int quitarId, List<BEFamilia> familias)
        {
            if (requestFamiliaUsuario)
            {
                familias.RemoveAll(x => x.FamiliaId != quitarId);
            }
        }

        private List<BEPatente> ComprobarPatentesDeUsuariosPropiosYGlobales(BEFamilia familiaABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            var usuarios = FamiliaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.FamiliaId);

            usuarios.ForEach(usuario => usuario.Patentes = ObtenerPatentesUsuario(usuario.IdUsuario));

            var patentesSinUsuarios = new List<BEPatente>();

            foreach (var usuario in usuarios)
            {
                patentesSinUsuarios.AddRange(familiaABorrar.Patentes
                    .Where(patente => !usuario.Patentes
                    .Select(patenteUsu => patenteUsu.IdPatente)
                    .Contains(patente.IdPatente)).ToList());

                patentesSinUsuarios = patentesSinUsuarios.Distinct().ToList();
            }

            foreach (var usuario in usuarios)
            {
                if (usuario.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(patSinU => usuario.Patentes.Any(patU => patU.IdPatente == patSinU.IdPatente));
                }

                ////SE ESTAN BORRANDO TODOS LOS USUARIOS DE UNA FAMILIA POR ESO NO PERMITE BORRAR UNA FAMILIA QUE TIENEN 2 USUARIOS

                usuariosGlobales.RemoveAll(usu => usu.IdUsuario == usuario.IdUsuario);
            }

            CargarPatentesUsuariosGloables(usuariosGlobales);

            foreach (var usuario in usuariosGlobales)
            {
                if (usuario.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuario.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            return patentesSinUsuarios;
        }

        private void CargarPatentesUsuariosGloables(List<BECuentaUsuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var familiasId = FamiliaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.IdUsuario);
                foreach (var idfam in familiasId)
                {
                    usuarioAComparar.Patentes.AddRange(FamiliaDAL.ObtenerPatentesFamilia(idfam));
                    usuarioAComparar.Patentes = usuarioAComparar.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
                }
            }
        }

        private void SetearPatentesUsuario(BECuentaUsuario usuario, List<int> IdFamilia)
        {
            ////usuario.Patentes.AddRange(usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId));

            usuario.Patentes.AddRange(FamiliaDAL.ObtenerPatentesDeFamilias(IdFamilia));

            usuario.Patentes = usuario.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
        }


        private bool ComprobarTablaUsuarioPatente()
        {
            return ObtenerTodasLasPatentesYUsuarios().Count > 0;
        }

        public bool CheckeoFamiliaParaBorrar(BEFamilia FamiliaABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            if (FamiliaABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            if (!(FamiliaDAL.ObtenerUsuariosPorFamilia(FamiliaABorrar.FamiliaId).Count > 0))
            {
                return true;
            }

            if (FamiliaDAL.ObtenerUsuariosPorFamilia(FamiliaABorrar.FamiliaId).Count > 1)
            {
                return true;
            }

            var patentesSinUsuarios = ComprobarPatentesDeUsuariosPropiosYGlobales(FamiliaABorrar, usuariosGlobales);

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckeoPatenteParaBorrar(BEPatente patente, BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool paraNegarOquitarDeFamilia = false)
        {
            if (!paraNegarOquitarDeFamilia)
            {
                ////si tiene la patente en su familia puedo borrarsela sin problema
                if (usuario.Familia.Select(fam => fam.Patentes.Any(patFU => patFU.IdPatente == patente.IdPatente)).FirstOrDefault())
                {
                    return true;
                }
            }

            var patentesSinUsuarios = new List<BEPatente>
            {
                patente
            };

            usuariosGlobales.RemoveAll(usu => usu.IdUsuario == usuario.IdUsuario);

            CargarPatentesUsuariosGloables(usuariosGlobales);

            foreach (var usuarioG in usuariosGlobales)
            {
                if (usuarioG.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuarioG.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckeoUsuarioParaBorrar(BECuentaUsuario UsuarioABorrar, List<BECuentaUsuario> UsuariosGlobales)
        {
            var patentesSinUsuarios = new List<BEPatente>();

            if (UsuarioABorrar.Patentes.Count <= 0)
            {
                if (UsuarioABorrar.Familia.Count > 0)
                {
                    return CheckeoDeFamiliasEnUsuariosSinPatentes(UsuarioABorrar, UsuariosGlobales);
                }

                return true;
            }

            ///si no tiene familia estoy permitiendo que se borre esta mal
            if (UsuarioABorrar.Familia.Count <= 0 && UsuarioABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            foreach (var familia in UsuarioABorrar.Familia)
            {
                patentesSinUsuarios.AddRange(ComprobarPatentesDeUsuariosPropiosYGlobales(familia, UsuariosGlobales));
            }

            patentesSinUsuarios.AddRange(UsuarioABorrar.Patentes);

            UsuariosGlobales.RemoveAll(usu => usu.IdUsuario == UsuarioABorrar.IdUsuario);

            CargarPatentesUsuariosGloables(UsuariosGlobales);

            foreach (var usuarioG in UsuariosGlobales)
            {
                if (usuarioG.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuarioG.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public bool ComprobarPatentesUsuario(int IdUsuario)
        {
            var query = string.Format("SELECT UsuarioId FROM UsuarioPatente WHERE UsuarioId = '{0}'", IdUsuario);
            var ids = new List<int>();

            CatchException(() =>
            {
                ids = Exec<int>(query);
            });

            if (ids.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<BEFamiliaPatente> ConsultarPatenteFamilia(int IdFamilia)
        {
            var queryString = "SELECT FamiliaPatente.FamiliaId, IdPatente FROM FamiliaPatente WHERE FamiliaId = @idFamilia";

            return CatchException(() =>
            {
                return Exec<BEFamiliaPatente>(queryString, new { @idFamilia = IdFamilia });
            });
        }

        public List<BEUsuarioPatente> ConsultarPatenteUsuario(int IdUsuario)
        {
            var queryString = "SELECT IdUsuario, IdPatente, Negada FROM USuarioPatente WHERE IdUsuario = @IdUsuario";

            return CatchException(() =>
            {
                return Exec<BEUsuarioPatente>(queryString, new { @IdUsuario = IdUsuario });
            });
        }

        public void GuardarPatentesUsuario(List<int> IdPatentes, int IdUsuario)
        {
            List<BEUsuarioPatente> patentesUsuarios = ObtenerTodasLasPatentesYUsuarios();

            if (!patentesUsuarios.Exists(x => x.IdPatente == IdPatentes[0] && x.IdUsuario == IdUsuario))
            {
                foreach (var id in IdPatentes)
                {
                    var queryString = $"INSERT INTO UsuarioPatente(IdPatente, UsuarioId, Negada) VALUES ({id},{IdUsuario}, 0)";

                    CatchException(() =>
                    {
                        return Exec(queryString);
                    });
                }
            }
        }

        public bool HabilitarPatenteUsuario(int IdPatente, int IdUsuario)
        {
            var queryString = $"UPDATE UsuarioPatente SET Negada = 0 WHERE UsuarioId = @IdUsuario AND IdPatente = @IdPatente";

            return CatchException(() =>
            {
                return Exec(queryString, new { @IdUsuario = IdUsuario, @IdPatente = IdPatente });
            });
        }

        public bool NegarPatenteUsuario(int IdPatentes, int IdUsuario)
        {
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<BEUsuarioPatente>();
            var queryString = string.Empty;

            CatchException(() =>
            {
                patentesUsuarios = Exec<BEUsuarioPatente>(optQuery);
            });

            if (patentesUsuarios.Exists(x => x.IdPatente == IdPatentes && x.IdUsuario == IdUsuario))
            {
                queryString = $"UPDATE UsuarioPatente SET Negada = 1 WHERE UsuarioId = @usuarioId AND IdPatente = @patenteId";
            }
            else
            {
                queryString = $"INSERT INTO UsuarioPatente(IdPatente, UsuarioId, Negada) VALUES ({IdPatentes},{IdUsuario}, 1)";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @IdUsuario = IdUsuario, @IdPatente = IdPatentes });
            });
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            var queryString = $"SELECT IdPatente FROM Patente WHERE Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public BEPatente ObtenerPatentePorDescripcion(string descripcion, int IdUsuario)
        {
            var queryString = $"SELECT Patente.IdPatente, Patente.Descripcion, (SELECT negada FROM UsuarioPatente WHERE UsuarioId = {IdUsuario} AND IdPatente = Patente.IdPatente) as Negada FROM Patente WHERE Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString).FirstOrDefault();
            });
        }

        public List<BEPatente> ObtenerPatentesUsuario(int IdUsuario)
        {
            return ConsultarPatenteUsuarioJOIN(IdUsuario);
        }

        private List<BEUsuarioPatente> ObtenerTodasLasPatentesYUsuarios()
        {
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<BEUsuarioPatente>();

            CatchException(() =>
            {
                patentesUsuarios = Exec<BEUsuarioPatente>(optQuery);
            });
            return patentesUsuarios;
        }

        private bool CheckeoDeFamiliasEnUsuariosSinPatentes(BECuentaUsuario usuarioABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            usuariosGlobales.Remove(usuarioABorrar);

            if (usuariosGlobales.Any(usuarioG => usuarioG.Familia.Any(fam => usuarioABorrar.Familia.Any(uFam => uFam.FamiliaId == fam.FamiliaId))))
            {
                return true;
            }

            var patentesUsuario = usuarioABorrar.Familia.Select(fam => fam.Patentes).FirstOrDefault();
            var patentesUsuariosGlobales = usuariosGlobales.Select(ug => ug.Patentes).ToList();

            if (patentesUsuario.All(upat => patentesUsuariosGlobales.All(pats => pats.Any(pat => pat.IdPatente == upat.IdPatente))))
            {
                return true;
            }

            return false;
        }
    }
}
