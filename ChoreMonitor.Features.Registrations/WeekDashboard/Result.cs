namespace ChoreMonitor.Features.Registrations.WeekDashboard
{
    using System;
    using System.Collections.Generic;

    public class Result
    {
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        public IEnumerable<Day> Days { get; set; }

        public Result()
        {
            Days = new List<Day>();
        }

        public class Day
        {
            public string Name { get; set; }
            public IEnumerable<Registration> Registrations { get; set; }

            public Day()
            {
                Registrations = new List<Registration>();
            }
        }

        public class Registration
        {
            public string CookedOne { get; set; }
            public string PerformedChore { get; set; }
            public DateTime ExecutionDate { get; set; }

        }
    }
}