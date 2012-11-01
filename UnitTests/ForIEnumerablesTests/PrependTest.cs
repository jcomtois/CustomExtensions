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
using Ploeh.AutoFixture;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class PrependTest
        {
            [Test]
            public void Prepend_IsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().Prepend(Fixture.CreateAnonymous<string>()), Throws.Nothing);
            }

            [Test]
            public void Prepend_OnEmptySequence_WithElement_ReturnsSequenceOfElement()
            {
                var element = Fixture.CreateAnonymous<string>();
                Assert.That(EmptyStringSequence.Prepend(element), Is.EqualTo(element.ToEnumerable()));
            }

            [Test]
            public void Prepend_OnEmptySequence_WithNullElement_ReturnsSequenceOfNullElement()
            {
                Assert.That(EmptyStringSequence.Prepend(null), Is.EqualTo(NullString.ToEnumerable()));
            }

            [Test]
            public void Prepend_OnNullSequence_WithElement_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.Prepend(Fixture.CreateAnonymous<string>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Prepend_OnNullSequence_WithNullElement_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.Prepend(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Prepend_OnSequence_WithElement_ReturnsElementPrependedToSequence()
            {
                var sequence = Fixture.CreateMany<string>().ToArray();
                var element = Fixture.CreateAnonymous<string>();
                Assert.That(sequence.Prepend(element), Is.EqualTo(element.ToEnumerable().Concat(sequence)));
            }

            [Test]
            public void Prepend_OnSequence_WithNullElement_ReturnsNullElelemntPrependedToSequence()
            {
                var sequence = Fixture.CreateMany<string>().ToArray();
                Assert.That(sequence.Prepend(NullString), Is.EqualTo(NullString.ToEnumerable().Concat(sequence)));
            }
        }
    }
}