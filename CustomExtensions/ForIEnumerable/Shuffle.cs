﻿#region License and Terms

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
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Returns lazily evaluated sequence of input (uses Fisher-Yates).  
        /// </summary>
        /// <param name="source">Sequence of type <typeparamref name="T"/>.  Will be fully enumerated prior to lazy return.</param>
        /// <param name="random"><see cref="Random"/> class instance</param>
        /// <typeparam name="T">Type conained in <paramref name="source"/></typeparam>
        /// <returns><see cref="IEnumerable{T}"/> of shuffled elements</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="random"/> is null</exception>
        public static IEnumerable<T> Shuffle <T>(this IEnumerable<T> source, Random random)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(random, "random")
                .CheckForExceptions();

            return ShuffleImplementation(source, random);
        }

        private static IEnumerable<T> ShuffleImplementation <T>(IEnumerable<T> source, Random random)
        {
            Debug.Assert(random != null, "random != null");
            Debug.Assert(source != null, "source != null");

            var elements = source.ToArray();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                var swapIndex = random.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }
    }
}