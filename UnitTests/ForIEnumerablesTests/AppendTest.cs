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
using Moq;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class AppendTest
        {
            [Test]
            public void Append_IsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().Append(It.IsAny<string>()), Throws.Nothing);
            }

            [Test]
            public void Append_OnEmptySequence_WithNull_ReturnsSequenceWithSingleNull()
            {
                Assert.That(EmptyStringEnumerable.Append(NullString), Is.EqualTo(Enumerable.Repeat(NullString, 1)));
            }

            [Test]
            public void Append_OnEmptySequence_WithSingleElement_ReturnsSequenceWithSingleElement()
            {
                Assert.That(EmptyStringEnumerable.Append(SingleLetterString), Is.EqualTo(Enumerable.Repeat(SingleLetterString, 1)));
            }

            [Test]
            public void Append_OnNullSequence_WithSingleLetterString_ThrowsValidationException()
            {
                Assert.That(() => NullSequence.Of<string>().Append(SingleLetterString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Append_OnSequenceOfTwo_WithAnotherElement_ReturnsAppendedSequence()
            {
                Assert.That(Enumerable.Repeat(SingleLetterString, 2).Append(SingleLetterString), Is.EqualTo(Enumerable.Repeat(SingleLetterString, 3)));
            }

            [Test]
            public void Append_OnSequenceOfTwo_WithNullElement_ReturnsAppendedSequence()
            {
                Assert.That(Enumerable.Repeat(SingleLetterString, 2).Append(NullString), Is.EqualTo(new[] {SingleLetterString, SingleLetterString, NullString}));
            }

            [Test]
            public void Append_OnnNullSequence_WithNullString_ThrowsValidationException()
            {
                Assert.That(() => NullSequence.Of<string>().Append(NullString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}