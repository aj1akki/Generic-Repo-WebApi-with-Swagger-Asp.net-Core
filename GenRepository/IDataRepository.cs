using System.Collections.Generic;

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
