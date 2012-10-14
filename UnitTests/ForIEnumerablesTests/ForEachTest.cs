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
        public class ForEachTest
        {
            [Test]
            public void SequenceEmptyActionGood()
            {
                var list = new List<string>();
                Assert.That(() => Enumerable.Empty<string>().ForEach(list.Add), Throws.Nothing);
                Assert.That(list, Is.Empty);
            }

            [Test]
            public void SequenceEmptyActionNull()
            {
                Assert.That(() => Enumerable.Empty<string>().ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodActionGood()
            {
                var list = new List<string>();
                Assert.That(() => Enumerable.Repeat("A", 3).ForEach(list.Add), Throws.Nothing);
                Assert.That(list, Is.EquivalentTo(Enumerable.Repeat("A", 3)));
            }

            [Test]
            public void SequenceGoodActionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 3).ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullActionGood()
            {
                Assert.That(() => NullSequence.Of<string>().ForEach(Console.WriteLine), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullActionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}