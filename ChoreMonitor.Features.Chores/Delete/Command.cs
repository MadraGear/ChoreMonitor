namespace ChoreMonitor.Features.Chores.Delete
{
    using MediatR;

    public class Command : IRequest
    {
        public int Id { get; set; }
    }
}