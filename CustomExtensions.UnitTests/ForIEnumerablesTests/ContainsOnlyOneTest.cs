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
        [Test]
        public void ContainsOnlyOne_OnEmptySequence_MeetsPredicate_ReturnsFalse()
        {
            var fixture = new BaseFixture();
            var emptySequence = Enumerable.Empty<object>();
            var predicate = fixture.Create<Func<object, bool>>();

            Assert.That(() => emptySequence.ContainsOnlyOne(predicate), Is.False);
        }

        [Test]
        public void ContainsOnlyOne_OnEmptySequence_PredicateNull_ThrowsValidationException()
        {
            var emptySequence = Enumerable.Empty<object>();
            Func<object, bool> nullPredicate = null;

            Assert.That(() => emptySequence.ContainsOnlyOne(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ContainsOnlyOne_OnEmptySequence_ReturnsFalse()
        {
            var emptySequence = Enumerable.Empty<object>();

            Assert.That(() => emptySequence.ContainsOnlyOne(), Is.False);
        }

        [Test]
        public void ContainsOnlyOne_OnNullSequence_ThrowsValidationException()
        {
            IEnumerable<object> nullSequence = null;

            Assert.That(() => nullSequence.ContainsOnlyOne(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ContainsOnlyOne_OnNullSequence_WithMeetsPredicate_ThrowsValidationException()
        {
            IEnumerable<object> nullSequence = null;
            var fixture = new BaseFixture();
            var predicate = fixture.Create<Func<object, bool>>();

            Assert.That(() => nullSequence.ContainsOnlyOne(predicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ContainsOnlyOne_OnNullSequence_WithNullPredicate_ThrowsValidationException()
        {
            IEnumerable<object> nullSequence = null;
            Func<object, bool> predicate = null;

            Assert.That(() => nullSequence.ContainsOnlyOne(predicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfOne_ReturnsTrue()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfOne = fixture.CreateMany<object>(1);

            Assert.That(() => sequenceOfOne.ContainsOnlyOne(), Is.True);
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfThree_AllMatchesPredicate_ReturnsFalse()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfThree = fixture.Create<object[]>();
            Func<object, bool> objectFunc = o => true;

            Assert.That(() => sequenceOfThree.ContainsOnlyOne(objectFunc), Is.False);
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfThree_NoMatchesPredicate_ReturnsFalse()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfThree = fixture.Create<object[]>();
            Func<object, bool> objectFunc = o => false;

            Assert.That(() => sequenceOfThree.ContainsOnlyOne(objectFunc), Is.False);
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfThree_OneMatchesPredicate_ReturnsTrue()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfThree = fixture.Create<object[]>();
            Func<object, bool> objectFunc = o => o == sequenceOfThree.First();

            Assert.That(() => sequenceOfThree.ContainsOnlyOne(objectFunc), Is.True);
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfThree_PredicateNull_ThrowsValidationException()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfThree = fixture.Create<object[]>();
            Func<object, bool> nullPredicate = null;

            Assert.That(() => sequenceOfThree.ContainsOnlyOne(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ContainsOnlyOne_OnSequenceOfThree_ReturnsFalse()
        {
            var fixture = new MultipleMockingFixture();
            var sequenceOfThree = fixture.Create<object[]>();

            Assert.That(() => sequenceOfThree.ContainsOnlyOne(), Is.False);
        }
    }
}