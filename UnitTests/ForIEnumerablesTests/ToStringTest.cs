using System;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ToStringTest
        {
            private readonly int[] _intArray = new[] { 1, 2, 3, 4, 5 };

            [Test]
            public void EmptyInput()
            {
                var expected = string.Empty;
                var actual = Enumerable.Empty<int>().ToString(i => i.ToString(), ", ");
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void GoodInput()
            {
                const string expected = "1, 2, 3, 4, 5";
                var actual = _intArray.ToString(i => i.ToString(), ", ");
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullInput()
            {
                Assert.Throws<ArgumentNullException>(() => _intArray.ToString(null, ","));
                int[] a2 = null;
                Assert.Throws<ArgumentNullException>(() => a2.ToString(i => i.ToString(), ","));
            }

            [Test]
            public void NullSeperatorInput()
            {
                const string expected = "12345";
                var actual = _intArray.ToString(i => i.ToString(), null);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}