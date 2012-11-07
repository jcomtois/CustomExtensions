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
        public class ToOrOtherTest
        {
            [Test]
            public void ToOrOther_ToBadConvertible_OnIntegerWithAnyBadConvertible_ReturnsFalse()
            {
                var fixture = new MultipleMockingFixture();
                var intValue = fixture.CreateAnonymous<int>();
                var convertible = fixture.CreateAnonymous<IConvertible>();
                IConvertible outParameter;
                var actual = intValue.ToOrOther(out outParameter, convertible);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrOther_ToBadConvertible_OnInteger_OutBadConvertible()
            {
                var fixture = new MultipleMockingFixture();
                var intValue = fixture.CreateAnonymous<int>();
                var convertible = fixture.CreateAnonymous<IConvertible>();
                IConvertible outParameter;
                intValue.ToOrOther(out outParameter, convertible);

                Assert.That(() => outParameter, Is.EqualTo(convertible));
            }

            [Test]
            public void ToOrOther_ToInteger_OnNullStringWithInteger_OutInteger()
            {
                string nullString = null;
                var fixture = new MultipleMockingFixture();
                var intValue = fixture.CreateAnonymous<int>();
                int outParameter;
                nullString.ToOrOther(out outParameter, intValue);

                Assert.That(() => outParameter, Is.EqualTo(intValue));
            }

            [Test]
            public void ToOrOther_ToObject_OnEmptyStringWithObject_OutStringAsObject()
            {
                var emptyStrying = string.Empty;
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                object outParameter;
                emptyStrying.ToOrOther(out outParameter, objectValue);

                Assert.That(() => outParameter, Is.EqualTo(emptyStrying));
            }

            [Test]
            public void ToOrOther_ToObject_OnEmptyStringWithObject_ReturnsEmptyStringAsObject()
            {
                var emptyString = string.Empty;
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();

                Assert.That(() => emptyString.ToOrOther(objectValue), Is.EqualTo(emptyString));
            }

            [Test]
            public void ToOrOther_ToObject_OnIntWithObject_ReturnsIntAsObject()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => intValue.ToOrOther(objectValue), Is.EqualTo(intValue));
            }

            [Test]
            public void ToOrOther_ToObject_OnMaxDoubleWithObject_OutMaxDoubleAsObject()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                object outParameter;
                double.MaxValue.ToOrOther(out outParameter, objectValue);

                Assert.That(() => outParameter, Is.EqualTo(double.MaxValue));
            }

            [Test]
            public void ToOrOther_ToObject_OnMaxDouble_WithObject_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                object outParameter;
                var actual = double.MaxValue.ToOrOther(out outParameter, objectValue);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntWithObject_OutNull()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                int? nullNullableInt = null;
                object outParameter;
                nullNullableInt.ToOrOther(out outParameter, objectValue);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntegerWithAnyObject_ReturnsTrue()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                int? nullNullabelInteger = null;
                object outParameter;

                Assert.That(() => nullNullabelInteger.ToOrOther(out outParameter, objectValue), Is.True);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntegerWithObject_ReturnsNull()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                int? nullNullableInt = null;

                Assert.That(() => nullNullableInt.ToOrOther(objectValue), Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullStringWithObject_ReturnsNull()
            {
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                string nullString = null;

                Assert.That(() => nullString.ToOrOther(objectValue), Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullStringWithObject_ReturnsTrue()
            {
                object outParameter;
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                string nullString = null;
                var actual = nullString.ToOrOther(out outParameter, objectValue);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithNonNumericString_OutNonNumericString()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                IConvertible convertible = mockConvertible.Object;
                var fixture = new MultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                convertible.ToOrOther(out outParameter, stringValue);

                Assert.That(() => outParameter, Is.EqualTo(stringValue));
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithNonNumericString_ReturnsNonNumericString()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                IConvertible convertible = mockConvertible.Object;
                var fixture = new MultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => convertible.ToOrOther(stringValue), Is.EqualTo(stringValue));
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWith_String_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                var fixture = new MultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IConvertible convertible = mockConvertible.Object;

                Assert.That(() => convertible.ToOrOther(out outParameter, stringValue), Throws.Exception);
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertible_WithString_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                var fixture = new MultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IConvertible convertible = mockConvertible.Object;
                var actual = convertible.ToOrOther(out outParameter, stringValue);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrOther_ToString_OnEmptyStringWithAnyObject_ReturnsTrue()
            {
                object outParameter;
                var emptyString = string.Empty;
                var fixture = new MultipleMockingFixture();
                var objectValue = fixture.CreateAnonymous<object>();
                var actual = emptyString.ToOrOther(out outParameter, objectValue);

                Assert.That(() => actual, Is.True);
            }

            [Test]
            public void ToOrOther_ToString_OnMaxDouble_ReturnsMaxDoubleString()
            {
                double maxDouble = double.MaxValue;
                var fixture = new MultipleMockingFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var actual = maxDouble.ToOrOther(stringValue);
                var expected = maxDouble.ToString();

                Assert.That(() => actual, Is.EqualTo(expected));
            }
        }
    }
}