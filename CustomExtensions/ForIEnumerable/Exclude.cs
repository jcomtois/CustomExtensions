using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Excludes all instances of <paramref name="element"/> from a sequence
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to exclude</param>
        /// <returns><see cref="IEnumerable"/> of type <typeparamref name="T"/> excluding <paramref name="element"/></returns>
        public static IEnumerable<T> Exclude <T>(this IEnumerable<T> source, T element)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ExcludeImplementation(source, element);
        }

        /// <summary>
        /// Excludes all instances that match <paramref name="predicate"/> from a sequence
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="predicate">Function used to test for a match.  Matches will be excluded.</param>
        /// <returns><see cref="IEnumerable"/> of type <typeparamref name="T"/> excluding <paramref name="predicate"/> matches</returns>
        public static IEnumerable<T> Exclude <T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(predicate, "predicate")
                .CheckForExceptions();

            return ExcludeImplementation(source, predicate);
        }

        /// <summary>
        /// Excludes all instances that are in <paramref name="exclusions"/> from a sequence
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="exclusions">Sequence of type <typeparamref name="T"/> to exclude each element of from <paramref name="source"/></param>
        /// <returns><see cref="IEnumerable"/> of type <typeparamref name="T"/> excluding <paramref name="exclusions"/> matches</returns>
        public static IEnumerable<T> Exclude <T>(this IEnumerable<T> source, IEnumerable<T> exclusions)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(exclusions, "exclusions")
                .CheckForExceptions();

            return ExcludeImplementation(source, exclusions);
        }

        private static IEnumerable<T> ExcludeImplementation <T>(this IEnumerable<T> source, IEnumerable<T> exclusions)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(exclusions != null, "exclusions cannot be null");

            var exclusionHashSet = new HashSet<T>(exclusions); // HashSet will not be filled until first item requested due to yield return below
            foreach (var s in source)
            {
                if (!exclusionHashSet.Contains(s))
                {
                    yield return s;
                }
            }
        }

        private static IEnumerable<T> ExcludeImplementation <T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(predicate != null, "predicate cannot be null");

            return source.Where(i => !predicate(i));
        }

        private static IEnumerable<T> ExcludeImplementation <T>(IEnumerable<T> source, T element)
        {
            Debug.Assert(source != null, "source cannot be null");

            return ExcludeImplementation(source, s => Equals(s, element));
        }
    }
}