using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    public class ExceptionMiddleware
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ExceptionMiddleware(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if ((contextFeature == null) || (contextFeature.Error == null))
                return;

            context.Response.StatusCode = (int)GetErrorCode(contextFeature.Error);
            context.Response.ContentType = "application/json";

            if (contextFeature.Error is ApplicationException)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error.Message));
                return;
            }

            if (hostingEnvironment.EnvironmentName == "Development")
            {
                string erro = JsonConvert.SerializeObject(new ProblemDetails()
                {
                    Status = context.Response.StatusCode,
                    Title = DateTime.Now.ToString() + " - " + contextFeature.Error.Message,
                    Detail = contextFeature.Error.StackTrace
                });
                Console.WriteLine(erro);
                await context.Response.WriteAsync(erro);
            }
            else
                await context.Response.WriteAsync(JsonConvert.SerializeObject("Erro inesperado"));
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                case ApplicationException _:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}