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
        /// Returns random element from sequence
        /// </summary>
        /// <param name="source">Source sequence</param>
        /// <param name="random"><see cref="Random"/> class instance</param>
        /// <typeparam name="T">Type conained in <paramref name="source"/></typeparam>
        /// <returns>Random element from sequence</returns>
        public static T RandomElement <T>(this IEnumerable<T> source, Random random)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .IsNotNull(random, "random")
                .CheckForExceptions();

            return RandomElementImplementation(source, random);
        }

        private static T RandomElementImplementation <T>(IEnumerable<T> source, Random random)
        {
            Debug.Assert(random != null, "random != null");
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source != null && source.Any(), "source cannot be empty");

            var collection = source as ICollection;
            if (collection != null)
            {
                var count = collection.Count;
                var index = random.Next(count);
                return source.ElementAt(index);
            }
            using (var iterator = source.GetEnumerator())
            {
                var start = iterator.MoveNext();
                Debug.Assert(start, "source cannot be empty");
                var countSoFar = 1;
                var current = iterator.Current;
                while (iterator.MoveNext())
                {
                    countSoFar++;
                    if (random.Next(countSoFar) == 0)
                    {
                        current = iterator.Current;
                    }
                }
                return current;
            }
        }
    }
}