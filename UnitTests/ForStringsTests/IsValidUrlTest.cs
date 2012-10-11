﻿using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsValidUrl
        {
            private const string NullString = null;
            private const string EmptyString = "";

            [Test]
            public void IsBadUrl_OnEmptyString_ReturnsFalse()
            {
                Assert.That(() => EmptyString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsBadUrl_OnMailTo_ReturnsTrue()
            {
                var testString = "mailto:fake@madeup.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsBadUrl_OnNormalTextString_ReturnsFalse()
            {
                var testString = "I'm a Bad URL.";
                Assert.That(() => testString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsBadUrl_OnNullString_ReturnsFalse()
            {
                Assert.That(() => NullString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsBadUrl_OnWebAddressMinusProtocol_ReturnsFalse()
            {
                var testString = "www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsBadUrl_OnWebAddressWithMadeUpProtocol_ReturnsTrue()
            {
                var testString = "madeup://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsBadUrl_OnWebAddressWithftpProtocol_ReturnsTrue()
            {
                var testString = "ftp://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsBadUrl_OnWebAddressWithhttpProtocol_ReturnsTrue()
            {
                var testString = "http://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsBadUrl_OnWebAddressWithhttpsProtocol_ReturnsTrue()
            {
                var testString = "https://www.google.com";
                Assert.That(() => testString.IsValidUrl(), Is.True);
            }
        }
    }
}