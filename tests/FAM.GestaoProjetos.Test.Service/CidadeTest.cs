using FAM.GestaoProjetos.Infra.Context;
using FAM.GestaoProjetos.Services.Interfaces;
using FAM.GestaoProjetos.Services.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FAM.GestaoProjetos.Test.Service
{
    class CidadeTest
    {
        private DbContextOptions<GestaoProjetosContext> _contextOptions;

        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            _contextOptions = new DbContextOptionsBuilder<GestaoProjetosContext>().UseSqlite(connection).Options;

            var server = TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Test, Category("Cidade.Tests"), Description("Buscar Todas Cidade Com Sucesso")]
        public void TestBuscarTodasCidadesComSucesso()
        {
            using (var context = new GestaoProjetosContext(_contextOptions))
            {
                //var test = await _service.BuscarTodos();
            }
            Assert.Pass();
        }
    }
}
