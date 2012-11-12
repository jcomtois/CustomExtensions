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
        public class LeftTest
        {
            [Test]
            public void Left_OnEmptyString_ReturnsEmptyString()
            {
                var emptyString = string.Empty;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyString.Left(intValue), Is.Empty);
            }

            [Test]
            public void Left_OnNullString_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullString.Left(intValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Left_OnNullString_WithNegativeLength_ThrowsValidationException()
            {
                string nullString = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();
                intValue = -intValue;

                Assert.That(() => nullString.Left(intValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Left_OnString_LengthEqualToStringLength_ReturnsCorrectSubstring()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var length = stringValue.Length;

                Assert.That(() => stringValue.Left(length), Is.EqualTo(stringValue));
            }

            [Test]
            public void Left_OnString_LengthGreaterThanStringLength_ReturnsCorrectSubstring()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var length = stringValue.Length + 1;

                Assert.That(() => stringValue.Left(length), Is.EqualTo(stringValue));
            }

            [Test]
            public void Left_OnString_LengthLessThanStringLength_ReturnsCorrectSubstring()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var length = stringValue.Length - 1;
                var expected = stringValue.Substring(0, length);

                Assert.That(() => stringValue.Left(length), Is.EqualTo(expected));
            }

            [Test]
            public void Left_OnString_WithNegativeLength_ThrowsValidationException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var intValue = fixture.CreateAnonymous<int>();
                intValue = -intValue;

                Assert.That(() => stringValue.Left(intValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }
        }
    }
}