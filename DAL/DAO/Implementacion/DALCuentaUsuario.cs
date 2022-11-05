using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BE;
using System.Data.SqlClient;
using Servicios;
using BE.Implementacion;
using DAL.Utilidades;
using BE.Interfaces;
using DAL.DAO.Interfaces;
using EasyEncryption;


namespace DAL.DAO.Implementacion
{
    public class DALCuentaUsuario : BaseDAO, ICrud<BECuentaUsuario>, DALIUsuario
    {
        //llave para encriptar y desencriptar.
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;
        private readonly DALIFamilia familiaDAL;
        private readonly DALIPatente patenteDAL;

        public DALCuentaUsuario(IDigitoVerificador digitoVerificador, DALIFamilia familiaDAL, DALIPatente patenteDAL)
        {
            this.digitoVerificador = digitoVerificador;
            this.familiaDAL = familiaDAL;
            this.patenteDAL = patenteDAL;
        }

        public SqlConnection mCon = new SqlConnection(new ConexionBD().CadenaConexion);

        public bool ActivarUsuario(string email)
        {
            var usu = ObtenerUsuarioConEmail(email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 1 WHERE UsuarioId = {0}", usu.IdUsuario);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Actualizar(BECuentaUsuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objUpd.Nombre, usu.Email, usu.Contraseña });

            var queryString = $"UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, Email = @email, Telefono = @telefono, Domicilio = @domicilio, DVH = @dvh, PrimerLogin=@PrimerLogin WHERE IdUsuario = @Idusuario";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @usuarioId = usu.IdUsuario,
                        @nombre = objUpd.Nombre,
                        @apellido = objUpd.Apellido,
                        @email = usu.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @dvh = digitoVH,
                        @PrimerLogin = objUpd.PrimerLogin,
                    });
            });
        }

        public bool Borrar(BECuentaUsuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 0 WHERE UsuarioId = {0}", usu.IdUsuario);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool CambiarContraseña(BECuentaUsuario usuario, string nuevaContraseña, bool primerLogin)
        {
            var contEncript = MD5.ComputeMD5Hash(nuevaContraseña);
            var queryString = string.Empty;
            if (primerLogin == true)
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña, PrimerLogin = 0 WHERE UsuarioId = @usuarioId";
            }
            else
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña WHERE UsuarioId = @usuarioId";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuario.IdUsuario, @contraseña = contEncript });
            });
        }

        public List<BECuentaUsuario> Cargar()
        {
            var queryString = "SELECT * FROM Usuario WHERE Activo = 1;";

            return CatchException(() =>
            {
                return Exec<BECuentaUsuario>(queryString);
            });
        }

        public void CargarDVHPatentes()
        {
            var query = "SELECT * FROM Usuario";
            var listaUsuarios = new List<BECuentaUsuario>();


            CatchException(() =>
            {
                listaUsuarios = Exec<BECuentaUsuario>(query);
            });

            foreach (var usuario in listaUsuarios)
            {
                var digito = digitoVerificador.CalcularDVHorizontal(new List<string>() { usuario.Nombre, usuario.Email, usuario.Contraseña });

                //HACER update

                var q = $"UPDATE Usuario SET DVH = {digito} WHERE UsuarioId = @Id";

                CatchException(() =>
                {
                    Exec(
                        q,
                        new
                        {
                            @Id = usuario.IdUsuario
                        });
                });
            }
        }

        public List<BECuentaUsuario> CargarInactivos()
        {
            throw new NotImplementedException();
        }

        public bool Crear(BECuentaUsuario objAlta)
        {
            //encripta mail y contraseña.
            //hash irreversible.
            var contEncript = MD5.ComputeMD5Hash(new Random().Next().ToString());
            //encriptar con Key e Iv
            var emailEncript = DES.Encrypt(objAlta.Email, Key, Iv);

            objAlta.IdUsuario = ObtenerUltimoIdUsuario() + 1;
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objAlta.Nombre, emailEncript, contEncript });

            //evitar sqlinjection @.
            var queryString = "INSERT INTO Usuario(Nombre, Apellido, Contraseña, Email, Telefono, Domicilio, ContadorIngresosIncorrectos, " +
                "IdCanalVenta, IdIdioma, PrimerLogin, DVH, Activo) " +
                "VALUES (@nombre, @apellido, @contraseña, @email, @telefono, @domicilio, @contadorIngresos, @idCanalVenta, @idIdioma, " +
                "@primerLogin, @dvh, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objAlta.Nombre,
                        @apellido = objAlta.Apellido,
                        @contraseña = contEncript,
                        @email = emailEncript,
                        @telefono = objAlta.Telefono,
                        @domicilio = objAlta.Domicilio,
                        @contadorIngresos = objAlta.ContadorIngresosIncorrectos = 0,
                        @idCanalVenta = objAlta.IdCanalVenta,
                        @idIdioma = objAlta.IdIdioma,
                        @primerLogin = Convert.ToByte(objAlta.PrimerLogin = true),
                        @dvh = digitoVH,
                        @activo = 1
                    });
            });
        }

        public bool DesactivarUsuario(string email)
        {
            return Borrar(new BECuentaUsuario() { Email = email });
        }

        public DataSet ExecuteDataSet(string pCadenaComando)
        {
            //Inserto filas en la base de datos
            DataSet mDs = new DataSet();
            SqlDataAdapter mDa = new SqlDataAdapter(pCadenaComando, mCon);
            mDa.Fill(mDs);
            if (mCon.State != ConnectionState.Closed) mCon.Close();
            return mDs;
        }

        public int ExecuteNonQuery(string pCommandText)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                int resultado = mCom.ExecuteNonQuery();
                mCon = new SqlConnection(new ConexionBD().CadenaConexion);
                return resultado;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public int ExecuteNonQuery(string pCommandText, string pDataBase)
        {
            try
            {
                SqlCommand mCom = new SqlCommand(pCommandText, mCon);
                mCon.Open();
                mCon.ChangeDatabase(pDataBase);
                return mCom.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        private int ObtenerUltimoIdUsuario()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Usuario]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }
        private bool ValidarContraseña(string contraseña, string contEncriptada)
        {
            if (contraseña == contEncriptada)
            {
                return true;
            }

            return false;
        }

        public bool LogIn(string email, string contraseña)
        {
            var ingresa = false;

            var usu = ObtenerUsuarioConEmail(email);

            if (usu.Email != null)
            {
                if (usu.Activo)
                {
                    if (!usu.PrimerLogin)
                    {
                        var cingresoInc = usu.ContadorIngresosIncorrectos;

                        if (cingresoInc < 3)
                        {
                            var contEncriptada = MD5.ComputeMD5Hash(contraseña);

                            ingresa = ValidarContraseña(usu.Contraseña, contEncriptada);

                            if (!ingresa)
                            {
                                AumentarIngresos(usu, usu.ContadorIngresosIncorrectos);
                                return false;
                            }

                            return true;
                        }

                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        private void AumentarIngresos(BECuentaUsuario usuario, int ingresos)
        {
            var ingresosSel = ingresos;
            var querySelect = string.Format("SELECT ContadorIngresosIncorrectos FROM Usuario WHERE UsuarioId = {0}", usuario.IdUsuario);

            CatchException(() =>
            {
                ingresosSel = 1 + Exec<int>(querySelect)[0];
            });

            var queryString = string.Format("UPDATE Usuario SET ContadorIngresosIncorrectos = {1} WHERE UsuarioId = {0}", usuario.IdUsuario, ingresosSel);

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public int ObtenerId(string pTabla)
        {
            try
            {
                SqlCommand mCom = new SqlCommand("SELECT ISNULL(MAX(" + pTabla + "_Id),0) FROM " + pTabla, mCon);
                mCon.Open();
                return int.Parse(mCom.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (mCon.State != ConnectionState.Closed)
                    mCon.Close();
            }
        }

        public List<BEPatente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            var queryString = $"SELECT UsuarioPatente.IdPatente, Patente.Descripcion, UsuarioPatente.Negada FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE UsuarioId = {usuarioId}";

            return CatchException(() =>
            {
                return Exec<BEPatente>(queryString);
            });
        }

        public BECuentaUsuario ObtenerUsuarioConEmail(string email)
        {
            var usuario = new List<BECuentaUsuario>();
            var queryString = "SELECT * FROM dbo.Usuario WHERE Email = @email";

            CatchException(() =>
            {
                usuario = Exec<BECuentaUsuario>(queryString, new { @email = DES.Encrypt(email, Key, Iv) });
            });

            if (usuario.Count > 0)
            {
                return usuario[0];
            }
            else
            {
                return new BECuentaUsuario();
            }
        }

        public BECuentaUsuario ObtenerUsuarioConId(int usuarioId)
        {
            var usuario = new List<BECuentaUsuario>();
            var queryString = "SELECT * FROM dbo.Usuario WHERE UsuarioId = @UsuarioId";

            CatchException(() =>
            {
                usuario = Exec<BECuentaUsuario>(queryString, new { UsuarioId = usuarioId });
            });

            if (usuario.Count > 0)
            {
                return usuario[0];
            }
            else
            {
                return new BECuentaUsuario();
            }
        }

        public List<BECuentaUsuario> TraerUsuariosConPatentesYFamilias()
        {
            var usuarios = Cargar();

            foreach (var usuario in usuarios)
            {
                usuario.Familia = new List<BEFamilia>();
                usuario.Patentes = new List<BEPatente>();

                usuario.Familia = familiaDAL.ObtenerFamiliasUsuario(usuario.IdUsuario);
                usuario.Patentes = patenteDAL.ObtenerPatentesUsuario(usuario.IdUsuario);
            }

            return usuarios;
        }

        public BECuentaUsuario CargarPatentesYFamiliaUsuario(BECuentaUsuario usuario)
        {
            usuario.Familia = new List<BEFamilia>();
            usuario.Patentes = new List<BEPatente>();

            usuario.Familia = familiaDAL.ObtenerFamiliasUsuario(usuario.IdUsuario);
            usuario.Patentes = patenteDAL.ObtenerPatentesUsuario(usuario.IdUsuario);

            return usuario;
        }
    }
}

