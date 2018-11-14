using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.DTO;
using Lab5.Models;
using Lab5.Repository;

namespace Lab5.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly IRepository _repository;
        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> BrowseAsync(string name = null)
        {
            var customers = await _repository.BrowseAsync(name);
            var customersDto = customers.Select(x => new CustomerDto() {Id=x.Id, FullName = x.Name + " " + x.Surname });
            return customersDto;

        }

        public async Task<int> CreateAsync(string name, string surname, int year)
        {
            var customer = new Customer() { Name = name, Surname = surname, Year = year };
            await _repository.AddAsync(customer);
            return customer.Id;
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var customer = await _repository.GetAsync(id);
            if (customer == null)
                return null;
            return new CustomerDto() { Id = customer.Id, FullName = customer.Name + " " + customer.Surname };
        }

        
    }
}
