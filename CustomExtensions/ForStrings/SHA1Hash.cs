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
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CustomExtensions.ForArrays;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        public enum OutputFormat
        {
            Digit,
            Hex,
            Base64,
        }

        /// <summary>
        /// Returns SHA1 Digest of UTF8 representation of input string
        /// </summary>
        /// <param name="source">String that will use UTF8 encoding</param>
        /// <param name="outputFormat">Formatting to be applied to output string.</param>
        /// <returns>SHA1 digest in format specified by <paramref name="outputFormat"/></returns>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> is null or empty</exception>
        public static string SHA1Hash(this string source, OutputFormat outputFormat = OutputFormat.Hex)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .CheckForExceptions();

            return SHA1HashImplementation(source, outputFormat);
        }

        private static string SHA1HashImplementation(string source, OutputFormat outputFormat)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0);

            byte[] bytes;
            using (SHA1 sha = new SHA1Managed())
            {
                bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            if (outputFormat == OutputFormat.Hex)
            {
                return bytes.ToHexString();
            }

            return outputFormat == OutputFormat.Base64 ? Convert.ToBase64String(bytes) : bytes.Select(x => string.Format("{0:d3}", x)).FlattenStrings();
        }
    }
}