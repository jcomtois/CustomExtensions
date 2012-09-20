using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Strips Input string of all occurences of specified character(s)
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="characters">IEnumerable containing characters to be stripped</param>
        /// <returns>Stripped string</returns>
        public static string Strip(this string source, IEnumerable<char> characters)
        {
            return source.IsNullOrEmpty() || characters == null ? source : new string(source.Where(c => !characters.Contains(c)).ToArray());
        }

        /// <summary>
        /// Strips Input string of all occurences of specified character
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="character">Character to strip from Input</param>
        /// <returns>Stripped string</returns>
        public static string Strip(this string source, char character)
        {
            return source.Strip(character.ToEnumerable());
        }

        /// <summary>
        /// Strips Input sting of all occurences of specified substring
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="substring">SubString to strip from Input</param>
        /// <returns>Stripped String</returns>
        public static string Strip(this string source, string substring)
        {
            if (source.IsNullOrEmpty() || substring.IsNullOrEmpty())
            {
                return source;
            }
            return source.Replace(substring, string.Empty);
        }
    }
}