namespace ChoreMonitor.Features.Chores.Create
{
    using MediatR;

    public class Command : IRequest<Result>
    {
        public string Name { get; set; }
        public short SomeValue { get; set; }
    }
}