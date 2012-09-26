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
        /// Invokes a transform function on each element of a generic sequence and returns the minimum resulting nullable value 
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The nullable minimum value in the sequence.</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="selector"/> is null</exception>
        public static TResult? NullableMin<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(selector, "selector")
                .CheckForExceptions();

            return NullableMinImplementation(source, selector);
        }

        private static TResult? NullableMinImplementation <TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct
        {
            Debug.Assert(selector != null, "selector != null");
            Debug.Assert(source != null, "source != null");

            return source.IsEmpty() ? default(TResult?) : source.Min(selector);
        }
    }
}