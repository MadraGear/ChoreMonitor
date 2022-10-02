namespace ChoreMonitor.Infrastructure.Exceptions
{
    using System;
    using System.Net;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ExceptionResponseFactory : IExceptionResponseFactory
    {
        private ILogger<ExceptionResponseFactory> _logger;

        public ExceptionResponseFactory(ILogger<ExceptionResponseFactory> logger)
        {
            _logger = logger;
        }

        public ErrorResponse Create(Exception exception)
        {
            return Handle((dynamic)exception);
        }

        private ErrorResponse Handle(NotFoundException exception)
        {
            return new ErrorResponse
            {
                HttpStatusCode = HttpStatusCode.NotFound,
                Message = exception.Message
            };
        }

        private ErrorResponse Handle(NotAuthorizedException exception)
        {
            return new ErrorResponse
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                Message = exception.Message
            };
        }

        private ErrorResponse Handle(InvalidOperationException exception)
        {
            return new ErrorResponse
            {
                HttpStatusCode = HttpStatusCode.Conflict,
                Message = exception.Message
            };
        }

        private ErrorResponse Handle(DbUpdateException exception)
        {
            return new ErrorResponse
            {
                HttpStatusCode = HttpStatusCode.Conflict,
                Message = exception.InnerException.Message
            };
        }

        private ErrorResponse Handle(Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception ocurred");
            return new ErrorResponse
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                Message = "Something went wrong. Contant the administrator.n\\" + exception.ToString()
            };
        }

    }
}