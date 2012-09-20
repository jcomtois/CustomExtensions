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
        public class DistinctByTest
        {
            [Test]
            public void DistinctByComparerIsLazy()
            {
                Assert.That(() => new BreakingSequence<int>().DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase), Throws.Nothing);
            }

            [Test]
            public void DistinctByIsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().DistinctBy(s => s.Length), Throws.Nothing);
            }

            [Test]
            public void SequenceEmptyKeySelectorGood()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy(i => i.ToString()), Is.Empty);
            }

            [Test]
            public void SequenceEmptyKeySelectorGoodComparerGood()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase), Is.Empty);
            }

            [Test]
            public void SequenceEmptyKeySelectorGoodComparerNull()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy(i => i.ToString(), null), Is.Empty);
            }

            [Test]
            public void SequenceEmptyKeySelectorNull()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy((Func<int, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceEmptyKeySelectorNullComparerGood()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceEmptyKeySelectorNullComparerNull()
            {
                Assert.That(() => Enumerable.Empty<int>().DistinctBy((Func<int, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodKeySelectorGood()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy(i => i.ToString()), Is.EqualTo(Enumerable.Repeat(1, 1)));
                Assert.That(() => (Enumerable.Range(1, 3).Concat(Enumerable.Range(1, 3))).DistinctBy(i => i.ToString()),
                            Is.EquivalentTo(Enumerable.Range(1, 3)));
            }

            [Test]
            public void SequenceGoodKeySelectorGoodComparerGood()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase), Is.EqualTo(Enumerable.Repeat(1, 1)));
                Assert.That(() => (Enumerable.Range(1, 3).Concat(Enumerable.Range(1, 3))).DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase),
                            Is.EquivalentTo(Enumerable.Range(1, 3)));
            }

            [Test]
            public void SequenceGoodKeySelectorGoodComparerNull()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy(i => i.ToString(), null), Is.EqualTo(Enumerable.Repeat(1, 1)));
                Assert.That(() => (Enumerable.Range(1, 3).Concat(Enumerable.Range(1, 3))).DistinctBy(i => i.ToString(), null),
                            Is.EquivalentTo(Enumerable.Range(1, 3)));
            }

            [Test]
            public void SequenceGoodKeySelectorNull()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy((Func<int, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodKeySelectorNullComparerGood()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodKeySelectorNullComparerNull()
            {
                Assert.That(() => Enumerable.Repeat(1, 3).DistinctBy((Func<int, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullKeySelectorGood()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy(i => i.ToString()),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullKeySelectorGoodComparerGood()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullKeySelectorGoodComparerNull()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy(i => i.ToString(), null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullKeySelectorNull()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy((Func<int, string>)null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceNullKeySelectorNullComparerGood()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy(null, StringComparer.OrdinalIgnoreCase),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceNullKeySelectorNullComparerNull()
            {
                Assert.That(() => NullSequence.Of<int>().DistinctBy((Func<int, string>)null, null),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}