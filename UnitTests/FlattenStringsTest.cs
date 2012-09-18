using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests
{
    public partial class IEnumerablesTests
    {
        [TestFixture]
        public class FlattenStringsTest
        {
            private readonly string[] _stringArray = new[] {"10", "20", "30"};
            private const string Flattened = "102030";

            [Test]
            public void EmptyInput()
            {
                var expected = string.Empty;
                var empty = Enumerable.Empty<string>();
                var actual = empty.FlattenStrings();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void GoodInput()
            {
                var expected = Flattened;
                var actual = _stringArray.FlattenStrings();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullInput()
            {
                var expected = string.Empty;
                string[] nullArray = null;
                var actual = nullArray.FlattenStrings();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}