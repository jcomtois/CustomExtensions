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
using CustomExtensions.ForIConvertible;
using Moq;
using NUnit.Framework;

namespace UnitTests.ForIConvertiblesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrNullTest
        {
            [Test]
            public void ToOrNull_ToBadConvertible_OnAnyInteger_OutNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                It.IsAny<int>().ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToBadConvertible_OnAnyInteger_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                Assert.That(() => It.IsAny<int>().ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNull_ToInteger_OnNullString_OutNull()
            {
                object outParameter;
                NullString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnEmptyString_OutObject()
            {
                object outParameter;
                EmptyString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNull_ToObject_OnEmptyString_ReturnsObject()
            {
                Assert.That(() => EmptyString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNull_ToObject_OnIntegerString_ReturnsObject()
            {
                Assert.That(() => IntegerString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNull_ToObject_OnMaxDouble_OutObject()
            {
                object outParameter;
                MaxDouble.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNull_ToObject_OnMaxDouble_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => MaxDouble.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_OutNull()
            {
                object outParameter;
                NullNullableInteger.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_ReturnsNull()
            {
                Assert.That(() => NullNullableInteger.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => NullNullableInteger.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullString_ReturnsNull()
            {
                Assert.That(() => NullString.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullString_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => NullString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_CallsToString()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                mockConvertible.Object.ToOrNull(out outParameter);
                mockConvertible.Verify(m => m.ToString(It.IsAny<IFormatProvider>()), Times.Once());
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_OutNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                mockConvertible.Object.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrNull(out outParameter), Throws.Exception);
            }

            [Test]
            public void ToOrNull_ToString_OnEmptyString_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => EmptyString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNull_ToString_OnMaxDouble_ReturnsString()
            {
                Assert.That(() => MaxDouble.ToOrNull<string>(), Is.EqualTo(MaxDouble.ToString()));
            }
        }
    }
}