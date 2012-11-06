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
using Ploeh.AutoFixture.AutoMoq;

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
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.To<bool>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToConvertible_OnNonNumericString_ThrowsInvalidCastException()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.To<IConvertible>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToFloat_OnDecimal_ReturnsFloat()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var decimalValue = fixture.CreateAnonymous<decimal>();
                float floatValue = Convert.ToSingle(decimalValue);

                Assert.That(() => decimalValue.To<float>(), Is.EqualTo(floatValue));
            }

            [Test]
            public void ToInt_OnEmptyString_ThrowsFormatException()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnIntegerString_ReturnsInteger()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var intValue = fixture.CreateAnonymous<int>();
                var integerString = intValue.ToString();

                Assert.That(() => integerString.To<int>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToInt_OnNonNumericString_ThrowsFormatException()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnNullString_ThrowsInvalidCastException()
            {
                string nullString = null;

                Assert.That(() => nullString.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToInteger_OnDecimal_ReturnsInteger()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var decimalValue = fixture.CreateAnonymous<decimal>();
                int intValue = Convert.ToInt32(decimalValue);

                Assert.That(() => decimalValue.To<int>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToInteger_OnMaxDouble_ThrowsOverFlowException()
            {
                Assert.That(() => double.MaxValue.To<int>(), Throws.TypeOf<OverflowException>());
            }

            [Test]
            public void ToInteger_OnNonNullNullableInteger_ReturnsTestInteger()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var intValue = fixture.CreateAnonymous<int>();
                int? nonNullNullableInt = intValue;

                Assert.That(() => nonNullNullableInt.To<int>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToInteger_OnNullNullableInteger_ThrowsInvalidCastException()
            {
                int? nullNullableInteger = null;

                Assert.That(() => nullNullableInteger.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToNullableInt_OnEmptyString_ThrowsFormatException()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.To<int?>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToNullableInt_OnIntegerString_ReturnsInteger()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var intValue = fixture.CreateAnonymous<int>();
                var intString = intValue.ToString();

                Assert.That(() => intString.To<int?>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToNullableInt_OnNullString_ReturnsNull()
            {
                string nullString = null;

                Assert.That(() => nullString.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInteger_OnIntegerString_ReturnsNullableInteger()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var intValue = fixture.CreateAnonymous<int>();
                var intString = intValue.ToString();

                Assert.That(() => intString.To<int?>(), Is.EqualTo(intValue));
            }

            [Test]
            public void ToNullableInteger_OnNullNullableInteger_ReturnsNull()
            {
                int? nullNullableInteger = null;

                Assert.That(() => nullNullableInteger.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInteger_OnNullNullableInteger_ReturnsNullNullableInteger()
            {
                int? nullNullableInteger = null;

                Assert.That(() => nullNullableInteger.To<int?>(), Is.EqualTo(nullNullableInteger));
            }

            [Test]
            public void ToString_OnBadConvertible_ThrowsInvalidCastException()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                IConvertible convertible = mockConvertible.Object;

                Assert.That(() => convertible.To<string>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToString_OnTestInteger_ReturnsTestIntegerString()
            {
                var fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
                var intValue = fixture.CreateAnonymous<int>();
                var intString = intValue.ToString();

                Assert.That(() => intValue.To<string>(), Is.EqualTo(intString));
            }
        }
    }
}