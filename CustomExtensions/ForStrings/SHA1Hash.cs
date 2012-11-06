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
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CustomExtensions.ForIEnumerable;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Returns SHA1 Digest of ASCII reprensentation of input string
        /// </summary>
        /// <param name="source">String that will use ASCII endcoding</param>
        /// <returns>SHA1 digest</returns>
        public static string SHA1Hash(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            using (SHA1 sha = new SHA1Managed())
            {
                return sha.ComputeHash(Encoding.ASCII.GetBytes(source)).Select(x => string.Format("{0:x2}", x)).FlattenStrings();
            }
        }
    }
}