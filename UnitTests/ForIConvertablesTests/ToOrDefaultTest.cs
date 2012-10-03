using CustomExtensions.ForIConvertible;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrDefaultTest
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
            public void ToOrDefaultInt_OnDouble_ReturnsDefaultInteger()
            {
                double number = double.MaxValue;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnBadString_ReturnsDefaultInteger()
            {
                string number = "ABC";
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnEmptyString_ReturnsDefaultInteger()
            {
                string number = string.Empty;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnNullNullableInteger_ReturnsDefaultInteger()
            {
                int? number = null;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnNullString_ReturnsDefaultInteger()
            {
                string number = null;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnString_ReturnsInteger()
            {
                string number = "1";
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(1));
            }

            [Test]
            public void ToOrDefaultNullableInt_OnDouble_ReturnsNull()
            {
                double number = double.MaxValue;
                Assert.That(() => number.ToOrDefault<int?>(), Is.Null);
            }

            [Test]
            public void ToOrDefaultOutInt_OnDouble_ReturnsDefaultInteger()
            {
                double number = double.MaxValue;
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInt_OnDouble_ReturnsFalse()
            {
                double number = double.MaxValue;
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInt_OnTestObject_ReturnsDefaultInt()
            {
                int outParameter;
                _testObject.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInt_OnTestObject_ReturnsFalse()
            {
                int outParameter;
                Assert.That(() => _testObject.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInteger_OnBadString_ReturnsDefaultInteger()
            {
                string number = "ABC";
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInteger_OnBadString_ReturnsFalse()
            {
                string number = "ABC";
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInteger_OnEmptyString_ReturnsDefaultInteger()
            {
                string number = string.Empty;
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInteger_OnEmptyString_ReturnsFalse()
            {
                string number = string.Empty;
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInteger_OnNullNullableInteger_ReturnsDefaultInteger()
            {
                int? number = null;
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInteger_OnNullNullableInteger_ReturnsFalse()
            {
                int? number = null;
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInteger_OnNullString_ReturnsDefaultInteger()
            {
                string number = null;
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultOutInteger_OnNullString_ReturnsFalse()
            {
                string number = null;
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutInteger_OnString_ReturnsInteger()
            {
                string number = "1";
                int outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(1));
            }

            [Test]
            public void ToOrDefaultOutInteger_OnString_ReturnsTrue()
            {
                string number = "1";
                int outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.True);
            }

            [Test]
            public void ToOrDefaultOutNullableInt_OnDouble_ReturnsFalse()
            {
                double number = double.MaxValue;
                int? outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutNullableInt_OnDouble_ReturnsNull()
            {
                double number = double.MaxValue;
                int? outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefaultOutSingle_OnDouble_ReturnsPositiveInfinity()
            {
                double number = double.MaxValue;
                float outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.EqualTo(float.PositiveInfinity));
            }

            [Test]
            public void ToOrDefaultOutSingle_OnDouble_ReturnsPositiveTrue()
            {
                double number = double.MaxValue;
                float outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.True);
            }

            [Test]
            public void ToOrDefaultOutString_OnTestObject_ReturnsFalse()
            {
                string outParameter;
                Assert.That(() => _testObject.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutString_OnTestObject_ReturnsNull()
            {
                string outParameter;
                _testObject.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrDefaultOutTestObject_OnInteger_ReturnsFalse()
            {
                int number = 0;
                TestObject outParameter;
                Assert.That(() => number.ToOrDefault(out outParameter), Is.False);
            }

            [Test]
            public void ToOrDefaultOutTestObject_OnInteger_ReturnsNull()
            {
                int number = 0;
                TestObject outParameter;
                number.ToOrDefault(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }
        }
    }
}