using Lab5.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Services
{
   public interface ICustomerService
    {
        Task<CustomerDto> GetAsync(int id);
        Task<IEnumerable<CustomerDto>> BrowseAsync(string name = null);
        Task<int> CreateAsync(string name, string surname, int year);
        Task UpdateAsync(int id, string name, string surname, int year);
        Task DeleteAsync(int id);

    }
}
