using FAM.GestaoProjetos.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Integration.Tests
{
    public class Tests : IDisposable
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>().UseEnvironment("Test"));

            _client = _server.CreateClient();
        }

        [Test]
        public async Task BuscarTodasCidades()
        {
            var response = await _client.GetAsync("api/cidades");
            Assert.AreEqual(response.IsSuccessStatusCode, true);
        }

        public void Dispose()
        {
            _server?.Dispose();
            _client?.Dispose();
        }
    }
}