﻿#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class DecryptTest
        {
            [Test]
            public void Decrypt_OnBadString_WithGoodKey_DoesNotDecrypt()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var validKey = fixture.Create<string>();

                Assert.That(() => stringValue.Decrypt(validKey), Is.Not.EqualTo(stringValue));
            }

            [Test]
            public void Decrypt_OnBadString_WithGoodKey_ReturnsNull()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var validKey = fixture.Create<string>();

                Assert.That(() => stringValue.Decrypt(validKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnEmptyString_ThrowsValidationError()
            {
                var emptyString = string.Empty;
                var fixture = new LatinMultipleMockingFixture();
                var decryptor = fixture.Create<IDecrypt>();
                var stringValue = fixture.Create<string>();

                Assert.That(() => emptyString.Decrypt(stringValue, decryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Decrypt_OnEncryptedString_KeyIsCaseSensitive()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var upperKey = stringValue.ToUpperInvariant();
                var lowerKey = stringValue.ToLowerInvariant();
                var encryptedWithUpper = stringValue.Encrypt(upperKey);

                Assert.That(() => encryptedWithUpper.Decrypt(lowerKey), Is.Not.EqualTo(stringValue));
            }

            [Test]
            public void Decrypt_OnEncryptedString_WithGoodKey_Decrypts()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var encryptionKey = fixture.Create<string>();
                var encryptedString = stringValue.Encrypt(encryptionKey);

                Assert.That(() => encryptedString.Decrypt(encryptionKey), Is.EqualTo(stringValue));
            }

            [Test]
            public void Decrypt_OnEncryptedString_WithWrongKey_DoesNotDecrypt()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var encryptionKey = fixture.Create<string>();
                var encryptedString = stringValue.Encrypt(encryptionKey);
                var wrongKey = encryptionKey + encryptionKey;

                Assert.That(() => encryptedString.Decrypt(wrongKey), Is.Not.EqualTo(stringValue));
            }

            [Test]
            public void Decrypt_OnEncryptedString_WithWrongKey_ReturnsNull()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var encryptionKey = fixture.Create<string>();
                var encryptedString = stringValue.Encrypt(encryptionKey);
                var wrongKey = encryptionKey + encryptionKey;

                Assert.That(() => encryptedString.Decrypt(wrongKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnNullString_ThrowsValidationError()
            {
                string nullString = null;
                var fixture = new LatinMultipleMockingFixture();
                var decryptor = fixture.Create<IDecrypt>();
                var stringValue = fixture.Create<string>();

                Assert.That(() => nullString.Decrypt(stringValue, decryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Decrypt_OnShortString_WithGoodKey_ReturnsNull()
            {
                string testString = Convert.ToBase64String(Encoding.UTF8.GetBytes("b"));
                var fixture = new LatinStringFixture();
                var encryptionKey = fixture.Create<string>();

                Assert.That(() => testString.Decrypt(encryptionKey), Is.Null);
            }

            [Test]
            public void Decrypt_OnString_DecryptIsCalled()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.Setup(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                IDecrypt decryptor = mockDecryptor.Object;
                stringValue.Decrypt(stringValue, decryptor);

                mockDecryptor.Verify(m => m.DecryptAES(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            }

            [Test]
            public void Decrypt_OnString_WithEmptyKey_ThrowsValidationError()
            {
                var emptyString = string.Empty;
                var fixture = new LatinMultipleMockingFixture();
                var decryptor = fixture.Create<IDecrypt>();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.Decrypt(emptyString, decryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Decrypt_OnString_WithGoodKey_ChecksMinimumSize()
            {
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.SetupGet(m => m.MinimumPasswordLength).Returns(12);
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                IDecrypt decryptor = mockDecryptor.Object;
                stringValue.Decrypt(stringValue, decryptor);

                mockDecryptor.VerifyGet(m => m.MinimumPasswordLength, Times.AtLeastOnce());
            }

            [Test]
            public void Decrypt_OnString_WithNullKey_ThrowsValidationError()
            {
                string nullString = null;
                var fixture = new LatinMultipleMockingFixture();
                var decryptor = fixture.Create<IDecrypt>();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.Decrypt(nullString, decryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Decrypt_OnString_WithShortKey_ThrowsValidationError()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var shortKey = stringValue.Substring(0, 3);
                var mockDecryptor = new Mock<IDecrypt>();
                mockDecryptor.SetupGet(m => m.MinimumPasswordLength).Returns(12);
                var decryptor = mockDecryptor.Object;

                Assert.That(() => stringValue.Decrypt(shortKey, decryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Decrypt_OnTamperedString_WithGoodKey_DoesNotDecrypt()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();
                var encryptionKey = fixture.Create<string>();
                var encryptedString = stringValue.Encrypt(encryptionKey);
                var bytes = Convert.FromBase64String(encryptedString);
                bytes[0]++;
                string testString = Convert.ToBase64String(bytes);

                Assert.That(() => testString.Decrypt(encryptionKey), Is.Null);
            }
        }
    }
}