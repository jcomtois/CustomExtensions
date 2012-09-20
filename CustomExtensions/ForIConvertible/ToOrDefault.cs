using System;

namespace CustomExtensions.ForIConvertible
{
    public static partial class ExtendIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or default value for <typeparamref name="T"/> if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <returns>Converted object or default value for <typeparamref name="T"/></returns>
        public static T ToOrDefault <T>(this IConvertible source)
        {
            T converted;
            source.ToOrDefault(out converted);
            return converted;
        }

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or default value for <typeparamref name="T"/> if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <param name="converted">Converted object or default value for <typeparamref name="T"/></param>
        /// <returns>True if conversion was successful, false if conversion failed and default value was returned</returns>
        public static bool ToOrDefault <T>(this IConvertible source, out T converted)
        {
            try
            {
                converted = To<T>(source);
                return true;
            }
            catch
            {
                converted = default(T);
                return false;
            }
        }
    }
}