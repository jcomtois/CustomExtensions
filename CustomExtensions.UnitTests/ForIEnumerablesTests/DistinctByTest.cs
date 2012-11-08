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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class DistinctByTest
        {
            [Test]
            public void DistinctBy_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();

                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();

                Assert.That(() => breakingSequence.DistinctBy(objectFunc), Throws.Nothing);
            }

            [Test]
            public void DistinctBy_OnDoubledSequence_WithKeySelector_ReturnsSingleSequence()
            {
                var fixture = new MultipleMockingFixture();
                var singleSequence = fixture.CreateAnonymous<object[]>();
                var doubleSequence = singleSequence.Concat(singleSequence);
                Func<object, object> objectFunc = o => o;

                Assert.That(() => doubleSequence.DistinctBy(objectFunc), Is.EqualTo(singleSequence));
            }

            [Test]
            public void DistinctBy_OnDoubledSequence_WithKeySelector_WithEqualityComparer_ReturnsSingleSequence()
            {
                var fixture = new MultipleMockingFixture();
                var singleSequence = fixture.CreateAnonymous<object[]>();
                var doubleSequence = singleSequence.Concat(singleSequence);
                Func<object, object> objectFunc = o => o;

                var mock = fixture.CreateAnonymous<Mock<IEqualityComparer<object>>>();
                mock.Setup(e => e.GetHashCode()).Returns((object o) => o.GetHashCode());
                mock.Setup(e => e.GetHashCode(It.IsAny<object>())).Returns((object o) => o.GetHashCode());
                mock.Setup(e => e.Equals(It.IsAny<object>())).Returns((object o, object b) => o.GetHashCode() == b.GetHashCode());
                mock.Setup(e => e.Equals(It.IsAny<object>(), It.IsAny<object>())).Returns((object o, object b) => o.GetHashCode() == b.GetHashCode());

                var equalityComparer = mock.Object;

                Assert.That(() => doubleSequence.DistinctBy(objectFunc, equalityComparer), Is.EqualTo(singleSequence));
            }

            [Test]
            public void DistinctBy_OnDoubledSequence_WithKeySelector_WithNullEqualityComparer_ReturnsSingleSequence()
            {
                var fixture = new MultipleMockingFixture();
                var singleSequence = fixture.CreateAnonymous<object[]>();
                var doubleSequence = singleSequence.Concat(singleSequence);
                Func<object, object> objectFunc = o => o;

                IEqualityComparer<object> nullEqualityComparer = null;

                Assert.That(() => doubleSequence.DistinctBy(objectFunc, nullEqualityComparer), Is.EqualTo(singleSequence));
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithKeySelector_ReturnsNoElements()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();

                Assert.That(() => emptySequence.DistinctBy(objectFunc), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithKeySelector_WithEqualityComparer_ReturnsNoElements()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();
                var equalityComparer = fixture.CreateAnonymous<IEqualityComparer<object>>();

                Assert.That(() => emptySequence.DistinctBy(objectFunc, equalityComparer), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithKeySelector_WithNullEqualityComparer_ReturnsNoElements()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();
                IEqualityComparer<object> nullEqualityComparer = null;

                Assert.That(() => emptySequence.DistinctBy(objectFunc, nullEqualityComparer), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithNullKeySelector_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, object> nullObjectFunc = null;

                Assert.That(() => emptySequence.DistinctBy(nullObjectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithNullKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                Func<object, object> nullObjectFunc = null;
                var equalityComparer = fixture.CreateAnonymous<IEqualityComparer<object>>();

                Assert.That(() => emptySequence.DistinctBy(nullObjectFunc, equalityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnEmptySequence_WithNullKeySelector_WithNullEqualityComparer_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, object> nullObjectFunc = null;
                IEqualityComparer<object> nullEqualityComparer = null;

                Assert.That(() => emptySequence.DistinctBy(nullObjectFunc, nullEqualityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithKeySelector_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();

                Assert.That(() => nullSequence.DistinctBy(objectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();
                var equalityComparer = fixture.CreateAnonymous<IEqualityComparer<object>>();

                Assert.That(() => nullSequence.DistinctBy(objectFunc, equalityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithKeySelector_WithNullEqualityComparere_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();
                IEqualityComparer<object> nullEqualityComparer = null;

                Assert.That(() => nullSequence.DistinctBy(objectFunc, nullEqualityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithNullKeySelector_ThrowsValidtationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, object> nullObjectFunc = null;

                Assert.That(() => nullSequence.DistinctBy(nullObjectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithNullKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, object> nullObjectFunc = null;
                var fixture = new MultipleMockingFixture();
                var equalityComparer = fixture.CreateAnonymous<IEqualityComparer<object>>();

                Assert.That(() => nullSequence.DistinctBy(nullObjectFunc, equalityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_OnNullSequence_WithNullKeySelector_WithNullEqualityComparer_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, object> nullObjectFunc = null;
                IEqualityComparer<object> nullEqualityComparer = null;

                Assert.That(() => nullSequence.DistinctBy(nullObjectFunc, nullEqualityComparer), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_WithEqualityComparer_IsLazy()
            {
                var fixture = new MultipleMockingFixture();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();
                var objectFunc = fixture.CreateAnonymous<Func<object, object>>();
                var equalityComparer = fixture.CreateAnonymous<IEqualityComparer<object>>();

                Assert.That(() => breakingSequence.DistinctBy(objectFunc, equalityComparer), Throws.Nothing);
            }
        }
    }
}