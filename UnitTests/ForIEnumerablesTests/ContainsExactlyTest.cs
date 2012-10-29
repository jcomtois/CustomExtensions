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
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ContainsExactlyTest
        {
            [Test]
            public void ContainsExactly_OnEmptySequence_OnOne_MeetsPredicate_ReturnsFalse()
            {
                Assert.That(() => EmptyStringSequence.ContainsExactly(1, Fixture.CreateAnonymous<Func<string, bool>>()), Is.False);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnOne_ReturnsFalse()
            {
                Assert.That(() => EmptyStringSequence.ContainsExactly(1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_MeetsPredicate_ReturnsTrue()
            {
                Assert.That(() => EmptyStringSequence.ContainsExactly(0, Fixture.CreateAnonymous<Func<string, bool>>()), Is.True);
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_PredicateNull_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.ContainsExactly(0, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnEmptySequence_OnZero_ReturnsTrue()
            {
                Assert.That(() => EmptyStringSequence.ContainsExactly(0), Is.True);
            }

            [Test]
            public void ContainsExactly_OnNullStringSequence_OnZero_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsExactly(0), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnNullStringSequence_OnZero_WithMeetsPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsExactly(0, Fixture.CreateAnonymous<Func<string, bool>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnNullStringSequence_OnZero_WithNullPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsExactly(0, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOfOne.ContainsExactly(1), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnTwo_ReturnsFalse()
            {
                Assert.That(() => SequenceOfOne.ContainsExactly(2), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOfOne_OnZero_ReturnsFalse()
            {
                Assert.That(() => SequenceOfOne.ContainsExactly(0), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnFour_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(4), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnOnThree_PredicatNull_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(3, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnOne_PredicateEqualToOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(1, i => i == 1), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnOne_PredicateGreaterThanOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(1, i => i > 1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnOne_PredicateLessThanOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(1, i => i < 1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnThree_PredicateGreaterThanOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(3, i => i > 1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnThree_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(3), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnTwo_PredicateGreaterThanOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(2, i => i > 1), Is.True);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnTwo_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(2), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnZero_PredicateEqualToOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(0, i => i == 1), Is.False);
            }

            [Test]
            public void ContainsExactly_OnSequenceOneTwoThree_OnZero_PredicateLessThanOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsExactly(0, i => i < 1), Is.True);
            }
        }
    }
}