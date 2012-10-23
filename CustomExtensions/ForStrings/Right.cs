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

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Returns the last <paramref name="length"/> characters of a string.
        /// If the string's source length is less than the given length the complete string is returned. If length is zero an empty string is returned.
        /// </summary>
        /// <param name="source"> the string to process </param>
        /// <param name="length"> Number of characters to return from right end of string</param>
        /// <returns>Returns the last <paramref name="length"/> characters of a string.</returns>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> is null or <paramref name="length"/>is negative.</exception>
        public static string Right(this string source, int length)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNegative(length, "length")
                .CheckForExceptions();

            return RightImplementation(source, length);
        }

        private static string RightImplementation(string source, int length)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(length >= 0);

            return source.Length > length ? source.Substring(source.Length - length, length) : source;
        }
    }
}