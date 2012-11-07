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
        public class ShuffleTest
        {
            [Test]
            public void Shuffle_OnEmptySequence_WithNullRandom_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Random nullRandom = null;

                Assert.That(() => emptySequence.Shuffle(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Shuffle_OnEmptySequence_WithRandom_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                var random = fixture.CreateAnonymous<Random>();

                Assert.That(() => emptySequence.Shuffle(random), Is.Empty);
            }

            [Test]
            public void Shuffle_OnNullSequence_WithNullRandom_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Random nullRandom = null;

                Assert.That(() => nullSequence.Shuffle(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Shuffle_OnNullSequence_WithRandom_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var random = fixture.CreateAnonymous<Random>();

                Assert.That(() => nullSequence.Shuffle(random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Shuffle_OnSequenceOfOne_WithRandom_ReturnsSequenceOfOne()
            {
                var fixture = new MultipleMockingFixture(1);
                var sequenceOfOne = fixture.CreateAnonymous<object[]>();
                var random = fixture.CreateAnonymous<Random>();

                Assert.That(() => sequenceOfOne.Shuffle(random), Is.EqualTo(sequenceOfOne));
            }

            [Test]
            public void Shuffle_OnSequence_IsLazy()
            {
                var fixture = new MultipleMockingFixture();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();
                var random = fixture.CreateAnonymous<Random>();

                Assert.That(() => breakingSequence.Shuffle(random), Throws.Nothing);
            }

            [Test]
            public void Shuffle_OnSequence_WithNullRandom_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();
                Random nullRandom = null;

                Assert.That(() => sequence.Shuffle(nullRandom), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Shuffle_OnSequence_WithRandom_ReturnsAllOriginalElements()
            {
                const int count = 100;
                var fixture = new MultipleMockingFixture(count);
                var sequence = fixture.CreateAnonymous<object[]>();
                var random = fixture.CreateAnonymous<Random>();
                var shuffled = sequence.Shuffle(random).ToArray();

                Assert.That(() => shuffled, Is.EquivalentTo(sequence));
            }

            [Test]
            public void Shuffle_OnSequence_WithRandom_ReturnsDifferentSequence()
            {
                const int count = 100;
                var fixture = new MultipleMockingFixture(count);
                var sequence = fixture.CreateAnonymous<object[]>();
                var random = fixture.CreateAnonymous<Random>();
                var shuffled = sequence.Shuffle(random).ToArray();

                var matches = 0;
                for (var i = 0; i < count; i++)
                {
                    if (sequence[i] == shuffled[i])
                    {
                        matches++;
                    }
                    else
                    {
                        break;
                    }
                }

                Assert.That(() => matches, Is.LessThan(count));
            }

            [Test]
            public void Shuffle_OnSequence_WithRandom_ReturnsSameSequenceWithKnownSeed()
            {
                const int count = 100;
                var fixture = new MultipleMockingFixture(count);
                var seed = fixture.CreateAnonymous<int>();
                var sequence = fixture.CreateAnonymous<object[]>();
                var random = new Random(seed);
                var shuffled1 = sequence.Shuffle(random).ToArray();
                random = new Random(seed);
                var shuffled2 = sequence.Shuffle(random).ToArray();

                Assert.That(() => shuffled1, Is.EqualTo(shuffled2));
            }
        }
    }
}