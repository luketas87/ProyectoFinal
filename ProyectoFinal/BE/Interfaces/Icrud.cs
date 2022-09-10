using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface Icrud<T>
    {
        bool Add(T AddedElement);
        IList<T> GetAll();

        bool Delete(T DeleteElement);
        bool Update(T DeleteElement);
    }
}
