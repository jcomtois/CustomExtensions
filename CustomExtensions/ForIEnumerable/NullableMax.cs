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
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the maximum resulting nullable value 
        /// </summary>
        /// <typeparam name="TSource">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The nullable maximum value in the sequence.</returns>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="selector"/> is null</exception>
        public static TResult? NullableMax <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct, IComparable<TResult>
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(selector, "selector")
                .CheckForExceptions();

            return NullableMaxImplementation(source, selector);
        }

        private static TResult? NullableMaxImplementation<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector) where TResult : struct, IComparable<TResult>
        {
            Debug.Assert(selector != null, "selector != null");
            Debug.Assert(source != null, "source != null");

            return source.IsEmpty() ? default(TResult?) : source.Max(selector);
        }
    }
}