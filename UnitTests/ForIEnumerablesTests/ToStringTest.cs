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
        public class ToStringTest
        {

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().ToString(i => i, ", "), Is.Empty);
            }

            [Test]
            public void SequenceGood()
            {
                Assert.That(Enumerable.Repeat("A", 3).ToString(s => s, ", "), Is.EqualTo("A, A, A"));
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(() => NullSequence.Of<string>().ToString(s => s, ", "), 
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodProjectionNull()
            {
                Assert.That(() => Enumerable.Repeat("A", 2).ToString(null, ", "),
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullProjectionNull()
            {
                Assert.That(() => NullSequence.Of<string>().ToString(null, ", "),
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SequenceGoodProjectionGoodSeperatorNull()
            {
                Assert.That(Enumerable.Repeat("A", 2).ToString(s => s, null), Is.EqualTo("AA"));
            }
        }
    }
}