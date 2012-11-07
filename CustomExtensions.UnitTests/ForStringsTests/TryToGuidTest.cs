#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
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
using NUnit.Framework;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class TryToGuidTest
        {
            private const string LowerCaseGuidNoDashesOrBraces = "ca761232ed4211cebacd00aa0057b223";
            private const string UpperCaseGuidWithDashesNoBraces = "CA761232-ED42-11CE-BACD-00AA0057B223";
            private const string UpperCaseGuidWithDashesWithBraces = "{CA761232-ED42-11CE-BACD-00AA0057B223}";
            private static readonly Guid GoodGuid = new Guid(UpperCaseGuidWithDashesWithBraces);
            private static readonly string LowerCaseGuidWithDashesWithBraces = UpperCaseGuidWithDashesWithBraces.ToLowerInvariant();
            private const string UpperCaseGuidWithDashesWithParenthesis = "(CA761232-ED42-11CE-BACD-00AA0057B223)";
            private const string UpperCaseGuidHex = "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}";

            [Test]
            public void TryToGuid_OnEmptyString_OutputsEmptyGuid()
            {
                Guid guid;
                var actual = NullTestString.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnEmptyString_ReturnsFalse()
            {
                Guid guid;
                Assert.That(() => EmptyTestString.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnInvalidString_OutputsEmptyGuid()
            {
                Guid guid;
                var actual = TestStringLatin.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnInvalidString_ReturnsFalse()
            {
                Guid guid;
                Assert.That(() => TestStringLatin.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidNoDashesOrBraces_OutputsGuid()
            {
                Guid guid;
                var actual = LowerCaseGuidNoDashesOrBraces.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidNoDashesOrBraces_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => LowerCaseGuidNoDashesOrBraces.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidWithDashesWithBraces_OutputsGuid()
            {
                Guid guid;
                var actual = LowerCaseGuidWithDashesWithBraces.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnLowerCaseGuidWithDashesWithBraces_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => LowerCaseGuidWithDashesWithBraces.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnNullString_OutputsEmptyGuid()
            {
                Guid guid;
                var actual = NullTestString.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void TryToGuid_OnNullString_ReturnsFalse()
            {
                Guid guid;
                Assert.That(() => NullTestString.TryToGuid(out guid), Is.False);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidHex_OutputsGuid()
            {
                Guid guid;
                var actual = UpperCaseGuidHex.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidHex_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => UpperCaseGuidHex.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesNoBraces_OutputsGuid()
            {
                Guid guid;
                var actual = UpperCaseGuidWithDashesNoBraces.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesNoBraces_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => UpperCaseGuidWithDashesNoBraces.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithBraces_OutputsGuid()
            {
                Guid guid;
                var actual = UpperCaseGuidWithDashesWithBraces.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithBraces_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => UpperCaseGuidWithDashesWithBraces.TryToGuid(out guid), Is.True);
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithParenthesis_OutputsGuid()
            {
                Guid guid;
                var actual = UpperCaseGuidWithDashesWithParenthesis.TryToGuid(out guid);
                Assert.That(() => guid, Is.EqualTo(GoodGuid));
            }

            [Test]
            public void TryToGuid_OnUpperCaseGuidWithDashesWithParenthesis_ReturnsTrue()
            {
                Guid guid;
                Assert.That(() => UpperCaseGuidWithDashesWithParenthesis.TryToGuid(out guid), Is.True);
            }
        }
    }
}