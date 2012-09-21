using System;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    [TestFixture]
    public class ReplaceTest
    {
        [Test]
        public void ReplaceSourceElementProjectionIsLazy()
        {
            Assert.That(() => new BreakingSequence<int>().Replace(2, i => i + 1), Throws.Nothing);
            Assert.That(() => new BreakingSequence<int>().Replace(2, i => i + 1).ToList(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void ReplaceSourceElementReplacementIsLazy()
        {
            Assert.That(() => new BreakingSequence<int>().Replace(2, 1), Throws.Nothing);
            Assert.That(() => new BreakingSequence<int>().Replace(2, 1).ToList(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void SequenceEmptyElementGoodProjectionGood()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace("A", s => s + "B"), Is.Empty);
        }

        [Test]
        public void SequenceEmptyElementGoodProjectionNull()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace("A", (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceEmptyElementGoodReplacementGood()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace("A", "B"), Is.Empty);
        }

        [Test]
        public void SequenceEmptyElementGoodReplacementNull()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace("A", (string)null), Is.Empty);
        }

        [Test]
        public void SequenceEmptyElementNullProjectionGood()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace(null, s => "A"), Is.Empty);
        }

        [Test]
        public void SequenceEmptyElementNullProjectionNull()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace(null, (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceEmptyElementNullReplacementGood()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace(null, "B"), Is.Empty);
        }

        [Test]
        public void SequenceEmptyElementNullReplacementNull()
        {
            Assert.That(() => Enumerable.Empty<string>().Replace(null, (string)null), Is.Empty);
        }

        [Test]
        public void SequenceGoodElementGoodProjectionGood()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("A", s => "AB"), Is.EquivalentTo(Enumerable.Repeat("AB", 3)));
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("B", s => "AB"), Is.EquivalentTo(Enumerable.Repeat("A", 3)));

            var object1 = new object();
            var object2 = new object();
            var object3 = new object();
            var object4 = new object();

            Assert.That(() => new[] {object1, object2, object3}.Replace(object1, o => null), Is.EquivalentTo(new[] {null, object2, object3}));
            Assert.That(() => new[] {object1, object2, object3}.Replace(object4, o => null), Is.EquivalentTo(new[] {object1, object2, object3}));
        }

        [Test]
        public void SequenceGoodElementGoodProjectionNull()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("A", (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceGoodElementGoodReplacementGood()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("A", "B"), Is.EquivalentTo(Enumerable.Repeat("B", 3)));
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("B", "A"), Is.EquivalentTo(Enumerable.Repeat("A", 3)));

            var object1 = new object();
            var object2 = new object();
            var object3 = new object();
            var object4 = new object();

            Assert.That(() => new[] {object1, object2, object3}.Replace(object1, object2), Is.EquivalentTo(new[] {object2, object2, object3}));
            Assert.That(() => new[] {object1, object2, object3}.Replace(object4, object2), Is.EquivalentTo(new[] {object1, object2, object3}));
        }

        [Test]
        public void SequenceGoodElementGoodReplacementNull()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace("A", (string)null), Is.EquivalentTo(Enumerable.Repeat((string)null, 3)));
        }

        [Test]
        public void SequenceGoodElementNullProjectionGood()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace(null, s => "A"), Is.EquivalentTo(Enumerable.Repeat("A", 3)));
            Assert.That(() => Enumerable.Repeat((string)null, 3).Replace(null, s => "A"), Is.EquivalentTo(Enumerable.Repeat("A", 3)));
        }

        [Test]
        public void SequenceGoodElementNullProjectionNull()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace(null, (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceGoodElementNullReplacementGood()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace(null, "B"), Is.EquivalentTo(Enumerable.Repeat("A", 3)));
            Assert.That(() => Enumerable.Repeat((string)null, 3).Replace(null, "B"), Is.EquivalentTo(Enumerable.Repeat("B", 3)));
        }

        [Test]
        public void SequenceGoodElementNullReplacementNull()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).Replace(null, (string)null), Is.EquivalentTo(Enumerable.Repeat("A", 3)));
        }

        [Test]
        public void SequenceNullElementGoodProjectionGood()
        {
            Assert.That(() => NullSequence.Of<string>().Replace("A", s => "AB"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullElementGoodProjectionNull()
        {
            Assert.That(() => NullSequence.Of<string>().Replace("A", (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
        }

        [Test]
        public void SequenceNullElementGoodReplacementGood()
        {
            Assert.That(() => NullSequence.Of<string>().Replace("A", "B"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullElementGoodReplacementNull()
        {
            Assert.That(() => NullSequence.Of<string>().Replace("A", (string)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullElementNullProjectionGood()
        {
            Assert.That(() => NullSequence.Of<string>().Replace(null, s => "AB"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullElementNullProjectionNull()
        {
            Assert.That(() => NullSequence.Of<string>().Replace(null, (Func<string, string>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
        }

        [Test]
        public void SequenceNullElementNullReplacementGood()
        {
            Assert.That(() => NullSequence.Of<string>().Replace(null, "B"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullElementNullReplacementNull()
        {
            Assert.That(() => NullSequence.Of<string>().Replace(null, (string)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }
    }
}