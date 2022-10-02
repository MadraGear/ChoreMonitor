namespace ChoreMonitor.Features.Chores.GetAll
{
    using System.Collections.Generic;

    public class Result
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public IEnumerable<Chore> Chores { get; set; }

        public Result()
        {
            Chores = new List<Chore>();
        }

        public class Chore
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}