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

namespace CustomExtensions.ForDateTime
{
    public static partial class ExtendDateTime
    {
        /// <summary>
        /// Formats <paramref name="source"/> to a string in yyyyMMdd pattern.  Uses en-US for <see cref="CultureInfo"/>
        /// </summary>
        /// <param name="source"><see cref="DateTime"/> to parse.</param>
        /// <returns><see cref="string"/> representing date as yyyyMMdd</returns>
        public static string FormatyyyyMMdd(this DateTime source)
        {
            var dateTimeFormatInfo = new CultureInfo("en-US", false).DateTimeFormat;
            return source.ToString("yyyyMMdd", dateTimeFormatInfo);
        }
    }
}