using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Checks input string for any occurence of given character
        /// </summary>
        /// <param name="source">String to check</param>
        /// <param name="character">Character to look for</param>
        /// <returns>True if character found</returns>
        public static bool ContainsAny(this string source, char character)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return source.ContainsAny(character.ToEnumerable());
        }

        /// <summary>
        /// Checks input string for any occurence of given character(s)
        /// </summary>
        /// <param name="source">String to check</param>
        /// <param name="characters">Character(s) to look for</param>
        /// <returns>True if any character(s) found</returns>
        public static bool ContainsAny(this string source, IEnumerable<char> characters)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(characters, "characters")
                .CheckForExceptions();

            return ContainsAnyImplementation(source, characters);
        }

        private static bool ContainsAnyImplementation(string source, IEnumerable<char> characters)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(characters != null, "characters != null");
            
            return !characters.IsEmpty() && source.Any(characters.Contains);
        }
    }
}