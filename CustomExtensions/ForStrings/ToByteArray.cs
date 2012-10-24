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

using System;
using System.Diagnostics;
using System.IO;
using CustomExtensions.ForArrays;
using CustomExtensions.Validation;
using System.Linq;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        internal static readonly char[] CaseInsensitiveHexCharacters = ExtendArray.HexCharacters.Union(ExtendArray.HexCharacters.Select(char.ToUpperInvariant)).ToArray();
        
        /// <summary>
        /// Converts a valid hex string representation into its corresponding byte array
        /// </summary>
        /// <param name="source">A non-null non-empty hex string representation of a byte array</param>
        /// <returns>Byte Array</returns>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> is null or empty.</exception>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> does not contain an even number of characters</exception>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> contains invalid hex characters</exception>
        public static byte[] ToByteArray(this string source)
        {
            var validator = Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .CheckForExceptions();

            if (source.Length % 2 != 0)
            {
                validator.AddException(new FormatException("Invalid number of characters in string.")).CheckForExceptions();                
            }

            var checkCharacters = source.TakeWhile(c => CaseInsensitiveHexCharacters.Contains(c)).Count();

            if (checkCharacters != source.Length)
            {
                validator.AddException(new FormatException("Source string is not a valid Hex string.")).CheckForExceptions();
            }

            return ToByteArrayImplementation(source);
        }

        private static byte[] ToByteArrayImplementation(string source)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0);
            Debug.Assert(source.Length % 2 == 0);

            var numberChars = source.Length / 2;
            var bytes = new byte[numberChars];
            using (var stringReader = new StringReader(source))
            {
                for (var i = 0; i < numberChars; i++)
                {
                    bytes[i] = Convert.ToByte(new string(new[] { (char)stringReader.Read(), (char)stringReader.Read() }), 16);
                }
            }
            return bytes;
        }
    }
}