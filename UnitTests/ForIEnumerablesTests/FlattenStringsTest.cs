using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class FlattenStringsTest
        {
            [Test]
            public void SequenceEmpty()
            {
                Assert.That(Enumerable.Empty<string>().FlattenStrings(), Is.Empty);
            }

            [Test]
            public void SequenceGood()
            {
                Assert.That(Enumerable.Repeat("A", 3).FlattenStrings(), Is.EqualTo("AAA"));
            }

            [Test]
            public void SequenceNull()
            {
                Assert.That(NullSequence.Of<string>().FlattenStrings(), Is.Empty);
            }
        }
    }
}