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
        public class ContainsNoneTest
        {
            [Test]
            public void ContainsNone_OnEmptyStringSeqeuence_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.ContainsNone(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnEmptyStringSequence_MeetsPredictate_ReturnsTrue()
            {
                Assert.That(() => EmptyStringSequence.ContainsNone(Fixture.CreateAnonymous<Func<string, bool>>()), Is.True);
            }

            [Test]
            public void ContainsNone_OnEmptyStringSequence_ReturnsTrue()
            {
                Assert.That(() => EmptyStringSequence.ContainsNone(), Is.True);
            }

            [Test]
            public void ContainsNone_OnNullStringSequence_MeetsPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsNone(Fixture.CreateAnonymous<Func<string, bool>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnNullStringSequence_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsNone(null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsNone_OnNullStringSequence_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ContainsNone(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnSequenceOfOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOfOne.ContainsNone(), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOneTwoThree_NullPredicate_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsNone(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsNone_OnSequenceOneTwoThree_PredicateEqualsOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsNone(i => i == 1), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOneTwoThree_PredicateGreaterThansOne_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsNone(i => i > 1), Is.False);
            }

            [Test]
            public void ContainsNone_OnSequenceOneTwoThree_PredicateLessThansOne_ReturnsTrue()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsNone(i => i < 1), Is.True);
            }

            [Test]
            public void ContainsNone_OnSequenceOneTwoThree_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.ContainsNone(), Is.False);
            }
        }
    }
}