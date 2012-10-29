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

using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ToEnumerableTest
        {
            #region Setup/Teardown

            [SetUp]
            public void Setup()
            {
                _theObject = new object();
            }

            #endregion

            private object _theObject;
            private readonly object _nullObject;

            [Test]
            public void ToEnumerable_OnNullObject_CreatesEnumerable()
            {
                Assert.That(() => _nullObject.ToEnumerable(), Is.EquivalentTo(Enumerable.Repeat(_nullObject, 1)));
            }

            [Test]
            public void ToEnumerable_OnObject_CreatesEnumerable()
            {
                Assert.That(() => _theObject.ToEnumerable(), Is.EquivalentTo(Enumerable.Repeat(_theObject, 1)));
            }

            [Test]
            public void ToEnumerable_OnObject_EnumeratingThrowsNothing()
            {
                Assert.That(() => _theObject.ToEnumerable().ToList(), Throws.Nothing);
            }
        }
    }
}