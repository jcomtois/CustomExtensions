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
        /// Performs an action on each element in <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="action"><see cref="Action"/> to be immediately applied to each element in <paramref name="source"/></param>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="action"/> is null</exception>
        public static void ForEach <T>(this IEnumerable<T> source, Action<T> action)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(action, "action")
                .CheckForExceptions();

            ForEachImplementation(source, action);
        }

        private static void ForEachImplementation <T>(IEnumerable<T> source, Action<T> action)
        {
            Debug.Assert(action != null, "action != null");
            Debug.Assert(source != null, "source != null");

            foreach (var element in source)
            {
                action(element);
            }
        }
    }
}