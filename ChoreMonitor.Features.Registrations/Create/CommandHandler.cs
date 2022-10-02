namespace ChoreMonitor.Features.Registrations.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChoreMonitor.Data;
    using ChoreMonitor.Entities;
    using MediatR;

    public class CommandHandler : IRequestHandler<Command, Result>
    {
        private readonly ChoreMonitorContext _db;
        private readonly IMapper _mapper;

        public CommandHandler(ChoreMonitorContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Result> Handle(Command command, CancellationToken token)
        {
            Registration newRegistration = _mapper.Map<Command, Registration>(command);

            await _db.Set<Registration>().AddAsync(newRegistration, token);
            await _db.SaveChangesAsync(token);

            return _mapper.Map<Registration, Result>(newRegistration);

        }
    }
}