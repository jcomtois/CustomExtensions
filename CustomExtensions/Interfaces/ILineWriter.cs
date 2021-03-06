﻿#region License and Terms

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

namespace CustomExtensions.Interfaces
{
    /// <summary>
    /// Contains methods to write lines of text
    /// </summary>
    public interface ILineWriter
    {
        /// <summary>
        /// Writes a new line
        /// </summary>
        void WriteLine();
        /// <summary>
        /// Writes <paramref name="value"/> to a new line of text
        /// </summary>
        /// <param name="value">String to write</param>
        void WriteLine(string value);
    }
}