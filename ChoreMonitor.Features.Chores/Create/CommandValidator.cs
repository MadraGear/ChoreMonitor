namespace ChoreMonitor.Features.Chores.Create
{
    using FluentValidation;

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(c => c.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}