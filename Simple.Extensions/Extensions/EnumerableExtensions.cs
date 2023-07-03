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

        /// <summary>
        /// Determines whether a sequence contains any duplicate elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to check for duplicates</param>
        /// <returns>true if the source sequence contains any duplicate elements; otherwise, false</returns>
        public static bool HasDuplicates<TSource>(this IEnumerable<TSource> source)
            => source.GroupBy(e => e).Any(e => e.Count() > 1);

        /// <summary>
        /// Returns duplicate elements in a sequence if exist
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to get duplicate elements</param>
        /// <returns><see cref="IEnumerable{TSource}"/> contains duplicate elements</returns>
        public static IEnumerable<TSource> FindDuplicates<TSource>(this IEnumerable<TSource> source)
        {
            HashSet<TSource> items = new HashSet<TSource>();

            foreach (TSource item in source)
                if (items.Add(item) is false) yield return item;
        }

        /// <summary>
        /// Remove duplicate elements in a sequence if exist
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to remove duplicate elements</param>
        /// <returns><see cref="IEnumerable{TSource}"/> contains unduplicate elements</returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IEnumerable<TSource> source)
        {
            HashSet<TSource> items = new HashSet<TSource>();

            foreach (TSource item in source)
                if (items.Add(item) is true) yield return item;
        }

        /// <summary>
        /// Returns duplicate elements with number of duplication
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to count number of duplication for duplicate elements</param>
        /// <returns><see cref="Dictionary{TSource, count}"/> contains duplicate elements and their count</returns>
        public static Dictionary<TSource, int> CountDuplicates<TSource>(this IEnumerable<TSource> source)
            => source.GroupBy(e => e).Where(e => e.Count() > 1).ToDictionary(k => k.Key, v => v.Count());

        /// <summary>
        /// Returns a number that represents how many elements in the specified sequence are duplicated
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">IEnumerable to count total number of duplicate elements</param>
        /// <returns><see cref="int"/> of total number of duplicate elements</returns>
        public static int TotalDuplicates<TSource>(this IEnumerable<TSource> source)
            => source.GroupBy(e => e).Count(e => e.Count() > 1);
    }
}
