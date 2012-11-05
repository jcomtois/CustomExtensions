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
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class FlattenStringsTest
        {
            [Test]
            public void FlattenStrings_OnEmptyStringSequence_ReturnsEmptyString()
            {
                var emptyStringSequence = Enumerable.Empty<string>();

                Assert.That(emptyStringSequence.FlattenStrings(), Is.Empty);
            }

            [Test]
            public void FlattenStrings_OnNullStringSequence_ReturnsEmptyString()
            {
                IEnumerable<string> nullStringSequence = null;

                Assert.That(nullStringSequence.FlattenStrings(), Is.Empty);
            }

            [Test]
            public void FlattenStrings_OnValidEnumerable_ReturnsCorrectString()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));                
                var testStrings = fixture.CreateMany<string>(5).ToList();
                var expected = testStrings.Aggregate((result, current) => result + current);

                Assert.That(testStrings.FlattenStrings(), Is.EqualTo(expected));
            }
        }
    }
}