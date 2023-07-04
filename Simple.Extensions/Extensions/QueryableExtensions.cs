using Simple.Extensions.BaseTypes;
using Simple.Extensions.ExtensionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">An IQueryable to paginate</param>
        /// <param name="pageNumber">The number of page</param>
        /// <param name="pageSize">The amount of records per page, by default is set to 10</param>
        /// <param name="cancellationToken"></param>
        /// <returns>PaginatedResult with IEnumerable of records and pagination meta data</returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source,
            int pageNumber,
            int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

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
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IQueryable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>An <see cref="IQueryable{TSource}"/> that contains elements from the input sequence that satisfy the condition specified by <paramref name="predicate"/> if the <paramref name="applyPredicate"/> is true</returns>
        /// <exception cref="ArgumentNullException">source or predicate or applyPredicte is null</exception>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            Func<bool> applyPredicate)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (applyPredicate is null) throw new ArgumentNullException(nameof(applyPredicate));

            return applyPredicate() ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate with apply predicate condtion either to apply the predicate or not
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IQueryable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>An <see cref="IQueryable{TSource}"/> that contains elements from the input sequence that satisfy the condition specified by <paramref name="predicate"/> if the <paramref name="applyPredicate"/> is true</returns>
        /// <exception cref="ArgumentNullException">source or predicate or applyPredicte is null</exception>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, int, bool>> predicate,
            Func<bool> applyPredicate)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (applyPredicate is null) throw new ArgumentNullException(nameof(applyPredicate));

            return applyPredicate() ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Sorts the elements of a sequence according to a key(s) and order direction
        /// </summary>
        /// <typeparam name="TSource">A sequence of values to order</typeparam>
        /// <param name="source">The type of the elements of source</param>
        /// <param name="orderByQueryString">string contains the key(s) and order direction to sort the sequence with,
        /// if the keys is unknown or the parameter is null or empty the sequence will be sorted by first property in ascending order</param>
        /// <returns><see cref="IQueryable{T}"/> whose elements are sorted according to a key and direction</returns>
        public static IQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, string orderByQueryString = default)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                orderByQueryString = string.Empty;

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<TSource>(orderByQueryString);

            return string.IsNullOrWhiteSpace(orderQuery)
                ? source
                : source.OrderBy(orderQuery);
        }
    }
}