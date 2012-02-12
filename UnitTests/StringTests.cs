using System;
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
    }
}