using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ForIEnumerable
    {
        /// <summary>
        /// Appends and element to a source
        /// </summary>
        /// <typeparam name="T">Type of source IEnumerable</typeparam>
        /// <param name="source">IEnumerable of type T</param>
        /// <param name="element">Element to append</param>
        /// <returns>IEnumerable of type T with element appended to the end</returns>
        public static IEnumerable<T> Append <T>(this IEnumerable<T> source, T element)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var t in source)
            {
                yield return t;
            }
            yield return element;
        }
    }
}