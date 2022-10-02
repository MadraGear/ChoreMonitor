namespace ChoreMonitor.Features.Registrations.GetAll
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ChoreMonitor.Data;
    using ChoreMonitor.Entities;
    using ChoreMonitor.Infrastructure;
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
            PagedList<Result.Registration> pagedList = await _db.Set<Registration>()
                    .AsNoTracking()
                    .Include(r => r.User)
                    .Include(r => r.Chore)
                    .ProjectTo<Result.Registration>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(query.Page ?? 1, query.Items ?? 10);

            return new Result()
            {
                PageSize = pagedList.PageSize,
                PageNumber = pagedList.PageNumber,
                HasNextPage = pagedList.HasNextPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                Registrations = pagedList.List
            };
        }
    }
}