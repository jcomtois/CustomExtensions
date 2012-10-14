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
using CustomExtensions.ForDateTime;
using NUnit.Framework;

namespace UnitTests.ForDateTimesTests
{
    [TestFixture]
    public class FormatyyyyMMddTest
    {
        [Test]
        public void FormatyyyMMddCorrectOutput()
        {
            Assert.That(new DateTime(2000, 1, 1).FormatyyyyMMdd(), Is.EqualTo("20000101"));
            Assert.That(new DateTime(1999, 12, 31).FormatyyyyMMdd(), Is.EqualTo("19991231"));
        }
    }
}