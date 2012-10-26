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
using CustomExtensions.COMInterop;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Attempts to convert a string to a <see cref="Guid"/>.
        /// </summary>
        /// <param name="source">The string to try to convert</param>
        /// <param name="result">Upon return will contain the <see cref="Guid"/></param>
        /// <returns>Returns true if successful, otherwise false</returns>
        /// <remarks>
        /// The alphabetic hexadecimal digits in the <paramref name="source"/> parameter can be upper or lower case. 
        /// For example, the following strings represent the same GUID:
        /// 
        /// "ca761232ed4211cebacd00aa0057b223" 
        /// "CA761232-ED42-11CE-BACD-00AA0057B223" 
        /// "{CA761232-ED42-11CE-BACD-00AA0057B223}" -- Prefer this version for speed
        /// "(CA761232-ED42-11CE-BACD-00AA0057B223)" 
        /// "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}" 
        /// 
        /// </remarks>
        public static bool TryToGuid(this string source, out Guid result)
        {
            //ClsidFromString returns the empty guid for null strings   
            if (source.IsNullOrEmpty())
            {
                result = Guid.Empty;
                return false;
            }

            var addBracesToSourceIfNeeded = source;

            // Check for {}
            if (addBracesToSourceIfNeeded[0] != '{')
            {
                addBracesToSourceIfNeeded = "{" + addBracesToSourceIfNeeded;
            }

            if (addBracesToSourceIfNeeded[addBracesToSourceIfNeeded.Length - 1] != '}')
            {
                addBracesToSourceIfNeeded += "}";
            }

            // Faster than managed version
            var hresult = NativeMethods.CLSIDFromString(addBracesToSourceIfNeeded, out result);
            if (hresult >= 0)
            {
                return true;
            }

            // Try Managed version

            try
            {
                result = new Guid(source);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is OverflowException ||
                    ex is FormatException ||
                    ex.GetType() == typeof (Exception))
                {
                    result = Guid.Empty;
                    return false;
                }
                throw;
            }
        }
    }
}