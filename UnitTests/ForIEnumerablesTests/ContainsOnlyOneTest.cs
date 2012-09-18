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
            public void InputContainsOnlyOneElment()
            {
                var source = Enumerable.Repeat(default(int), 1);
                const bool expected = true;
                var actual = source.ContainsOnlyOne();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void InputContainsMoreThanOneElment()
            {
                var source = Enumerable.Repeat(default(int), 2);
                const bool expected = false;
                var actual = source.ContainsOnlyOne();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void InputContainsLessThanOneElment()
            {
                var source = Enumerable.Repeat(default(int), 0);
                const bool expected = false;
                var actual = source.ContainsOnlyOne();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void InputEmpty()
            {
                var source = Enumerable.Empty<int>();
                const bool expected = false;
                var actual = source.ContainsOnlyOne();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void InputNull()
            {
                int[] source = null;
                Assert.Throws<ValidationException>(() => source.ContainsOnlyOne());
            }
        }
    }
}