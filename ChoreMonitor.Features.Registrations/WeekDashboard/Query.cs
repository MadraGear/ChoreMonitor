namespace ChoreMonitor.Features.Registrations.WeekDashboard
{
    using System;
    using MediatR;

    public class Query : IRequest<Result>
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
    }
}