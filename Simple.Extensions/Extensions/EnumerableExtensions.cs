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
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="applyPredicate">A function which determines applying the predicate or not</param>
        /// <returns>Return IEnumerable that contains elements from the input sequence that satisfy the condition specified by predicate if the applyPredicate is true</returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source,
            Func<T, bool> predicate,
            Func<bool> applyPredicate)
        => applyPredicate() ? source.Where(predicate) : source;
    }
}
