using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.ForIEnumerable
{
   public static partial class ExtendIEnumerable
    {       
        

       

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

        /// <summary>
        /// Prepends and element to a source
        /// </summary>
        /// <typeparam name="T">Type of source IEnumerable</typeparam>
        /// <param name="source">IEnumerable of type T</param>
        /// <param name="element">Element to append</param>
        /// <returns>IEnumerable of type T with element appended to the end</returns>
        public static IEnumerable<T> Prepend <T>(this IEnumerable<T> source, T element)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            yield return element;
            foreach (var t in source)
            {
                yield return t;
            }
        }

        /// <summary>
        /// Returns random element from sequence
        /// </summary>
        /// <param name="source">Source sequence</param>
        /// <param name="random">Random class instance</param>
        /// <typeparam name="T">Type conained in source</typeparam>
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
        /// Returns lazily evaluated shuffle of input (uses Fisher-Yates)
        /// </summary>
        /// <param name="source">Source sequence</param>
        /// <param name="random">Random class instance</param>
        /// <typeparam name="T">Type contained in source</typeparam>
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

        public static IEnumerable<T> ToEnumerable <T>(this T Input)
        {
            return new[] {Input}.AsEnumerable();
        }

       

        /// <summary>
        /// Implements Where(filter-lambda).Select(selector-lambda) in a single operation
        /// </summary>
        /// <typeparam name="TSrc">Type of source IEnumerable</typeparam>
        /// <typeparam name="TResult">Resulting type</typeparam>
        /// <param name="source">IEnumerable of type TSrc</param>
        /// <param name="predicate">Expression to check for a match</param>
        /// <param name="selector">Expression to convert from TSrc to TResult</param>
        /// <returns>IEnumerable of type TResult that matches predicate</returns>
        public static IEnumerable<TResult> WhereSelect <TSrc, TResult>(this IEnumerable<TSrc> source, Predicate<TSrc> predicate, Converter<TSrc, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            foreach (var t in source)
            {
                if (predicate(t))
                {
                    yield return selector(t);
                }
            }
        }
    }
}