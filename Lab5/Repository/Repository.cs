using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.Models;

namespace Lab5.Repository
{
    public class Repository : IRepository
    {
        public readonly Db.Db _db;
     
        public Repository()
        {
            _db = new Db.Db();
        }

        public async Task<IEnumerable<Customer>> BrowseAsync(string name = null)
        {
            
            IEnumerable<Customer> customers;
            if (!string.IsNullOrWhiteSpace(name))
            {
                customers = _db.Customers.Where(x => x.Name.ToLower() == name.ToLower());
            }
            else
            {
                customers = _db.Customers;
            }
            return await Task.FromResult(customers);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _db.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetAsync(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return null; 
            return await Task.FromResult(customer);
        }
    }
}
