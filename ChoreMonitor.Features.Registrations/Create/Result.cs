namespace ChoreMonitor.Features.Registrations.Create
{
    using System;
    
    public class Result
    {
        public int Id { get; set; }
        public User CookedOne { get; set; }
        public Chore PerformedChore { get; set; }
        public DateTime ExecutionDate { get; set; }   

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Chore
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}