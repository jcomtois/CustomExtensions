using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsValidUrl
        {
            [Test]
            public void IsValidUrl_OnEmptyString_ReturnsFalse()
            {
                Assert.That(() => EmptyTestString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnMailTo_ReturnsTrue()
            {
                var testString = "mailto:fake@madeup.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnNormalTextString_ReturnsFalse()
            {
                var testString = TestStringLatin;
                Assert.That(() => testString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnNullString_ReturnsFalse()
            {
                Assert.That(() => NullTestString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnWebAddressMinusProtocol_ReturnsFalse()
            {
                var testString = "www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithMadeUpProtocol_ReturnsTrue()
            {
                var testString = "madeup://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithftpProtocol_ReturnsTrue()
            {
                var testString = "ftp://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithhttpProtocol_ReturnsTrue()
            {
                var testString = "http://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithhttpsProtocol_ReturnsTrue()
            {
                var testString = "https://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }
        }
    }
}