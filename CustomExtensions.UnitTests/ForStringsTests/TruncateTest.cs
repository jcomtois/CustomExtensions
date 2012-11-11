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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class TruncateTest
        {
            private const string Ellipsis = "...";
            private static readonly int ValidLength = Ellipsis.Length + 1;

            [Test]
            public void Truncate_OnEmptyString_WithInvalidLength_ThrowsValidationException()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.Truncate(ValidLength - 1), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnEmptyString_WithValidLength_ReturnsEmptyString()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.Truncate(ValidLength), Is.Empty);
            }

            [Test]
            public void Truncate_OnNullString_WithInValidLength_ThrowsValidationException()
            {
                string nullString = null;
                var maxLength = ValidLength - 1;

                Assert.That(() => nullString.Truncate(maxLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Truncate_OnNullString_WithValidLength_ThrowsValidationException()
            {
                string nullString = null;

                Assert.That(() => nullString.Truncate(ValidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Truncate_OnString_LengthIsGreaterThanElpises_ReturnsString()
            {
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();
                var maxLength = ValidLength - 1;
                var shortString = new string(charValue, maxLength);

                Assert.That(() => shortString.Truncate(ValidLength + 1), Is.EqualTo(shortString));
            }

            [Test]
            public void Truncate_OnString_WithInvalidLength_ThrowsValidationException()
            {
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();
                var maxLength = ValidLength - 1;
                var equalString = new string(charValue, maxLength);

                Assert.That(() => equalString.Truncate(maxLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnString_WithLengthEqualToString_ReturnsString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.Truncate(stringValue.Length), Is.EqualTo(stringValue));
            }

            [Test]
            public void Truncate_OnString_WithLengthIsEqualToEllipsis_ReturnsString()
            {
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();
                var equalString = new string(charValue, ValidLength);

                Assert.That(() => equalString.Truncate(ValidLength), Is.EqualTo(equalString));
            }

            [Test]
            public void Truncate_OnString_WithLengthIsGreaterThanEllipsis_ReturnsString()
            {
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();
                var maxLength = ValidLength + 1;
                var equalString = new string(charValue, maxLength);

                Assert.That(() => equalString.Truncate(maxLength), Is.EqualTo(equalString));
            }

            [Test]
            public void Truncate_OnString_WithValidLength_ReturnsString()
            {
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();
                var maxLength = ValidLength - 1;
                var shortString = new string(charValue, maxLength);

                Assert.That(() => shortString.Truncate(ValidLength), Is.EqualTo(shortString));
            }

            [Test]
            public void Truncate_OnString_WithValidLength_ReturnsTruncatedString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var expected = stringValue.Substring(0, ValidLength - Ellipsis.Length) + Ellipsis;

                Assert.That(() => stringValue.Truncate(ValidLength), Is.EqualTo(expected));
            }
        }
    }
}