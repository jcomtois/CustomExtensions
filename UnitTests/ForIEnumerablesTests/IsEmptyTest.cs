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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class IsEmptyTest
        {
            [Test]
            public void IsEmpty_OnGenericCollectionEmpty_ReturnsTrue()
            {
                ICollection<int> sequence = EmptyIntegerSequence.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnGenericCollectionMultipleItem_ReturnsFalse()
            {
                ICollection<int> sequence = SequenceOneTwoThree.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.False);
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
                ICollection<int> sequence = SequenceOfOne.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableEmpty_ReturnsTrue()
            {
                Assert.That(() => EmptyIntegerSequence.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableMultipleItem_ReturnsFalse()
            {
                Assert.That(() => SequenceOneTwoThree.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableNull_ThrowsValidationException()
            {
                Assert.That(() => NullIntegerSequence.IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmpty_OnGenericEnumerableSingleItem_ReturnsFalse()
            {
                Assert.That(() => SequenceOfOne.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionEmpty_ReturnsTrue()
            {
                ICollection sequence = EmptyIntegerSequence.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnNonGenericCollectionMultipleItem_ReturnsFalse()
            {
                ICollection sequence = SequenceOneTwoThree.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.False);
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
                ICollection sequence = SequenceOfOne.ToList();
                Assert.That(() => sequence.IsEmpty(), Is.False);
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableEmpty_ReturnsTrue()
            {
                IEnumerable sequence = EmptyIntegerSequence;
                Assert.That(() => sequence.IsEmpty(), Is.True);
            }

            [Test]
            public void IsEmpty_OnNonGenericEnumerableMultipleItem_ReturnsFalse()
            {
                IEnumerable sequence = SequenceOneTwoThree;
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
                IEnumerable sequence = SequenceOfOne;
                Assert.That(() => sequence.IsEmpty(), Is.False);
            }
        }
    }
}