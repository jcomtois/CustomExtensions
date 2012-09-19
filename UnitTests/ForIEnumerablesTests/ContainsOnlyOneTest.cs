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
        public class ContainsOnlyOneTest
        {
            [Test]
            public void SequenceContainsLessThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 0).ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void SequenceContainsMoreThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 2).ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void SequenceContainsOnlyOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 1).ContainsOnlyOne(), Is.True);
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void SequenceEmptyProjectionGood()
            {
                Assert.That(() => Enumerable.Empty<int>().ContainsOnlyOne(i => i == 1), Is.False);
            }

            [Test]
            public void SequenceEmptyProjectionNull()
            {
                Assert.That(() => Enumerable.Empty<string>().ContainsOnlyOne(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodProjectionGood()
            {
                Assert.That(() => Enumerable.Range(1, 3).ContainsOnlyOne(i => i == 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsOnlyOne(i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsOnlyOne(i => i < 1), Is.False);
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 1).ContainsOnlyOne(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsOnlyOne(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionGood()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsOnlyOne(s => true), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsOnlyOne(null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}