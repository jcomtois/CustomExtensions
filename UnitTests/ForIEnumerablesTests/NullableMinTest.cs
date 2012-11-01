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
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class NullableMinTest
        {
            [Test]
            public void NullableMin_OnEmptySequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => EmptyIntegerSequence.NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMin_OnEmptySequence_WithSelector_ReturnsNull()
            {
                Assert.That(() => EmptyIntegerSequence.NullableMin(Fixture.CreateAnonymous<Func<int, int>>()), Is.Null);
            }

            [Test]
            public void NullableMin_OnNullSequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => NullIntegerSequence.NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void NullableMin_OnNullSequence_WithSelector_ThrowsValidationException()
            {
                Assert.That(() => NullIntegerSequence.NullableMin(Fixture.CreateAnonymous<Func<int, int>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMin_OnSequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMin_OnSequence_WithSelector_ReturnsMin()
            {
                var fixture = new Fixture();
                fixture.Register(() => fixture.CreateMany<int>());
                var integers = fixture.CreateAnonymous<IEnumerable<int>>().ToArray();
                var func = fixture.CreateAnonymous<Func<int, decimal>>();
                Assert.That(() => integers.NullableMin(func), Is.EqualTo(integers.Min(func)));
            }
        }
    }
}