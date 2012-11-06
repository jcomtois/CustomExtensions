#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

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
        /// Strips <paramref name="source"/> string of all occurences of specified <paramref name="characters"/>
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="characters">IEnumerable containing characters to be stripped from <paramref name="source"/></param>
        /// <returns>Stripped string</returns>
        /// <exception cref="ValidationException"> Thrown if <paramref name="source"/> or <paramref name="characters"/> is null.</exception>
        public static string Strip(this string source, IEnumerable<char> characters)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(characters, "characters")
                .CheckForExceptions();

            return StripImplementation(source, characters);
        }

        /// <summary>
        /// Strips <paramref name="source"/> string of all occurences of specified <paramref name="character"/>
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="character">Character to strip from <paramref name="source"/></param>
        /// <returns>Stripped string</returns>
        /// <exception cref="ValidationException"> Thrown if <paramref name="source"/> is null.</exception>
        public static string Strip(this string source, char character)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return StripImplementation(source, character.ToEnumerable());
        }

        /// <summary>
        /// Strips <paramref name="source"/> string of all occurences of specified <paramref name="substring"/>
        /// </summary>
        /// <param name="source">String to strip</param>
        /// <param name="substring">SubString to strip from <paramref name="source"/></param>
        /// <returns>Stripped String</returns>
        /// <exception cref="ValidationException"> Thrown if <paramref name="source"/> or <paramref name="substring"/> is null.</exception>
        public static string Strip(this string source, string substring)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(substring, "substring")
                .CheckForExceptions();

            return StripImplementationString(source, substring);
        }

        private static string StripImplementation(string source, IEnumerable<char> characters)
        {
            Debug.Assert(characters != null, "characters != null");
            Debug.Assert(source != null, "source != null");

            if (source.Length < 1 || characters.IsEmpty())
            {
                return source;
            }

            var hashSet = new HashSet<char>(characters);

            return new string(source.Where(c => !hashSet.Contains(c)).ToArray());
        }

        private static string StripImplementationString(string source, string substring)
        {
            Debug.Assert(substring != null, "substring != null");
            Debug.Assert(source != null, "source != null");

            if (source.Length < 1 || substring.Length < 1 || substring.Length > source.Length)
            {
                return source;
            }

            return source.Replace(substring, string.Empty);
        }
    }
}