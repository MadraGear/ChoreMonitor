namespace ChoreMonitor.Features.Users.GetByEmail
{
    using MediatR;
    
    public class Query : IRequest<Result>
    {
        public string Email { get; set; }
    }
}