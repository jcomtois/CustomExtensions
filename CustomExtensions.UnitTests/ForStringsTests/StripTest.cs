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
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
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
        public class StripTest
        {
            [Test]
            public void Strip_OnEmptySource_WithEmptyCharacters_ReturnsEmptyString()
            {
                var emptyString = string.Empty;
                var emptyChars = Enumerable.Empty<char>();

                Assert.That(() => emptyString.Strip(emptyChars), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySource_WithEmptyString_ReturnsEmptyString()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.Strip(emptyString), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySource_WithMultiCharacters_ReturnsEmptyString()
            {
                var emptyString = string.Empty;
                var fixture = new MultipleMockingFixture();
                var multipleCharacters = fixture.CreateAnonymous<IEnumerable<char>>();

                Assert.That(() => emptyString.Strip(multipleCharacters), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySource_WithNullCharacters_ThrowsValidationException()
            {
                var emptyString = string.Empty;
                IEnumerable<char> nullCharacters = null;

                Assert.That(() => emptyString.Strip(nullCharacters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnEmptySource_WithNullString_ThrowsValidationException()
            {
                var emptyString = string.Empty;
                string nullString = null;

                Assert.That(() => emptyString.Strip(nullString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnEmptySource_WithSingleCharacterEnumerable_ReturnsEmptyString()
            {
                var emptyString = string.Empty;
                var fixture = new MultipleMockingFixture(1);
                var singleCharEnumerable = fixture.CreateAnonymous<IEnumerable<char>>();

                Assert.That(() => emptyString.Strip(singleCharEnumerable), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySource_WithSingleCharacter_ReturnsEmptyString()
            {
                var emptyString = string.Empty;
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();

                Assert.That(() => emptyString.Strip(charValue), Is.Empty);
            }

            [Test]
            public void Strip_OnNullSource_WithEmptyCharacters_ThrowsValidationException()
            {
                string nullString = null;
                var emptyChars = Enumerable.Empty<char>();

                Assert.That(() => nullString.Strip(emptyChars), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSource_WithEmptyString_ThrowsValidationException()
            {
                string nullString = null;
                var emptyString = string.Empty;

                Assert.That(() => nullString.Strip(emptyString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSource_WithMultiCharacters_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new MultipleMockingFixture();
                var multipleCharacters = fixture.CreateAnonymous<IEnumerable<char>>();

                Assert.That(() => nullString.Strip(multipleCharacters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSource_WithNullCharacters_ThrowsValidationException()
            {
                string nullString = null;
                IEnumerable<char> nullCharacters = null;

                Assert.That(() => nullString.Strip(nullCharacters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Strip_OnNullSource_WithNullString_ThrowsValidationException()
            {
                string nullString = null;

                Assert.That(() => nullString.Strip(nullString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Strip_OnNullSource_WithSingleCharacterEnumerable_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new MultipleMockingFixture(1);
                var singleCharEnumerable = fixture.CreateAnonymous<IEnumerable<char>>();

                Assert.That(() => nullString.Strip(singleCharEnumerable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSource_WithSingleCharacter_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();

                Assert.That(() => nullString.Strip(charValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnSource_WithEmptyCharacters_ReturnsSameString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var emptyChars = Enumerable.Empty<char>();

                Assert.That(() => stringValue.Strip(emptyChars), Is.EqualTo(stringValue));
            }

            [Test]
            public void Strip_OnSource_WithEmptyString_ReturnsSameString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var emptyString = string.Empty;

                Assert.That(() => stringValue.Strip(emptyString), Is.EqualTo(stringValue));
            }

            [Test]
            public void Strip_OnSource_WithMultiCharacters_ReturnsStrippedString()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                stringValue = stringValue + stringValue;
                var multichars = stringValue.Take(5);
                var expected = new string(stringValue.Exclude(multichars).ToArray());

                Assert.That(() => stringValue.Strip(multichars), Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnSource_WithNoMatches_ReturnsSource()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var first10 = stringValue.Take(10);
                var excluded = new string(stringValue.Exclude(first10).ToArray());

                Assert.That(() => excluded.Strip(first10), Is.EqualTo(excluded));
            }

            [Test]
            public void Strip_OnSource_WithNullCharacters_ThrowsValidationException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IEnumerable<char> nullCharacters = null;

                Assert.That(() => stringValue.Strip(nullCharacters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnSource_WithNullString_ThrowsValidationException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                string nullString = null;

                Assert.That(() => stringValue.Strip(nullString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnSource_WithSingleCharacterEnumerable_ReturnsStrippedString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                stringValue = stringValue + stringValue;
                var singleCharEnumerable = stringValue.Take(1);
                var expected = new string(stringValue.Exclude(singleCharEnumerable).ToArray());

                Assert.That(() => stringValue.Strip(singleCharEnumerable), Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnSource_WithSingleCharacter_ReturnsStrippedString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                stringValue = stringValue + stringValue;
                var singleChar = stringValue.Last();
                var expected = stringValue.Replace(singleChar.ToString(), string.Empty);

                Assert.That(() => stringValue.Strip(singleChar), Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnSource_WithSourceString_ReturnsEmptyString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.Strip(stringValue), Is.Empty);
            }
        }
    }
}