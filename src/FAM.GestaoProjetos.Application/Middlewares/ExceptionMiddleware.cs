using FAM.GestaoProjetos.Application.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Application.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                await TratarDefautlErro((int)ex.StatusCode, ex.Message, httpContext);

            }
            catch (Exception ex)
            {
                await TratarDefautlErro(500, JsonSerializer.Serialize(new { erro = "Erro inesperado" }), httpContext);
            }
        }

        private async Task TratarDefautlErro(int statusCode, string mensagem, HttpContext context)
        {
            var bytes = Encoding.UTF8.GetBytes(mensagem);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
