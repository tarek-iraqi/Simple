using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate with apply predicate condtion either to apply the predicate or not
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains elements from the input sequence that satisfy the condition specified by <paramref name="predicate"/> if the <paramref name="applyPredicate"/> is true</returns>
        /// <exception cref="ArgumentNullException">source or predicate or applyPredicte is null</exception>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
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
        /// <param name="source">IEnumerable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> that contains elements from the input sequence that satisfy the condition specified by <paramref name="predicate"/> if the <paramref name="applyPredicate"/> is true</returns>
        /// <exception cref="ArgumentNullException">source or predicate or applyPredicte is null</exception>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate,
            Func<bool> applyPredicate)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (applyPredicate is null) throw new ArgumentNullException(nameof(applyPredicate));

            return applyPredicate() ? source.Where(predicate) : source;
        }
    }
}
