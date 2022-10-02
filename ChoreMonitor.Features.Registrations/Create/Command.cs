namespace ChoreMonitor.Features.Registrations.Create
{
    using System;
    using MediatR;

    public class Command : IRequest<Result>
    {
        public int UserId { get; set; }
        public int ChoreId { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}