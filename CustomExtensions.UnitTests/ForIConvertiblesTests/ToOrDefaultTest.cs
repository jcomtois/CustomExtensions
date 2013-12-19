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
        public class ToOrDefaultTest
        {
            [Test]
            public void ToOrDefault_ToBadConvertible_OnAnyInteger_OutNull()
            {
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();
                IConvertible outParameter;
                intValue.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefault_ToBadConvertible_OnAnyInteger_ReturnsFalse()
            {
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();
                IConvertible outParameter;
                var actual = intValue.ToOrDefault(out outParameter);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrDefault_ToFloat_OnMaxDouble_OutPositiveInfinity()
            {
                float outParameter;
                double.MaxValue.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(float.PositiveInfinity));
            }

            [Test]
            public void ToOrDefault_ToFloat_OnMaxDouble_ReturnsTrue()
            {
                float outParameter;
                var actual = double.MaxValue.ToOrDefault(out outParameter);

                Assert.That(() => actual, Is.True);
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

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInt_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(c => c.ToInt32(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                int outParameter;
                var actual = mockConvertible.Object.ToOrDefault(out outParameter);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_OutDefaultInteger()
            {
                int outParameter;
                double.MaxValue.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_ReturnsDefaultInteger()
            {
                Assert.That(() => double.MaxValue.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInt_OnMaxDouble_ReturnsFalse()
            {
                int outParameter;

                Assert.That(() => double.MaxValue.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_OutDefaultInteger()
            {
                int outParameter;
                var emptyString = string.Empty;
                emptyString.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_ReturnsDefaultInteger()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnEmptyString_ReturnsFalse()
            {
                int outParameter;
                var emptyString = string.Empty;

                Assert.That(() => emptyString.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_OutInteger()
            {
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();
                var integerString = intValue.ToString();
                int outParameter;
                integerString.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(intValue));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_ReturnsInteger()
            {
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();
                var integerString = intValue.ToString();

                Assert.That(() => integerString.ToOrDefault<int>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnIntegerString_ReturnsTrue()
            {
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();
                var integerString = intValue.ToString();
                int outParameter;

                Assert.That(() => integerString.ToOrDefault(out outParameter), Is.True);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_OutDefaultInteger()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                int outParameter;
                stringValue.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_ReturnsDefaultInteger()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNonNumericString_ReturnsFalse()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                int outParameter;
                var actual = stringValue.ToOrDefault(out outParameter);

                Assert.That(() => actual, Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_OutDefaultInteger()
            {
                int? nullNullableInteger = null;
                int outParameter;
                nullNullableInteger.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_ReturnsDefaultInteger()
            {
                int? nullNullableInteger = null;

                Assert.That(() => nullNullableInteger.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullNullableInteger_ReturnsFalse()
            {
                int? nullNullableInteger = null;
                int outParameter;

                Assert.That(() => nullNullableInteger.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_OutDefaultInteger()
            {
                int outParameter;
                string nullString = null;
                nullString.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_ReturnsDefaultInteger()
            {
                string nullString = null;

                Assert.That(() => nullString.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefault_ToInteger_OnNullString_ReturnsFalse()
            {
                int outParameter;
                string nullString = null;

                Assert.That(() => nullString.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_OutNull()
            {
                int? outParameter;
                double.MaxValue.ToOrDefault(out outParameter);

                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_ReturnsFalse()
            {
                int? outParameter;

                Assert.That(() => double.MaxValue.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefault_ToNullableInt_OnMaxDouble_ReturnsNull()
            {
                Assert.That(() => double.MaxValue.ToOrDefault<int?>(), Is.Null);
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
                var actual = mockConvertible.Object.ToOrDefault(out outParameter);

                Assert.That(() => actual, Is.False);
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