namespace ChoreMonitor.Features.Registrations.Create
{
    using System;
    using System.Globalization;
    using ChoreMonitor.Infrastructure;
    using FluentValidation;

    public class CommandValidator : AbstractValidator<Command>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public CommandValidator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;

            RuleFor(c => c.ChoreId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty();
            RuleFor(c => c.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty();


            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("NL-nl");
            DateTime now = dateTimeProvider.Now();
            
            RuleFor(c => c.ExecutionDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .ExclusiveBetween(now.FirstDayOfWeek(cultureInfo), now.LastDayOfWeek(cultureInfo));
        }
    }
}