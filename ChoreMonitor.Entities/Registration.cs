namespace ChoreMonitor.Entities
{
    using System;

    public class Registration
    {
        public Guid Id { get; set; }
        public DateTime ExecutionDate { get; set; }        
        public int ChoreID { get; set; }
        public Chore Chore { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}