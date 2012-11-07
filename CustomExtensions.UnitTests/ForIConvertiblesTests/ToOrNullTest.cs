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
using CustomExtensions.UnitTests.Customization.Fixtures;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIConvertiblesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrNullTest
        {
            [Test]
            public void ToOrNull_ToBadConvertible_OnAnyInteger_OutNull()
            {
                var fixture = new MultipleMockingFixture();
                IConvertible outParameter;
                fixture.CreateAnonymous<int>().ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToBadConvertible_OnAnyInteger_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                IConvertible outParameter;
                var actual = fixture.CreateAnonymous<int>().ToOrNull(out outParameter);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrNull_ToInteger_OnNullString_OutNull()
            {
                object outParameter;
                string nullString = null;
                nullString.ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnEmptyString_OutObject()
            {
                object outParameter;
                var emptyString = string.Empty;
                emptyString.ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Not.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnEmptyString_ReturnsObject()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.ToOrNull<object>(), Is.Not.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnIntegerString_ReturnsObject()
            {
                var fixture = new MultipleMockingFixture();
                var intValue = fixture.CreateAnonymous<int>();
                var integerString = intValue.ToString();

                Assert.That(() => integerString.ToOrNull<object>(), Is.Not.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnMaxDouble_OutObject()
            {
                object outParameter;
                double.MaxValue.ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Not.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnMaxDouble_ReturnsTrue()
            {
                object outParameter;
                var actual = double.MaxValue.ToOrNull(out outParameter);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_OutNull()
            {
                object outParameter;
                int? nullNullableInteger = null;
                nullNullableInteger.ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_ReturnsNull()
            {
                int? nullNullableInteger = null;

                Assert.That(() => nullNullableInteger.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullNullableInteger_ReturnsTrue()
            {
                int? nullNullableInteger = null;
                object outParameter;
                var actual = nullNullableInteger.ToOrNull(out outParameter);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullString_ReturnsNull()
            {
                string nullString = null;

                Assert.That(() => nullString.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNull_ToObject_OnNullString_ReturnsTrue()
            {
                object outParameter;
                string nullString = null;
                var actual = nullString.ToOrNull(out outParameter);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_CallsToString()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                IConvertible convertible = mockConvertible.Object;
                convertible.ToOrNull(out outParameter);

                mockConvertible.Verify(m => m.ToString(It.IsAny<IFormatProvider>()), Times.Once());
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_OutNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                IConvertible convertible = mockConvertible.Object;
                convertible.ToOrNull(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                IConvertible convertible = mockConvertible.Object;
                var actual = convertible.ToOrNull(out outParameter);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrNull_ToString_OnBadConvertible_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                IConvertible convertible = mockConvertible.Object;

                Assert.That(() => convertible.ToOrNull(out outParameter), Throws.Exception);
            }

            [Test]
            public void ToOrNull_ToString_OnEmptyString_ReturnsTrue()
            {
                object outParameter;
                string emptyString = string.Empty;
                var actual = emptyString.ToOrNull(out outParameter);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrNull_ToString_OnMaxDouble_ReturnsString()
            {
                var actual = double.MaxValue.ToOrNull<string>();
                var expected = double.MaxValue.ToString();

                Assert.That(() => actual, Is.EqualTo(expected));
            }
        }
    }
}