using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ForIEnumerable
    {
        /// <summary>
        /// Checks to see if <paramref name="source"/> contains exactly <paramref name="count"/> instances of an item that meets a predicate
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="count">Number of specified matches</param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if <paramref name="source"/> contains exactly <paramref name="count"/> items that match <paramref name="predicate"/></returns>
        public static bool ContainsExactly <T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            Validate.Begin()
                .IsNotNegative(count, "count")
                .IsNotNull(source, "source")
                .IsNotNull(predicate, "predicate")
                .CheckForExceptions();

            return ContainsExactlyImplementation(source, count, predicate);
        }

        /// <summary>
        /// Checks to see if <paramref name="source"/> contains exactly <paramref name="count"/> instances of an item
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="count">Number of specified items</param>
        /// <returns>True if <paramref name="source"/> contains exactly <paramref name="count"/> items</returns>
        public static bool ContainsExactly <T>(this IEnumerable<T> source, int count)
        {
            Validate.Begin()
                .IsNotNegative(count, "count")
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ContainsExactlyImplementation(source, count);
        }

        internal static bool ContainsExactlyImplementation <T>(IEnumerable<T> source, int count)
        {
            Debug.Assert(source != null, "source cannot be null.");
            Debug.Assert(count >= 0, "count must be non-negative.");

            return source.Count() == count;
        }

        internal static bool ContainsExactlyImplementation <T>(IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            Debug.Assert(source != null, "source cannot be null.");
            Debug.Assert(count >= 0, "count must be non-negative.");
            Debug.Assert(predicate != null, "predicate cannot be null.");

            return source.Where(predicate).Take(count + 1).Count() == count;
        }
    }
}