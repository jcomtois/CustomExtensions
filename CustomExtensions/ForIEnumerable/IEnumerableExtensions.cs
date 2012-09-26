using System;
using System.Collections.Generic;

namespace CustomExtensions.ForIEnumerable
{
   public static partial class ExtendIEnumerable
    {       
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