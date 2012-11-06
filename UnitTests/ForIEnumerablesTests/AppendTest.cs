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
        public class AppendTest
        {
            [Test]
            public void AppendIsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().Append("A"), Throws.Nothing);
            }

            [Test]
            public void SequenceEmptyElementGood()
            {
                Assert.That(Enumerable.Empty<string>().Append("A"), Is.EqualTo(Enumerable.Repeat("A", 1)));
            }

            [Test]
            public void SequenceEmptyElementNull()
            {
                Assert.That(Enumerable.Empty<string>().Append(null), Is.EqualTo(Enumerable.Repeat<string>(null, 1)));
            }

            [Test]
            public void SequenceGoodElementGood()
            {
                Assert.That(Enumerable.Repeat("A", 2).Append("A"), Is.EqualTo(Enumerable.Repeat("A", 3)));
            }

            [Test]
            public void SequenceGoodElementNull()
            {
                Assert.That(Enumerable.Repeat("A", 2).Append(null), Is.EqualTo(new[] {"A", "A", null}));
            }

            [Test]
            public void SequenceNullElelmentNull()
            {
                Assert.That(() => NullSequence.Of<string>().Append(null), Throws.TypeOf<ValidationException>());
            }

            [Test]
            public void SequenceNullElementGood()
            {
                Assert.That(() => NullSequence.Of<string>().Append("A"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}