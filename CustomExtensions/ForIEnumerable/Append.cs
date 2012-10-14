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
        /// Appends an element to a source <see cref="IEnumerable"/>
        /// </summary>
        /// <typeparam name="T">Type of source <see cref="IEnumerable"/></typeparam>
        /// <param name="source"><see cref="IEnumerable"/> of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to append</param>
        /// <returns><paramref name="source"/> with element of type <typeparamref name="T"/> appended to the end</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static IEnumerable<T> Append <T>(this IEnumerable<T> source, T element)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return AppendImplementation(source, element);
        }

        private static IEnumerable<T> AppendImplementation <T>(this IEnumerable<T> source, T element)
        {
            Debug.Assert(source != null, "source cannot be null.");

            return source.Concat(element.ToEnumerable());
        }
    }
}