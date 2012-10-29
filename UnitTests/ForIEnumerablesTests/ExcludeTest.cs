﻿#region License and Terms

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
        public class ExcludeTest
        {
            [Test]
            public void ExcludeSourceElementIsLazy()
            {
                Assert.That(() => new BreakingSequence<int>().Exclude(2), Throws.Nothing);
                Assert.That(() => new BreakingSequence<int>().Exclude(2).ToList(), Throws.TypeOf<InvalidOperationException>());
            }

            [Test]
            public void ExcludeSourceExclusionsIsLazy()
            {
                Assert.That(() => Enumerable.Range(1, 3).Exclude(new BreakingSequence<int>()), Throws.Nothing);
                Assert.That(() => Enumerable.Range(1, 3).Exclude(new BreakingSequence<int>()).ToList(), Throws.TypeOf<InvalidOperationException>());
            }

            [Test]
            public void ExcludeSourcePredicateIsLazy()
            {
                Assert.That(() => new BreakingSequence<int>().Exclude(i => i == 2), Throws.Nothing);
                Assert.That(() => new BreakingSequence<int>().Exclude(i => i == 2).ToList(), Throws.TypeOf<InvalidOperationException>());
            }

            [Test]
            public void SequenceEmptyElementGood()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude("A"), Is.Empty);
            }

            [Test]
            public void SequenceEmptyElementNull()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude((string)null), Is.Empty);
            }

            [Test]
            public void SequenceEmptyExclusionsGood()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude(new[] {"A"}), Is.Empty);
            }

            [Test]
            public void SequenceEmptyExclusionsNull()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude(NullSequence.Of<string>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceEmptyPredicateGood()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude(s => s == "A"), Is.Empty);
            }

            [Test]
            public void SequenceEmptyPredicateNull()
            {
                Assert.That(() => Enumerable.Empty<string>().Exclude((Func<string, bool>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodElementGood()
            {
                Assert.That(Enumerable.Range(1, 3).Exclude(2), Is.EquivalentTo(new[] {1, 3}));

                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(string1), Is.EquivalentTo(new[] {string3}));

                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object3}));

                object1 = new object();
                object2 = new object();
                object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object2, object3}));

                object2 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void SequenceGoodElementNull()
            {
                Assert.That(Enumerable.Repeat("A", 3).Exclude((string)null), Is.EqualTo(Enumerable.Repeat("A", 3)));
                Assert.That(new[] {"A", null, "B"}.Exclude((string)null), Is.EquivalentTo(new[] {"A", "B"}));
            }

            [Test]
            public void SequenceGoodExclusionsGood()
            {
                Assert.That(Enumerable.Range(1, 3).Exclude(new[] {2}), Is.EquivalentTo(new[] {1, 3}));

                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(new[] {string1}), Is.EquivalentTo(new[] {string3}));

                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] {object1, object2, object3}.Exclude(new[] {object1}), Is.EquivalentTo(new[] {object3}));

                object1 = new object();
                object2 = new object();
                object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(new[] {object1}), Is.EquivalentTo(new[] {object2, object3}));

                object2 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(new[] {object1}), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void SequenceGoodExclusionsNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 3).Exclude(NullSequence.Of<string>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodPredicateGood()
            {
                Assert.That(Enumerable.Range(1, 3).Exclude(i => i == 2), Is.EquivalentTo(new[] {1, 3}));

                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(s => s == string1), Is.EquivalentTo(new[] {string3}));

                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                var object4 = object1; // Avoid access to modified closure warning
                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object4), Is.EquivalentTo(new[] {object3}));

                object1 = new object();
                object2 = new object();
                object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object2, object3}));

                object2 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void SequenceGoodPredicateNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 3).Exclude((Func<string, bool>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullElementGood()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude("A"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullElementNull()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude((string)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullExclusionsGood()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude(new[] {"A"}), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullExclusionsNull()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude(NullSequence.Of<string>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceNullPredicateGood()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude(s => s == "A"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullPredicateNull()
            {
                Assert.That(() => NullSequence.Of<string>().Exclude((Func<string, bool>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}