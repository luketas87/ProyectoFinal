using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Servicios;
using BE.Implementacion;
using DAL.Utilidades;
using BE.Interfaces;
using DAL.DAO.Interfaces;
using EasyEncryption;


namespace DAL.DAO.Implementacion
{
    public class DALCuentaUsuario : BaseDAO, ICrud<BECuentaUsuario>, DALICuentaUsuario
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

        public bool ActivarUsuario(string email)
        {
            var usu = ObtenerUsuarioConEmail(email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 1 WHERE IdUsuario = {0}", usu.IdUsuario);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Actualizar(BECuentaUsuario objUpd)
        {

            var usu = ObtenerUsuarioConEmail(objUpd.Email);                           //no carga el email en usu
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> {/* objUpd.Nombre,*/ usu.Email/*, objUpd.Contraseña*/ });

            var queryString = $"UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, Email = @email, Telefono = @telefono, Domicilio = @domicilio, DVH = @dvh, PrimerLogin=@PrimerLogin WHERE IdUsuario = @IdUsuario";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @IdUsuario = usu.IdUsuario,
                        @nombre = objUpd.Nombre,
                        @apellido = objUpd.Apellido,
                        @contraseña = objUpd.Contraseña,
                        @email = usu.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @dvh = digitoVH,
                        @PrimerLogin = objUpd.PrimerLogin,
                    }); ;
            });
        }

        public bool Borrar(BECuentaUsuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("UPDATE Usuario SET Activo = 0 WHERE IdUsuario = {0}", usu.IdUsuario);

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
                queryString = "UPDATE Usuario SET Contraseña = @contraseña, PrimerLogin = 0 WHERE IdUsuario = @IdUsuario";
            }
            else
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña WHERE IdUsuario = @IdUsuario";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @IdUsuario = usuario.IdUsuario, @contraseña = contEncript });
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

                var q = $"UPDATE Usuario SET DVH = {digito} WHERE IdUsuario = @Id";

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
            var queryString = "SELECT Email FROM Usuario WHERE Activo = 0;";
            var usuarios = new List<BECuentaUsuario>();

            CatchException(() =>
            {
                usuarios = Exec<BECuentaUsuario>(queryString);
            });

            usuarios.ForEach(x => DES.Decrypt(x.Email, Key, Iv));

            return usuarios;
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
        /*
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
        }*/

        private void AumentarIngresos(BECuentaUsuario usuario, int ingresos)
        {
            var ingresosSel = ingresos;
            var querySelect = string.Format("SELECT ContadorIngresosIncorrectos FROM Usuario WHERE IdUsuario = {0}", usuario.IdUsuario);

            CatchException(() =>
            {
                ingresosSel = 1 + Exec<int>(querySelect)[0];
            });

            var queryString = string.Format("UPDATE Usuario SET ContadorIngresosIncorrectos = {1} WHERE IdUsuario = {0}", usuario.IdUsuario, ingresosSel);

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<BEPatente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            var queryString = $"SELECT UsuarioPatente.IdPatente, Patente.Descripcion, UsuarioPatente.Negada FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE IdUsuario = {usuarioId}";

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
            var queryString = "SELECT * FROM dbo.Usuario WHERE IdUsuario = @IdUsuario";

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
            var queryString = "SELECT * FROM Usuario WHERE Activo = 1;";

            return CatchException(() =>
            {
                return Exec<BECuentaUsuario>(queryString);
            });
        }

        public BECuentaUsuario CargarPatentesYFamiliaUsuario(BECuentaUsuario usuario)
        {
            usuario.Familia = new List<BEFamilia>();
            usuario.Patentes = new List<BEPatente>();

            usuario.Familia = familiaDAL.ObtenerFamiliasUsuario(usuario.IdUsuario);
            usuario.Patentes = patenteDAL.ObtenerPatentesUsuario(usuario.IdUsuario);

            return usuario;
        }

        public bool Login(string email, string contrasenia)
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
                            var contEncriptada = MD5.ComputeMD5Hash(contrasenia);

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
    }


}


