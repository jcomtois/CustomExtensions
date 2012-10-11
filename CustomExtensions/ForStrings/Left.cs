using System.Diagnostics;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Returns the first <paramref name="length"/> characters of <paramref name="source"/>.
        /// If the string's length is less than the given length the complete string is returned. If length is zero an empty string is returned.
        /// </summary>
        /// <param name="source"> The string to process </param>
        /// <param name="length"> Number of characters to return </param>
        /// <returns>Sub-string containing <paramref name="length"/> characters</returns>
        /// <exception cref="ValidationException">when <paramref name="source"/> is null or <paramref name="length"/> is less than 0</exception>
        public static string Left(this string source, int length)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNegative(length, "length")
                .CheckForExceptions();

            return LeftImplementation(source, length);
        }

        private static string LeftImplementation(string source, int length)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(length >= 0);

            return source.Length > length ? source.Substring(0, length) : source;
        }
    }
}