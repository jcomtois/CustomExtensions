using System;
using CustomExtensions.ForIConvertible;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrDefaultTest
        {
            [Test]
            public void ToOrDefaultInteger_OnString_ReturnsInteger()
            {
                string number = "1";
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(1));
            }

            [Test]
            public void ToOrDefaultInteger_OnEmptyString_ReturnsDefaultInteger()
            {
                string number = string.Empty;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnNullString_ReturnsDefaultInteger()
            {
                string number = null;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultInteger_OnBadString_ReturnsDefaultInteger()
            {
                string number = "ABC";
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultSingle_OnDouble_ReturnsPositiveInfinity()
            {
                double number = double.MaxValue;
                Assert.That(() => number.ToOrDefault<float>(), Is.EqualTo(float.PositiveInfinity));
            }

            [Test]
            public void ToOrDefaultInt_OnDouble_ReturnsDefaultInteger()
            {
                double number = double.MaxValue;
                Assert.That(() => number.ToOrDefault<int>(), Is.EqualTo(default(int)));
            }

            [Test]
            public void ToOrDefaultNullableInt_OnDouble_ReturnsNull()
            {
                double number = double.MaxValue;
                Assert.That(() => number.ToOrDefault<int?>(), Is.Null);
            }
 
        }
    }
}