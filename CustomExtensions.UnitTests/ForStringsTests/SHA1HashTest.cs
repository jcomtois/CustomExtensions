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
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.ForStrings;
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class SHA1HashTest
        {
            private static readonly byte[] BytesOfKnownHashForTestString = KnownHashForTestString.ToByteArray();
            private const string TestString = "1234";
            private const string KnownHashForTestString = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220"; // http://www.fileformat.info/tool/hash.htm?text=1234

            [Test]
            public void SHA1Hash_OnAllLatinString_HandlesAllLatinCharacters()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.SHA1Hash(), Throws.Nothing);
            }

            [Test]
            public void SHA1Hash_OnEmptyString_ThrowsValidationException()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.SHA1Hash(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void SHA1Hash_OnNullString_ThrowsValidationException()
            {
                string nullString = null;

                Assert.That(() => nullString.SHA1Hash(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SHA1Hash_OnStringUsingBase64Encoding_HashesProperly()
            {
                var base64String = Convert.ToBase64String(BytesOfKnownHashForTestString);

                Assert.That(() => TestString.SHA1Hash(ExtendString.OutputFormat.Base64), Is.EqualTo(base64String));
            }

            [Test]
            public void SHA1Hash_OnStringUsingDigitEncoding_HashesProperly()
            {
                var expected = BytesOfKnownHashForTestString.Select(b => b.ToString("d3")).FlattenStrings();

                Assert.That(() => TestString.SHA1Hash(ExtendString.OutputFormat.Digit), Is.EqualTo(expected));
            }

            [Test]
            public void SHA1Hash_OnStringUsingHexEncoding_HashesProperly()
            {
                Assert.That(() => TestString.SHA1Hash(), Is.EqualTo(KnownHashForTestString));
            }
        }
    }
}