using System;
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    [TestFixture]
    public class ForEachTest
    {
        [Test]
        public void SequenceEmptyActionGood()
        {
            var list = new List<string>();
            Assert.That(() => Enumerable.Empty<string>().ForEach(list.Add), Throws.Nothing);
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void SequenceEmptyActionNull()
        {
            Assert.That(() => Enumerable.Empty<string>().ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceGoodActionGood()
        {
            var list = new List<string>();
            Assert.That(() => Enumerable.Repeat("A", 3).ForEach(list.Add), Throws.Nothing);
            Assert.That(list, Is.EquivalentTo(Enumerable.Repeat("A", 3)));
        }

        [Test]
        public void SequenceGoodActionNull()
        {
            Assert.That(() => Enumerable.Repeat("A", 3).ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullActionGood()
        {
            Assert.That(() => NullSequence.Of<string>().ForEach(Console.WriteLine), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SequenceNullActionNull()
        {
            Assert.That(() => NullSequence.Of<string>().ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
        }
    }
}