using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SokolovskiyClinicService.DataHandler;
using SokolovskiyClinicService.DataHandler.Response;

namespace SokolovskiyClinicService.Exceptions
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception is WarningException
                ? ControllerResponse.Warning(exception.Message)
                : ControllerResponse.Exception(ExceptionMessages.Error);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}