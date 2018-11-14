using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Repository
{
    public interface IRepository
    {
        Task<Customer> GetAsync(int id);
        Task<IEnumerable<Customer>> BrowseAsync(string name = null);
        Task<Customer> AddAsync(Customer customer);
    }
}
