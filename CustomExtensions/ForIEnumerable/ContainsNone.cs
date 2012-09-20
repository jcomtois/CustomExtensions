using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Checks to see if <paramref name="source"/> contains no instances of an item that meets a predicate
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if <paramref name="source"/> contains no items that matches <paramref name="predicate"/></returns>
        public static bool ContainsNone <T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(predicate, "predicate")
                .CheckForExceptions();

            return ContainsNoneImplementation(source, predicate);
        }

        /// <summary>
        /// Checks to see if <paramref name="source"/> contains no instances
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <returns>True if <paramref name="source"/> contains no items</returns>
        public static bool ContainsNone <T>(this IEnumerable<T> source)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ContainsNoneImplementation(source);
        }

        internal static bool ContainsNoneImplementation <T>(IEnumerable<T> source)
        {
            Debug.Assert(source != null, "source cannot be null");

            return !source.Any();
        }

        internal static bool ContainsNoneImplementation <T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(predicate != null, "predicate cannot be null");

            return ContainsExactlyImplementation(source, 0, predicate);
        }
    }
}