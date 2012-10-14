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