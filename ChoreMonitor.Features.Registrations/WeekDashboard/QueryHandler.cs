namespace ChoreMonitor.Features.Registrations.WeekDashboard
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
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
        private readonly IDateTimeProvider _dateTimeProvider;

        public QueryHandler(ChoreMonitorContext db, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            _db = db;
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result> Handle(Query query, CancellationToken token)
        {
            DateTime date = query.Year.HasValue && query.Month.HasValue && query.Day.HasValue
                ? new DateTime(query.Year.Value, query.Month.Value, query.Day.Value)
                : _dateTimeProvider.Now();
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("NL-nl");

            DateTime firstDay = date.FirstDayOfWeek(cultureInfo);
            DateTime lastDay = date.LastDayOfWeek(cultureInfo);

            List<Result.Registration> registrations = await GetRegistrations(firstDay, lastDay);
            List<Result.Day> days = ContructDays(registrations);

            return new Result()
            {
                FirstDay = firstDay,
                LastDay = lastDay,
                Days = days
            };
        }

        private Task<List<Result.Registration>> GetRegistrations(DateTime firstDay, DateTime lastDay)
        {
            return _db.Set<Registration>()
                .AsNoTracking()
                .Where(r => r.ExecutionDate > firstDay && r.ExecutionDate < lastDay)
                .Include(r => r.User)
                .Include(r => r.Chore)
                .ProjectTo<Result.Registration>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private static List<Result.Day> ContructDays(List<Result.Registration> registrations)
        {
            Dictionary<DayOfWeek, List<Result.Registration>> registrationsByWeek = registrations
                .GroupBy(r => r.ExecutionDate.DayOfWeek)
                .ToDictionary(g => g.Key, g => g.ToList());

            return  Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .Select(d => CreateDay(d, registrationsByWeek))
                .ToList();
        }

        private static Result.Day CreateDay(DayOfWeek dayOfWeek, Dictionary<DayOfWeek, List<Result.Registration>> registrations)
        {
            return new Result.Day
            {
                Name = dayOfWeek.ToString(),
                Registrations = registrations.ContainsKey(dayOfWeek) ? registrations[dayOfWeek] : new List<Result.Registration>()
            };
        }
    }
}