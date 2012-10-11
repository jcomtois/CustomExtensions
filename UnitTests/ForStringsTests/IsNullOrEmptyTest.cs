using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsNullOrEmptyTest
        {
            private const string ValidString = "TestString";
            private const string EmptyString = "";
            private const string NullString = null;

            [Test]
            public void IsNullOrEmpty_OnEmptyString_ReturnsTrue()
            {
                Assert.That(() => EmptyString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnNullString_ReturnsTrue()
            {
                Assert.That(() => NullString.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void IsNullOrEmpty_OnValidString_ReturnsFalse()
            {
                Assert.That(() => ValidString.IsNullOrEmpty(), Is.False);
            }
        }
    }
}