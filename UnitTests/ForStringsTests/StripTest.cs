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
using System.Linq;
using CustomExtensions.ForStrings;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class StripTest
        {
            private static readonly char[] SingleCharacterArray = new []{'a'};
            private static readonly char[] MultiCharacterArray = new []{'a', 'b', 'c'};
            private static readonly char[] NullCharacterArray = null;
            private static readonly char[] EmptyCharacterArray = new char[]{};
            private const char SingleCharacter = 'a';
            private const string SubString = "abc";

            [Test]
            public void Strip_OnNullSourceMultiCharacters_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(MultiCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSourceNullCharacters_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(NullCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Strip_OnNullSourceEmptyCharacters_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(EmptyCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSourceSingleCharacterArray_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(SingleCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSourceSingleCharacter_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(SingleCharacter), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSourceNullString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(NullTestString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Strip_OnNullSourceEmptyString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(EmptyTestString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnNullSourceSubString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Strip(SubString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            // empty

            [Test]
            public void Strip_OnEmptySourceMultiCharacters_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(MultiCharacterArray), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySourceNullCharacters_ThrowsValidationException()
            {
                Assert.That(() => EmptyTestString.Strip(NullCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnEmptySourceEmptyCharacters_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(EmptyCharacterArray), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySourceSingleCharacterArray_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(SingleCharacterArray), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySourceSingleCharacter_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(SingleCharacter), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySourceNullString_ThrowsValidationException()
            {
                Assert.That(() => EmptyTestString.Strip(NullTestString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnEmptySourceEmptyString_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(EmptyTestString), Is.Empty);
            }

            [Test]
            public void Strip_OnEmptySourceSubString_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Strip(SubString), Is.Empty);
            }

            // Latin

            [Test]
            public void Strip_OnValidSourceMultiCharacters_ReturnsStrippedString()
            {
                var expected = MultiCharacterArray.Aggregate(TestStringLatin, (current, c) => current.Replace(c.ToString(), string.Empty));
                Assert.That(() => TestStringLatin.Strip(MultiCharacterArray), Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnValidSourceNullCharacters_ThrowsValidationException()
            {
                Assert.That(() => TestStringLatin.Strip(NullCharacterArray), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnValidSourceEmptyCharacters_ReturnsSameString()
            {
                Assert.That(() => TestStringLatin.Strip(EmptyCharacterArray), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Strip_OnValidSourceSingleCharacterArray_ReturnsStrippedString()
            {
                var expected = SingleCharacterArray.Aggregate(TestStringLatin, (current, c) => current.Replace(c.ToString(), string.Empty));
                Assert.That(() => TestStringLatin.Strip(SingleCharacterArray),  Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnValidSourceSingleCharacter_ReturnsStrippedString()
            {
                var expected = TestStringLatin.Replace(SingleCharacter.ToString(), string.Empty);
                Assert.That(() => TestStringLatin.Strip(SingleCharacter), Is.EqualTo(expected));
            }

            [Test]
            public void Strip_OnValidSourceNullString_ThrowsValidationException()
            {
                Assert.That(() => TestStringLatin.Strip(NullTestString), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Strip_OnValidSourceEmptyString_ReturnsSameString()
            {
                Assert.That(() => TestStringLatin.Strip(EmptyTestString), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Strip_OnValidSourceSubString_ReturnsStrippedString()
            {
                var expected = TestStringLatin.Replace(SubString, string.Empty);
                Assert.That(() => TestStringLatin.Strip(SubString), Is.EqualTo(expected));      
            }
        }
    }
}