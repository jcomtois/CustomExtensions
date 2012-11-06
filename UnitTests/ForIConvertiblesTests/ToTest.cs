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
        public class ToTest
        {
            [Test]
            public void ToBool_OnNonNumericString_ThrowsFormatException()
            {
                Assert.That(() => NonNumericString.To<bool>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToConvertible_OnNonNumericString_ThrowsInvalidCastException()
            {
                Assert.That(() => NonNumericString.To<IConvertible>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToFloat_OnTestDecimal_ReturnsTestFloat()
            {
                Assert.That(() => TestDecimal.To<float>(), Is.EqualTo(TestFloat));
            }

            [Test]
            public void ToInt_OnEmptyString_ThrowsFormatException()
            {
                Assert.That(() => EmptyString.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnIntegerString_ReturnsTestInteger()
            {
                Assert.That(() => IntegerString.To<int>(), Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToInt_OnNonNumericString_ThrowsFormatException()
            {
                Assert.That(() => NonNumericString.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnNullString_ThrowsInvalidCastException()
            {
                Assert.That(() => NullString.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToInteger_OnDecimal_ReturnsInteger()
            {
                Assert.That(() => TestDecimal.To<int>(), Is.EqualTo((int)TestDecimal));
            }

            [Test]
            public void ToInteger_OnMaxDouble_ThrowsOverFlowException()
            {
                Assert.That(() => double.MaxValue.To<int>(), Throws.TypeOf<OverflowException>());
            }

            [Test]
            public void ToInteger_OnNonNullNullableInteger_ReturnsTestInteger()
            {
                Assert.That(() => NonNullNullableInteger.To<int>(), Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToInteger_OnNullNullableInteger_ThrowsInvalidCastException()
            {
                Assert.That(() => NullNullableInteger.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToNullableInt_OnEmptyString_ThrowsFormatException()
            {
                Assert.That(() => EmptyString.To<int?>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToNullableInt_OnIntegerString_ReturnsTestInteger()
            {
                Assert.That(() => IntegerString.To<int?>(), Is.EqualTo(TestInteger));
            }

            [Test]
            public void ToNullableInt_OnNullString_ReturnsNull()
            {
                Assert.That(() => NullString.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInteger_OnIntegerString_ReturnsNullableInteger()
            {
                Assert.That(() => IntegerString.To<int?>(), Is.InstanceOf<int?>());
            }

            [Test]
            public void ToNullableInteger_OnNullNullableInteger_ReturnsNull()
            {
                Assert.That(() => NullNullableInteger.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInteger_OnNullNullableInteger_ReturnsNullNullableInteger()
            {
                Assert.That(() => NullNullableInteger.To<int?>(), Is.EqualTo(NullNullableInteger));
            }

            [Test]
            public void ToString_OnBadConvertible_ThrowsInvalidCastException()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                Assert.That(() => mockConvertible.Object.To<string>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToString_OnTestInteger_ReturnsTestIntegerString()
            {
                Assert.That(() => TestInteger.To<string>(), Is.EqualTo(IntegerString));
            }
        }
    }
}