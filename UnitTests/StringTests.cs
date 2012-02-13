using System;
using System.Linq;
using CustomExtensions.Strings;
using NUnit.Framework;

namespace UnitTests
{
    public class StringTests
    {
        [TestFixture]
        public class EncryptAndDecrypt
        {
            private const string TestText = "The quick brown fox jumped over the lazy dog.  1234567890";
            private const string TestKey = "TESTKEY";

            [Test]
            public void NullKeyEmptyKey()
            {
                Assert.Throws<ArgumentException>(() => TestText.Encrypt(string.Empty));
                Assert.Throws<ArgumentException>(() => TestText.Encrypt(null));
                Assert.Throws<ArgumentException>(() => TestText.Decrypt(string.Empty));
                Assert.Throws<ArgumentException>(() => TestText.Decrypt(null));
            }

            [Test]
            public void NullTextEmptyText()
            {
                const string nullString = null;
                Assert.Throws<ArgumentException>(() => string.Empty.Encrypt(TestKey));
                Assert.Throws<ArgumentException>(() => nullString.Encrypt(TestKey));
                Assert.Throws<ArgumentException>(() => string.Empty.Decrypt(TestKey));
                Assert.Throws<ArgumentException>(() => nullString.Decrypt(TestKey));
            }

            [Test]
            public void StringEncryptAndDecrypt()
            {
                var encrypted = TestText.Encrypt(TestKey);
                var decrypted = encrypted.Decrypt(TestKey);

                Assert.AreEqual(decrypted, TestText);
            }

            [Test]
            public void WrongKey()
            {
                const string wrongKey = TestKey+TestKey;
                var encrypted = TestText.Encrypt(TestKey);
                var decrypted = encrypted.Decrypt(wrongKey);

                Assert.IsNull(decrypted);
                Assert.AreNotEqual(decrypted, TestText);
            }
        }

        [TestFixture]
        public class Right
        {
            private const string TestString = "abc123ABC456Test";

            [Test]
            public void RightString()
            {
                const string right = "Right";
                const string testString = TestString + right;
                const string expected = right;
                var actual = testString.Right(right.Length);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LengthZero()
            {
                var expected = string.Empty;
                var actual = TestString.Right(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Right(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Right(5);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerString()
            {
                const string expected = TestString;
                var actual = TestString.Right(TestString.Length*2);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class Truncate
        {
            private const string TestString = "abc123";

            [Test]
            public void TruncateString()
            {
                var expected = TestString;
                var actual = TestString.Truncate(1);

                Assert.AreEqual(expected, actual);

                expected = TestString;
                actual = TestString.Truncate(2);

                Assert.AreEqual(expected, actual);

                expected = TestString;
                actual = TestString.Truncate(3);

                Assert.AreEqual(expected, actual);

                expected = "a...";
                actual = TestString.Truncate(4);
                Assert.AreEqual(expected, actual);

                expected = "ab...";
                actual = TestString.Truncate(5);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LengthZero()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Truncate(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Truncate(5);

                Assert.AreEqual(expected, actual);

                expected = null;
                actual = expected.Truncate(5);

                Assert.IsNull(actual);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerThanString()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}