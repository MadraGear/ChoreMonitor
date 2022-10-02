namespace ChoreMonitor.Features.Users.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class CreateBehavior
        : IPipelineBehavior<Command, Result>
    {
        public async Task<Result> Handle(
            Command request, CancellationToken cancellationToken, 
            RequestHandlerDelegate<Result> next)
        {
            Result response = await next();

            response.Email = $"{response.Email} {nameof(CreateBehavior)}";

            return response;
        }
    }
}