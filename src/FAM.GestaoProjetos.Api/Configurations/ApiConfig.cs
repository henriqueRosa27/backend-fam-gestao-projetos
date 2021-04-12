using FAM.GestaoProjetos.Application.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FAM.GestaoProjetos.Api.Configurations
{
    public static class ApiConfig
    {
        public static void ApiServiceConfig(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ApiApplicationConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
