namespace ChoreMonitor.Infrastructure.Exceptions
{
    using System.Net;

    public class ErrorResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
    }
}