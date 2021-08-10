using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepo.GenRepository
{
    public interface IDataRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Change(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
