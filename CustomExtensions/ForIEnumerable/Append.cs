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
        /// Appends an element to a source <see cref="IEnumerable"/>
        /// </summary>
        /// <typeparam name="T">Type of source <see cref="IEnumerable"/></typeparam>
        /// <param name="source"><see cref="IEnumerable"/> of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to append</param>
        /// <returns><paramref name="source"/> with element of type <typeparamref name="T"/> appended to the end</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static IEnumerable<T> Append <T>(this IEnumerable<T> source, T element)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return AppendImplementation(source, element);
        }

        private static IEnumerable<T> AppendImplementation <T>(this IEnumerable<T> source, T element)
        {
            Debug.Assert(source != null, "source cannot be null.");

            return source.Concat(element.ToEnumerable());
        }
    }
}