using System;
using CustomExtensions.ForIConvertible;
using Moq;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToTest
        {
            [Test]
            public void ToBool_OnString_ThrowsFormatException()
            {
                string testString = "ABC";
                Assert.That(() => testString.To<bool>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToConvertible_OnString_ThrowsInvalidCastException()
            {
                string testString = "ABC";
                Assert.That(() => testString.To<IConvertible>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToFloat_OnDecimal_ReturnsFloat()
            {
                decimal number = 1.1m;
                Assert.That(() => number.To<float>(), Is.EqualTo(1.1f));
            }

            [Test]
            public void ToInt_OnBadString_ThrowsFormatException()
            {
                string number = "ABC";
                Assert.That(() => number.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnEmptyString_ThrowsFormatException()
            {
                string number = string.Empty;
                Assert.That(() => number.To<int>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToInt_OnNullString_ThrowsInvalidCastException()
            {
                string number = null;
                Assert.That(() => number.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToInt_OnString_ReturnsInt()
            {
                string number = "10";
                Assert.That(() => number.To<int>(), Is.EqualTo(10));
            }

            [Test]
            public void ToInteger_OnDecimal_ReturnsInteger()
            {
                decimal number = 1.1m;
                Assert.That(() => number.To<int>(), Is.EqualTo(1));
            }

            [Test]
            public void ToInteger_OnMaxDouble_ThrowsOverFlowException()
            {
                double number = double.MaxValue;
                Assert.That(() => number.To<int>(), Throws.TypeOf<OverflowException>());
            }

            [Test]
            public void ToInteger_OnNullNullableInteger_ThrowsInvalidCastException()
            {
                int? number = null;
                Assert.That(() => number.To<int>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToInteger_OnNullableInteger_ReturnsInteger()
            {
                int? number = 1;
                Assert.That(() => number.To<int>(), Is.EqualTo(1));
            }

            [Test]
            public void ToNullableInt_OnEmptyString_ThrowsFormatException()
            {
                string number = string.Empty;
                Assert.That(() => number.To<int?>(), Throws.TypeOf<FormatException>());
            }

            [Test]
            public void ToNullableInt_OnNullString_ReturnsNull()
            {
                string number = null;
                Assert.That(() => number.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInt_OnString_ReturnsNullableInt()
            {
                string number = "10";
                Assert.That(() => number.To<int?>(), Is.EqualTo(10));
            }

            [Test]
            public void ToNullableInteger_OnInteger_ReturnsNullableInteger()
            {
                int number = 1;
                Assert.That(() => number.To<int?>(), Is.InstanceOf<int?>());
            }

            [Test]
            public void ToNullableInteger_OnNullInteger_ReturnsNull()
            {
                int? number = null;
                Assert.That(() => number.To<int?>(), Is.Null);
            }

            [Test]
            public void ToNullableInteger_OnNullInteger_ReturnsNullableInteger()
            {
                int? number = null;
                int? number2 = number.To<int?>();
                Assert.That(() => number2, Is.EqualTo(number));
            }

            [Test]
            public void ToString_OnBadConvertible_ThrowsInvalidCastException()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                Assert.That(() => mockConvertible.Object.To<string>(), Throws.TypeOf<InvalidCastException>());
            }

            [Test]
            public void ToString_OnInteger_ReturnsString()
            {
                int number = 10;
                Assert.That(() => number.To<string>(), Is.EqualTo("10"));
            }
        }
    }
}