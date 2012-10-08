using System;
using System.Linq;
using CustomExtensions.ForStrings;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class EncryptTest
        {
            [Test]
            public void Encrypt_OnEmptyString_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.Encrypt(It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = string.Empty;
                string testKey = "Key";
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnGoodStringWithEmptyKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.Encrypt(It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = "Test";
                string testKey = string.Empty;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnGoodStringWithNullKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.Encrypt(It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = "Test";
                string testKey = null;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Encrypt_OnGoodString_EncryptIsCalled()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.Encrypt(It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = "Test";
                string testKey = "Key";
                var output = testString.Encrypt(testKey, mockEncryptor.Object);
                mockEncryptor.Verify(m => m.Encrypt(It.IsAny<string>()), Times.Once());
            }

            [Test]
            public void Encrypt_OnGoodString_KeyIsCaseSensitive()
            {
                string testString = "Test String";
                string upperKey = "KEY";
                string lowerKey = upperKey.ToLowerInvariant();
                var encryptedWithUpper = testString.Encrypt(upperKey);
                var encryptedWithLower = testString.Encrypt(lowerKey);
                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputDecryptsImproperlyWithWrongKey()
            {
                string testString = "The quick brown fox jumped over the lazy dog.  1234567890 !@#$%^&*()_+~~~~~~\\n\n\n";
                string testKey = "YABBAdabb@d0o";
                var encrypted = testString.Encrypt(testKey);
                string wrongKey = "Oooops";
                var decrypted = encrypted.Decrypt(wrongKey);
                Assert.That(() => decrypted, Is.Not.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputDecryptsProperlyWithGoodKey()
            {
                string testString = "The quick brown fox jumped over the lazy dog.  1234567890 !@#$%^&*()_+~~~~~~\\n\n\n";
                string testKey = "YABBAdabb@d0o";
                var encrypted = testString.Encrypt(testKey);
                var decrypted = encrypted.Decrypt(testKey);
                Assert.That(() => decrypted, Is.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputIsInCorrectFormat()
            {
                var validCharacters = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', '-'};
                string testString = "Test";
                string testKey = "Key";
                var output = testString.Encrypt(testKey);
                var difference = output.ToUpperInvariant().Except(validCharacters);
                Assert.That(() => difference, Is.Empty);
            }

            [Test]
            public void Encrypt_OnGoodString_SourceIsCaseSensitive()
            {
                string testStringUpper = "TEST STRING";
                string testStringLower = testStringUpper.ToLowerInvariant();
                string testKey = "KEY";
                var encryptedWithUpper = testStringUpper.Encrypt(testKey);
                var encryptedWithLower = testStringLower.Encrypt(testKey);
                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnGoodString_StringIsEncrypted()
            {
                string testString = "Test";
                string testKey = "Key";
                var output = testString.Encrypt(testKey);
                Assert.That(() => output, Is.Not.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnNullString_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.Encrypt(It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = null;
                string testKey = "Key";
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}