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
using System.Collections;
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
        public class IsEmptyTest
        {
            [Test]
            public void IsEmpty_OnGenericCollectionEmpty_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                ICollection<object> emptyGenericCollection = fixture.CreateAnonymous<ICollection<object>>();
                emptyGenericCollection.Clear();

                Assert.That(() => emptyGenericCollection.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnGenericCollectionMultipleItem_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                ICollection<object> nonEmptyGenericCollection = fixture.CreateAnonymous<ICollection<object>>();

                Assert.That(() => nonEmptyGenericCollection.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnGenericCollectionNull_ThrowsValidationException()
            {
                ICollection<int> nullCollection = null;

                Assert.That(() => nullCollection.IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmpty_OnGenericCollectionSingleItem_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture(1);
                var singleItemCollection = fixture.CreateAnonymous<ICollection<object>>();

                Assert.That(() => singleItemCollection.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableEmpty_ReturnsTrue()
            {
                IEnumerable<object> emptyEnumerable = Enumerable.Empty<object>();

                Assert.That(() => emptyEnumerable.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableMultipleItem_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var nonEmptyEnumerable = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => nonEmptyEnumerable.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableNull_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;

                Assert.That(() => nullSequence.IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableSingleItem_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture(1);
                var singleItemEnumerable = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => singleItemEnumerable.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionEmpty_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var mock = fixture.CreateAnonymous<Mock<IEnumerable>>();
                IEnumerable emptyNonGenericCollection = mock.Object;

                Assert.That(() => emptyNonGenericCollection.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionMultipleItem_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                IEnumerable nonEmptyNonGenericCollection = fixture.CreateMany<object>();

                Assert.That(() => nonEmptyNonGenericCollection.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionNull_ThrowsValidationException()
            {
                ICollection nullCollection = null;

                Assert.That(() => nullCollection.IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionSingleItem_ReturnsFalse()
            {
                var fixture = new BaseFixture();
                var mock = new Mock<ICollection>();
                mock.Setup(m => m.Count).Returns(1);
                mock.Setup(m => m.GetEnumerator()).Returns(fixture.CreateAnonymous<object>().ToEnumerable().GetEnumerator);
                ICollection singleItemNonGenericCollection = mock.Object;

                Assert.That(() => singleItemNonGenericCollection.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableEmpty_ReturnsTrue()
            {
                var mock = new Mock<IEnumerable>();
                mock.Setup(m => m.GetEnumerator()).Returns(() => new Mock<IEnumerator>().Object);
                IEnumerable emptyNonGenericEnumerable = mock.Object;

                Assert.That(() => emptyNonGenericEnumerable.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableMultipleItem_ReturnsFalse()
            {
                var fixture = new BaseFixture();
                var mock = new Mock<IEnumerable>();
                mock.Setup(m => m.GetEnumerator()).Returns(fixture.CreateMany<object>().GetEnumerator);
                IEnumerable sequence = mock.Object;

                Assert.That(() => sequence.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableNull_ThrowsValidationException()
            {
                IEnumerable nullCollection = null;

                Assert.That(() => nullCollection.IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableSingleItem_ReturnsFalse()
            {
                var fixture = new BaseFixture();
                var mock = fixture.CreateAnonymous<Mock<IEnumerable>>();
                mock.Setup(m => m.GetEnumerator()).Returns(fixture.CreateAnonymous<object>().ToEnumerable().GetEnumerator);
                IEnumerable sequence = mock.Object;

                Assert.That(() => sequence.IsEmpty(), Is.False);
            }
        }
    }
}