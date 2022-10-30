using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface ICrud<T> 
    {
        bool Crear(T objAlta);
        List<T> Cargar();
        bool Borrar(T objDel);
        bool Actualizar(T objUpd);
    }
}
