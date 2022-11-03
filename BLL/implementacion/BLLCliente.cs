using BE.Implementacion;
using BLL.Interfaces;
using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.implementacion
{
    public class BLLCliente : BLLICliente
    {
        public BECliente ClienteSeleccionado { get; set; } = new BECliente();

        private readonly DALICliente clienteDAL;


        public BLLCliente(DALICliente clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public string ObtenerClienteConId(int? IdCliente)
        {
            return clienteDAL.ObtenerClienteConId(IdCliente);
        }

        public bool Crear(BECliente objAlta)
        {
            return clienteDAL.Crear(objAlta);
        }

        public List<BECliente> Cargar()
        {
            throw new NotImplementedException();
        }

        public bool Borrar(BECliente objDel)
        {
            return clienteDAL.Borrar(objDel);
        }

        public bool Actualizar(BECliente objUpd)
        {
            return clienteDAL.Actualizar(objUpd);
        }
    }
}
