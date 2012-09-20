using System;

namespace CustomExtensions.ForIConvertible
{
    public static partial class ExtendIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or provided other value if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <param name="other">Value to return if conversion fails</param>
        /// <returns>Converted object or <paramref name="other"/> if conversion fails</returns>
        public static T ToOrOther <T>(this IConvertible source, T other)
        {
            T converted;
            source.ToOrOther(out converted, other);
            return converted;
        }

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or provided other value if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <param name="converted">Converted object or <paramref name="other"/> if conversion fails</param>
        /// <param name="other">Value to return if conversion fails</param>
        /// <returns>True if conversion was successful, false if conversion failed and <paramref name="other"/> was returned</returns>
        public static bool ToOrOther <T>(this IConvertible source, out T converted, T other)
        {
            try
            {
                converted = To<T>(source);
                return true;
            }
            catch
            {
                converted = other;
                return false;
            }
        }
    }
}