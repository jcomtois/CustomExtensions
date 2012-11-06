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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Transforms sequence of strings into seperated list string
        /// </summary>
        /// <param name="source"><see cref="IEnumerable"/> of type <see cref="string"/></param>
        /// <param name="separator">String to seperate each element in result string</param>
        /// <returns>String listing all elements</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>        
        public static string ToString (this IEnumerable<string> source, string separator)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ToStringImplementation(source, s => s, separator);
        }

        /// <summary>
        /// Uses a projection to transform a sequence into a seperated list string
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source"><see cref="IEnumerable"/> of type <typeparamref name="T"/></param>
        /// <param name="projection">Function to apply to each element to return a string representation</param>
        /// <param name="separator">String to seperate each element in result string</param>
        /// <returns>String listing all elements</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="projection"/> is null</exception>
        public static string ToString <T>(this IEnumerable<T> source, Func<T, string> projection, string separator)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(projection, "projection")
                .CheckForExceptions();

            return ToStringImplementation(source, projection, separator);
        }

        private static string ToStringImplementation <T>(IEnumerable<T> source, Func<T, string> projection, string separator)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(projection != null, "projection cannot be null");

            return string.Join(separator, source.Select(projection).ToArray());
        }
    }
}