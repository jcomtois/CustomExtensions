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
using CustomExtensions.Validation;
using NUnit.Framework;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class TruncateTest
        {
            private const string Ellipsis = "...";
            private static readonly int ValidLength = Ellipsis.Length + 1;
            private static readonly int InvalidLength = ValidLength - 1;
            private static readonly string ShortString = new string('a', InvalidLength);
            private static readonly string EqualString = new string('a', ValidLength);
            private static readonly string LongString = new string('a', ValidLength + 1);

            [Test]
            public void Truncate_OnEmptyStringWithInValidLength_ThrowsValidationException()
            {
                Assert.That(() => EmptyTestString.Truncate(InvalidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnEmptyStringWithValidLength_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Truncate(ValidLength), Is.Empty);
            }

            [Test]
            public void Truncate_OnEqualStringLengthIsEqualToEllipsis_ReturnsString()
            {
                Assert.That(() => EqualString.Truncate(ValidLength), Is.EqualTo(EqualString));
            }

            [Test]
            public void Truncate_OnEqualStringLengthIsGreaterThanEllipses_ReturnsString()
            {
                Assert.That(() => EqualString.Truncate(ValidLength + 1), Is.EqualTo(EqualString));
            }

            [Test]
            public void Truncate_OnEqualStringWithInvalidLength_ThrowsValidationException()
            {
                Assert.That(() => EqualString.Truncate(InvalidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnNullStringWithInValidLength_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Truncate(InvalidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Truncate_OnNullStringWithValidLength_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Truncate(ValidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Truncate_OnShortStringLengthIsGreaterThanElpises_ReturnsString()
            {
                Assert.That(() => ShortString.Truncate(ValidLength + 1), Is.EqualTo(ShortString));
            }

            [Test]
            public void Truncate_OnShortStringWithInvalidLength_ThrowsValidationException()
            {
                Assert.That(() => ShortString.Truncate(InvalidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnShortStringWithValidLength_ReturnsString()
            {
                Assert.That(() => ShortString.Truncate(ValidLength), Is.EqualTo(ShortString));
            }

            [Test]
            public void Truncate_OnValidStringWithInvalidLength_ThrowsValidationException()
            {
                Assert.That(() => LongString.Truncate(InvalidLength), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Truncate_OnValidStringWithLengthEqualToString_ReturnsString()
            {
                Assert.That(() => TestStringLatin.Truncate(TestStringLatin.Length), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Truncate_OnValidStringWithValidLength_ReturnsTruncatedString()
            {
                var expected = LongString.Substring(0, ValidLength - Ellipsis.Length) + Ellipsis;
                Assert.That(() => LongString.Truncate(ValidLength), Is.EqualTo(expected));
            }
        }
    }
}