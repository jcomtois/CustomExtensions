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
        /// Determines whether or not <paramref name="source"/> is empty in an efficient way
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <returns>True if <paramref name="source"/> contains no elements</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static bool IsEmpty <T>(this IEnumerable<T> source)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return IsEmptyImplementation(source);
        }

        private static bool IsEmptyImplementation <T>(IEnumerable<T> source)
        {
            Debug.Assert(source != null, "source != null");

            var genericCollection = source as ICollection<T>;
            if (genericCollection != null)
            {
                return genericCollection.Count == 0;
            }

            var nonGenericCollection = source as ICollection;
            if (nonGenericCollection != null)
            {
                return nonGenericCollection.Count == 0;
            }

            return !source.Any();
        }
    }
}