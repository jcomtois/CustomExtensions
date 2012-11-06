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

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="source"> string that will be truncated </param>
        /// <param name="maxLength"> total length of characters to maintain before the truncate happens </param>
        /// <returns> truncated string </returns>
        public static string Truncate(this string source, int maxLength)
        {
            if (maxLength <= 0 || source.IsNullOrEmpty() || source.Length <= maxLength)
            {
                return source;
            }

            const string suffix = "...";

            var strLength = maxLength - suffix.Length;
            return strLength <= 0 ? source : string.Format("{0}{1}", source.Substring(0, strLength), suffix);
        }
    }
}