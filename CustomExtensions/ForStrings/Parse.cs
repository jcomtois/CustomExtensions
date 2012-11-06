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

using System.ComponentModel;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Attempts to parse a string into specified type.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="source">Input.  Null or empty returns Default for T</param>
        /// <returns>Instance of T as represented by source</returns>
        public static T Parse <T>(this string source)
        {
            var result = default(T);
            if (!source.IsNullOrEmpty())
            {
                var tc = TypeDescriptor.GetConverter(typeof (T));
                result = (T)tc.ConvertFrom(source);
            }
            return result;
        }
    }
}