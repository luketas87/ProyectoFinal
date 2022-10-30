using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Implementacion;

namespace DAL.DAO.Interfaces
{
    public interface DALICliente : ICrud<BECliente>
    {
        string ObtenerClienteConId(int? IdCliente);
    }
}
