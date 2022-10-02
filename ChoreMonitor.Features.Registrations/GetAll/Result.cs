namespace ChoreMonitor.Features.Registrations.GetAll
{
    using System;
    using System.Collections.Generic;

    public class Result
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }

        public Result()
        {
            Registrations = new List<Registration>();
        }

        public class Registration
        {
            public int Id { get; set; }
            public User CookedOne { get; set; }
            public Chore PerformedChore { get; set; }
            public DateTime ExecutionDate { get; set; }


        }

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