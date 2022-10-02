namespace  ChoreMonitor.Infrastructure.Exceptions
{
    using System;

    public interface IExceptionResponseFactory
    {
        ErrorResponse Create(Exception exception);
    }
}