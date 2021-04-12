using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FAM.GestaoProjetos.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void SwaggerServiceConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FAM.GestaoProjetos.Api", Version = "v1" });
            });
        }

        public static void SwaggerApplicationConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FAM.GestaoProjetos.Api v1"));
            }
        }
    }
}
