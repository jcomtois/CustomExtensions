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
            public void EmptyInput()
            {
                Assert.That(Enumerable.Empty<string>().FlattenStrings(), Is.Empty);
            }

            [Test]
            public void GoodInput()
            {
                Assert.That(Enumerable.Repeat("A", 3).FlattenStrings(), Is.EqualTo("AAA"));
            }

            [Test]
            public void NullInput()
            {
                Assert.That(NullSequence.Of<string>().FlattenStrings(), Is.Empty);
            }
        }
    }
}