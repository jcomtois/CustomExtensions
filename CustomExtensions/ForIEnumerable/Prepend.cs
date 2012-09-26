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
        /// Prepends an element to a source <see cref="IEnumerable"/>
        /// </summary>
        /// <typeparam name="T">Type of source <see cref="IEnumerable"/></typeparam>
        /// <param name="source"><see cref="IEnumerable"/> of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to append</param>
        /// <returns><paramref name="source"/> with element of type <typeparamref name="T"/> prepended to the beginning</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return PrependImplementation(source, element);
        }

        private static IEnumerable<T> PrependImplementation <T>(this IEnumerable<T> source, T element)
        {
            Debug.Assert(source != null, "source cannot be null.");

            return Enumerable.Repeat(element, 1).Concat(source);
        }
    }
}