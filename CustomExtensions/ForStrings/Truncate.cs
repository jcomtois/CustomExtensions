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
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        private const string Suffix = "...";

        /// <summary>
        /// Truncates the string to a specified length and replace the truncated with a "..."
        /// <paramref name="maxLength"/> must be 4 or greater in order to avoid an exception and visually
        /// indicate truncation
        /// </summary>
        /// <param name="source"> string that will be truncated </param>
        /// <param name="maxLength"> total length of characters to maintain before the truncate happens.  Must be >= 4</param>
        /// <returns> truncated string </returns>
        /// <exception cref="ValidationException"> trown if <paramref name="source"/> is null or <paramref name="maxLength"/> is less than 4</exception>
        public static string Truncate(this string source, int maxLength)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsAtLeast(Suffix.Length + 1, maxLength, "maxLength")
                .CheckForExceptions();

            return TruncateImplementation(source, maxLength);
        }

        private static string TruncateImplementation(string source, int maxLength)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(maxLength >= Suffix.Length + 1);

            if (source.Length <= maxLength)
            {
                return source;
            }

            var subStringLength = maxLength - Suffix.Length;

            return string.Format("{0}{1}", source.Substring(0, subStringLength), Suffix);
        }
    }
}