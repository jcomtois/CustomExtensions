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
        /// Attempts to convert a string to a guid.
        /// </summary>
        /// <param name="source">The string to try to convert</param>
        /// <param name="resultGuid">Upon return will contain the Guid</param>
        /// <returns>Returns true if successful, otherwise false</returns>
        public static bool TryToGuid(this string source, out Guid resultGuid)
        {
            //ClsidFromString returns the empty guid for null strings   
            if (source.IsNullOrEmpty())
            {
                resultGuid = Guid.Empty;
                return false;
            }

            var hresult = NativeMethods.CLSIDFromString(source, out resultGuid);
            if (hresult >= 0)
            {
                return true;
            }
            resultGuid = Guid.Empty;
            return false;
        }
    }
}