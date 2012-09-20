using System.ComponentModel;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Attempts to parse a string into specified type.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="source">Input.  Null or empty returns Default for T</param>
        /// <returns>Instance of T as represented by source</returns>
        public static T Parse <T>(this string source)
        {
            var result = default(T);
            if (!source.IsNullOrEmpty())
            {
                var tc = TypeDescriptor.GetConverter(typeof (T));
                result = (T)tc.ConvertFrom(source);
            }
            return result;
        }
    }
}