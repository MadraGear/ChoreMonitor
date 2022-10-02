namespace ChoreMonitor.Api.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using ChoreMonitor.Infrastructure.Exceptions;
    using System.Text.Json;

    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionResponseFactory _exceptionResponseFactory;

        public ErrorHandler(RequestDelegate next, IExceptionResponseFactory exceptionResponseFactory)
        {
            _next = next;
            _exceptionResponseFactory = exceptionResponseFactory;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */ )
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ErrorResponse errorResponse = _exceptionResponseFactory.Create(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.HttpStatusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { error = errorResponse.Message }));
        }
    }
}