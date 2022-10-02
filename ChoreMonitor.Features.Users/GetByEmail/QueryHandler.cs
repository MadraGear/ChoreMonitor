namespace ChoreMonitor.Features.Users.GetByEmail
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ChoreMonitor.Data;
    using ChoreMonitor.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class QueryHandler : IRequestHandler<Query, Result>
    {
        private readonly ChoreMonitorContext _db;
        private readonly IMapper _mapper;

        public QueryHandler(ChoreMonitorContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Result> Handle(Query query, CancellationToken token)
        {
            var result = await _db.Set<User>()
                .AsNoTracking()
                .Where(u => u.Email == query.Email)
                .ProjectTo<Result>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(token);


            return result;
        }
    }
}