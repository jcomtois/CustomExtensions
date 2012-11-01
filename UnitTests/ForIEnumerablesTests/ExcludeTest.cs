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
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ExcludeTest
        {
            [Test]
            public void Exclude_OnEmptySequence_WithSequence_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => emptySequence.Exclude(sequence), Is.Empty);
            }

            [Test]
            public void Exclude_OnEmptySequence_WithNullPredicate_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => emptySequence.Exclude(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnEmptySequence_WithNullSequence_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                IEnumerable<object> nullSequence = null;

                Assert.That(() => emptySequence.Exclude(nullSequence), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnEmptySequence_WithNull_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                object nullObject = null;

                Assert.That(() => emptySequence.Exclude(nullObject), Is.Empty);
            }

            [Test]
            public void Exclude_OnEmptySequence_WithPredicate_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectFunc = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => emptySequence.Exclude(objectFunc), Is.Empty);
            }

            [Test]
            public void Exclude_OnEmptySequence_WithSingleElement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => emptySequence.Exclude(objectValue), Is.Empty);
            }

            [Test]
            public void Exclude_OnNullSequence_WithSequence_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => nullSequence.Exclude(sequence), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithNullSequence_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;

                Assert.That(() => nullSequence.Exclude(nullSequence), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithNull_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                object nullObject = null;

                Assert.That(() => nullSequence.Exclude(nullObject), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithNullPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, bool> nullPredicate = null;

                Assert.That(() => nullSequence.Exclude(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectFunc = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => nullSequence.Exclude(objectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithElement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => nullSequence.Exclude(objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectAsSequence_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(object1.ToEnumerable()), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectReferenceAsSequence_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(object4.ToEnumerable()), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectReference_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(object4), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObject_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_WithPredicateOnObjectReference_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object4), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_ExcludeObjectAsSequence_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] {object1, object2, object3}.Exclude(object1.ToEnumerable()), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_ExcludeObject_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringsContainingNullValue_WithNullStringAsSequence_ReturnsSequenceWithoutNullValue()
            {
                left offhere
                Assert.That(new[] {"A", null, "B"}.Exclude(NullString.ToEnumerable()), Is.EquivalentTo(new[] {"A", "B"}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringsContainingNullValue_WithNullString_ReturnsSequenceWithoutNullValue()
            {
                Assert.That(new[] {"A", null, "B"}.Exclude(NullString), Is.EquivalentTo(new[] {"A", "B"}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringsContainingNullValue_WithPredicate_ReturnsSequenceWithoutNullValue()
            {
                Assert.That(new[] {"A", null, "B"}.Exclude(s => s == NullString), Is.EquivalentTo(new[] {"A", "B"}));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_ExcludeStringAsSequence_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(string1.ToEnumerable()), Is.EquivalentTo(new[] {string3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_ExcludeString_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(string1), Is.EquivalentTo(new[] {string3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_WithNullStringAsSequence_ReturnsSequenceOfStrings()
            {
                var testSequence = Fixture.CreateMany<string>().ToList();
                Assert.That(() => testSequence.Exclude(NullString.ToEnumerable()), Is.EqualTo(testSequence));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_WithNullString_ReturnsSequenceOfStrings()
            {
                var testSequence = Fixture.CreateMany<string>().ToList();
                Assert.That(() => testSequence.Exclude(NullString), Is.EqualTo(testSequence));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(new[] {string1, string2, string3}.Exclude(s => s == string1), Is.EquivalentTo(new[] {string3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_WithPredicate_ReturnsSequenceOfStrings()
            {
                var testSequence = Fixture.CreateMany<string>().ToList();
                Assert.That(() => testSequence.Exclude(s => s == NullString), Is.EqualTo(testSequence));
            }

            [Test]
            public void Exclude_OnSequenceOneTwoThree_WithPredicateEqualsTwo_ReturnsSequenceOneThree()
            {
                Assert.That(() => SequenceOneTwoThree.Exclude(i => i == 2), Is.EqualTo(SequenceOneTwoThree.Where(i => i != 2)));
            }

            [Test]
            public void Exclude_OnSequenceOneTwoThree_WithTwoAsSequence_ReturnsSequenceOneThree()
            {
                Assert.That(() => SequenceOneTwoThree.Exclude(2.ToEnumerable()), Is.EqualTo(SequenceOneTwoThree.Where(i => i != 2)));
            }

            [Test]
            public void Exclude_OnSequenceOneTwoThree_WithTwo_ReturnsSequenceOneThree()
            {
                Assert.That(() => SequenceOneTwoThree.Exclude(2), Is.EqualTo(SequenceOneTwoThree.Where(i => i != 2)));
            }

            [Test]
            public void Exclude_OnSequence_WithNullPredicate_ThrowsValidationException()
            {
                Assert.That(() => Fixture.CreateMany<string>().Exclude((Func<string, bool>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_WithEnumerable_IsLazy()
            {
                Assert.That(() => Fixture.CreateMany<int>().Exclude(new BreakingSequence<int>()), Throws.Nothing);
            }

            [Test]
            public void Exclude_WithPredicate_IsLazy()
            {
                Assert.That(() => new BreakingSequence<int>().Exclude(Fixture.CreateAnonymous<Func<int, bool>>()), Throws.Nothing);
            }

            [Test]
            public void Exclude_WithSingleElement_IsLazy()
            {
                Assert.That(() => new BreakingSequence<int>().Exclude(Fixture.CreateAnonymous<int>()), Throws.Nothing);
            }
        }
    }
}