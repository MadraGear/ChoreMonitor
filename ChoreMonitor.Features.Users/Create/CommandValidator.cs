namespace ChoreMonitor.Features.Users.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using ChoreMonitor.Data;
    using ChoreMonitor.Entities;
    using FluentValidation;
    using Microsoft.EntityFrameworkCore;

    public class CommandValidator : AbstractValidator<Command>
    {
        private ChoreMonitorContext _db;

        public CommandValidator(ChoreMonitorContext db)
        {
            _db = db;
        
            RuleFor(c => c.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(2, 50);
            RuleFor(c => c.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(IsEmailUniqueAsync);
        }

        private Task<bool> IsEmailUniqueAsync(string email, CancellationToken token)
        {
            return _db.Set<User>()
                .AllAsync(u => u.Email != email, token);
        }
    }
}