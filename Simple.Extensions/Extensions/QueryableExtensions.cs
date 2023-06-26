using Simple.Extensions.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Retrieve number of records with pagination data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNumber">The number of page</param>
        /// <param name="pageSize">The amount of records per page, by default is set to 10</param>
        /// <param name="cancellationToken"></param>
        /// <returns>PaginatedResult with IEnumerable of records and pagination meta data</returns>
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

        /// <summary>
        /// Filters a sequence of values based on a predicate with apply predicate condtion either to apply the predicate or not
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">IQueryable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>Return IQueryable that contains elements from the input sequence that satisfy the condition specified by predicate if the applyPredicate is true</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate,
            Func<bool> applyPredicate)
        => applyPredicate() ? source.Where(predicate) : source;
    }
}