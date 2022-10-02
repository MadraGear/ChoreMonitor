namespace ChoreMonitor.Features.Registrations.Delete
{
    using MediatR;

    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}