using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Computes the average of a sequence of <see cref="decimal"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="decimal"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal AverageOrDefault(this IEnumerable<decimal> source, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="decimal"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="decimal"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal? AverageOrDefault(this IEnumerable<decimal?> source, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="double"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="double"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault(this IEnumerable<double> source, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="double"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="double"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault(this IEnumerable<double?> source, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="int"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="int"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault(this IEnumerable<int> source, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="int"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="int"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault(this IEnumerable<int?> source, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="long"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="long"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault(this IEnumerable<long> source, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="long"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="long"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault(this IEnumerable<long?> source, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="float"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <see cref="float"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float AverageOrDefault(this IEnumerable<float> source, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="float"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="float"/> values</param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float? AverageOrDefault(this IEnumerable<float?> source, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of <see cref="decimal"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="decimal"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of nullable <see cref="decimal"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="decimal"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static decimal? AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal defaultValue = default(decimal))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of <see cref="double"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="double"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of nullable <see cref="double"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="double"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double defaultValue = default(double))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of <see cref="int"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="int"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of nullable <see cref="int"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="int"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, int defaultValue = default(int))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of <see cref="long"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="long"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of nullable <see cref="long"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="long"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static double? AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, long defaultValue = default(long))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of <see cref="float"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to  <see cref="float"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }

        /// <summary>
        /// Computes the average of a projection of nullable <see cref="float"/> values from a sequence of <typeparamref name="TSource"/> values or returns a default value if null or empty
        /// </summary>
        /// <param name="source">A sequence of <typeparamref name="TSource"/> values</param>
        /// <param name="selector">A projection from <typeparamref name="TSource"/> to nullable <see cref="float"/> </param>
        /// <param name="defaultValue">A value to use as a default if <paramref name="source"/> is null or empty</param>
        /// <returns>Average value for sequence or <paramref name="defaultValue"/> if sequence is null or empty</returns>
        public static float? AverageOrDefault <TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float defaultValue = default(float))
        {
            return source == null ? defaultValue : source.Select(selector).DefaultIfEmpty(defaultValue).Average();
        }
    }
}