using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;
using DAL.DAO.Implementacion;
using DAL.Utilidades;

namespace BLL.implementacion
{
    public class BLLBackup
    {
        string cmd;
        public void Backup(int bkp, string direccion)
        {

            string database = SqlUtilidades.Connection().Database;

            cmd = $"BACKUP DATABASE {database} TO ";

            for (int i = 1; i <= bkp; i++)
            {
                if (i < bkp)
                {
                    cmd += $"DISK = '{direccion}\\Backup-{i} - {DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")}.bak',";
                }
                else
                {
                    cmd += $"DISK = '{direccion}\\Backup-{i} - {DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")}.bak'";
                }
            }

            //DALCuentaUsuario dAOCuentaUsuario = new DALCuentaUsuario();

            //dAOCuentaUsuario.ExecuteNonQuery(cmd);
        }
    }
}
