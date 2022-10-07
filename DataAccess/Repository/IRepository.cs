using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Delete(int id);

        T Update(int id, T entity);

        T Create(T entity);
    }
}
