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
        public class ContainsAnyTest
        {
            [Test]
            public void ContainsAny_OnCharacter_OnEmptyString_ReturnsFalse()
            {
                var emptyString = string.Empty;
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();

                Assert.That(() => emptyString.ContainsAny(charValue), Is.False);
            }

            [Test]
            public void ContainsAny_OnCharacter_OnNullString_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new BaseFixture();
                var charValue = fixture.CreateAnonymous<char>();

                Assert.That(() => nullString.ContainsAny(charValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAny_OnCharacter_OnStringWithMany_ReturnsTrue()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var charValue = fixture.CreateAnonymous<char>();
                stringValue += new string(charValue, 10);

                Assert.That(() => stringValue.ContainsAny(charValue), Is.True);
            }

            [Test]
            public void ContainsAny_OnCharacter_OnStringWithNone_ReturnsFalse()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var charValue = fixture.CreateAnonymous<char>();
                stringValue = new string(stringValue.Exclude(charValue).ToArray());

                Assert.That(() => stringValue.ContainsAny(charValue), Is.False);
            }

            [Test]
            public void ContainsAny_OnCharacter_OnStringWithOne_ReturnsTrue()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var charValue = fixture.CreateAnonymous<char>();
                stringValue = new string(stringValue.Exclude(charValue).ToArray());
                stringValue += charValue.ToString();

                Assert.That(() => stringValue.ContainsAny(charValue), Is.True);
            }

            [Test]
            public void ContainsAny_OnCharacter_OnString_IsCaseSensitive()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var upperCaseChar = stringValue.First(char.IsUpper);
                stringValue = stringValue.ToLowerInvariant();

                Assert.That(() => stringValue.ContainsAny(upperCaseChar), Is.False);
            }

            [Test]
            public void ContainsAny_OnEmptyCharacters_OnEmptyString_ReturnsFalse()
            {
                string emptyString = string.Empty;
                var emptyCharacters = Enumerable.Empty<char>();

                Assert.That(() => emptyString.ContainsAny(emptyCharacters), Is.False);
            }

            [Test]
            public void ContainsAny_OnEmptyCharacters_OnNullString_ThrowsValidationException()
            {
                string nullString = null;
                var emptyCharacters = Enumerable.Empty<char>();

                Assert.That(() => nullString.ContainsAny(emptyCharacters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAny_OnEmptyCharacters_OnString_ReturnsFalse()
            {
                var emptyCharacters = Enumerable.Empty<char>();
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.ContainsAny(emptyCharacters), Is.False);
            }

            [Test]
            public void ContainsAny_OnEnumerableCharacters_OnEmptyString_ReturnsFalse()
            {
                string emptyString = string.Empty;
                var fixture = new MultipleMockingFixture();
                var characters = fixture.CreateAnonymous<IEnumerable<char>>();

                Assert.That(() => emptyString.ContainsAny(characters), Is.False);
            }

            [Test]
            public void ContainsAny_OnEnumerableCharacters_OnNullString_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new MultipleMockingFixture();
                var characters = fixture.CreateAnonymous<char[]>();

                Assert.That(() => nullString.ContainsAny(characters), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAny_OnEnumerableCharacters_OnStringWithMany_ReturnsTrue()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var characters = fixture.CreateAnonymous<char[]>();
                stringValue += new string(characters);

                Assert.That(() => stringValue.ContainsAny(characters), Is.True);
            }

            [Test]
            public void ContainsAny_OnEnumerableCharacters_OnStringWithNone_ReturnsFalse()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var characters = fixture.CreateAnonymous<char[]>();
                stringValue = new string(stringValue.Exclude(characters).ToArray());

                Assert.That(() => stringValue.ContainsAny(characters), Is.False);
            }

            [Test]
            public void ContainsAny_OnEnumerableCharacters_OnStringWithOne_ReturnsTrue()
            {
                var fixture = new LatinMultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                stringValue = new string(stringValue.Distinct().ToArray());
                var characters = stringValue.Take(1);

                Assert.That(() => stringValue.ContainsAny(characters), Is.True);
            }

            [Test]
            public void ContainsAny_OnNullCharacters_OnNullString_ThrowsValidationException()
            {
                IEnumerable<char> nullChars = null;
                string nullString = null;

                Assert.That(() => nullString.ContainsAny(nullChars), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ContainsAny_OnNullCharacters_OnString_ThrowsValidationException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IEnumerable<char> nullChars = null;

                Assert.That(() => stringValue.ContainsAny(nullChars), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}