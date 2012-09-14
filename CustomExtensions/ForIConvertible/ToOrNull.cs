using System;

namespace CustomExtensions.ForIConvertible
{
    public static partial class ForIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or null if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.  Must be a class.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <returns>Converted object or default value for <typeparamref name="T"/></returns>
        public static T ToOrNull <T>(this IConvertible source) where T : class
        {
            T converted;
            source.ToOrNull(out converted);
            return converted;
        }

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or null if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <param name="converted">Converted object or null</param>
        /// <returns>True if conversion was successful, false if conversion failed and null was returned</returns>
        public static bool ToOrNull <T>(this IConvertible source, out T converted) where T : class
        {
            try
            {
                converted = To<T>(source);
                return true;
            }
            catch
            {
                converted = null;
                return false;
            }
        }
    }
}