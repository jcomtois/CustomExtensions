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
        public class ContainsOnlyOneTest
        {
            [Test]
            public void ContainsOnlyOne_OnEmptyStringSequence_MeetsPredicate_ReturnsFalse()
            {
                Assert.That(() => EmptyStringSequence.ContainsOnlyOne(Fixture.CreateAnonymous<Func<string, bool>>()), Is.False);
            }

            [Test]
            public void ContainsOnlyOne_OnEmptyStringSequence_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.ContainsOnlyOne(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsOnlyOne_OnEmptyStringSequence_ReturnsFalse()
            {
                Assert.That(() => EmptyStringSequence.ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void ContainsOnlyOne_OnNullStringSequence_MeetsPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsOnlyOne(Fixture.CreateAnonymous<Func<string, bool>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsOnlyOne_OnNullStringSequence_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsOnlyOne(null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsOnlyOne_OnNullStringSequence_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsOnlyOne(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOfOne_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => SequenceOfOne.ContainsOnlyOne(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOfOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOfOne.ContainsOnlyOne(), Is.True);
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOneTwoThree_PredicateEqualsOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsOnlyOne(i => i == 1), Is.True);
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOneTwoThree_PredicateGreaterThanOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsOnlyOne(i => i > 1), Is.False);
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOneTwoThree_PredicateLessThanOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsOnlyOne(i => i < 1), Is.False);
            }

            [Test]
            public void ContainsOnlyOne_OnSequenceOneTwoThree_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsOnlyOne(), Is.False);
            }
        }
    }
}