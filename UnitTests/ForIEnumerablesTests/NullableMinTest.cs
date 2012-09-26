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
        public class NullableMinTest
        {
            [Test]
            public void SequenceEmptySelectorGood()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMin(i => (decimal)i), Is.Null);
            }

            [Test]
            public void SequenceEmptySelectorNull()
            {
                Assert.That(() => Enumerable.Empty<int>().NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodSelectorGood()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMin(i => (decimal)i), Is.EqualTo(1m));
            }

            [Test]
            public void SequenceGoodSelectorNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorGood()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMin(i => (decimal)i), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorNull()
            {
                Assert.That(() => NullSequence.Of<int>().NullableMin<int, int>(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}