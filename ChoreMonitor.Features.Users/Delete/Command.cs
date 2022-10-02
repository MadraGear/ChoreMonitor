namespace ChoreMonitor.Features.Users.Delete
{
    using MediatR;

    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}