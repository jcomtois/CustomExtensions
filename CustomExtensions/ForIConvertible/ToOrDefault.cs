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

namespace CustomExtensions.ForIConvertible
{
    public static partial class ExtendIConvertible
    {
        //http://stackoverflow.com/a/939498/213169

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or default value for <typeparamref name="T"/> if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <returns>Converted object or default value for <typeparamref name="T"/></returns>
        public static T ToOrDefault <T>(this IConvertible source)
        {
            T converted;
            source.ToOrDefault(out converted);
            return converted;
        }

        /// <summary>
        /// Converts IConvertible object to type <typeparamref name="T"/> or default value for <typeparamref name="T"/> if conversion fails
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="source">Object implementing <see cref="IConvertible"/></param>
        /// <param name="converted">Converted object or default value for <typeparamref name="T"/></param>
        /// <returns>True if conversion was successful, false if conversion failed and default value was returned</returns>
        public static bool ToOrDefault <T>(this IConvertible source, out T converted)
        {
            try
            {
                converted = To<T>(source);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is InvalidCastException ||
                    ex is FormatException ||
                    ex is OverflowException ||
                    ex is ArgumentNullException)
                {
                    converted = default(T);
                    return false;
                }
                throw;
            }
        }
    }
}