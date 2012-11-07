#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using CustomExtensions.ForStrings;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class EncryptTest : EncryptionTestBase
        {
            [Test]
            public void Encrypt_OnEmptyString_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = EmptyTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnGoodStringWithEmptyKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = TestStringLatin;
                string testKey = EmptyKey;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnGoodStringWithGoodKey_ChecksMinimumSize()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockEncryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                testString.Encrypt(testKey, mockEncryptor.Object);
                mockEncryptor.VerifyGet(m => m.MinimumPasswordLength, Times.AtLeastOnce());
            }

            [Test]
            public void Encrypt_OnGoodStringWithNullKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = TestStringLatin;
                string testKey = NullKey;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Encrypt_OnGoodStringWithShortKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockEncryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                string testString = TestStringLatin;
                string testKey = ShortKey;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Encrypt_OnGoodString_EncryptIsCalled()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var output = testString.Encrypt(testKey, mockEncryptor.Object);
                mockEncryptor.Verify(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            }

            [Test]
            public void Encrypt_OnGoodString_KeyIsCaseSensitive()
            {
                string testString = TestStringLatin;
                string upperKey = ValidLengthKey;
                string lowerKey = upperKey.ToLowerInvariant();
                var encryptedWithUpper = testString.Encrypt(upperKey);
                var encryptedWithLower = testString.Encrypt(lowerKey);
                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputDecryptionReturnsNullWithWrongKey()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var encrypted = testString.Encrypt(testKey);
                string wrongKey = testKey + testKey;
                var decrypted = encrypted.Decrypt(wrongKey);
                Assert.That(() => decrypted, Is.Null);
            }

            [Test]
            public void Encrypt_OnGoodString_OutputDecryptsImproperlyWithWrongKey()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var encrypted = testString.Encrypt(testKey);
                string wrongKey = testKey + testKey;
                var decrypted = encrypted.Decrypt(wrongKey);
                Assert.That(() => decrypted, Is.Not.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputDecryptsProperlyWithGoodKey()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var encrypted = testString.Encrypt(testKey);
                var decrypted = encrypted.Decrypt(testKey);
                Assert.That(() => decrypted, Is.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnGoodString_OutputIsInCorrectFormat()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var output = testString.Encrypt(testKey);
                Assert.That(() => Convert.FromBase64String(output), Throws.Nothing);
            }

            [Test]
            public void Encrypt_OnGoodString_SourceIsCaseSensitive()
            {
                string testStringUpper = TestStringLatin;
                string testStringLower = testStringUpper.ToLowerInvariant();
                string testKey = ValidLengthKey;
                var encryptedWithUpper = testStringUpper.Encrypt(testKey);
                var encryptedWithLower = testStringLower.Encrypt(testKey);
                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnGoodString_StringIsEncrypted()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var output = testString.Encrypt(testKey);
                Assert.That(() => output, Is.Not.EqualTo(testString));
            }

            [Test]
            public void Encrypt_OnNullString_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = NullTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Encrypt(testKey, mockEncryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Encrypt_OnRepeatedGoodString_OutputMutatesOnSubsequentCalls()
            {
                string testString = TestStringLatin;
                string testKey = ValidLengthKey;
                var lastTry = testString.Encrypt(testKey);
                string currentTry = null;
                for (var i = 0; i < 10; i++)
                {
                    currentTry = testString.Encrypt(testKey);
                    if (lastTry != currentTry)
                    {
                        break;
                    }
                }
                Assert.That(() => lastTry, Is.Not.EqualTo(currentTry));
            }
        }
    }
}