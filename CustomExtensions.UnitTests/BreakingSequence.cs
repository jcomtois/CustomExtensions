﻿#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
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
using System.Collections;
using System.Collections.Generic;

namespace CustomExtensions.UnitTests
{
    /// <summary>
    /// Used to test for lazy evaluation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BreakingSequence <T> : IEnumerable<T>
    {
        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException("GetEnumerator was accessed on a BreakingSequence!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}