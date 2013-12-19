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
        public class ToStringTest
        {
            [Test]
            public void ToString_OnEmptySequence_WithNullProjection_WithNullSeparator_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, string> nullProjection = null;
                string nullSeparator = null;

                Assert.That(() => emptySequence.ToString(nullProjection, nullSeparator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnEmptySequence_WithNullProjection_WithSeparator_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new LatinStringFixture();
                Func<object, string> nullProjection = null;
                var separator = fixture.Create<string>();

                Assert.That(() => emptySequence.ToString(nullProjection, separator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnEmptySequence_WithProjection_WithNullSeparator_ReturnsEmptyString()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var projection = fixture.Create<Func<object, string>>();
                string nullSeparator = null;

                Assert.That(() => emptySequence.ToString(projection, nullSeparator), Is.Empty);
            }

            [Test]
            public void ToString_OnEmptySequence_WithProjection_WithSeparator_ReturnsEmptyString()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new LatinStringFixture();
                var projection = fixture.Create<Func<object, string>>();
                var separator = fixture.Create<string>();

                Assert.That(() => emptySequence.ToString(projection, separator), Is.Empty);
            }

            [Test]
            public void ToString_OnEmptyStringSequence_WithNullSeparator_ReturnsEmptyString()
            {
                var emptySequence = Enumerable.Empty<string>();
                string nullSeparator = null;

                Assert.That(() => emptySequence.ToString(nullSeparator), Is.Empty);
            }

            [Test]
            public void ToString_OnEmptyStringSequence_WithSeparator_ReturnsEmptyString()
            {
                var emptySequence = Enumerable.Empty<string>();
                var fixture = new LatinStringFixture();
                var separator = fixture.Create<string>();

                Assert.That(() => emptySequence.ToString(separator), Is.Empty);
            }

            [Test]
            public void ToString_OnNullSequence_WithNullProjection_WithNullSeparator_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, string> nullProjection = null;
                string nullSeparator = null;

                Assert.That(() => nullSequence.ToString(nullProjection, nullSeparator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToString_OnNullSequence_WithNullProjection_WithSeparator_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new LatinStringFixture();
                Func<object, string> nullProjection = null;
                var separator = fixture.Create<string>();

                Assert.That(() => nullSequence.ToString(nullProjection, separator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToString_OnNullSequence_WithProjection_WithSeparator_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new LatinStringFixture();
                var projection = fixture.Create<Func<object, string>>();
                var separator = fixture.Create<string>();

                Assert.That(() => nullSequence.ToString(projection, separator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnNullStringSequence_WithNullSeparator_ThrowsValidationException()
            {
                IEnumerable<string> nullSequence = null;
                string nullSeparator = null;

                Assert.That(() => nullSequence.ToString(nullSeparator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnNullStringSequence_WithSeparator_ThrowsValidationException()
            {
                IEnumerable<string> nullSequence = null;
                var fixture = new LatinStringFixture();
                var separator = fixture.Create<string>();

                Assert.That(() => nullSequence.ToString(separator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnSequenceOfOne_WithProjection_WithSeparator_ReturnsNonSeparatedString()
            {
                var fixture = new LatinMultipleMockingFixture(1);
                var sequence = fixture.Create<object[]>();
                var projection = fixture.Create<Func<object, string>>();
                var separator = fixture.Create<string>();
                var expected = projection(sequence[0]);

                Assert.That(() => sequence.ToString(projection, separator), Is.EqualTo(expected));
            }

            [Test]
            public void ToString_OnSequence_WithNullProjection_WithNullSeparator_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<object[]>();
                Func<object, string> nullProjection = null;
                string nullSeparator = null;

                Assert.That(() => sequence.ToString(nullProjection, nullSeparator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnSequence_WithNullProjection_WithSeparator_ThrowsValidationException()
            {
                var fixture = new LatinMultipleMockingFixture();
                var sequence = fixture.Create<object[]>();
                Func<object, string> nullProjection = null;
                var separator = fixture.Create<string>();

                Assert.That(() => sequence.ToString(nullProjection, separator), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ToString_OnSequence_WithProjection_WithNullSeparator_ReturnsNonSeparatedString()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<object[]>();
                var projection = fixture.Create<Func<object, string>>();
                string nullSeparator = null;
                var expected = projection(sequence[0]) + projection(sequence[1]) + projection(sequence[2]);

                Assert.That(() => sequence.ToString(projection, nullSeparator), Is.EqualTo(expected));
            }

            [Test]
            public void ToString_OnSequence_WithProjection_WithSeparator_ReturnsSeparatedString()
            {
                var fixture = new LatinMultipleMockingFixture();
                var sequence = fixture.Create<object[]>();
                var projection = fixture.Create<Func<object, string>>();
                var separator = fixture.Create<string>();
                var expected = projection(sequence[0]) + separator + projection(sequence[1]) + separator + projection(sequence[2]);

                Assert.That(() => sequence.ToString(projection, separator), Is.EqualTo(expected));
            }

            [Test]
            public void ToString_OnStringSequenceOfOne_WithSeparator_ReturnsNonSeparatedString()
            {
                var fixture = new LatinMultipleMockingFixture(1);
                var stringSequence = fixture.Create<string[]>();
                var separator = fixture.Create<string>();

                var expected = stringSequence[0];

                Assert.That(() => stringSequence.ToString(separator), Is.EqualTo(expected));
            }

            [Test]
            public void ToString_OnStringSequence_WithNullSeparator_ReturnsNonSeparatedString()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringSequence = fixture.Create<string[]>();
                string nullSeparator = null;
                var expected = stringSequence[0] + stringSequence[1] + stringSequence[2];

                Assert.That(() => stringSequence.ToString(nullSeparator), Is.EqualTo(expected));
            }

            [Test]
            public void ToString_OnStringSequence_WithSeparator_ReturnsSeparatedString()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringSequence = fixture.Create<string[]>();
                var separator = fixture.Create<string>();

                var expected = stringSequence[0] + separator + stringSequence[1] + separator + stringSequence[2];

                Assert.That(() => stringSequence.ToString(separator), Is.EqualTo(expected));
            }
        }
    }
}