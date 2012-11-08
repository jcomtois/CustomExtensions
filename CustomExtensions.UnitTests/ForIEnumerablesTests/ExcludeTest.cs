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
        public class ExcludeTest
        {
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
                var fixture = new BaseFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => emptySequence.Exclude(objectFunc), Is.Empty);
            }

            [Test]
            public void Exclude_OnEmptySequence_WithSequence_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => emptySequence.Exclude(sequence), Is.Empty);
            }

            [Test]
            public void Exclude_OnEmptySequence_WithSingleElement_ReturnsEmptySequence()
            {
                var emptySequence = Enumerable.Empty<object>();
                var fixture = new BaseFixture();
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => emptySequence.Exclude(objectValue), Is.Empty);
            }

            [Test]
            public void Exclude_OnNullSequence_WithElement_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => nullSequence.Exclude(objectValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithNullPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Func<object, bool> nullPredicate = null;

                Assert.That(() => nullSequence.Exclude(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
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
            public void Exclude_OnNullSequence_WithPredicate_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new BaseFixture();
                var objectFunc = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => nullSequence.Exclude(objectFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnNullSequence_WithSequence_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();

                Assert.That(() => nullSequence.Exclude(sequence), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnSequenceContainingNullValue_WithNullAsSequence_ReturnsSequenceWithoutNullValue()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                objects[1] = null;
                var objectsNoNull = new[] {objects[0], objects[2]};
                var nullInSequence = ((object)null).ToEnumerable();

                Assert.That(() => objects.Exclude(nullInSequence), Is.EquivalentTo(objectsNoNull));
            }

            [Test]
            public void Exclude_OnSequenceContainingNullValue_WithNull_ReturnsSequenceWithoutNullValue()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                objects[1] = null;
                object nullObject = null;
                var objectsNoNull = new[] {objects[0], objects[2]};

                Assert.That(() => objects.Exclude(nullObject), Is.EquivalentTo(objectsNoNull));
            }

            [Test]
            public void Exclude_OnSequenceContainingNullValue_WithPredicate_ReturnsSequenceWithoutNullValue()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                objects[1] = null;
                object nullObject = null;
                var objectsNoNull = new[] {objects[0], objects[2]};

                Assert.That(() => objects.Exclude(s => s == nullObject), Is.EquivalentTo(objectsNoNull));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectAsSequence_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object1.ToEnumerable()), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectReferenceAsSequence_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object4.ToEnumerable()), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObjectReference_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object4), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_ExcludeObject_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_WithPredicateOnObjectReference_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = object1;
                var object3 = new object();
                var object4 = object1;

                Assert.That(() => new[] {object1, object2, object3}.Exclude(o => o == object4), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfObjects_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesReferenceComparison()
            {
                var object1 = new object();
                var object2 = new object();
                var object3 = new object();

                Assert.That(() => new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object2, object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_ExcludeObjectAsSequence_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object1.ToEnumerable()), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_ExcludeObject_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(() => new[] {object1, object2, object3}.Exclude(object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStringObjects_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(() => new[] {object1, object2, object3}.Exclude(o => o == object1), Is.EquivalentTo(new[] {object3}));
            }

            [Test]
            public void Exclude_OnSequenceOfStrings_WithPredicate_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(() => new[] {string1, string2, string3}.Exclude(s => s == string1), Is.EquivalentTo(new[] {string3}));
            }

            [Test]
            public void Exclude_OnSequence_ExcludeElementAsSequence_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(() => new[] {string1, string2, string3}.Exclude(string1.ToEnumerable()), Is.EquivalentTo((string3.ToEnumerable())));
            }

            [Test]
            public void Exclude_OnSequence_ExcludeElement_ReturnsOnlyUnMatchedInstances_UsesValueComparison()
            {
                const string string1 = "A";
                const string string2 = "A";
                const string string3 = "B";

                Assert.That(() => new[] {string1, string2, string3}.Exclude(string1), Is.EquivalentTo(string3.ToEnumerable()));
            }

            [Test]
            public void Exclude_OnSequence_WithMatchedPredicate_ReturnsSequenceWithoutMatches()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                var match = objects[1];
                var expected = new[] {objects[0], objects[2]};

                Assert.That(() => objects.Exclude(s => s == match), Is.EqualTo(expected));
            }

            [Test]
            public void Exclude_OnSequence_WithNullAsSequence_ReturnsSequence()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                object nullObject = null;
                var sequenceWithNullObject = nullObject.ToEnumerable();

                Assert.That(() => objects.Exclude(sequenceWithNullObject), Is.EqualTo(objects));
            }

            [Test]
            public void Exclude_OnSequence_WithNullPredicate_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();
                Func<object, bool> nullPredicate = null;

                Assert.That(() => sequence.Exclude(nullPredicate), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Exclude_OnSequence_WithNull_ReturnsSequence()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                object nullObject = null;

                Assert.That(() => objects.Exclude(nullObject), Is.EqualTo(objects));
            }

            [Test]
            public void Exclude_OnSequence_WithUnMatchedPredicate_ReturnsSequence()
            {
                var fixture = new MultipleMockingFixture();
                var objects = fixture.CreateAnonymous<object[]>();
                object nullObject = null;

                Assert.That(() => objects.Exclude(s => s == nullObject), Is.EqualTo(objects));
            }

            [Test]
            public void Exclude_WithEnumerable_IsLazy()
            {
                var fixture = new BaseFixture();
                var sequence = fixture.CreateAnonymous<BreakingSequence<object>>();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();

                Assert.That(() => sequence.Exclude(breakingSequence), Throws.Nothing);
            }

            [Test]
            public void Exclude_WithPredicate_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();
                var predicate = fixture.CreateAnonymous<Func<object, bool>>();

                Assert.That(() => breakingSequence.Exclude(predicate), Throws.Nothing);
            }

            [Test]
            public void Exclude_WithSingleElement_IsLazy()
            {
                var fixture = new BaseFixture();
                var breakingSequence = fixture.CreateAnonymous<BreakingSequence<object>>();
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => breakingSequence.Exclude(objectValue), Throws.Nothing);
            }
        }
    }
}