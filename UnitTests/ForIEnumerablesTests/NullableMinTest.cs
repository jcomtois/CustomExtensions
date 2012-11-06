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
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class NullableMinTest
        {
            [Test]
            public void SequenceEmptySelectorGood()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMin(i => (decimal)i), Is.Null);
            }

            [Test]
            public void SequenceEmptySelectorNull()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodSelectorGood()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMin(i => (decimal)i), Is.EqualTo(1m));
            }

            [Test]
            public void SequenceGoodSelectorNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorGood()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMin(i => (decimal)i), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorNull()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}