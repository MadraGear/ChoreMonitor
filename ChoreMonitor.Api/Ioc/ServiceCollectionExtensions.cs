namespace ChoreMonitor.Api
{
    using System.Reflection;
    using AutoMapper;
    using ChoreMonitor.Api.BackgroundTasks;
    using ChoreMonitor.Data;
    using ChoreMonitor.Infrastructure;
    using ChoreMonitor.Infrastructure.Exceptions;
    using FluentValidation.AspNetCore;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Create = ChoreMonitor.Features.Users.Create;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHostedService, QueuedTask>();

            Assembly[] assemblies = new Assembly[]
            {
                typeof(ChoreMonitor.Features.Chores.Create.Command).Assembly,
                typeof(ChoreMonitor.Features.Registrations.Create.Command).Assembly,
                typeof(ChoreMonitor.Features.Users.Create.Command).Assembly
            };

            services.AddTransient<IExceptionResponseFactory, ExceptionResponseFactory>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<ITaskQueue, TaskQueue>();

            // services.AddDbContext<ChoreMonitorContext>(options =>
            //     options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

            services.AddDbContext<ChoreMonitorContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddControllers()
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblies(assemblies);
                });
            services.AddAutoMapper(assemblies);
            services.AddMediatR(assemblies);


            // NB: volgorde van registratie is volgorde van uitvoering
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(TransactionBehavior<,>));

            services.AddScoped(
                typeof(IPipelineBehavior<Create.Command, Create.Result>),
                typeof(Create.CreateBehavior));

            //services.AddHostedService<QueuedTask>();
            

            return services;
        }
    }
}