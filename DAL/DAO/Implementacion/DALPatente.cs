using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.DAO.Interfaces;
using DAL.Utilidades;
using BE.Interfaces;

namespace DAL.DAO.Implementacion 
{
    public class DALPatente : BaseDAO, DALIPatente
    {
        private readonly IDigitoVerificador digitoVerificador;
        private readonly DALIFamilia familiaDAL;

        public DALPatente(IDigitoVerificador digitoVerificador, DALIFamilia familiaDAL)
        {
            this.digitoVerificador = digitoVerificador;
            this.familiaDAL = familiaDAL;
        }

        public bool AsignarPatente(int familiaId, int patenteId)
        {
            var asignado = false;
            CatchException(() =>
            {
                asignado = Exec($"INSERT INTO FamiliaPatente (IdFamilia, IdPatente) VALUES ({familiaId}, {patenteId})");
            });

            return asignado;
        }

        public List<BEPatente> ObtenerPatentesUsuario(int usuarioId)
        {
            return ConsultarPatenteUsuarioJOIN(usuarioId);
        }

        public bool BorrarPatente(int familiaId, int patenteId)
        {
            var borrada = false;

            CatchException(() =>
            {
                borrada = Exec($"DELETE FROM FamiliaPatente WHERE IdFamilia = {familiaId} AND IdPatente = {patenteId}");
            });

            return borrada;
        }

        public List<BEPatente> Cargar()
        {
            var queryString = "SELECT * FROM Patente";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString);
            });
        }

        public void GuardarPatentesUsuario(List<int> patentesId, int usuarioId)
        {
            List<BEUsuarioPatente> patentesUsuarios = ObtenerTodasLasPatentesYUsuarios();

            if (!patentesUsuarios.Exists(x => x.IdPatente == patentesId[0] && x.IdUsuario == usuarioId))
            {
                foreach (var id in patentesId)
                {
                    var queryString = $"INSERT INTO UsuarioPatente(IdPatente, IdUsuario, Negada) VALUES ({id},{usuarioId}, 0)";

                    CatchException(() =>
                    {
                        return Exec(queryString);
                    });
                }
            }
        }

        public bool NegarPatenteUsuario(int patenteId, int usuarioId)
        {
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<BEUsuarioPatente>();
            var queryString = string.Empty;

            CatchException(() =>
            {
                patentesUsuarios = Exec<BEUsuarioPatente>(optQuery);
            });

            if (patentesUsuarios.Exists(x => x.IdPatente == patenteId && x.IdUsuario == usuarioId))
            {
                queryString = $"UPDATE UsuarioPatente SET Negada = 1 WHERE IdUsuario = @usuarioId AND IdPatente = @patenteId";
            }
            else
            {
                queryString = $"INSERT INTO UsuarioPatente(IdPatente, IdUsuario, Negada) VALUES ({patenteId},{usuarioId}, 1)";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuarioId, @patenteId = patenteId });
            });
        }

        public bool HabilitarPatenteUsuario(int patenteId, int usuarioId)
        {
            var queryString = $"UPDATE UsuarioPatente SET Negada = 0 WHERE IdUsuario = @usuarioId AND IdPatente = @patenteId";

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuarioId, @patenteId = patenteId });
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

        public BEPatente ObtenerPatentePorDescripcion(string descripcion, int usuarioId)
        {
            var queryString = $"SELECT Patente.IdPatente, Patente.Descripcion, (SELECT negada FROM UsuarioPatente WHERE IdUsuario = {usuarioId} AND IdPatente = Patente.IdPatente) as Negada FROM Patente WHERE Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString).FirstOrDefault();
            });
        }

        public bool ComprobarPatentesUsuario(int usuarioId)
        {
            var query = string.Format("SELECT IdUsuario FROM UsuarioPatente WHERE IdUsuario = '{0}'", usuarioId);
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

        public List<BEFamiliaPatente> ConsultarPatenteFamilia(int familiaId)
        {
            var queryString = "SELECT FamiliaPatente.IdFamilia, IdPatente FROM FamiliaPatente WHERE IdFamilia = @idFamilia";

            return CatchException(() =>
            {
                return Exec<BEFamiliaPatente>(queryString, new { @idFamilia = familiaId });
            });
        }

        public List<BEFamiliaPatente> ConsultarPatenteFamiliaJOIN(int familiaId)
        {
            var queryString = "SELECT FamiliaPatente.IdPatente, Descripcion FROM FamiliaPatente INNER JOIN Patente ON FamiliaPatente.IdPatente = Patente.IdPatente WHERE IdFamilia = @familiaId";

            return CatchException(() =>
            {
                return Exec<BEFamiliaPatente>(queryString, new { @idFamilia = familiaId });
            });
        }

        public List<BEUsuarioPatente> ConsultarPatenteUsuario(int usuarioId)
        {
            var queryString = "SELECT IdUsuario, IdPatente, Negada FROM USuarioPatente WHERE IdUsuario = @usuarioId";

            return CatchException(() =>
            {
                return Exec<BEUsuarioPatente>(queryString, new { @usuarioId = usuarioId });
            });
        }

        public List<BEPatente> ConsultarPatenteUsuarioJOIN(int usuarioId)
        {
            var queryString = "SELECT UsuarioPatente.IdPatente, Descripcion FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE IdUsuario = @usuarioId";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString, new { @usuarioId = usuarioId });
            });
        }

        public void BorrarPatentesUsuario(List<int> patentesId, int usuarioId)
        {
            foreach (var id in patentesId)
            {
                var queryString = $"DELETE FROM UsuarioPatente WHERE IdPatente = {id} AND IdUsuario = {usuarioId}";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }

        public bool CheckeoDePatentesParaBorrar(BECuentaUsuario usuario, List<BECuentaUsuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int quitarId = 0)
        {
            CheckeoUsuarioParaBorrar(usuario, usuariosGlobales);

            ///Si ningun usuario tiene patentes no se puede borrar ningun usuario
            if (!ComprobarTablaUsuarioPatente())
            {
                return false;
            }

            ////Si hay usuarios en la tabla de familias no puedo borrar a todas las familias paso 5
            ////NO SE ESTA IDENTIFICANDO QUE FAMILIA NO SE PUEDE BORRAR
            ////if (ComprobarUsuarioFamilia())
            ////{
            ////    return false;
            ////}

            ////CheckeoFamiliaParaBorrar(familiaABorrar);

            var diccionarioPatentes = new Dictionary<int, int>();
            List<BECuentaUsuario> usuariosGlobal = usuariosGlobales;
            List<int> familiasIds = usuario.Familia.Select(familia => familia.IdFamilia).ToList();

            CargaUsuario(usuario, requestFamiliaUsuario, quitarId, usuariosGlobal);

            ////Revisar metodo que obtiene las patentes de las familias, que trae???? las patentes de una familia sola o de todas
            ////if (!esBorrado)
            ////{
            ////    if (usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId).Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
            ////    {
            ////        if (usuario.Patentes.Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
            ////        {
            ////            return true;
            ////        }
            ////    }
            ////}

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

        public bool CheckeoUsuarioParaBorrar(BECuentaUsuario usuarioABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            var patentesSinUsuarios = new List<BEPatente>();

            if (usuarioABorrar.Patentes.Count <= 0)
            {
                if (usuarioABorrar.Familia.Count > 0)
                {
                    return CheckeoDeFamiliasEnUsuariosSinPatentes(usuarioABorrar, usuariosGlobales);
                }

                return true;
            }

            ///si no tiene familia estoy permitiendo que se borre esta mal
            if (usuarioABorrar.Familia.Count <= 0 && usuarioABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            foreach (var familia in usuarioABorrar.Familia)
            {
                patentesSinUsuarios.AddRange(ComprobarPatentesDeUsuariosPropiosYGlobales(familia, usuariosGlobales));
            }

            patentesSinUsuarios.AddRange(usuarioABorrar.Patentes);

            usuariosGlobales.RemoveAll(usu => usu.IdUsuario == usuarioABorrar.IdUsuario);

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

        public bool CheckeoFamiliaParaBorrar(BEFamilia familiaABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            if (familiaABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            if (!(familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.IdFamilia).Count > 0))
            {
                return true;
            }

            if (familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.IdFamilia).Count > 1)
            {
                return true;
            }

            var patentesSinUsuarios = ComprobarPatentesDeUsuariosPropiosYGlobales(familiaABorrar, usuariosGlobales);

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

        private static void RemoverIdsFamilias(bool requestFamiliaUsuario, int quitarId, List<BEFamilia> familias)
        {
            if (requestFamiliaUsuario)
            {
                familias.RemoveAll(x => x.IdFamilia != quitarId);
            }
        }

        private List<BEPatente> ComprobarPatentesDeUsuariosPropiosYGlobales(BEFamilia familiaABorrar, List<BECuentaUsuario> usuariosGlobales)
        {
            var usuarios = familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.IdFamilia);

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

        private bool ComprobarTablaUsuarioPatente()
        {
            return ObtenerTodasLasPatentesYUsuarios().Count > 0;
        }

        private void CargaUsuario(BECuentaUsuario usuario, bool requestFamiliaUsuario, int quitarId, List<BECuentaUsuario> usuariosGlobal)
        {
            usuariosGlobal.RemoveAll(x => x.IdUsuario == usuario.IdUsuario);

            RemoverIdsFamilias(requestFamiliaUsuario, quitarId, usuario.Familia);

            SetearPatentesUsuario(usuario, usuario.Familia.Select(familia => familia.IdFamilia).ToList());
        }

        private void CargarUsuariosGlobales(BECuentaUsuario usuario, bool requestFamilia, List<BECuentaUsuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var familiasId = familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.IdUsuario);

                usuarioAComparar.Familia = new List<BEFamilia>();
                usuarioAComparar.Patentes = new List<BEPatente>();

                foreach (var idfam in familiasId)
                {
                    usuarioAComparar.Familia.Add(new BEFamilia() { IdFamilia = idfam });

                    if (requestFamilia)
                    {
                        if (usuarioAComparar.Familia.Exists(a => usuario.Familia.All(x => a.IdFamilia == x.IdFamilia)))
                        {
                            usuarioAComparar.Familia.RemoveAll(x => x.IdFamilia == idfam);
                        }
                        else
                        {
                            usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                        }
                    }
                    else
                    {
                        usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                    }
                }
            }
        }

        private void CargarPatentesUsuariosGloables(List<BECuentaUsuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var familiasId = familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.IdUsuario);
                foreach (var idfam in familiasId)
                {
                    usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                    usuarioAComparar.Patentes = usuarioAComparar.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
                }
            }
        }

        private void SetearPatentesUsuario(BECuentaUsuario usuario, List<int> familiaId)
        {
            ////usuario.Patentes.AddRange(usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId));

            usuario.Patentes.AddRange(familiaDAL.ObtenerPatentesDeFamilias(familiaId));

            usuario.Patentes = usuario.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
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

            if (usuariosGlobales.Any(usuarioG => usuarioG.Familia.Any(fam => usuarioABorrar.Familia.Any(uFam => uFam.IdFamilia == fam.IdFamilia))))
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
            }
        }
    }
}
