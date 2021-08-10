using GenericRepo.Context;
using GenericRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepo.GenRepository
{
    public class CustomerRepo<TEntity> : IDataRepository<Customer> where TEntity:class
    {
        readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Change(Customer customer, Customer entity)
        {
            customer.Name = entity.Name;
            customer.Email = entity.Email;
            customer.Mobile = entity.Mobile;

            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges(); ;
        }

        public Customer Get(int id)
        {
            return _context.Customers
              .FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
