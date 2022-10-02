namespace ChoreMonitor.Features.Users.Create
{
    using MediatR;

    public class Command : IRequest<Result>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}