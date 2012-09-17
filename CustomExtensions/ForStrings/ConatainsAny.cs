using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;

namespace CustomExtensions.ForStrings
{
    public static partial class ForStrings
    {
        /// <summary>
        /// Checks input string for any occurence of given character
        /// </summary>
        /// <param name="source">String to check</param>
        /// <param name="character">Character to look for</param>
        /// <returns>True if character found</returns>
        public static bool ContainsAny(this string source, char character)
        {
            return source.ContainsAny(character.ToEnumerable());
        }

        /// <summary>
        /// Checks input stringfor any occurence of given character(s)
        /// </summary>
        /// <param name="source">String to check</param>
        /// <param name="characters">Character(s) to look for</param>
        /// <returns>True if any character(s) found</returns>
        public static bool ContainsAny(this string source, IEnumerable<char> characters)
        {
            return !source.IsNullOrEmpty() && characters != null && source.Any(characters.Contains);
        }
    }
}