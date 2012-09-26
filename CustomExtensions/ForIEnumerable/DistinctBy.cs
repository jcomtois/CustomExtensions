using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomExtensions.Validation;
using MoreLinq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// WRAPPER FOR MORELINQ.DISTINCTBY
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the default eqaulity comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="keySelector"/> is null</exception>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
                                                                      Func<TSource, TKey> keySelector)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(keySelector, "keySelector")
                .CheckForExceptions();

            return DistinctByImplementation(source, keySelector);
        }

        /// <summary>
        /// WRAPPER FOR MORELINQ.DISTINCTBY
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <param name="comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="keySelector"/> is null</exception>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
                                                                      Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(keySelector, "keySelector")
                .CheckForExceptions();

            return DistinctByImplementation(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImplementation <TSource, TKey>(this IEnumerable<TSource> source,
                                                                                     Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(keySelector != null, "keySelector cannot be null");

            return MoreEnumerable.DistinctBy(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImplementation <TSource, TKey>(this IEnumerable<TSource> source,
                                                                                     Func<TSource, TKey> keySelector)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(keySelector != null, "keySelector cannot be null");

            return MoreEnumerable.DistinctBy(source, keySelector, null);
        }
    }
}