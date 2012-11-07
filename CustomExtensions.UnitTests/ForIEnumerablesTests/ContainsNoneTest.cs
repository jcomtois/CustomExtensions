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
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ContainsNoneTest
        {
            [Test]
            public void ContainsNone_OnEmptySequence_MeetsPredicate_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var emptySequence = Enumerable.Empty<object>();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => emptySequence.ContainsNone(predicate), Is.True);
            }

            [Test]
            public void ContainsNone_OnEmptySequence_PredicateNull_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => emptySequence.ContainsNone(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnEmptySequence_ReturnsTrue()
            {
                var emptySequence = Enumerable.Empty<object>();

                Assert.That(() => emptySequence.ContainsNone(), Is.True);
            }

            [Test]
            public void ContainsNone_OnNullSequence_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;

                Assert.That(() => nullSequence.ContainsNone(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnNullSequence_WithMeetsPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => nullSequence.ContainsNone(predicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnNullSequence_WithNullPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, bool> nullPredicate = null;

                Assert.That(() => nullSequence.ContainsNone(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsNone_OnSequenceOfOne_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var sequenceOfOne = fixture.CreateMany<object>(1);

                Assert.That(() => sequenceOfOne.ContainsNone(), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOfThree_AllMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture(3);
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => true;

                Assert.That(() => sequenceOfThree.ContainsNone(objectFunc), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOfThree_NoMatchesPredicate_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture(3);
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => false;

                Assert.That(() => sequenceOfThree.ContainsNone(objectFunc), Is.True);
            }

            [Test]
            public void ContainsNone_OnSequenceOfThree_OneMatchesPredicate_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture(3);
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> objectFunc = o => o == sequenceOfThree.First();

                Assert.That(() => sequenceOfThree.ContainsNone(objectFunc), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOfThree_PredicateNull_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture(3);
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => sequenceOfThree.ContainsNone(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnSequenceOfThree_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture(3);
                var sequenceOfThree = fixture.CreateAnonymous<object[]>();

                Assert.That(() => sequenceOfThree.ContainsNone(), Is.False);
            }
        }
    }
}