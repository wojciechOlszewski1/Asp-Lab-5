using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.DTO;
using Lab5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var events = await _customerService.GetAsync(id);
            return Json(events);
        }
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var events = await _customerService.BrowseAsync(name);
            return Json(events);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCustomerDto customer)
        {
            var id = await _customerService.CreateAsync(customer.Name, customer.Surname, customer.Year);
            return Created($"api/Customer/{id}", null);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CreateCustomerDto customer)
        {
            await _customerService.UpdateAsync(id, customer.Name, customer.Surname, customer.Year);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}