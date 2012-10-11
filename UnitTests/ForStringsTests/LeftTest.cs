using System;
using CustomExtensions.ForStrings;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class Left
        {
            [Test]
            public void Left_OnEmptyString_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Left(5), Is.Empty);
            }

            [Test]
            public void Left_OnGoodStringExactLength_ReturnsWholeString()
            {
                var length = TestStringLatin.Length;
                Assert.That(() => TestStringLatin.Left(length), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Left_OnGoodStringLengthLonger_ReturnsWholeString()
            {
                var length = TestStringLatin.Length + 1;
                Assert.That(() => TestStringLatin.Left(length), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Left_OnGoodStringWithNegativeLength_ThrowsValidationException()
            {
                Assert.That(() => TestStringLatin.Left(-5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Left_OnGoodStringWithZeroLength_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Left(0), Is.Empty);
            }

            [Test]
            public void Left_OnGoodString_ReturnsProperSubString()
            {
                var expected = TestStringLatin.Substring(0, 3);
                Assert.That(() => TestStringLatin.Left(3), Is.EqualTo(expected));
            }

            [Test]
            public void Left_OnNullStringWithNegativeLength_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Left(-5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Left_OnNullString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Left(5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}