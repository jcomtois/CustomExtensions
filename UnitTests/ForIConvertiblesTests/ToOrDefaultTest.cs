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
using Ploeh.AutoFixture;

namespace UnitTests.ForIConvertiblesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrDefaultTest
        {
            private Fixture _fixture;

            [SetUp]
            public void SetUp()
            {
                _fixture = new Fixture();
            }

            [Test]
            public void ToOrDefault_ToBadConvertible_OnAnyInteger_OutNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                _fixture.CreateAnonymous<int>().ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefault_ToBadConvertible_OnAnyInteger_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                var outParameter = mockConvertible.Object;
                Assert.That(() => _fixture.CreateAnonymous<int>().ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToFloat_OnMaxDouble_OutPositiveInfinity()
            {
                float outParameter;
                MaxDouble.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(float.PositiveInfinity));
            }

            [Test]
            public void ToOrDefault_ToFloat_OnMaxDouble_ReturnsTrue()
            {
                float outParameter;
                Assert.That(() => MaxDouble.ToOrDefault(out outParameter), Is.True);
            }

            [Test]
            public void ToOrDefault_ToInt_OnBadConvertible_CallsToInt32()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(c => c.ToInt32(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                int outParameter;
                mockConvertible.Object.ToOrDefault(out outParameter);
                mockConvertible.Verify(c => c.ToInt32(It.IsAny<IFormatProvider>()), Times.Once());
            }

            [Test]
            public void ToOrDefault_ToInt_OnBadConvertible_OutDefaultInt()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(c => c.ToInt32(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                int outParameter;
                mockConvertible.Object.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInt_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(c => c.ToInt32(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                int outParameter;
                Assert.That(() => mockConvertible.Object.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_OutDefaultInteger()
            {
                int outParameter;
                MaxDouble.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_ReturnsDefaultInteger()
            {
                Assert.That(() => MaxDouble.ToOrDefault<int>(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => MaxDouble.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_OutDefaultInteger()
            {
                int outParameter;
                EmptyString.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_ReturnsDefaultInteger()
            {
                Assert.That(() => EmptyString.ToOrDefault<int>(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => EmptyString.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_OutInteger()
            {
                int outParameter;
                IntegerString.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_ReturnsInteger()
            {
                Assert.That(() => IntegerString.ToOrDefault<int>(), Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_ReturnsTrue()
            {
                int outParameter;
                Assert.That(() => IntegerString.ToOrDefault(out outParameter), Is.True);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_OutDefaultInteger()
            {
                int outParameter;
                NonNumericString.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_ReturnsDefaultInteger()
            {
                Assert.That(() => NonNumericString.ToOrDefault<int>(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => NonNumericString.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_OutDefaultInteger()
            {
                int outParameter;
                NullNullableInteger.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_ReturnsDefaultInteger()
            {
                Assert.That(() => NullNullableInteger.ToOrDefault<int>(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => NullNullableInteger.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_OutDefaultInteger()
            {
                int outParameter;
                NullString.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_ReturnsDefaultInteger()
            {
                Assert.That(() => NullString.ToOrDefault<int>(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => NullString.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_OutNull()
            {
                int? outParameter;
                MaxDouble.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_ReturnsFalse()
            {
                int? outParameter;
                Assert.That(() => MaxDouble.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_ReturnsNull()
            {
                Assert.That(() => MaxDouble.ToOrDefault<int?>(), Is.Null);
            }

            [Test]
            public void ToOrDefault_ToString_OnBadConvertible_CallsToString()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                mockConvertible.Object.ToOrDefault(out outParameter);
                mockConvertible.Verify(m => m.ToString(It.IsAny<IFormatProvider>()), Times.Once());
            }

            [Test]
            public void ToOrDefault_ToString_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToString_OnBadConvertible_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrDefault(out outParameter), Throws.Exception);
            }

            [Test]
            public void ToOrDefault_Totring_OnBadConvertible_OutNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                mockConvertible.Object.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }
        }
    }
}