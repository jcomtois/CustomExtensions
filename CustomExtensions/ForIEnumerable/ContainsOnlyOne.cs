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
using System.Collections.Generic;
using System.Diagnostics;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Checks to see if <paramref name="source"/> contains exactly one instance of an item that meets a predicate
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="predicate">Function to check each item for a match</param>
        /// <returns>True if <paramref name="source"/> contains exactly one item that matches <paramref name="predicate"/></returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="predicate"/> is null</exception>
        public static bool ContainsOnlyOne <T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(predicate, "predicate")
                .CheckForExceptions();

            return ContainsOnlyOneImplementation(source, predicate);
        }

        /// <summary>
        /// Checks to see if <paramref name="source"/> contains exactly one item
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <returns>True if <paramref name="source"/> contains exactly one item</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static bool ContainsOnlyOne <T>(this IEnumerable<T> source)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ContainsOnlyOneImplementation(source);
        }

        internal static bool ContainsOnlyOneImplementation <T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Debug.Assert(source != null, "source cannot be null.");
            Debug.Assert(predicate != null, "predicate cannot be null.");

            return ContainsExactlyImplementation(source, 1, predicate);
        }

        internal static bool ContainsOnlyOneImplementation <T>(this IEnumerable<T> source)
        {
            Debug.Assert(source != null, "source cannot be null.");

            return ContainsExactlyImplementation(source, 1);
        }
    }
}