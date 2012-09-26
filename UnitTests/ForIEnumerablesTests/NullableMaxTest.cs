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
        public class NullableMaxTest
        {
            [Test]
            public void SequenceEmptySelectorGood()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMax(i => (decimal)i), Is.Null);
            }

            [Test]
            public void SequenceEmptySelectorNull()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodSelectorGood()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMax(i => (decimal)i), Is.EqualTo(10m));
            }

            [Test]
            public void SequenceGoodSelectorNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorGood()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMax(i => (decimal)i), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorNull()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMax<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}