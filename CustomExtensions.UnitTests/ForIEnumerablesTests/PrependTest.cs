#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class PrependTest
        {
            [Test]
            public void Prepend_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.Create<BreakingSequence<object>>();

                Assert.That(() => breakingSequence.Prepend(breakingSequence), Throws.Nothing);
            }

            [Test]
            public void Prepend_OnEmptySequence_WithElement_ReturnsSequenceOfElement()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();

                Assert.That(emptySequence.Prepend(objectValue), Is.EqualTo(objectValue.ToEnumerable()));
            }

            [Test]
            public void Prepend_OnEmptySequence_WithNullElement_ReturnsSequenceOfNullElement()
            {
                var emptySequence = Enumerable.Empty<object>();
                object nullObject = null;

                Assert.That(emptySequence.Prepend(nullObject), Is.EqualTo(nullObject.ToEnumerable()));
            }

            [Test]
            public void Prepend_OnNullSequence_WithElement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();

                Assert.That(() => nullSequence.Prepend(objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Prepend_OnNullSequence_WithNullElement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                object nullObject = null;

                Assert.That(() => nullSequence.Prepend(nullObject), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Prepend_OnSequence_WithElement_ReturnsElementPrependedToSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var element = fixture.Create<object>();
                var expected = element.ToEnumerable().Concat(sequence);

                Assert.That(sequence.Prepend(element), Is.EqualTo(expected));
            }

            [Test]
            public void Prepend_OnSequence_WithNullElement_ReturnsNullElelemntPrependedToSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                var expected = nullObject.ToEnumerable().Concat(sequence);

                Assert.That(sequence.Prepend(nullObject), Is.EqualTo(expected));
            }
        }
    }
}