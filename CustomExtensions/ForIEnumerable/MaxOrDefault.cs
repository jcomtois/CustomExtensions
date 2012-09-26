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
        /// Invokes a transform function on each element of a generic sequence and returns the maximum resulting value or default if empty
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="defaultValue">Optional default value to retrun.  Uses type default if not specified.</param>
        /// <returns>The maximum value in the sequence or default value if provided.</returns>
        public static TResult MaxOrDefault <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue = default(TResult))
        {
            Validate.Begin()
                .IsNotNull(selector, "selector")
                .CheckForExceptions();

            return MaxOrDefaultImplementation(source, selector, defaultValue);
        }

        /// <summary>
        /// Returns maximum value of generic sequence or default if empty
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="defaultValue">Optional default value to retrun.  Uses type default if not specified.</param>
        /// <returns>The maximum value in the sequence or default value if provided.</returns>
        public static T MaxOrDefault <T>(this IEnumerable<T> source, T defaultValue = default(T))
        {
            return MaxOrDefaultImplementation(source, defaultValue);
        }

        /// <summary>
        /// Computes the max of a sequence of <see cref="decimal"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="decimal"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal MaxOrDefault(this IEnumerable<decimal> source, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="decimal"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="decimal"/> values</param>
        /// <returns>Max value for sequence or <see cref="decimal"/> default if sequence is null or empty</returns>
        public static decimal? MaxOrDefault(this IEnumerable<decimal?> source)
        {
            return MaxOrDefault(source, default(decimal));
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="decimal"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="decimal"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal? MaxOrDefault(this IEnumerable<decimal?> source, decimal defaultValue)
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of <see cref="double"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="double"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault(this IEnumerable<double> source, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="double"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="double"/> values</param>
        /// <returns>Max value for sequence or <see cref="double"/> default if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<double?> source)
        {
            return MaxOrDefault(source, default(double));
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="double"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="double"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<double?> source, double defaultValue)
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of <see cref="int"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="int"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault(this IEnumerable<int> source, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="int"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="int"/> values</param>
        /// <returns>Max value for sequence or <see cref="int"/> default if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<int?> source)
        {
            return MaxOrDefault(source, default(int));
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="int"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="int"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<int?> source, int defaultValue)
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of <see cref="long"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="long"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault(this IEnumerable<long> source, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="long"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="long"/> values</param>
        /// <returns>Max value for sequence or <see cref="long"/> default if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<long?> source)
        {
            return MaxOrDefault(source, default(long));
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="long"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="long"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault(this IEnumerable<long?> source, long defaultValue)
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of <see cref="float"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="float"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float MaxOrDefault(this IEnumerable<float> source, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="float"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="float"/> values</param>
        /// <returns>Max value for sequence or <see cref="float"/> default if sequence is null or empty</returns>
        public static float? MaxOrDefault(this IEnumerable<float?> source)
        {
            return MaxOrDefault(source, default(float));
        }

        /// <summary>
        /// Computes the max of a sequence of nullable <see cref="float"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="float"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float? MaxOrDefault(this IEnumerable<float?> source, float defaultValue)
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of <see cref="decimal"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="decimal"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="decimal"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="decimal"/> </param>
        /// <returns>Max value for sequence or <see cref="decimal"/> if sequence is null or empty</returns>
        public static decimal? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return MaxOrDefault(source, selector, default(decimal));
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="decimal"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="decimal"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal defaultValue)
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of <see cref="double"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="double"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="double"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="double"/> </param>
        /// <returns>Max value for sequence or <see cref="double"/> defualt if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return MaxOrDefault(source, selector, default(double));
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="double"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="double"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double defaultValue)
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of <see cref="int"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="int"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="int"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="int"/> </param>
        /// <returns>Max value for sequence or <see cref="int"/> defualt if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return MaxOrDefault(source, selector, default(int));
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="int"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="int"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, int defaultValue)
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of <see cref="long"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="long"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="long"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="long"/> </param>
        /// <returns>Max value for sequence or <see cref="long"/> defualt if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return MaxOrDefault(source, selector, default(long));
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="long"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="long"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, long defaultValue)
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of <see cref="float"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="float"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="float"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="float"/> </param>
        /// <returns>Max value for sequence or <see cref="float"/> default if sequence is null or empty</returns>
        public static float? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return MaxOrDefault(source, selector, default(float));
        }

        /// <summary>
        /// Computes the max of a projection of nullable <see cref="float"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="float"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Max value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float? MaxOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float defaultValue)
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Max();
        }

        private static T MaxOrDefaultImplementation <T>(IEnumerable<T> source, T defaultValue)
        {
            return (source == null || source.IsEmpty()) ? defaultValue : source.Max();
        }

        private static TResult MaxOrDefaultImplementation <TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue)
        {
            Debug.Assert(selector != null, "selector != null");

            return (source == null || source.IsEmpty()) ? defaultValue : source.Max(selector);
        }
    }
}