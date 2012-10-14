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
        public class RandomElementTest
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

            public RandomElementTest()
            {
                var rand = new Random(seed);
                _first10RandomIntegers = Enumerable.Range(0, 10).Select(i => rand.Next(10)).ToList();
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(() => Enumerable.Empty<int>().RandomElement(_random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void SequenceEmptyRandomNull()
            {
                Assert.That(() => Enumerable.Empty<int>().RandomElement(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                try
                {
                    Enumerable.Empty<int>().RandomElement(null);
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

            [Test]
            [Timeout(seed * 2000)]
            public void SequenceGoodNotICollection()
            {
                // Only tests that all values are eventually chosen
                var checkList = Enumerable.Range(0, 10);
                var dic = checkList.ToDictionary(i => i, e => 0);
                while (dic.ContainsValue(0))
                {
                    dic[checkList.RandomElement(_random)]++;
                }
                Console.WriteLine("Dictionary contains {0} items", dic.Values.Sum());
            }

            [Test]
            public void SequenceGoodRandomNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).RandomElement(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodTypeOfICollection()
            {
                var checkList = Enumerable.Range(0, 10).ToList();
                foreach (var i in _first10RandomIntegers)
                {
                    Assert.That(() => checkList.RandomElement(_random), Is.EqualTo(checkList[i]));
                }
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<int>().RandomElement(_random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                try
                {
                    NullSequence.Of<int>().RandomElement(_random);
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

            [Test]
            public void SequenceNullRandomNull()
            {
                Assert.That(() => NullSequence.Of<int>().RandomElement(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                try
                {
                    NullSequence.Of<int>().RandomElement(null);
                    Assert.Fail();
                }
                catch (ValidationException vex)
                {
                    var multiException = vex.InnerException as MultiException;
                    if (multiException == null)
                    {
                        Assert.Fail();
                    }
                    Assert.That(() => multiException.InnerExceptions.ToList(), Has.Count.EqualTo(3));
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentNullException>());
                    Assert.That(() => multiException.InnerExceptions.OfType<ArgumentNullException>().ToList(), Has.Count.EqualTo(2));
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentException>());
                }
            }
        }
    }
}