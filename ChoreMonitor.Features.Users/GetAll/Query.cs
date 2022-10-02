namespace ChoreMonitor.Features.Users.GetAll
{
    using MediatR;
    
    public class Query : IRequest<Result>
    {
        public int? Items { get; set; }
        public int? Page { get; set; }
    }
}