using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.DAO;
using EasyEncryption;
using DAL.Utilidades;
using DAL.DAO.Interfaces;
using BE.Interfaces;

namespace DAL.DAO.Implementacion
{
    public class DALBitacora : BaseDAO, DALIBitacora
    {
        public const string Key = "bZr2URKx";
        public const string Code = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;


        public DALBitacora(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public void CargarDVHBitacora()
        {
            var query = "SELECT * FROM Bitacora";
            var listaBitacora = new List<BEBitacora>();


            CatchException(() =>
            {
                listaBitacora = Exec<BEBitacora>(query);
            });

            foreach (var bitacora in listaBitacora)
            {
                var digito = digitoVerificador.CalcularDVHorizontal(new List<string>() 
                { bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad 
                });

                //HACER update

                var q = $"UPDATE Bitacora SET DVH = {digito} WHERE IdLog = @Id";

                CatchException(() =>
                {
                    Exec(
                        q,
                        new
                        {
                            @Id = bitacora.IdLog
                        });
                });
            }
        }

        public List<string> CargarUsuarios()
        {
            var queryString = "SELECT Usuario FROM Bitacora GROUP BY Usuario";

            return CatchException(() =>
            {
                return Exec<string>(queryString);
            });
        }

        public void FiltrarBitacora(BEFiltroBitacora filtros)
        {

            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND IdUsuario IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            CatchException(() =>
            {
                return Exec(queryString.ToString());
            });
        }

        public int GenerarDVH()
        {
            var bitacora = new BEBitacora();
            var Idbitacora = ObtenerUltimoIdBitacora();

            if (Idbitacora == 1)
            {
                bitacora.InformacionAsociada = "primer login";
                bitacora.Actividad = "Login";
                bitacora.Criticidad = "primer Login";
            }

            bitacora = LeerBitacoraConId(Idbitacora);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> 
            { 
                bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad 
            });
            return digitoVH;
        }

        public BEBitacora LeerBitacoraConId(int IdBitacora)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {IdBitacora}";

            return CatchException(() =>
            {
                return Exec<BEBitacora>(queryString)[0];
            });
        }

        public List<BEBitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta)
        {
            var queryImpl = "SET DATEFORMAT 'YMD' SELECT * from Bitacora WHERE ";
            var idsUsuParameters = string.Empty;
            var criticidadesParameters = string.Empty;
            var coma = string.Empty;
            var query = string.Empty;
            var bitacoras = new List<BEBitacora>();

            if (usuarios.Count != 0)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    idsUsuParameters += coma + "'" + usuarios[i] + "'";
                }

                queryImpl += string.Format("Usuario IN ({0}) AND  ", idsUsuParameters);
            }

            coma = string.Empty;
            if (criticidades.Count != 0)
            {
                for (int i = 0; i < criticidades.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    criticidadesParameters += coma + "'" + criticidades[i] + "'";
                }

                queryImpl += string.Format("Criticidad IN ({0}) AND  ", criticidadesParameters);
            }

            query = string.Format(queryImpl + " Fecha BETWEEN '{0}' AND '{1}'", desde, hasta);

            CatchException(() =>
            {
                bitacoras = Exec<BEBitacora>(query);
            });

            bitacoras.ForEach(x => x.InformacionAsociada = DES.Decrypt(x.InformacionAsociada, Key, Code));

            return bitacoras;
        }

        public int ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString).FirstOrDefault();
            });
        }

        public void RegistarEnBitactora(string mensaje, string logLevel, string logger)
        {
            
            var queryString = "INSERT INTO Bitacora([Fecha], [Criticidad], [Actividad], [InformacionAsociada], [Usuario], [DVH]) VALUES(@log_date, @log_level, @logger, @message, 'Sistema', @dvh)"; /*'Sistema'*/
            var date = DateTime.Now;
            var dvh = this.GenerarDVH();
                
            CatchException(() =>
                {
                    Exec(
                        queryString,
                        new
                        {
                            @log_date = date ,
                            @log_level = logLevel,
                            @logger = logger,
                            @message = DES.Encrypt(mensaje,Key, Code),
                            //@usuario = musuario,
                            @dvh = dvh
                        });
                });
        }


    }
}
