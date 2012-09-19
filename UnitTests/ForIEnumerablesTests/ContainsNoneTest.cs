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
        public class ContainsNoneTest
        {
            [Test]
            public void SequenceContainsLessThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 0).ContainsNone(), Is.True);
            }

            [Test]
            public void SequenceContainsMoreThanOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 2).ContainsNone(), Is.False);
            }

            [Test]
            public void SequenceContainsOnlyOneElement()
            {
                Assert.That(Enumerable.Repeat("A", 1).ContainsNone(), Is.False);
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ContainsNone(), Is.True);
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsNone(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 1).ContainsNone(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceEmptyProjectionNull()
            {
                Assert.That(() => Enumerable.Empty<string>().ContainsNone(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionGood()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsNone(s => true ), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ContainsNone(null), 
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceGoodProjectionGood()
            {
                Assert.That(() => Enumerable.Range(1, 3).ContainsNone(i => i == 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsNone(i => i > 1), Is.False);
                Assert.That(() => Enumerable.Range(1, 3).ContainsNone(i => i < 1), Is.True);
            }

            [Test]
            public void SequenceEmptyProjectionGood()
            {
                Assert.That(() => Enumerable.Empty<int>().ContainsNone(i => i == 1), Is.True);
            }
        }
    }
}