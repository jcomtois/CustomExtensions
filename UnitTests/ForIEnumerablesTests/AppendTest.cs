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
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

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
                var breakingSequnce = new BreakingSequence<object>();
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => breakingSequnce.Append(objectValue), Throws.Nothing);
            }

            [Test]
            public void Append_OnEmptySequence_WithElement_ReturnsSequenceWithElement()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => emptySequence.Append(objectValue), Is.EqualTo(objectValue.ToEnumerable()));
            }

            [Test]
            public void Append_OnEmptySequence_WithNull_ReturnsSequenceWithSingleNull()
            {
                var emptySequence = Enumerable.Empty<object>();
                object nullObject = null;

                Assert.That(() => emptySequence.Append(nullObject), Is.EqualTo(nullObject.ToEnumerable()));
            }

            [Test]
            public void Append_OnNullSequence_WithElelment_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => nullSequence.Append(objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Append_OnNullSequence_WithNullElement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                object nullObject = null;

                Assert.That(() => nullSequence.Append(nullObject), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Append_OnSequence_WithElement_ReturnsAppendedSequence()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectArray = fixture.CreateAnonymous<object[]>();
                var objectValue = fixture.CreateAnonymous<object>();
                var appendedSequence = objectArray.Concat(objectValue.ToEnumerable());

                Assert.That(() => objectArray.Append(objectValue), Is.EqualTo(appendedSequence));
            }

            [Test]
            public void Append_OnSequence_WithNullElement_ReturnsAppendedSequence()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectArray = fixture.CreateAnonymous<object[]>();
                object nullValue = null;
                var appendedSequence = objectArray.Concat(nullValue.ToEnumerable());

                Assert.That(() => objectArray.Append(nullValue), Is.EqualTo(appendedSequence));
            }
        }
    }
}