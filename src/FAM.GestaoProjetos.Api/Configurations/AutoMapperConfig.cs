using AutoMapper;
using FAM.GestaoProjetos.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FAM.GestaoProjetos.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperServiceConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var mappingConfig = AutoMapperSetup.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
