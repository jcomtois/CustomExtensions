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
                const string wrongKey = TestKey + TestKey;
                var encrypted = TestText.Encrypt(TestKey);
                var decrypted = encrypted.Decrypt(wrongKey);

                Assert.IsNull(decrypted);
                Assert.AreNotEqual(decrypted, TestText);
            }
        }

        [TestFixture]
        public class IsValidUrl
        {
            [Test]
            public void BadUrl()
            {
                var testString = string.Empty;

                Assert.IsFalse(testString.IsValidUrl(), testString);

                testString = null;
                Assert.IsFalse(testString.IsValidUrl(), testString);

                testString = "Bad URL";
                Assert.IsFalse(testString.IsValidUrl(), testString);

                testString = @"www.google.com";

                Assert.IsFalse(testString.IsValidUrl(), testString);
            }

            [Test]
            public void GoodUrl()
            {
                var testString = @"http://www.google.com";

                Assert.IsTrue(testString.IsValidUrl(), testString);

                testString = @"https://www.google.com/doodles/finder/2012/All%20doodles";

                Assert.IsTrue(testString.IsValidUrl(), testString);

                testString = @"mailto:me@example.com";
                Assert.IsTrue(testString.IsValidUrl(), testString);
            }
        }

        [TestFixture]
        public class Left
        {
            private const string TestString = "abc123ABC456Test";

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Left(5);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LeftString()
            {
                const string left = "Left";
                const string testString = left + TestString;
                const string expected = left;
                var actual = testString.Left(left.Length);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LengthZero()
            {
                var expected = string.Empty;
                var actual = TestString.Left(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Left(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerString()
            {
                const string expected = TestString;
                var actual = TestString.Left(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class Right
        {
            private const string TestString = "abc123ABC456Test";

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Right(5);

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
            public void LongerString()
            {
                const string expected = TestString;
                var actual = TestString.Right(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void RightString()
            {
                const string right = "Right";
                const string testString = TestString + right;
                const string expected = right;
                var actual = testString.Right(right.Length);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class Parse
        {
            [Test]
            public void ValidInput()
            {
                var testString = "123";
                
                Assert.AreEqual(testString.Parse<int>(), 123);
                Assert.IsInstanceOf<int>(testString.Parse<int>());

                Assert.AreEqual(testString.Parse<int?>(), 123);
                Assert.IsInstanceOf<int?>(testString.Parse<int?>());

                Assert.AreEqual(testString.Parse<double>(), 123.0);
                Assert.IsInstanceOf<double>(testString.Parse<double>());

                Assert.AreEqual(testString.Parse<double?>(), 123.0);
                Assert.IsInstanceOf<double?>(testString.Parse<double?>());

                Assert.AreEqual(testString.Parse<decimal>(), 123.0m);
                Assert.IsInstanceOf<decimal>(testString.Parse<decimal>());

                Assert.AreEqual(testString.Parse<decimal?>(), 123.0m);
                Assert.IsInstanceOf<decimal?>(testString.Parse<decimal?>());

                testString = "1/23/2012";

                Assert.AreEqual(testString.Parse<DateTime>(), new DateTime(2012,1,23));
                Assert.IsInstanceOf<DateTime>(testString.Parse<DateTime>());
            }
        }

        [TestFixture]
        public class ToNameValueCollection
        {
            private const string TestString = "param1=hello;param2=goodbye;param3=end;";

            [Test]
            public void InValidInput()
            {
                var testString = TestString + "=invalid";
                var actual = testString.ToNameValueCollection(';', '=');

                Assert.AreNotEqual(3, actual.Count);
            }

            [Test]
            public void SameSeperators()
            {
                Assert.Throws<ArgumentException>(() => TestString.ToNameValueCollection(';', ';'));
            }

            [Test]
            public void ValidInput()
            {
                var actual = TestString.ToNameValueCollection(';', '=');

                Assert.AreEqual(3, actual.Count);
                Assert.AreEqual("param1", actual.Keys[0]);
                Assert.AreEqual("param2", actual.Keys[1]);
                Assert.AreEqual("param3", actual.Keys[2]);
                Assert.AreEqual("hello", actual.GetValues("param1").First());
                Assert.AreEqual("goodbye", actual.GetValues("param2").First());
                Assert.AreEqual("end", actual.GetValues("param3").First());
            }
        }

        [TestFixture]
        public class Truncate
        {
            private const string TestString = "abc123";

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
            public void LengthZero()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Truncate(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerThanString()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }

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
        }
    }
}