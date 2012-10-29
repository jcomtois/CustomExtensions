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
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ContainsExactlyTest
        {
            [Test]
            public void SequenceContainsLessThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 0).ContainsExactly(0), Is.True);
                Assert.That(Enumerable.Repeat("A", 0).ContainsExactly(1), Is.False);
            }

            [Test]
            public void SequenceContainsMoreThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(1), Is.False);
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(2), Is.True);
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(3), Is.False);
            }

            [Test]
            public void SequenceContainsOnlyOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(1), Is.True);
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(0), Is.False);
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(2), Is.False);
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ContainsExactly(0), Is.True);
                Assert.That(Enumerable.Empty<string>().ContainsExactly(1), Is.False);
            }

            [Test]
            public void SequenceEmptyProjectionGood()
            {
                Assert.That(() => Enumerable.Empty<int>().ContainsExactly(0, i => i == 1), Is.True);
                Assert.That(() => Enumerable.Empty<int>().ContainsExactly(1, i => i == 1), Is.False);
            }

            [Test]
            public void SequenceEmptyProjectionNull()
            {
                Assert.That(() => Enumerable.Empty<string>().ContainsExactly(0, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodProjectionGood()
            {
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(0, i => i == 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i == 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(2, i => i > 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(3, i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(0, i => i < 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i < 1), Is.False);
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 1).ContainsExactly(1, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(2), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionGood()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(0, s => true), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(0, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}