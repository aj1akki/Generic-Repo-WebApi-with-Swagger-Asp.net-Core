
using GenericRepo.Context;
using GenericRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepo.GenRepository
{
    public class CustomerRepo<T> : IDataRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> entities;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Change(T entity)
        {
            _context.Update(entity);
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
           
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                entities.Remove(entity);
                _context.SaveChanges();
            }

        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
    }
}
