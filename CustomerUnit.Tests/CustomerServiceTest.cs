using FluentAssertions;
using Lab5.Models;
using Lab5.Repository;
using Lab5.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerUnit.Tests
{
   public class CustomerServiceTest
    {
        [Fact]
        public async Task invoke_create_customer()
        {
            //arrange
            var customerRepositoryMock = new Mock<IRepository>();
            ICustomerService service = new CustomerService(customerRepositoryMock.Object);

            //act
            await service.CreateAsync("Adam", "Adam", 14);

            //assert
            customerRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once());

        }

        [Fact]
        public async Task invoke_get_customer()
        {
            //arrange
            Customer customer = new Customer() {Id=5, Name = "Piotr", Surname = "Kowalski", Year = 14 };
            var customerRepositoryMock = new Mock<IRepository>();
            ICustomerService service = new CustomerService(customerRepositoryMock.Object);

            customerRepositoryMock.Setup(x => x.GetAsync(customer.Id)).ReturnsAsync(customer);
            //act
            var customerDto = await service.GetAsync(customer.Id);

            //assert
            customerRepositoryMock.Verify(x => x.GetAsync(customer.Id), Times.Once());
            customerDto.Should().NotBeNull();
            customerDto.Id.Equals(customer.Id);
        }
    }
}
