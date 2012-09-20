using System;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Returns the first few characters of the string with a length specified by the given parameter. If the string's length is less than the given length the complete string is returned. If length is zero or less an empty string is returned
        /// </summary>
        /// <param name="source"> the string to process </param>
        /// <param name="length"> Number of characters to return </param>
        /// <returns> </returns>
        public static string Left(this string source, int length)
        {
            length = Math.Max(length, 0);
            return source.Length > length ? source.Substring(0, length) : source;
        }
    }
}