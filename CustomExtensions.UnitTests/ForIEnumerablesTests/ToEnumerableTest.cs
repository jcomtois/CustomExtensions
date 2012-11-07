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
using CustomExtensions.ForIEnumerable;
using CustomExtensions.UnitTests.Customization.Fixtures;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ToEnumerableTest
        {
            [Test]
            public void ToEnumerable_OnNullObject_CreatesEnumerable()
            {
                object nullObject = null;

                Assert.That(() => nullObject.ToEnumerable(), Is.InstanceOf<IEnumerable<object>>());
            }

            [Test]
            public void ToEnumerable_OnObject_CreatesEnumerable()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => objectValue.ToEnumerable(), Is.InstanceOf<IEnumerable<object>>());
            }
        }
    }
}