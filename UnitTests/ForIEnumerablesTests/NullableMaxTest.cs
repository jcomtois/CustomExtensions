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
        public class NullableMaxTest
        {
            [Test]
            public void NullableMax_OnEmptySequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => EmptyIntegerSequence.NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnEmptySequence_WithSelector_ReturnsNull()
            {
                Assert.That(() => EmptyIntegerSequence.NullableMax(Fixture.CreateAnonymous<Func<int, int>>()), Is.Null);
            }

            [Test]
            public void NullableMax_OnNullSequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => NullIntegerSequence.NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void NullableMax_OnNullSequence_WithSelector_ThrowsValidationException()
            {
                Assert.That(() => NullIntegerSequence.NullableMax(Fixture.CreateAnonymous<Func<int, int>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnSequence_WithNullSelector_ThrowsValidationException()
            {
                Assert.That(() => SequenceOneTwoThree.NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnSequence_WithSelector_ReturnsMax()
            {
                var fixture = new Fixture();
                fixture.Register(() => fixture.CreateMany<int>());
                var integers = fixture.CreateAnonymous<IEnumerable<int>>().ToArray();
                var func = fixture.CreateAnonymous<Func<int, decimal>>();
                Assert.That(() => integers.NullableMax(func), Is.EqualTo(integers.Max(func)));
            }
        }
    }
}