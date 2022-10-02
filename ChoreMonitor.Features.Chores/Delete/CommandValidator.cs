namespace ChoreMonitor.Features.Chores.Delete
{
    using ChoreMonitor.Data;
    using FluentValidation;
    using ChoreMonitor.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class CommandValidator : AbstractValidator<Command>
    {
        private readonly ChoreMonitorContext _db;

        public CommandValidator(ChoreMonitorContext db)
        {
            _db = db;

            RuleFor(c => c)
                .MustAsync(MustExistAsync)
                .WithMessage(c => $"Chore with id {c.Id} not found");            
        }

        private Task<bool> MustExistAsync(Command command, CancellationToken token)
        {
            return _db.Set<Chore>()
                .AnyAsync(u => u.Id == command.Id, token);
        }
    }
}