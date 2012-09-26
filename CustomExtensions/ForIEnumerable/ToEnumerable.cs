using System.Collections.Generic;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Takes any input and returns it as a sequence containing a single item which is that input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable <T>(this T Input)
        {
            yield return Input;
        }
    }
}