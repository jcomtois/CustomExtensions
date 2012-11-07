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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class RandomElementTest
        {
            [Test]
            public void RandomElement_OnCollectionSequence_EventuallyChoosesEachItem()
            {
                var fixture = new MultipleMockingFixture(10);
                var checkList = fixture.CreateAnonymous<object[]>();
                var dic = checkList.ToDictionary(i => i, e => 0);
                var random = fixture.CreateAnonymous<Random>();
                var maxIterations = 1000 * checkList.Count();
                var iterations = 0;

                while (dic.ContainsValue(0))
                {
                    dic[checkList.RandomElement(random)]++;
                    var i = iterations++;
                    Assert.That(() => i, Is.LessThan(maxIterations), string.Format("Dictionary contains {0} items", dic.Values.Sum()));
                }
            }

            [Test]
            public void RandomElement_OnCollectionSequence_ProducesRepeatableOutput_BasedOnKnownSeed()
            {
                const int numberItemsToCheck = 100;
                var fixture = new MultipleMockingFixture(numberItemsToCheck);
                var seed = fixture.CreateAnonymous<int>();
                var random = new Random(seed);
                var integersFromSeed = Enumerable.Range(0, numberItemsToCheck).Select(i => random.Next(numberItemsToCheck)).ToArray();

                var checkList = fixture.CreateAnonymous<object[]>();

                random = new Random(seed);

                foreach (var i in integersFromSeed)
                {
                    Assert.That(() => checkList.RandomElement(random), Is.EqualTo(checkList[i]));
                }
            }

            [Test]
            public void RandomElement_OnEmptySequence_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var random = fixture.CreateAnonymous<Random>();
                var emptySequence = Enumerable.Empty<object>();

                Assert.That(() => emptySequence.RandomElement(random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void RandomElement_OnEmptySequence_WithNullRandom_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Random nullRandom = null;

                Assert.That(() => emptySequence.RandomElement(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void RandomElement_OnNonCollectionSequence_EventuallyChoosesEachItem()
            {
                var fixture = new MultipleMockingFixture(10);
                IEnumerable<object> checkList = fixture.CreateMany<object>().ToArray().Select(o => o);
                var dic = checkList.ToDictionary(i => i, e => 0);
                var random = fixture.CreateAnonymous<Random>();
                var maxIterations = 1000 * checkList.Count();
                var iterations = 0;

                while (dic.ContainsValue(0))
                {
                    dic[checkList.RandomElement(random)]++;
                    var i = iterations++;
                    Assert.That(() => i, Is.LessThan(maxIterations), string.Format("Dictionary contains {0} items", dic.Values.Sum()));
                }
            }

            [Test]
            public void RandomElement_OnNonCollectionSequence_ProducesRepeatableOutput_BasedOnKnownSeed()
            {
                const int numberItemsToCheck = 100;
                var fixture = new MultipleMockingFixture(numberItemsToCheck);
                var seed = fixture.CreateAnonymous<int>();
                IEnumerable<object> checkList = fixture.CreateAnonymous<object[]>().Select(o => o);

                var random = new Random(seed);
                var trial1 = Enumerable.Range(0, numberItemsToCheck).Select(r => checkList.RandomElement(random)).ToArray();
                random = new Random(seed);
                var trial2 = Enumerable.Range(0, numberItemsToCheck).Select(r => checkList.RandomElement(random)).ToArray();

                Assert.That(() => trial1, Is.EqualTo(trial2));
            }

            [Test]
            public void RandomElement_OnNullSequence_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var random = fixture.CreateAnonymous<Random>();

                Assert.That(() => nullSequence.RandomElement(random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void RandomElement_OnNullSequence_WithNullRandom_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Random nullRandom = null;

                Assert.That(() => nullSequence.RandomElement(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void RandomElement_OnSequenceOfOne_AlwaysChoosesSameItem()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                var sequenceOfOne = objectValue.ToEnumerable();
                var random = fixture.CreateAnonymous<Random>();

                for (var i = 0; i < 10000; i++)
                {
                    Assert.That(() => sequenceOfOne.RandomElement(random), Is.EqualTo(objectValue));
                }
            }

            [Test]
            public void RandomElement_OnSequence_WithNullRandom_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();
                Random nullRandom = null;

                Assert.That(() => sequence.RandomElement(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}