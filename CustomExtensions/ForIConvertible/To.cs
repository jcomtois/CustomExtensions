using System;
using System.Globalization;

namespace CustomExtensions.ForIConvertible
{
    public static partial class ExtendIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <returns>Converted object</returns>       
        public static T To <T>(this IConvertible source)
        {
            var t = typeof (T);

            if (!t.IsGenericType ||
                (t.GetGenericTypeDefinition() != typeof (Nullable<>)))
            {
                return (T)Convert.ChangeType(source, t, CultureInfo.InvariantCulture);
            }

            if (source == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(source, Nullable.GetUnderlyingType(t), CultureInfo.InvariantCulture);
        }
    }
}