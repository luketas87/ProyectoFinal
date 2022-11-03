﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Utilidades;
using BE.Interfaces;
using BE.Implementacion;
using DAL.DAO.Interfaces;

namespace DAL.DAO.Implementacion
{
    public class DALFamilia : BaseDAO, ICrud<BEFamilia>, DALIFamilia
    {
        private readonly IDigitoVerificador digitoVerificador;

        public DALFamilia(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Actualizar(BEFamilia objUpd)
        {
            var queryString = $"UPDATE Familia SET Descripcion = '{objUpd.Descripcion}' WHERE IdFamilia = {objUpd.FamiliaId}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Borrar(BEFamilia objDel)
        {
            var familia = ObtenerFamiliaConDescripcion(objDel.Descripcion);

            var queryString = $"DELETE FROM Familia WHERE IdFamilia = {familia.FamiliaId}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public void BorrarFamiliaDeFamiliaPatente(int IdFamilia)
        {
            var queryString = string.Format("DELETE FROM FamiliaPatente WHERE FamiliaId = {0}", IdFamilia);

            CatchException(() =>
            {
                Exec(queryString);
            });
        }

        public void BorrarFamiliasUsuario(List<BEFamilia> Familias, int IdUsuario)
        {
            foreach (var familia in Familias)
            {
                var queryString = $"DELETE FROM FamiliaUsuario WHERE IdFamilia = {familia.FamiliaId} and IdUsuario = {IdUsuario}";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }

        public List<BEFamilia> Cargar()
        {
            var queryString = "SELECT * FROM Familia;";

            return CatchException(() =>
            {
                return Exec<BEFamilia>(queryString);
            });
        }

        public bool ComprobarUsoFamilia(int IdFamilia)
        {
            var result = new List<int>();
            var queryString = "SELECT FamiliaId FROM FamiliaUsuario WHERE FamiliaId = @idfamilia";

            CatchException(() =>
            {
                result = Exec<int>(queryString, new { @idfamilia = IdFamilia });
            });

            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Crear(BEFamilia objAlta)
        {
            var queryString = $"INSERT INTO Familia(Descripcion) VALUES ('{objAlta.Descripcion}')";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public void GuardarFamiliasUsuario(List<int> IdFamilia, int IdUsuario)
        {
            foreach (var id in IdFamilia)
            {
                var queryString = $"INSERT INTO FamiliaUsuario(FamiliaId, UsuarioId) VALUES('{id}','{IdUsuario}')";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }

        public string ObtenerDescripcionFamiliaPorId(int IdFamilia)
        {
            var queryString = $"SELECT Descripcion FROM Familia WHERE FamiliaId = {IdFamilia}";

            return CatchException(() =>
            {
                return Exec<string>(queryString).FirstOrDefault();
            });
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> IdFamilia)
        {
            var famsdesc = new List<string>();

            foreach (var id in IdFamilia)
            {
                var queryString = $"SELECT Descripcion FROM Familia WHERE FamiliaId = {id}";

                CatchException(() =>
                {
                    famsdesc.Add(Exec<string>(queryString).FirstOrDefault());
                });
            }

            return famsdesc;
        }

        public BEFamilia ObtenerFamiliaConDescripcion(string Descripcion)
        {
            var queryString = $"SELECT * from Familia Where Descripcion = '{Descripcion}'";
            var familia = new BEFamilia();

            CatchException(() =>
            {
                familia = Exec<BEFamilia>(queryString).FirstOrDefault();
            });

            familia.Patentes = ObtenerPatentesFamilia(familia.FamiliaId);

            return familia;
        }

        public List<BEFamilia> ObtenerFamiliasUsuario(int IdUsuario)
        {
            var familiasDb = Cargar();
            var familiaUsuario = ObtenerIdsFamiliasPorUsuario(IdUsuario);

            return familiasDb.FindAll(x => familiaUsuario.Any(y => y == x.FamiliaId));
        }

        public int ObtenerIdFamiliaPorDescripcion(string Descripcion)
        {
            var queryString = "SELECT FamiliaId FROM Familia WHERE Descripcion = @descripcion";

            return CatchException(() =>
            {
                return Exec<int>(queryString, new { @descripcion = Descripcion }).FirstOrDefault();
            });
        }

        public int ObtenerIdFamiliaPorUsuario(int IdUsuario)
        {
            var queryString = $"SELECT FamiliaId FROM FamiliaUsuario WHERE UsuarioId = {IdUsuario}";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int IdUsuario)
        {
            var famIds = new List<int>();

            var queryString = $"SELECT FamiliaId FROM FamiliaUsuario WHERE UsuarioId = {IdUsuario}";

            famIds = CatchException(() =>
            {
                return Exec<int>(queryString);
            });
            return famIds;
        }

        public List<BEPatente> ObtenerPatentesDeFamilias(List<int> IdFamilia)
        {
            var patentes = new List<BEPatente>();
            var auxpat = new List<BEPatente>();
            var resultado = new List<BEPatente>();

            foreach (var id in IdFamilia)
            {
                var queryString = $"SELECT * FROM FamiliaPatente WHERE FamiliaId = {id}";

                auxpat = CatchException(() =>
                {
                    return Exec<BEPatente>(queryString);
                });
                patentes.AddRange(auxpat);
            }

            auxpat = new List<BEPatente>();

            foreach (var patente in patentes)
            {
                var querypatente = $"SELECT Id, FamiliaId, FamiliaPatente.IdPatente, Descripcion FROM FamiliaPatente INNER JOIN Patente on FamiliaPatente.IdPatente = Patente.IdPatente WHERE FamiliaPatente.IdPatente ={patente.IdPatente}";

                auxpat = CatchException(() =>
                {
                    return Exec<BEPatente>(querypatente);
                });
                resultado.AddRange(auxpat);
            }

            return resultado;
        }

        public List<BEPatente> ObtenerPatentesFamilia(int IdFamilia)
        {
            var patentes = new List<BEPatente>();
            var queryString = $"SELECT distinct IdPatente FROM FamiliaPatente WHERE FamiliaId = {IdFamilia}";

            CatchException(() =>
            {
                patentes = Exec<BEPatente>(queryString);
            });

            foreach (var patente in patentes)
            {
                var queryPatente = $"SELECT Descripcion FROM Patente WHERE IdPatente = {patente.IdPatente}";
                patente.Descripcion = Exec<string>(queryPatente).FirstOrDefault();
            }

            return patentes;
        }

        public List<BEUsuarioFamilia> ObtenerTodasLasFamiliasYUsuarios()
        {
            var query = "SELECT * FROM FamiliaUsuario";
            var familiasUsuarios = new List<BEUsuarioFamilia>();

            CatchException(() =>
            {
                familiasUsuarios = Exec<BEUsuarioFamilia>(query);
            });

            return familiasUsuarios;
        }

        public List<BECuentaUsuario> ObtenerUsuariosPorFamilia(int IdFamilia)
        {
            var listaUsuarios = new List<BECuentaUsuario>();
            var queryString = string.Format("SELECT DISTINCT UsuarioId FROM FamiliaUsuario WHERE FamiliaId = {0}", IdFamilia);

            var ids = Exec<int>(queryString);

            if (ids.Count > 0)
            {
                var stringIds = string.Join<int>(",", ids);

                CatchException(() =>
                {
                    var queryUsuario = string.Format("SELECT * FROM Usuario WHERE Activo = 1 AND UsuarioId IN ({0})", stringIds);

                    listaUsuarios = Exec<BECuentaUsuario>(queryUsuario);
                });

                foreach (var usuario in listaUsuarios)
                {
                    usuario.Familia = new List<BEFamilia>();
                    usuario.Patentes = new List<BEPatente>();

                    usuario.Familia = ObtenerFamiliasUsuario(usuario.IdUsuario);
                }
            }

            return listaUsuarios;
        }
    }
}
