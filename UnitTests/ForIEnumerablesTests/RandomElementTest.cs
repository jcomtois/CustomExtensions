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
        public class RandomElementTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _random = new Random(Seed);
            }

            #endregion

            private Random _random;
            private const int Seed = 1;
            private readonly IList<int> _first10RandomIntegersFromSeed;

            public RandomElementTest()
            {
                var rand = new Random(Seed);
                _first10RandomIntegersFromSeed = Enumerable.Range(0, 10).Select(i => rand.Next(10)).ToList();
            }

            [Test]
            public void RadomElement_OnEmptySequence_ThrowsValidationException()
            {
                Assert.That(() => EmptyIntegerSequence.RandomElement(Fixture.CreateAnonymous<Random>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void RandomElement_OnEmptySequence_WithNullRandom_ThrowsValidationException()
            {
                Assert.That(() =>EmptyIntegerSequence.RandomElement(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());                
            }

            [Test]
            [Timeout(2000)]
            public void RandomElement_OnSequence_EventuallyChosesEachItem()
            {
                var checkList = Fixture.CreateMany<string>().ToArray();
                var dic = checkList.ToDictionary(i => i, e => 0);
                while (dic.ContainsValue(0))
                {
                    dic[checkList.RandomElement(_random)]++;
                }
                Console.WriteLine("Dictionary contains {0} items", dic.Values.Sum());
            }

            [Test]
            public void RandomElement_OnSequence_WithNullRandom_ThrowsValidationException()
            {
                Assert.That(() => Fixture.CreateMany<int>().RandomElement(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodTypeOfICollection()
            {
                var checkList = Enumerable.Range(0, 10).ToList();
                foreach (var i in _first10RandomIntegersFromSeed)
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