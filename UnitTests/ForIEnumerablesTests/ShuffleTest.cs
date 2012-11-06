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
        public class ShuffleTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _random = new Random(seed);
            }

            #endregion

            private Random _random;
            private const int seed = 1;
            private readonly IList<int> _first10RandomIntegers;

            public ShuffleTest()
            {
                var rand = new Random(seed);
                _first10RandomIntegers = Enumerable.Range(0, 10).Select(i => rand.Next(10)).ToList();
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(() => Enumerable.Empty<int>().Shuffle(_random), Throws.Nothing);
                Assert.That(() => Enumerable.Empty<int>().Shuffle(_random), Is.Empty);
            }

            [Test]
            public void SequenceEmptyRandomNull()
            {
                Assert.That(() => Enumerable.Empty<int>().Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodRandomGood()
            {
                var checkList = Enumerable.Range(0, 10).ToList();
                Assert.That(() => checkList.Shuffle(_random), Is.EquivalentTo(checkList));
                Assert.That(() => checkList, Is.Ordered);
                Assert.That(() => checkList.Shuffle(_random), Is.Not.Ordered);
            }

            [Test]
            public void SequenceGoodRandomNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullRandomGood()
            {
                Assert.That(() => NullSequence.Of<int>().Shuffle(_random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullRandomNull()
            {
                Assert.That(() => NullSequence.Of<int>().Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                try
                {
                    NullSequence.Of<int>().Shuffle(null);
                    Assert.Fail();
                }
                catch (ValidationException vex)
                {
                    var multiException = vex.InnerException as MultiException;
                    if (multiException == null)
                    {
                        Assert.Fail();
                    }
                    Assert.That(() => multiException.InnerExceptions.ToList(), Has.Count.EqualTo(2));
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentNullException>());
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentException>());
                }
            }
        }
    }
}