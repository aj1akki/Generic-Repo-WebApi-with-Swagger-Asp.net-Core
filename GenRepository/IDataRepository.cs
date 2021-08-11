using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepo.GenRepository
{
    public interface IDataRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Change(T entity);
        void Delete(T entity);
    }
}
