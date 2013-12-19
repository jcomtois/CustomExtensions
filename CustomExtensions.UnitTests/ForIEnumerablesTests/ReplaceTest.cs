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
        public class ReplaceTest
        {
            [Test]
            public void Replace_OnEmptySequence_WithElement_WithNullProjection_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                Func<object, object> nullFunc = null;

                Assert.That(() => emptySequence.Replace(objectValue, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnEmptySequence_WithElement_WithNullReplacement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                object nullObject = null;

                Assert.That(() => emptySequence.Replace(objectValue, nullObject), Is.Empty);
            }

            [Test]
            public void Replace_OnEmptySequence_WithElement_WithProjection_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => emptySequence.Replace(objectValue, objectFunc), Is.Empty);
            }

            [Test]
            public void Replace_OnEmptySequence_WithElement_WithReplacement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();

                Assert.That(() => emptySequence.Replace(objectValue, objectValue), Is.Empty);
            }

            [Test]
            public void Replace_OnEmptySequence_WithNullElement_WithNullProjection_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                object nullObject = null;
                Func<object, object> nullFunc = null;

                Assert.That(() => emptySequence.Replace(nullObject, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnEmptySequence_WithNullElement_WithNullReplacement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                object nullObject = null;

                Assert.That(() => emptySequence.Replace(nullObject, nullObject), Is.Empty);
            }

            [Test]
            public void Replace_OnEmptySequence_WithNullElement_WithProjection_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                object nullObject = null;
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => emptySequence.Replace(nullObject, objectFunc), Is.Empty);
            }

            [Test]
            public void Replace_OnEmptySequence_WithNullElement_WithReplacement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                object nullObject = null;
                var objectValue = fixture.Create<object>();

                Assert.That(() => emptySequence.Replace(nullObject, objectValue), Is.Empty);
            }

            [Test]
            public void Replace_OnNullSequence_WithElement_WithNullProjection_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                Func<object, object> nullFunc = null;

                Assert.That(() => nullSequence.Replace(objectValue, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithElement_WithNullReplacement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                object nullObject = null;

                Assert.That(() => nullSequence.Replace(objectValue, nullObject), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithElement_WithProjection_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => nullSequence.Replace(objectValue, objectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithElement_WithReplacement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.Create<object>();

                Assert.That(() => nullSequence.Replace(objectValue, objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithNullElement_WithNullProjection_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                object nullObject = null;
                Func<object, object> nullFunc = null;

                Assert.That(() => nullSequence.Replace(nullObject, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithNullElement_WithNullReplacement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                object nullObject = null;

                Assert.That(() => nullSequence.Replace(nullObject, nullObject), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithNullElement_WithProjection_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                object nullObject = null;
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => nullSequence.Replace(nullObject, objectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnNullSequence_WithNullElement_WithReplacement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                object nullObject = null;
                var objectValue = fixture.Create<object>();

                Assert.That(() => nullSequence.Replace(nullObject, objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnSequenceWithNulls_WithNullElement_WithNullReplacement_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                sequence[1] = nullObject;

                Assert.That(() => sequence.Replace(nullObject, nullObject), Is.EqualTo(sequence));
            }

            [Test]
            public void Replace_OnSequenceWithNulls_WithNullElement_WithReplacement_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                sequence[0] = nullObject;
                var objectValue = fixture.Create<object>();
                var expected = new[] {objectValue, sequence[1], sequence[2]};

                Assert.That(() => sequence.Replace(nullObject, objectValue), Is.EqualTo(expected));
            }

            [Test]
            public void Replace_OnSequence_WithElement_WithNullProjection_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = fixture.Create<object>();
                Func<object, object> nullFunc = null;

                Assert.That(() => sequence.Replace(objectValue, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnSequence_WithElement_WithNullReplacement_ReturnsWithNullAsReplacement()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = sequence[2];
                object nullObject = null;
                var expected = new[] {sequence[0], sequence[1], nullObject};

                Assert.That(() => sequence.Replace(objectValue, nullObject), Is.EqualTo(expected));
            }

            [Test]
            public void Replace_OnSequence_WithElement_WithProjection_ReturnsSequenceWithReplacement()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = sequence[1];
                var objectFunc = fixture.Create<Func<object, object>>();
                var projectedValue = objectFunc(objectValue);
                var expected = new[] {sequence[0], projectedValue, sequence[2]};

                Assert.That(() => sequence.Replace(objectValue, objectFunc), Is.EqualTo(expected));
            }

            [Test]
            public void Replace_OnSequence_WithElement_WithReplacement_ReturnsSequenceWithReplacement()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = sequence[0];
                var replacementValue = fixture.Create<object>();
                var expected = new[] {replacementValue, sequence[1], sequence[2]};

                Assert.That(() => sequence.Replace(objectValue, replacementValue), Is.EqualTo(expected));
            }

            [Test]
            public void Replace_OnSequence_WithNoMatches_WithProjection_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = fixture.Create<object>();
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => sequence.Replace(objectValue, objectFunc), Is.EqualTo(sequence));
            }

            [Test]
            public void Replace_OnSequence_WithNoMatches_WithReplacement_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                var objectValue = fixture.Create<object>();
                var replacementValue = fixture.Create<object>();

                Assert.That(() => sequence.Replace(objectValue, replacementValue), Is.EqualTo(sequence));
            }

            [Test]
            public void Replace_OnSequence_WithNullElement_WithNullProjection_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                Func<object, object> nullFunc = null;

                Assert.That(() => sequence.Replace(nullObject, nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Replace_OnSequence_WithNullElement_WithNullReplacement_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;

                Assert.That(() => sequence.Replace(nullObject, nullObject), Is.EqualTo(sequence));
            }

            [Test]
            public void Replace_OnSequence_WithNullElement_WithProjection_NullsReplacedInSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                sequence[1] = nullObject;
                sequence[2] = nullObject;
                var objectFunc = fixture.Create<Func<object, object>>();
                var expected = new[] {sequence[0], objectFunc(sequence[1]), objectFunc(sequence[2])};

                Assert.That(() => sequence.Replace(nullObject, objectFunc), Is.EqualTo(expected));
            }

            [Test]
            public void Replace_OnSequence_WithNullElement_WithReplacement_ReturnsOriginalSequence()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<object>>();
                object nullObject = null;
                var objectValue = fixture.Create<object>();

                Assert.That(() => sequence.Replace(nullObject, objectValue), Is.EqualTo(sequence));
            }

            [Test]
            public void Replace_WithProjection_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.Create<BreakingSequence<object>>();
                var objectValue = fixture.Create<object>();
                var objectFunc = fixture.Create<Func<object, object>>();

                Assert.That(() => breakingSequence.Replace(objectValue, objectFunc), Throws.Nothing);
            }

            [Test]
            public void Replace_WithReplacement_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.Create<BreakingSequence<object>>();
                var objectValue = fixture.Create<object>();

                Assert.That(() => breakingSequence.Replace(objectValue, objectValue), Throws.Nothing);
            }
        }
    }
}