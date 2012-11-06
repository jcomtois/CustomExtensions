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
using CustomExtensions.ForArrays;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForArrayTests
{
    public partial class ArrayTests
    {
        [TestFixture]
        public class ToHexStringTest
        {
            [Test]
            public void ToHexString_OnNullArray_ThrowsValidationException()
            {
                Assert.That(() => NullByteArray.ToHexString(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToHexString_OnEmptyArray_ThrowsValidationException()
            {
                Assert.That(() => EmptyByteArray.ToHexString(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void ToHexString_OnValidArray_ConvertsToStringCorrectly()
            {
                var expected = BitConverter.ToString(ValidByteArray).Replace("-", string.Empty).ToLowerInvariant();
                Assert.That(() => ValidByteArray.ToHexString(), Is.EqualTo(expected));
            }

            [Test]
            public void ToHexString_OnSingleHighByteArray_ConvertsToStringCorrectly()
            {
                var expected = BitConverter.ToString(SingleHighByteArray).Replace("-", string.Empty).ToLowerInvariant();
                Assert.That(() => SingleHighByteArray.ToHexString(), Is.EqualTo(expected));
            }

            [Test]
            public void ToHexString_OnSingleLowByteArray_ConvertsToStringCorrectly()
            {
                var expected = BitConverter.ToString(SingleLowByteArray).Replace("-", string.Empty).ToLowerInvariant();
                Assert.That(() => SingleLowByteArray.ToHexString(), Is.EqualTo(expected));
            }

        }
    }
}