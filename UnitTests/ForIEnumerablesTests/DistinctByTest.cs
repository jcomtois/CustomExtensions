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
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class DistinctByTest
        {
            [Test]
            public void DistinctBy_IsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().DistinctBy(Fixture.CreateAnonymous<Func<string, bool>>()), Throws.Nothing);
            }

            [Test]
            public void DistinctBy_OnDoubledSequenceOneTwoThree_WithKeySelector_ReturnsSingleSequenceOnTwoThree()
            {
                Assert.That(() => SequenceOneTwoThree.Concat(SequenceOneTwoThree).DistinctBy(i => i.ToString()), Is.EqualTo(SequenceOneTwoThree));
            }

            [Test]
            public void DistinctBy_OnDoubledSequenceOneTwoThree_WithKeySelector_WithEqualityComparer_ReturnsSingleSequenceOnTwoThree()
            {
                Assert.That(() => SequenceOneTwoThree.Concat(SequenceOneTwoThree).DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase), Is.EqualTo(SequenceOneTwoThree));
            }

            [Test]
            public void DistinctBy_OnDoubledSequenceOneTwoThree_WithKeySelector_WithNullEqualityComparer_ReturnsSingleSequenceOnTwoThree()
            {
                Assert.That(() => SequenceOneTwoThree.Concat(SequenceOneTwoThree).DistinctBy(i => i.ToString(), null), Is.EqualTo(SequenceOneTwoThree));
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithKeySelector_ReturnsNoElements()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>()), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithKeySelector_WithEqualityComparer_ReturnsNoElements()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>(), StringComparer.OrdinalIgnoreCase), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithKeySelector_WithNullEqualityComparer_ReturnsNoElements()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>(), null), Is.Empty);
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithNullKeySelector_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy((Func<string, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithNullKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnEmptyStringSequence_WithNullKeySelector_WithNullEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.DistinctBy((Func<string, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithKeySelector_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>()),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>(), StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithKeySelector_WithNullEqualityComparere_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy(Fixture.CreateAnonymous<Func<string, string>>(), null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithNullKeySelector_ThrowsValidtationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy((Func<string, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithNullKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_OnNullStringSequence_WithNullKeySelector_WithNullEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.DistinctBy((Func<string, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void DistinctBy_OnSequenceOneOneOne_WithKeySelector_ReturnsSingleElement()
            {
                Assert.That(() => SequenceOneOneOne.DistinctBy(i => i.ToString()), Is.EqualTo(1.ToEnumerable()));
            }

            [Test]
            public void DistinctBy_OnSequenceOneOneOne_WithKeySelector_WithEqualityComparer_ReturnsSingleElement()
            {
                Assert.That(() => SequenceOneOneOne.DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase), Is.EqualTo(1.ToEnumerable()));
            }

            [Test]
            public void DistinctBy_OnSequenceOneOneOne_WithKeySelector_WithNullEqualityComparer_ReturnsSingleElement()
            {
                Assert.That(() => SequenceOneOneOne.DistinctBy(i => i.ToString(), null), Is.EqualTo(1.ToEnumerable()));
            }

            [Test]
            public void DistinctBy_OnSequenceOneTwoThree_WithNullKeySelector_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.DistinctBy((Func<int, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnSequenceOneTwoThree_WithNullKeySelector_WithEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_OnSequenceOneTwoThree_WithNullKeySelector_WithNullEqualityComparer_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.DistinctBy((Func<int, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void DistinctBy_WithEqualityComparer_IsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().DistinctBy(Fixture.CreateAnonymous<Func<string, string>>(), StringComparer.OrdinalIgnoreCase), Throws.Nothing);
            }
        }
    }
}