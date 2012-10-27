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
        public class ToOrOtherTest
        {
            [Test]
            public void ToOrOther_ToBadConvertible_OnTestIntegerWithAnyBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                Assert.That(() => TestInteger.ToOrOther(out outParameter, It.IsAny<IConvertible>()), Is.False);
            }

            [Test]
            public void ToOrOther_ToBadConvertible_OnTestInteger_OutBadConvertible()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                TestInteger.ToOrOther(out outParameter, mockConvertible.Object);
                Assert.That(() => outParameter, Is.EqualTo(mockConvertible.Object));
            }

            [Test]
            public void ToOrOther_ToInteger_OnNullStringWithTestInteger_OutTestInteger()
            {
                int outParameter;
                NullString.ToOrOther(out outParameter, TestInteger);
                Assert.That(() => outParameter, Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToOrOther_ToObject_OnEmptyStringWithTestObject_OutStringAsObject()
            {
                object outParameter;
                EmptyString.ToOrOther(out outParameter, TestObject);
                Assert.That(() => outParameter, Is.Not.EqualTo(TestObject));
            }

            [Test]
            public void ToOrOther_ToObject_OnEmptyStringWithTestObject_ReturnsTestObject()
            {
                Assert.That(() => EmptyString.ToOrOther(TestObject), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrOther_ToObject_OnMaxDoubleWithAnyObject_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => MaxDouble.ToOrOther(out outParameter, It.IsAny<object>()), Is.True);
            }

            [Test]
            public void ToOrOther_ToObject_OnMaxDoubleWithTestObject_OutTestObject()
            {
                object outParameter;
                MaxDouble.ToOrOther(out outParameter, TestObject);
                Assert.That(() => outParameter, Is.Not.EqualTo(TestObject));
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntegerWithAnyObject_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => NullNullableInteger.ToOrOther(out outParameter, It.IsAny<object>()), Is.True);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntegerWithTestObject_OutNull()
            {
                object outParameter;
                NullNullableInteger.ToOrOther(out outParameter, TestObject);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullNullableIntegerWithTestObject_ReturnsNull()
            {
                Assert.That(() => NullNullableInteger.ToOrOther(TestObject), Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullStringWithAnyObject_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => NullString.ToOrOther(out outParameter, It.IsAny<object>()), Is.True);
            }

            [Test]
            public void ToOrOther_ToObject_OnNullStringWithTestObject_ReturnsNull()
            {
                Assert.That(() => NullString.ToOrOther(TestObject), Is.Null);
            }

            [Test]
            public void ToOrOther_ToObject_OnStringWithTestObject_ReturnsTestObject()
            {
                Assert.That(() => TestInteger.ToOrOther(TestObject), Is.Not.EqualTo(TestObject));
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithAnyString_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrOther(out outParameter, It.IsAny<string>()), Is.False);
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithAnyString_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrOther(out outParameter, It.IsAny<string>()), Throws.Exception);
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithNonNumericString_OutNonNumericString()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                mockConvertible.Object.ToOrOther(out outParameter, NonNumericString);
                Assert.That(() => outParameter, Is.EqualTo(NonNumericString));
            }

            [Test]
            public void ToOrOther_ToString_OnBadConvertibleWithNonNumericString_ReturnsNonNumericString()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                Assert.That(() => mockConvertible.Object.ToOrOther(NonNumericString), Is.EqualTo(NonNumericString));
            }

            [Test]
            public void ToOrOther_ToString_OnEmptyStringWithAnyObject_ReturnsTrue()
            {
                object outParameter;
                Assert.That(() => EmptyString.ToOrOther(out outParameter, It.IsAny<object>()), Is.True);
            }

            [Test]
            public void ToOrOther_ToString_OnMaxDouble_ReturnsMaxDoubleString()
            {
                Assert.That(() => MaxDouble.ToOrOther(It.IsAny<string>()), Is.EqualTo(MaxDouble.ToString()));
            }
        }
    }
}