﻿using BE.Implementacion;
using BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface BLLICliente : ICrud<BECliente>
    {
        string ObtenerClienteConId(int? IdCliente);
    }
}
