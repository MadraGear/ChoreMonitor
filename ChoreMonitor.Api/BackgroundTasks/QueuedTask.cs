namespace ChoreMonitor.Api.BackgroundTasks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ChoreMonitor.Features.Chores.Create;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class QueuedTask : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ITaskQueue _taskQueue;

        public QueuedTask(IServiceScopeFactory scopeFactory, ITaskQueue taskQueue)
        {
            _scopeFactory = scopeFactory;
            _taskQueue = taskQueue;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                foreach (string item in _taskQueue.GetConsumingEnumerable())
                {
                    using (IServiceScope scope = _scopeFactory.CreateScope())
                    {
                        IMediator mediator = scope.ServiceProvider.GetService<IMediator>();
                        mediator.Send(new Command { Name = item });
                    }
                }
            });

        }
    }
}