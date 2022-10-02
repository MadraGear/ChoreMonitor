namespace ChoreMonitor.Features.Users.GetByEmail
{
    using FluentValidation;
    
    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(q => q.Email)
                .EmailAddress();
        }
    }
}