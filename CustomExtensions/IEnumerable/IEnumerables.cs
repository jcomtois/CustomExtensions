using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.IEnumerables
{
    /// <summary>
    /// Extensions for IEnumerable members
    /// </summary>
    public static class IEnumerables
    {

       /// <summary>
       /// Returns random element from sequence
       /// </summary>
       /// <param name="source">Source sequence</param>
       /// <param name="random">Random class instance</param>
       /// <typeparam name="T">Type conained in collection</typeparam>
       /// <returns>Random Elelemnt from sequence</returns>
       /// <exception cref="ArgumentNullException"></exception>
       /// <exception cref="InvalidOperationException"></exception>
       public static T RandomElement<T>(this IEnumerable<T> source, Random random)
       {
           if (source == null)
           {
               throw new ArgumentNullException("source");
           }
           if (random == null)
           {
               throw new ArgumentNullException("random");
           }

           var collection = source as ICollection;
           if (collection != null)
           {
               var count = collection.Count;
               if (count == 0)
               {
                   throw new InvalidOperationException("Sequence was empty.");
               }
               var index = random.Next(count);
               return source.ElementAt(index);
           }
           using (var iterator = source.GetEnumerator())
           {
               if (!iterator.MoveNext())
               {
                   throw new InvalidOperationException("Sequence was empty.");
               }
               var countSoFar = 1;
               T current = iterator.Current;
               while (iterator.MoveNext())
               {
                   countSoFar++;
                   if (random.Next(countSoFar) == 0)
                   {
                       current = iterator.Current;
                   }
               }
               return current;
           }
       }

        /// <summary>
        /// Determines whether or not IEnumerable is null or empty in an efficient way
        /// </summary>
        /// <typeparam name="T">The Type of elements in IEnumerable</typeparam>
        /// <param name="source">The sequence of values to examine</param>
        /// <returns>True if <paramref name="source"/> is null or empty.</returns>
        public static bool IsEmpty <T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var genericCollection = source as ICollection<T>;
            if (genericCollection != null)
            {
                return genericCollection.Count == 0;
            }

            var nonGenericCollection = source as ICollection;
            if (nonGenericCollection != null)
            {
                return nonGenericCollection.Count == 0;
            }

            return !source.Any();
        }

        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the maximum resulting value or default if empty
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="DefaultValue"> </param>
        /// <returns>The maximum value in the sequence or default value if provided.</returns>
        public static TResult MaxOrDefault <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult DefaultValue = default(TResult))
        {
            return source.IsEmpty() ? DefaultValue : source.Max(selector);
        }

        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the minimum resulting value or default if empty
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="DefaultValue"> </param>
        /// <returns>The minimum value in the sequence or default value if provided.</returns>
        public static TResult MinOrDefault <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult DefaultValue = default(TResult))
        {
            return source.IsEmpty() ? DefaultValue : source.Min(selector);
        }

       
        public static decimal AverageOrDefault(this IEnumerable<decimal> source, decimal DefaultValue = default(decimal))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static decimal? AverageOrDefault(this IEnumerable<decimal?> source, decimal DefaultValue = default(decimal))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault(this IEnumerable<double> source, double DefaultValue = default(double))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault(this IEnumerable<double?> source, double DefaultValue = default(double))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault(this IEnumerable<int> source, int DefaultValue = default(int))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault(this IEnumerable<int?> source, int DefaultValue = default(int))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault(this IEnumerable<long> source, long DefaultValue = default(long))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault(this IEnumerable<long?> source, long DefaultValue = default(long))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static float AverageOrDefault(this IEnumerable<float> source, float DefaultValue = default(float))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static float? AverageOrDefault(this IEnumerable<float?> source, float DefaultValue = default(float))
        {
            return source == null ? DefaultValue : source.DefaultIfEmpty(DefaultValue).Average();
        }

        public static decimal AverageOrDefault<TSource>(this IEnumerable<TSource> source,Func<TSource, decimal> selector, decimal DefaultValue = default(decimal))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();            
        }

        public static decimal? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal DefaultValue = default(decimal))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double DefaultValue = default(double))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double DefaultValue = default(double))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int DefaultValue = default(int))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector, int DefaultValue = default(int))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector, long DefaultValue = default(long))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static double? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector, long DefaultValue = default(long))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static float AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector, float DefaultValue = default(float))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        public static float? AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector, float DefaultValue = default(float))
        {
            return source == null ? DefaultValue : source.Select(selector).DefaultIfEmpty(DefaultValue).Average();
        }

        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the maximum resulting nullable value 
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The nullable maximum value in the sequence.</returns>
        public static TResult? NullableMax <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct
        {
            return source.IsEmpty() ? (TResult?)null : source.Max(selector);
        }

        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the minimum resulting nullable value 
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the minimum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The nullable minimum value in the sequence.</returns>
        public static TResult? NullableMin <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct
        {
            return source.IsEmpty() ? (TResult?)null : source.Min(selector);
        }

        public static IEnumerable<T> ToEnumerable<T>(this T Input)
        {
            return new [] { Input }.AsEnumerable();
        }
    }
}