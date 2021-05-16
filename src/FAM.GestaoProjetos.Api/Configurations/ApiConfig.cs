using FAM.GestaoProjetos.Application.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text.Json;

namespace FAM.GestaoProjetos.Api.Configurations
{
    public static class ApiConfig
    {
        public class SnakeCasePropertyNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name)
            {
                return string.Concat(name.Select((character, index) =>
                        index > 0 && char.IsUpper(character)
                            ? "_" + character
                            : character.ToString()))
                    .ToLower();
            }
        }

        public static void ApiServiceConfig(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCasePropertyNamingPolicy());
        }

        public static void ApiApplicationConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
