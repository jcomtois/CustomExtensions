#region License and Terms

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
        public class EncryptTest
        {
            [Test]
            public void Encrypt_OnEmptyString_ThrowsValidationError()
            {
                var emptyString = string.Empty;
                var fixture = new LatinMultipleMockingFixture();
                var encryptor = fixture.CreateAnonymous<IEncrypt>();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => emptyString.Encrypt(stringValue, encryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnNullString_ThrowsValidationError()
            {
                string nullString = null;
                var fixture = new LatinMultipleMockingFixture();
                var encryptor = fixture.CreateAnonymous<IEncrypt>();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => nullString.Encrypt(stringValue, encryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Encrypt_OnString_EncryptIsCalled()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IEncrypt encrypt = mockEncryptor.Object;
                stringValue.Encrypt(stringValue, encrypt);

                mockEncryptor.Verify(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            }

            [Test]
            public void Encrypt_OnString_KeyIsCaseSensitive()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var upperKey = stringValue.ToUpperInvariant();
                var lowerKey = stringValue.ToLowerInvariant();
                var encryptedWithUpper = stringValue.Encrypt(upperKey);
                var encryptedWithLower = stringValue.Encrypt(lowerKey);

                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnString_OutputIsInCorrectFormat()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var output = stringValue.Encrypt(stringValue);
                Assert.That(() => Convert.FromBase64String(output), Throws.Nothing);
            }

            [Test]
            public void Encrypt_OnString_OutputMutatesOnSubsequentCallsWithSameInput()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var lastTry = stringValue.Encrypt(stringValue);
                string currentTry = null;
                for (var i = 0; i < 10; i++)
                {
                    currentTry = stringValue.Encrypt(stringValue);
                    if (lastTry != currentTry)
                    {
                        break;
                    }
                }
                Assert.That(() => lastTry, Is.Not.EqualTo(currentTry));
            }

            [Test]
            public void Encrypt_OnString_SourceIsCaseSensitive()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var upperSource = stringValue.ToUpperInvariant();
                var lowerSource = stringValue.ToLowerInvariant();
                var encryptedWithUpper = upperSource.Encrypt(stringValue);
                var encryptedWithLower = lowerSource.Encrypt(stringValue);

                Assert.That(() => encryptedWithUpper, Is.Not.EqualTo(encryptedWithLower));
            }

            [Test]
            public void Encrypt_OnString_StringIsEncrypted()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var output = stringValue.Encrypt(stringValue);

                Assert.That(() => output, Is.Not.EqualTo(stringValue));
            }

            [Test]
            public void Encrypt_OnString_WithEmptyKey_ThrowsValidationError()
            {
                var emptyString = string.Empty;
                var fixture = new LatinMultipleMockingFixture();
                var encryptor = fixture.CreateAnonymous<IEncrypt>();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.Encrypt(emptyString, encryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Encrypt_OnString_WithKey_ChecksMinimumSize()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockEncryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                IEncrypt encryptor = mockEncryptor.Object;
                stringValue.Encrypt(stringValue, encryptor);

                mockEncryptor.VerifyGet(m => m.MinimumPasswordLength, Times.AtLeastOnce());
            }

            [Test]
            public void Encrypt_OnString_WithNullKey_ThrowsValidationError()
            {
                string nullString = null;
                var fixture = new LatinMultipleMockingFixture();
                var encryptor = fixture.CreateAnonymous<IEncrypt>();
                var stringValue = fixture.CreateAnonymous<string>();

                Assert.That(() => stringValue.Encrypt(nullString, encryptor), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Encrypt_OnString_WithShortKey_ThrowsValidationError()
            {
                var mockEncryptor = new Mock<IEncrypt>();
                mockEncryptor.Setup(m => m.EncryptAES(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());
                mockEncryptor.Setup(m => m.MinimumPasswordLength).Returns(12);
                var fixture = new LatinStringFixture();
                var stringValue = fixture.CreateAnonymous<string>();
                var shortKey = stringValue.Substring(0, 3);
                IEncrypt encrypt = mockEncryptor.Object;

                Assert.That(() => stringValue.Encrypt(shortKey, encrypt), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }
        }
    }
}