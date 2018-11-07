using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.DTO;
using Lab5.Models;

namespace Lab5.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly Db.Db _db;
        public CustomerService()
        {
            _db = new Db.Db();
        }

        public async Task<IEnumerable<CustomerDto>> BrowseAsync(string name = null)
        {
            var customers = _db.Customers;
            IEnumerable<CustomerDto> customersDto;
            if (!string.IsNullOrWhiteSpace(name))
            {
                customersDto = _db.Customers.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new CustomerDto() { Id = x.Id, FullName = x.Name + " " + x.Surname });
            }
            else
                customersDto = customers.Select(x => new CustomerDto() { Id = x.Id, FullName = x.Name + " " + x.Surname });
            return await Task.FromResult(customersDto);

        }

        public async Task<int> CreateAsync(string name, string surname, int year)
        {
            var customer = new Customer() { Name = name, Surname = surname, Year = year };
            _db.Add(customer);
            await _db.SaveChangesAsync();
            return customer.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new NullReferenceException();
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();

        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return null;
            CustomerDto customerDto = new CustomerDto() { Id = customer.Id, FullName = customer.Name + " " + customer.Surname };
            return await Task.FromResult(customerDto);
        }

        public async Task UpdateAsync(int id, string name, string surname, int year)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new NullReferenceException();
            customer.Name = name;
            customer.Surname = surname;
            customer.Year = year;
        }
    }
}
