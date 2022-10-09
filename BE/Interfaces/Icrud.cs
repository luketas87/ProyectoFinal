using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface ICrud<T> where T : IEntity
    {
        T GetById(Guid id);
        IList<T> GetAll();
        void Save(T entity);
        void Delete(T entity);

    }
}
