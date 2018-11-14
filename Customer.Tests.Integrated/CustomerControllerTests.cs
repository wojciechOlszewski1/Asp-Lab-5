using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;
using Lab5;
using System.Threading.Tasks;

namespace Customer.Tests.Integrated
{
   public class CustomerControllerTests 
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
       
        public CustomerControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task fetching()
        {
            var response = await _client.GetAsync("api/Customer");
        }
    }
}
