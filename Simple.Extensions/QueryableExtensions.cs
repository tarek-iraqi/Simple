using Simple.Extensions.BaseTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source,
        int pageNumber,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        long count = 0;
        IEnumerable<T> items = Enumerable.Empty<T>();

        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        await Task.Run(() =>
        {
            count = source.LongCount();
            items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }, cancellationToken);

        return new PaginatedResult<T>(items, count, pageNumber, pageSize);
    }
}