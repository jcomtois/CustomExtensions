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

using System;
using CustomExtensions.ForStrings;
using CustomExtensions.UnitTests.Customization.Fixtures;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class TryToGuidTest
        {
            [Test]
            public void TryToGuid_OnEmptyString_OutputsEmptyGuid()
            {
                Guid guid;
                var emptyString = string.Empty;
                emptyString.TryToGuid(out guid);

                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnEmptyString_ReturnsFalse()
            {
                Guid guid;
                var emptyString = string.Empty;

                Assert.That(() => emptyString.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnInvalidString_OutputsEmptyGuid()
            {
                Guid guid;
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                stringValue.TryToGuid(out guid);

                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnInvalidString_ReturnsFalse()
            {
                Guid guid;
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidNoDashesOrBraces_OutputsGuid()
            {
                Guid guid;
                const string lowerCaseGuidNoDashesOrBraces = "ca761232ed4211cebacd00aa0057b223";
                lowerCaseGuidNoDashesOrBraces.TryToGuid(out guid);
                var expected = new Guid("{CA761232-ED42-11CE-BACD-00AA0057B223}");

                Assert.That(() => guid, Is.EqualTo(expected));
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidNoDashesOrBraces_ReturnsTrue()
            {
                Guid guid;
                const string lowerCaseGuidNoDashesOrBraces = "ca761232ed4211cebacd00aa0057b223";

                Assert.That(() => lowerCaseGuidNoDashesOrBraces.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidWithDashesWithBraces_OutputsGuid()
            {
                Guid guid;
                const string newGuid = "{CA761232-ED42-11CE-BACD-00AA0057B223}";
                newGuid.ToLowerInvariant().TryToGuid(out guid);
                var expected = new Guid(newGuid);

                Assert.That(() => guid, Is.EqualTo(expected));
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidWithDashesWithBraces_ReturnsTrue()
            {
                Guid guid;
                const string newGuid = "{CA761232-ED42-11CE-BACD-00AA0057B223}";

                Assert.That(() => newGuid.ToLowerInvariant().TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnNullString_OutputsEmptyGuid()
            {
                Guid guid;
                string nullString = null;
                nullString.TryToGuid(out guid);

                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnNullString_ReturnsFalse()
            {
                Guid guid;
                string nullString = null;

                Assert.That(() => nullString.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidHex_OutputsGuid()
            {
                Guid guid;
                const string hexGuid = "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}";
                hexGuid.TryToGuid(out guid);
                var expected = new Guid("{CA761232-ED42-11CE-BACD-00AA0057B223}");

                Assert.That(() => guid, Is.EqualTo(expected));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidHex_ReturnsTrue()
            {
                Guid guid;
                const string hexGuid = "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}";

                Assert.That(() => hexGuid.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesNoBraces_OutputsGuid()
            {
                Guid guid;
                const string newGuid = "CA761232-ED42-11CE-BACD-00AA0057B223";
                newGuid.TryToGuid(out guid);
                var expected = new Guid("{CA761232-ED42-11CE-BACD-00AA0057B223}");

                Assert.That(() => guid, Is.EqualTo(expected));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesNoBraces_ReturnsTrue()
            {
                Guid guid;
                const string newGuid = "CA761232-ED42-11CE-BACD-00AA0057B223";

                Assert.That(() => newGuid.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithBraces_OutputsGuid()
            {
                Guid guid;
                const string newGuid = "{CA761232-ED42-11CE-BACD-00AA0057B223}";
                newGuid.TryToGuid(out guid);

                Assert.That(() => guid, Is.EqualTo(new Guid(newGuid)));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithBraces_ReturnsTrue()
            {
                Guid guid;
                const string newGuid = "{CA761232-ED42-11CE-BACD-00AA0057B223}";

                Assert.That(() => newGuid.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithParenthesis_OutputsGuid()
            {
                Guid guid;
                const string newGuid = "(CA761232-ED42-11CE-BACD-00AA0057B223)";
                newGuid.TryToGuid(out guid);
                var expected = new Guid("{CA761232-ED42-11CE-BACD-00AA0057B223}");

                Assert.That(() => guid, Is.EqualTo(expected));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithParenthesis_ReturnsTrue()
            {
                Guid guid;
                const string newGuid = "(CA761232-ED42-11CE-BACD-00AA0057B223)";

                Assert.That(() => newGuid.TryToGuid(out guid), Is.True);
            }
        }
    }
}