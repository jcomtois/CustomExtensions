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

using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsNullOrEmptyTest
        {
            [Test]
            public void IsNullOrEmpty_OnEmptyString_ReturnsTrue()
            {
                Assert.That(() => EmptyTestString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnNullString_ReturnsTrue()
            {
                Assert.That(() => NullTestString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnValidString_ReturnsFalse()
            {
                Assert.That(() => TestStringLatin.IsNullOrEmpty(), Is.False);
            }
        }
    }
}