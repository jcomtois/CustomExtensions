using System;
using CustomExtensions.ForIConvertible;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrNullTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _testObject = new TestObject();
            }

            #endregion

            private TestObject _testObject;

            [Test]
            public void ToOrNullObject_OnEmptyString_ReturnsObject()
            {
                string testString = string.Empty;
                Assert.That(() => testString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                Assert.That(() => number.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNullObject_OnNullString_ReturnsNull()
            {
                string testString = null;
                Assert.That(() => testString.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNullObject_OnString_ReturnsObject()
            {
                string testString = "1";
                Assert.That(() => testString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutInteger_OnNullString_ReturnsNull()
            {
                string testString = null;
                object outParameter;
                testString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutObject_OnDouble_ReturnsObject()
            {
                double number = double.MaxValue;
                object outParameter;
                number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutObject_OnDouble_ReturnsTrue()
            {
                double number = double.MaxValue;
                object outParameter;
                Assert.That(() => number.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutObject_OnEmptyString_ReturnsObject()
            {
                string testString = string.Empty;
                object outParameter;
                testString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                object outParameter;
                number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutObject_OnNullNullableInteger_ReturnsTrue()
            {
                int? number = null;
                object outParameter;
                Assert.That(() => number.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutObject_OnNullString_ReturnsTrue()
            {
                string testString = null;
                object outParameter;
                Assert.That(() => testString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutString_OnEmptyString_ReturnsTrue()
            {
                string testString = string.Empty;
                object outParameter;
                Assert.That(() => testString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutString_OnTestObject_ReturnsFalse()
            {
                string outParameter;
                Assert.That(() => _testObject.ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNullOutString_OnTestObject_ReturnsNull()
            {
                string outParameter;
                _testObject.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutTestObject_OnInteger_ReturnsFalse()
            {
                int number = 0;
                TestObject outParameter;
                Assert.That(() => number.ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNullOutTestObject_OnInteger_ReturnsNull()
            {
                int number = 0;
                TestObject outParameter;
                number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullString_OnDouble_ReturnsString()
            {
                double number = 1d;
                Assert.That(() => number.ToOrNull<string>(), Is.EqualTo("1"));
            }

            [Test]
            public void ToOrNullString_OnTestObject_ReturnsNull()
            {
                Assert.That(() => _testObject.ToOrNull<string>(), Is.Null);
            }
        }

    }
}