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

using System.Diagnostics;
using CustomExtensions.Validation;

namespace CustomExtensions.ForArrays
{
    public static partial class ExtendArray
    {
        private static readonly char[] HexCharacters = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

        /// <summary>
        /// Converts a byte array to a Hex String representation
        /// </summary>
        /// <param name="source">A non-null, non-empty array of bytes</param>
        /// <returns>Tex string representation.  Letters are lowercase.</returns>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> is null or empty.</exception>
        public static string ToHexString(this byte[] source)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .CheckForExceptions();

            return ToHexStringImplementation(source);
        }

        private static string ToHexStringImplementation(byte[] source)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0);

            var index = 0;
            var position = index;
            var length = source.Length;
            var c = new char[length * 2];
            byte sourceByte;

            while (index < length)
            {
                sourceByte = source[index++];
                c[position++] = HexCharacters[sourceByte / 0x10];
                c[position++] = HexCharacters[sourceByte % 0x10];
            }
            return new string(c, 0, c.Length);
        }
    }
}