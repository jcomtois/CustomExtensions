using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Converts <see cref="IEnumerable"/> of type <see cref="string"/> to a single string with all items appended
        /// </summary>
        /// <param name="source"> <see cref="IEnumerable"/> of type <see cref="string"/></param>
        /// <returns> <see cref="string"/> of appended strings, empty if null input</returns>
        public static string FlattenStrings(this IEnumerable<string> source)
        {
            return source == null ? string.Empty : ToStringImplementation(source, s => s, null);
        }
    }
}