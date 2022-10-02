namespace ChoreMonitor.Features.Users.GetAll
{
    using System.Collections.Generic;

    public class Result
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public IEnumerable<User> Users { get; set; }

        public Result()
        {
            Users = new List<User>();
        }

        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }
    }
}