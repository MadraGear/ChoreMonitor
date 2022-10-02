namespace ChoreMonitor.Features.Users.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChoreMonitor.Data;
    using ChoreMonitor.Entities;
    using ChoreMonitor.Infrastructure.Exceptions;
    using MediatR;

    public class CommandHandler : IRequestHandler<Command>
    {
        private readonly ChoreMonitorContext _db;
        private readonly IMapper _mapper;

        public CommandHandler(ChoreMonitorContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command command, CancellationToken token)
        {
            _db.Set<User>().Remove(await _db.Set<User>().FindAsync(command.Id));
            await _db.SaveChangesAsync(token);

            return default;
        }
    }
}