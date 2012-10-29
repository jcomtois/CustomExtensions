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

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ToStringTest
        {
            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ToString(i => i, ", "), Is.Empty);
            }

            [Test]
            public void SequenceGood()
            {
                Assert.That(Enumerable.Repeat("A", 3).ToString(s => s, ", "), Is.EqualTo("A, A, A"));
            }

            [Test]
            public void SequenceGoodProjectionGoodSeperatorNull()
            {
                Assert.That(Enumerable.Repeat("A", 2).ToString(s => s, null), Is.EqualTo("AA"));
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 2).ToString(null, ", "),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ToString(s => s, ", "),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ToString(null, ", "),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}