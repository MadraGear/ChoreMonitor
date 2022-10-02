namespace ChoreMonitor.Features.Users.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;

    public class UserCreatedProcessorLast : IRequestPostProcessor<Command, Result>
    {
        private readonly ILogger<UserCreatedProcessorLast> _logger;

        public UserCreatedProcessorLast(ILogger<UserCreatedProcessorLast> logger)
        {
            _logger = logger;
        }

        public Task Process(Command request, Result response, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                response.Email = $"{response.Email} {nameof(UserCreatedProcessorLast)}";
                using (_logger.BeginScope(this))
                {
                    _logger.LogInformation($"Calling UserCreatedProcessorLast: {response.Email}");
                }
            });
        }
    }
}