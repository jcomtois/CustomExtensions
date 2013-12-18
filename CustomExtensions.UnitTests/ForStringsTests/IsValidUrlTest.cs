#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using CustomExtensions.ForStrings;
using CustomExtensions.UnitTests.Customization.Fixtures;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class IsValidUrl
        {
            [Test]
            public void IsValidUrl_OnEmptyString_ReturnsFalse()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnMailTo_ReturnsTrue()
            {
                const string testString = "mailto:fake@madeup.com";

                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnNormalTextString_ReturnsFalse()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnNullString_ReturnsFalse()
            {
                string nullString = null;

                Assert.That(() => nullString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnWebAddressMinusProtocol_ReturnsFalse()
            {
                const string testString = "www.google.com";

                Assert.That(() => testString.IsValidUrl(), Is.False);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithMadeUpProtocol_ReturnsTrue()
            {
                const string testString = "madeup://www.google.com";

                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithftpProtocol_ReturnsTrue()
            {
                const string testString = "ftp://www.google.com";

                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithhttpProtocol_ReturnsTrue()
            {
                const string testString = "http://www.google.com";

                Assert.That(() => testString.IsValidUrl(), Is.True);
            }

            [Test]
            public void IsValidUrl_OnWebAddressWithhttpsProtocol_ReturnsTrue()
            {
                const string testString = "https://www.google.com";

                Assert.That(() => testString.IsValidUrl(), Is.True);
            }
        }
    }
}