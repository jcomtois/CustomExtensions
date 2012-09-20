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
        public class ContainsExactlyTest
        {
            [Test]
            public void SequenceContainsLessThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 0).ContainsExactly(0), Is.True);
                Assert.That(Enumerable.Repeat("A", 0).ContainsExactly(1), Is.False);
            }

            [Test]
            public void SequenceContainsMoreThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(1), Is.False);
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(2), Is.True);
                Assert.That(Enumerable.Repeat("A", 2).ContainsExactly(3), Is.False);
            }

            [Test]
            public void SequenceContainsOnlyOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(1), Is.True);
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(0), Is.False);
                Assert.That(Enumerable.Repeat("A", 1).ContainsExactly(2), Is.False);
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ContainsExactly(0), Is.True);
                Assert.That(Enumerable.Empty<string>().ContainsExactly(1), Is.False);
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(2), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 1).ContainsExactly(1, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceEmptyProjectionNull()
            {
                Assert.That(() => Enumerable.Empty<string>().ContainsExactly(0, null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionGood()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(0, s => true ), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsExactly(0, null), 
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceGoodProjectionGood()
            {
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(0, i => i == 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i == 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(2, i => i > 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(3, i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(0, i => i < 1), Is.True);
                Assert.That(() => Enumerable.Range(1, 3).ContainsExactly(1, i => i < 1), Is.False);
            }

            [Test]
            public void SequenceEmptyProjectionGood()
            {
                Assert.That(() => Enumerable.Empty<int>().ContainsExactly(0, i => i == 1), Is.True);
                Assert.That(() => Enumerable.Empty<int>().ContainsExactly(1, i => i == 1), Is.False);
            }
        }
    }
}