namespace ChoreMonitor.Features.Users.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;

    public class UserCreatedProcessor : IRequestPostProcessor<Command, Result>
    {
        private readonly ILogger<UserCreatedProcessor> _logger;

        public UserCreatedProcessor(ILogger<UserCreatedProcessor> logger)
        {
            _logger = logger;
        }
        public Task Process(Command request, Result response, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {

                response.Email = $"{response.Email} {nameof(UserCreatedProcessor)}";
                using (_logger.BeginScope(this))
                {
                    _logger.LogInformation($"Calling UserCreatedProcessor: {response.Email}");
                }
            });
        }
    }
}