using Lab5.DTO;
using Lab5.Models;
using Lab5.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerUnit.Tests
{

   public class CustomerRepositoryTest
    {
        [Fact]
        public async Task add_user_to_db()
        {
            //arrange
            Customer customer = new Customer() { Name = "Piotr", Surname = "Kowalski", Year = 14 };
            IRepository repository = new Repository();

            //act
           var customerInDb =  await repository.AddAsync(customer);

            //assert
            Assert.Equal(customerInDb,customer);
        }
        
        
    }
}
