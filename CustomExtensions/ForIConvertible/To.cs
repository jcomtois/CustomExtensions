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
using System.Globalization;

namespace CustomExtensions.ForIConvertible
{
    public static partial class ExtendIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <returns>Converted object</returns>       
        public static T To <T>(this IConvertible source)
        {
            var t = typeof (T);

            if (!t.IsGenericType ||
                (t.GetGenericTypeDefinition() != typeof (Nullable<>)))
            {
                return (T)Convert.ChangeType(source, t, CultureInfo.InvariantCulture);
            }

            if (source == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(source, Nullable.GetUnderlyingType(t), CultureInfo.InvariantCulture);
        }
    }
}