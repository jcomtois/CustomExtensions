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
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class ToByteArrayTest
        {
            [Test]
            public void ToByteArray_OnEmptyString_ThrowsValidationException()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void ToByteArray_OnInvalidCharacterCountString_ThrowsValidatioException()
            {
                const string invalidCharacterCountString = "123";

                Assert.That(() => invalidCharacterCountString.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<FormatException>());
            }

            [Test]
            public void ToByteArray_OnNonHexString_ThrowsValidationException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<FormatException>());
            }

            [Test]
            public void ToByteArray_OnNullString_ThrowsValidationException()
            {
                string nullString = null;

                Assert.That(() => nullString.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToByteArray_OnValidHexString_ReturnsProperByteArray()
            {
                var fixture = new MultipleMockingFixture(256);
                var bytes = fixture.CreateAnonymous<byte[]>();
                var hexString = BitConverter.ToString(bytes).Strip('-');

                Assert.That(() => hexString.ToByteArray(), Is.EqualTo(bytes));
            }

            [Test]
            public void ToByteArray_OnValidLowerHexString_ReturnsProperByteArray()
            {
                var fixture = new MultipleMockingFixture(256);
                var bytes = fixture.CreateAnonymous<byte[]>();
                var hexString = BitConverter.ToString(bytes).Strip('-').ToLowerInvariant();

                Assert.That(() => hexString.ToLowerInvariant().ToByteArray(), Is.EqualTo(bytes));
            }

            [Test]
            public void ToByteArray_OnValidUpperHexString_ReturnsProperByteArray()
            {
                var fixture = new MultipleMockingFixture(256);
                var bytes = fixture.CreateAnonymous<byte[]>();
                var hexString = BitConverter.ToString(bytes).Strip('-').ToUpperInvariant();

                Assert.That(() => hexString.ToUpperInvariant().ToByteArray(), Is.EqualTo(bytes));
            }
        }
    }
}