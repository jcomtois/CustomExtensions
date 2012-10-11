using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsNullOrEmptyTest
        {
            [Test]
            public void IsNullOrEmpty_OnEmptyString_ReturnsTrue()
            {
                Assert.That(() => EmptyTestString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnNullString_ReturnsTrue()
            {
                Assert.That(() => NullTestString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnValidString_ReturnsFalse()
            {
                Assert.That(() => TestStringLatin.IsNullOrEmpty(), Is.False);
            }
        }
    }
}