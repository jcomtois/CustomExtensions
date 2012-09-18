using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ForIEnumerable
    {
        /// <summary>
        /// Checks to see if source contains exactly count number of items that meets a condition
        /// </summary>
        /// <typeparam name="T">Type contained in source</typeparam>
        /// <param name="source">IEnumerable of type T</param>
        /// <param name="count">Number of specified matches</param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if source contains exact number of matches</returns>
        public static bool ContainsExactly <T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            if (count == 1)
            {
                return source.ContainsOnlyOne(predicate);
            }

            if (count == 0)
            {
                return source.ContainsNone(predicate);
            }

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return source.Count(predicate).Equals(count);
        }
    }
}