using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChoreMonitor.Infrastructure
{
    public static class PagedListExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var subset = new List<T>();
            var totalCount = 0;

            if (superset != null)
            {
                totalCount = superset.Count();
                if (totalCount > 0)
                {
                    subset.AddRange(
                        (pageNumber == 1)
                            ? await superset
                                .Skip(0)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken)
                                .ConfigureAwait(false)
                            : await superset
                                .Skip(((pageNumber - 1) * pageSize))
                                .Take(pageSize)
                                .ToListAsync(cancellationToken)
                                .ConfigureAwait(false)
                    );
                }
            }

            return new PagedList<T>(subset, pageNumber, pageSize, totalCount);
        }

        public static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, int pageNumber, int pageSize)
        {
            return ToPagedListAsync<T>(superset, pageNumber, pageSize, CancellationToken.None);
        }
    }
}