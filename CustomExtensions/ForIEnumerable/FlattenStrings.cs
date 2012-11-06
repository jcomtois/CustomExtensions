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

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Converts <see cref="IEnumerable"/> of type <see cref="string"/> to a single string with all items appended
        /// </summary>
        /// <param name="source"> <see cref="IEnumerable"/> of type <see cref="string"/></param>
        /// <returns> <see cref="string"/> of appended strings, empty if null input</returns>
        public static string FlattenStrings(this IEnumerable<string> source)
        {
            return source == null ? string.Empty : ToStringImplementation(source, s => s, null);
        }
    }
}