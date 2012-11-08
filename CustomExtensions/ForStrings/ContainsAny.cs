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

            var hs = new HashSet<char>(characters);
            return !hs.IsEmpty() && source.Any(hs.Contains);
        }
    }
}