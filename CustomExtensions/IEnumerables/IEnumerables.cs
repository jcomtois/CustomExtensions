using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.Strings;

namespace CustomExtensions.IEnumerables
{
    /// <summary>
    /// Extensions for IEnumerable members
    /// </summary>
    public static class IEnumerables
    {
        /// <summary>
        /// Checks to see if collection contains exactly count number of items that meets a condition
        /// </summary>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="count">Number of specified matches</param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if collection contains exact number of matches</returns>
        public static bool ContainsExactly <T>(this IEnumerable<T> collection, int count, Func<T, bool> predicate)
        {
            if (count == 1)
            {
                return collection.ContainsOnlyOne(predicate);
            }

            if (count == 0)
            {
                return collection.ContainsNone(predicate);
            }

            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return collection.Count(predicate).Equals(count);
        }

        /// <summary>
        /// Checks to see if collection contains exactly one instance of an item that meets a condition
        /// </summary>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if collection contains exactly one item that matches</returns>
        public static bool ContainsOnlyOne <T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            var found = false;
            foreach (var i in collection)
            {
                if (predicate(i))
                {
                    if (!found)
                    {
                        found = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return found;
        }

        /// <summary>
        /// Checks to see if collection contains no instances of an item that meets a condition
        /// </summary>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if collection contains no item that matches</returns>
        public static bool ContainsNone <T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return collection.All(i => !predicate(i));
        }


        /// <summary>
        /// Performs an action on each element in a sequence
        /// </summary>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="function">Function with no parameters that returns void</param>
        public static void ExecuteForEach<T>(this IEnumerable<T> collection, Action<T> function)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            foreach (var i in collection)
            {
                function(i);
            }
        }

        /// <summary>
        /// Executes action on every element of an IEnumerable
        /// </summary>
        /// <typeparam name="T1">Type contained in collection</typeparam>
        /// <typeparam name="T2">Type returned as result of function</typeparam>
        /// <param name="collection">Collection of type T1</param>
        /// <param name="function">Function to apply over each element in collection</param>
        /// <returns>IEnumerable of type T2</returns>
        public static IEnumerable<T2> ExecuteForEach<T1, T2>(this IEnumerable<T1> collection,
              Func<T1, T2> function)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }            
            return collection.Select(function).ToList().AsEnumerable();
        }


        /// <summary>
        /// Creates a specified formatted listing for a collection
        /// </summary>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <param name="collection">Collection of type T</param>
        /// <param name="StringElement">Function to apply to each element to return a string representation</param>
        /// <param name="separator">String to seperate each element in result string</param>
        /// <returns>String listing all elements</returns>
        public static string ToString<T>(this IEnumerable<T> collection, Func<T, string> StringElement, string separator)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (StringElement == null)
            {
                throw new ArgumentNullException("StringElement");
            }
            return string.Join(separator, collection.Select(StringElement).ToArray());
        }
        
        /// <summary>
        /// Returns lazily evaluated shuffle of input (uses Fisher-Yates)
        /// </summary>
        /// <param name="source">Source sequence</param>
        /// <param name="random">Random class instance</param>
        /// <typeparam name="T">Type contained in collection</typeparam>
        /// <returns>IEnumerable of shuffled elements</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Shuffle <T>(this IEnumerable<T> source, Random random)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (random == null)
            {
                throw new ArgumentNullException("random");
            }

            var elements = source.ToArray();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                var swapIndex = random.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

       /// <summary>
       /// Returns random element from sequence
       /// </summary>
       /// <param name="source">Source sequence</param>
       /// <param name="random">Random class instance</param>
       /// <typeparam name="T">Type conained in collection</typeparam>
       /// <returns>Random Elelemnt from sequence</returns>
       /// <exception cref="ArgumentNullException"></exception>
       /// <exception cref="InvalidOperationException"></exception>
       public static T RandomElement <T>(this IEnumerable<T> source, Random random)
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