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
        public class ContainsExactlyTest
        {
            [Test]
            public void ContainsExactly_OnEmptySequence_OnOne_MeetsPredicate_ReturnsFalse()
            {
                var fixture = new BaseFixture();
                var emptySequence = Enumerable.Empty<object>();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => emptySequence.ContainsExactly(1, predicate), Is.False);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnOne_ReturnsFalse()
            {
                var emptySequence = Enumerable.Empty<object>();

                Assert.That(() => emptySequence.ContainsExactly(1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_MeetsPredicate_ReturnsTrue()
            {
                var fixture = new BaseFixture();
                var emptySequence = Enumerable.Empty<object>();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => emptySequence.ContainsExactly(0, predicate), Is.True);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_PredicateNull_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => emptySequence.ContainsExactly(0, nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_ReturnsTrue()
            {
                var emptySequence = Enumerable.Empty<object>();

                Assert.That(() => emptySequence.ContainsExactly(0), Is.True);
            }

            [Test]
            public void ContainsExactly_OnNullSequence_OnZero_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;

                Assert.That(() => nullSequence.ContainsExactly(0), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnNullSequence_OnZero_WithMeetsPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => nullSequence.ContainsExactly(0, predicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnNullSequence_OnZero_WithNullPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, bool> predicate = null;

                Assert.That(() => nullSequence.ContainsExactly(0, predicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnOne_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfOne = fixture.CreateMany<object>(1);

                Assert.That(() => sequenceOfOne.ContainsExactly(1), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnTwo_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfOne = fixture.CreateMany<object>(1);

                Assert.That(() => sequenceOfOne.ContainsExactly(2), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnZero_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfOne = fixture.CreateMany<object>(1);

                Assert.That(() => sequenceOfOne.ContainsExactly(0), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnFour_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();

                Assert.That(() => sequenceOfThree.ContainsExactly(4), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnOnThree_PredicateNull_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => sequenceOfThree.ContainsExactly(3, nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnOne_AllMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => true;

                Assert.That(() => sequenceOfThree.ContainsExactly(1, objectFunc), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnOne_NoMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => false;

                Assert.That(() => sequenceOfThree.ContainsExactly(1, objectFunc), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnOne_OneMatchesPredicate_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => o == sequenceOfThree.First();

                Assert.That(() => sequenceOfThree.ContainsExactly(1, objectFunc), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnThree_AllMatchesPredicate_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => true;

                Assert.That(() => sequenceOfThree.ContainsExactly(3, objectFunc), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnThree_NoMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => false;

                Assert.That(() => sequenceOfThree.ContainsExactly(3, objectFunc), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnThree_OneMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => o == sequenceOfThree.First();

                Assert.That(() => sequenceOfThree.ContainsExactly(3, objectFunc), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfThree_OnThree_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();

                Assert.That(() => sequenceOfThree.ContainsExactly(3), Is.True);
            }
        }
    }
}