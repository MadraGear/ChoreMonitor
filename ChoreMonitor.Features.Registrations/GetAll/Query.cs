using MediatR;

namespace ChoreMonitor.Features.Registrations.GetAll
{
    public class Query : IRequest<Result>
    {
        public int? Items { get; set; }
        public int? Page { get; set; }
    }
}