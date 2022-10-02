using System.Collections.Generic;

namespace ChoreMonitor.Infrastructure
{
    public class PagedList<T>
    {
        private int _totalCount = 0;

        public PagedList(List<T> list, int pageNumber, int pageSize, int totalCount)
        {
            List = list;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public int PageCount { get; private set; }
        public int TotalCount
        {
            get { return _totalCount;}
            private set 
            {
                _totalCount = value;
                if (PageSize == 0 || _totalCount == 0)
                    return;
                PageCount = _totalCount / PageSize;
                if (TotalCount % PageSize > 0)
                    PageCount++;
            } 
        }
        public bool HasNextPage 
        {
            get { return (PageNumber < PageCount); }
        }
        public bool HasPreviousPage
        {
            get { return (PageNumber > 1); }
        }
        
    }
}