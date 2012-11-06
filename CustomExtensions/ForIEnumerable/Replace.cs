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
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Replaces all instances of <paramref name="element"/> in a sequence with <paramref name="replacement"/>
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to be replaced</param>
        /// <param name="replacement">Element of type <typeparamref name="T"/> to replace <paramref name="element"/> </param>
        /// <returns><see cref="IEnumerable"/> of type <typeparamref name="T"/> replacing <paramref name="element"/> with <paramref name="replacement"/></returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null</exception>
        public static IEnumerable<T> Replace <T>(this IEnumerable<T> source, T element, T replacement)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .CheckForExceptions();

            return ReplaceImplementation(source, element, replacement);
        }

        /// <summary>
        /// Replaces all instances of <paramref name="element"/> in a sequence with a projection of type <typeparamref name="T"/> to type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="element">Element of type <typeparamref name="T"/> to be replaced</param>
        /// <param name="projection">Projection of type <typeparamref name="T"/> to type <typeparamref name="T"/> </param>
        /// <returns><see cref="IEnumerable"/> of type <typeparamref name="T"/> replacing <paramref name="element"/> with <paramref name="projection"/> of type <typeparamref name="T"/></returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="projection"/> is null</exception>
        public static IEnumerable<T> Replace <T>(this IEnumerable<T> source, T element, Func<T, T> projection)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(projection, "projection")
                .CheckForExceptions();

            return ReplaceImplementation(source, element, projection);
        }

        private static IEnumerable<T> ReplaceImplementation <T>(IEnumerable<T> source, T element, Func<T, T> projection)
        {
            Debug.Assert(source != null, "source cannot be null");
            Debug.Assert(projection != null, "projection cannot be null");

            foreach (var s in source)
            {
                if (Equals(element, s))
                {
                    yield return projection(s);
                }
                else
                {
                    yield return s;
                }
            }
        }

        private static IEnumerable<T> ReplaceImplementation <T>(IEnumerable<T> source, T element, T replacement)
        {
            Debug.Assert(source != null, "source cannot be null");

            return ReplaceImplementation(source, element, s => replacement);
        }
    }
}