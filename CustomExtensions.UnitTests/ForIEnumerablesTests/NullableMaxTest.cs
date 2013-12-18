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
        public class NullableMaxTest
        {
            [Test]
            public void NullableMax_OnEmptySequence_WithNullSelector_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<GenericComparableStruct>();
                Func<GenericComparableStruct, GenericComparableStruct> nullFunc = null;

                Assert.That(() => emptySequence.NullableMax(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnEmptySequence_WithSelector_ReturnsNull()
            {
                var emptySequence = Enumerable.Empty<GenericComparableStruct>();
                var fixture = new BaseFixture();
                var selector = fixture.Create<Func<GenericComparableStruct, GenericComparableStruct>>();

                Assert.That(() => emptySequence.NullableMax(selector), Is.Null);
            }

            [Test]
            public void NullableMax_OnNullSequence_WithNullSelector_ThrowsValidationException()
            {
                IEnumerable<GenericComparableStruct> nullSequence = null;
                Func<GenericComparableStruct, GenericComparableStruct> nullFunc = null;

                Assert.That(() => nullSequence.NullableMax(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void NullableMax_OnNullSequence_WithSelector_ThrowsValidationException()
            {
                IEnumerable<GenericComparableStruct> nullSequence = null;
                var fixture = new BaseFixture();
                var selector = fixture.Create<Func<GenericComparableStruct, GenericComparableStruct>>();

                Assert.That(() => nullSequence.NullableMax(selector), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnSequence_WithNullSelector_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IEnumerable<GenericComparableStruct>>();
                Func<GenericComparableStruct, GenericComparableStruct> nullFunc = null;

                Assert.That(() => sequence.NullableMax(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void NullableMax_OnSequence_WithSelector_ReturnsMax()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.Create<IList<GenericComparableStruct>>();
                var selector = fixture.Create<Func<GenericComparableStruct, GenericComparableStruct>>();
                var max = sequence.Max(selector);

                Assert.That(() => sequence.NullableMax(selector), Is.EqualTo(max));
            }
        }
    }
}