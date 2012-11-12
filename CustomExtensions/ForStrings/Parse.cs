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
using System.ComponentModel;
using System.Diagnostics;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Attempts to parse a string into specified type.
        /// </summary>
        /// <typeparam name="T">Type to attempt to convert to</typeparam>
        /// <param name="source">Input</param>
        /// <returns>Instance of T as represented by source string</returns>
        /// <exception cref="ValidationException">Thrown if <paramref name="source"/> is null or empty</exception>
        /// <exception cref="NotSupportedException">Thrown if the conversion fails.</exception>
        public static T Parse <T>(this string source)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .CheckForExceptions();

            return ParseImplementation<T>(source);            
        }

        private static T ParseImplementation<T>(string source)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0);

            var typeConverter = TypeDescriptor.GetConverter(typeof (T));
            T result;
            try
            {
                result = (T)typeConverter.ConvertFromString(source);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is FormatException)
                {
                    throw new NotSupportedException("Invalid string format", ex.InnerException);
                }
                throw;
            }
            return result;
        }
    }
}