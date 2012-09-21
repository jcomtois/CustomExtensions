using System;
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
            public void SequenceGoodElementGood()
            {
                Assert.That(Enumerable.Range(1, 3).Exclude(2), Is.EquivalentTo(new [] { 1, 3}));

                var string1 = "A";
                var string2 = "A";
                var string3 = "B";

                Assert.That(new [] {string1, string2, string3}.Exclude(string1), Is.EquivalentTo(new [] {string3}));

                object object1 = "A";
                object object2 = "A";
                object object3 = "B";

                Assert.That(new[] { object1, object2, object3 }.Exclude(object1), Is.EquivalentTo(new[] { object3 }));

                object1 = new object();
                object2 = new object();
                object3 = new object();

                Assert.That(new[] { object1, object2, object3 }.Exclude(object1), Is.EquivalentTo(new[] { object2, object3 }));

                object2 = object1;

                Assert.That(new[] { object1, object2, object3 }.Exclude(object1), Is.EquivalentTo(new[] { object3 }));
            }

            [Test]
            public void SequenceGoodElementNull()
            {
                Assert.That(Enumerable.Repeat("A", 3).Exclude((string)null), Is.EqualTo(Enumerable.Repeat("A", 3)));
                Assert.That(new [] {"A", null, "B"}.Exclude((string)null), Is.EquivalentTo(new [] {"A", "B"}));
            }

            [Test]
            public void ExcludeSourceExclusionsIsLazy()
            {
                Assert.That(() => Enumerable.Range(1,3).Exclude(new BreakingSequence<int>()), Throws.Nothing);
                Assert.That(() => Enumerable.Range(1,3).Exclude(new BreakingSequence<int>()).ToList(), Throws.TypeOf<InvalidOperationException>());
            }
        }
    }
}