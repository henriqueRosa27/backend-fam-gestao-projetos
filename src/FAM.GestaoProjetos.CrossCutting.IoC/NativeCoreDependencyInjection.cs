using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Infra.Context;
using FAM.GestaoProjetos.Infra.Repositories;
using FAM.GestaoProjetos.Services.Interfaces;
using FAM.GestaoProjetos.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FAM.GestaoProjetos.CrossCutting.IoC
{

    public static class NativeCoreInjector
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<GestaoProjetosContext>();

            #region Repositories
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            #endregion

            #region Services
            services.AddScoped<ICidadeService, CidadeService>();
            #endregion
            var isTest = configuration.GetSection("IsTest").Value;

            if(!string.IsNullOrEmpty(isTest) && isTest == "True")
                services.AddDbContext<GestaoProjetosContext>(options =>
                   options.UseInMemoryDatabase("GestaoProjetos"));
            else 
                services.AddDbContext<GestaoProjetosContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
