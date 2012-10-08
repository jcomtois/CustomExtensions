using System;
using CustomExtensions.ForIConvertible;
using Moq;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrOtherTest
        {
            [Test]
            public void ToOrOtherObject_OnEmptyString_ReturnsObject()
            {
                string testString = string.Empty;
                object newObject = new object();
                Assert.That(() => testString.ToOrOther(newObject), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrOtherObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                object newObject = new object();
                Assert.That(() => number.ToOrOther(newObject), Is.Null);
            }

            [Test]
            public void ToOrOtherObject_OnNullString_ReturnsNull()
            {
                string testString = null;
                object newObject = new object();
                Assert.That(() => testString.ToOrOther(newObject), Is.Null);
            }

            [Test]
            public void ToOrOtherObject_OnString_ReturnsNewObject()
            {
                string testString = "1";
                object newObject = new object();
                Assert.That(() => testString.ToOrOther(newObject), Is.Not.EqualTo(newObject));
            }

            [Test]
            public void ToOrOtherOutBadConvertible_OnInteger_ReturnsBadConvertible()
            {
                var mockConvertible = new Mock<IConvertible>();
                int number = 0;
                var outParameter = mockConvertible.Object;
                number.ToOrOther(out outParameter, mockConvertible.Object);
                Assert.That(() => outParameter, Is.EqualTo(mockConvertible.Object));
            }

            [Test]
            public void ToOrOtherOutInteger_OnNullString_ReturnsOther()
            {
                string testString = null;
                int outParameter;
                testString.ToOrOther(out outParameter, 1);
                Assert.That(() => outParameter, Is.EqualTo(1));
            }

            [Test]
            public void ToOrOtherOutObject_OnDouble_ReturnsObject()
            {
                double number = double.MaxValue;
                object testObject = new object();
                object outParameter;
                number.ToOrOther(out outParameter, testObject);
                Assert.That(() => outParameter, Is.Not.EqualTo(testObject));
            }

            [Test]
            public void ToOrOtherOutObject_OnDouble_ReturnsTrue()
            {
                double number = double.MaxValue;
                object testObject = new object();
                object outParameter;
                Assert.That(() => number.ToOrOther(out outParameter, testObject), Is.True);
            }

            [Test]
            public void ToOrOtherOutObject_OnEmptyString_ReturnsStringAsObject()
            {
                string testString = string.Empty;
                object testObject = new object();
                object outParameter;
                testString.ToOrOther(out outParameter, testObject);
                Assert.That(() => outParameter, Is.Not.EqualTo(testObject));
            }

            [Test]
            public void ToOrOtherOutObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                object outParameter;
                number.ToOrOther(out outParameter, new object());
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrOtherOutObject_OnNullNullableInteger_ReturnsTrue()
            {
                int? number = null;
                object testObject = new object();
                object outParameter;
                Assert.That(() => number.ToOrOther(out outParameter, testObject), Is.True);
            }

            [Test]
            public void ToOrOtherOutObject_OnNullString_ReturnsTrue()
            {
                string testString = null;
                object testObject = new object();
                object outParameter;
                Assert.That(() => testString.ToOrOther(out outParameter, testObject), Is.True);
            }

            [Test]
            public void ToOrOtherOutString_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrOther(out outParameter, "TEST"), Is.False);
            }

            [Test]
            public void ToOrOtherOutString_OnBadConvertible_ReturnsOther()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                string testString = "TEST";
                mockConvertible.Object.ToOrOther(out outParameter, testString);
                Assert.That(() => outParameter, Is.EqualTo(testString));
            }

            [Test]
            public void ToOrOtherOutString_OnEmptyString_ReturnsTrue()
            {
                string testString = string.Empty;
                object testObject = new object();
                object outParameter;
                Assert.That(() => testString.ToOrOther(out outParameter, testObject), Is.True);
            }

            [Test]
            public void ToOrOtherOutTestObject_OnInteger_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                int number = 0;
                var outParameter = mockConvertible.Object;
                Assert.That(() => number.ToOrOther(out outParameter, mockConvertible.Object), Is.False);
            }

            [Test]
            public void ToOrOtherString_OnDouble_ReturnsString()
            {
                double number = 1d;
                Assert.That(() => number.ToOrOther("2"), Is.EqualTo("1"));
            }

            [Test]
            public void ToOrOtherString_OnTestObject_ReturnsString()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string testString = "TEST";
                Assert.That(() => mockConvertible.Object.ToOrOther(testString), Is.EqualTo(testString));
            }
        }
    }
}