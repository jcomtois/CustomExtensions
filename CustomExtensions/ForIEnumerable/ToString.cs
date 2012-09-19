using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ForIEnumerable
    {
        /// <summary>
        /// Uses a projection to transform a sequence into a seperated list
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source"><see cref="IEnumerable"/> of type <typeparamref name="T"/></param>
        /// <param name="projection">Function to apply to each element to return a string representation</param>
        /// <param name="separator">String to seperate each element in result string</param>
        /// <returns>String listing all elements</returns>
        public static string ToString <T>(this IEnumerable<T> source, Func<T, string> projection, string separator)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(projection, "projection")
                .CheckForExceptions();

            return ToStringImplementation(source, projection, separator);
        }

        internal static string ToStringImplementation <T>(IEnumerable<T> source, Func<T, string> projection, string separator)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(projection != null, "projection cannot be null");

            return string.Join(separator, source.Select(projection).ToArray());
        }
    }
}