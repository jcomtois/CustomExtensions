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
using System.Text;
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
        public class DecryptTest : EncryptionTestBase
        {
            private static readonly string ValidEncryptedTestString = TestStringLatin.Encrypt(ValidLengthKey);
            private const string BadEncryptedTestString = "$%^#&@*(*%(#&@^!*@#";

            [Test]
            public void Decrypt_OnBadStringWithGoodKey_DoesNotDecrypt()
            {
                string testString = BadEncryptedTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Not.EqualTo(TestStringLatin));
            }

            [Test]
            public void Decrypt_OnBadStringWithGoodKey_ReturnsNull()
            {
                string testString = BadEncryptedTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnEmptyString_ThrowsValidationError()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = EmptyTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey, mockDecryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Decrypt_OnGoodStringWithEmptyKey_ThrowsValidationError()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = ValidEncryptedTestString;
                string testKey = EmptyKey;
                Assert.That(() => testString.Decrypt(testKey, mockDecryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Decrypt_OnGoodStringWithGoodKey_ChecksMinimumSize()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockDecryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                string testString = ValidEncryptedTestString;
                string testKey = ValidLengthKey;
                var output = testString.Decrypt(testKey, mockDecryptor.Object);
                mockDecryptor.VerifyGet(m => m.MinimumPasswordLength, Times.AtLeastOnce());
            }

            [Test]
            public void Decrypt_OnGoodStringWithGoodKey_Decrypts()
            {
                string testString = ValidEncryptedTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Decrypt_OnGoodStringWithNullKey_ThrowsValidationError()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = ValidEncryptedTestString;
                string testKey = NullKey;
                Assert.That(() => testString.Decrypt(testKey, mockDecryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Decrypt_OnGoodStringWithShortKey_ThrowsValidationError()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockDecryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                string testString = ValidEncryptedTestString;
                string testKey = ShortKey;
                Assert.That(() => testString.Decrypt(testKey, mockDecryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Decrypt_OnGoodStringWithWrongKey_DoesNotDecrypt()
            {
                string testString = ValidEncryptedTestString;
                string testKey = ValidLengthKey + ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Not.EqualTo(TestStringLatin));
            }

            [Test]
            public void Decrypt_OnGoodStringWithWrongKey_ReturnsNull()
            {
                string testString = ValidEncryptedTestString;
                string testKey = ValidLengthKey + ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnGoodString_DecryptIsCalled()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = ValidEncryptedTestString;
                string testKey = ValidLengthKey;
                var output = testString.Decrypt(testKey, mockDecryptor.Object);
                mockDecryptor.Verify(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            }

            [Test]
            public void Decrypt_OnNullString_ThrowsValidationError()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                string testString = NullTestString;
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey, mockDecryptor.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Decrypt_OnShortStringWithGoodKey_ReturnsNull()
            {
                string testString = Convert.ToBase64String(Encoding.UTF8.GetBytes("b"));
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnTamperedStringWithGoodKey_DoesNotDecrypt()
            {
                var bytes = Convert.FromBase64String(ValidEncryptedTestString);
                bytes[0]++;
                string testString = Convert.ToBase64String(bytes);
                string testKey = ValidLengthKey;
                Assert.That(() => testString.Decrypt(testKey), Is.Null);
            }
        }
    }
}