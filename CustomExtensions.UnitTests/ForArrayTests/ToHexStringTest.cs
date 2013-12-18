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
using CustomExtensions.ForArrays;
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForArrayTests
{
    public partial class ArrayTests
    {
        [TestFixture]
        public class ToHexStringTest
        {
            [Test]
            public void ToHexString_OnEmptyArray_ThrowsValidationException()
            {
                byte[] emptyByteArray = new byte[0];

                Assert.That(() => emptyByteArray.ToHexString(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void ToHexString_OnNullArray_ThrowsValidationException()
            {
                byte[] nullByteArray = null;

                Assert.That(() => nullByteArray.ToHexString(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ToHexString_OnSingleHighByteArray_ConvertsToStringCorrectly()
            {
                var singleHighByteArray = new[] {byte.MaxValue};
                var expected = BitConverter.ToString(singleHighByteArray).Replace("-", string.Empty).ToLowerInvariant();

                Assert.That(() => singleHighByteArray.ToHexString(), Is.EqualTo(expected));
            }

            [Test]
            public void ToHexString_OnSingleLowByteArray_ConvertsToStringCorrectly()
            {
                var singleLowByteArray = new[] {byte.MinValue};
                var expected = BitConverter.ToString(singleLowByteArray).Replace("-", string.Empty).ToLowerInvariant();

                Assert.That(() => singleLowByteArray.ToHexString(), Is.EqualTo(expected));
            }

            [Test]
            public void ToHexString_OnValidArray_ConvertsToStringCorrectly()
            {
                var fixture = new MultipleMockingFixture(512);
                var validBytes = fixture.Create<byte[]>();
                var expected = BitConverter.ToString(validBytes).Replace("-", string.Empty).ToLowerInvariant();

                Assert.That(() => validBytes.ToHexString(), Is.EqualTo(expected));
            }
        }
    }
}