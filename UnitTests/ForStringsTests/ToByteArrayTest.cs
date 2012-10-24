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
using UnitTests.ForArrayTests;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class ToByteArrayTest
        {
            private static readonly byte[] _validByteArray = ArrayTests.ValidByteArray;
            private static readonly string _bitConverterString = BitConverter.ToString(_validByteArray).Replace("-", string.Empty).Trim();

            [Test]
            public void ToByteArray_OnEmptyString_ThrowsValidationException()
            {
                Assert.That(() => EmptyTestString.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
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
                Assert.That(() => TestStringLatin.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<FormatException>());
            }

            [Test]
            public void ToByteArray_OnNullString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.ToByteArray(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToByteArray_OnValidHexString_ReturnsProperByteArray()
            {
                Assert.That(() => _bitConverterString.ToByteArray(), Is.EqualTo(_validByteArray));
            }

            [Test]
            public void ToByteArray_OnValidLowerHexString_ReturnsProperByteArray()
            {
                Assert.That(() => _bitConverterString.ToLowerInvariant().ToByteArray(), Is.EqualTo(_validByteArray));
            }

            [Test]
            public void ToByteArray_OnValidUpperHexString_ReturnsProperByteArray()
            {
                Assert.That(() => _bitConverterString.ToUpperInvariant().ToByteArray(), Is.EqualTo(_validByteArray));
            }
        }
    }
}