namespace ChoreMonitor.Features.Chores.Create
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
            Chore newChore = _mapper.Map<Command, Chore>(command);

            await _db.Set<Chore>().AddAsync(newChore, token);
            await _db.SaveChangesAsync(token);

            return _mapper.Map<Chore, Result>(newChore);

        }
    }
}