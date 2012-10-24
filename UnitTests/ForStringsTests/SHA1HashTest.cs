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
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class SHA1HashTest
        {

            [Test]
            public void SHA1Hash_OnNullString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.SHA1Hash(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void SHA1Hash_OnEmptyString_ThrowsValidationException()
            {
                Assert.That(() => EmptyTestString.SHA1Hash(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }


            [Test]
            public void SHA1Hash_OnStringWithHexEncoding_HashesProperly()
            {
                var testString = "1234";
                var knownHash = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220"; // http://www.fileformat.info/tool/hash.htm?text=1234
                Assert.That(() => testString.SHA1Hash(ExtendString.OutputFormat.Hex), Is.EqualTo(knownHash));
            }


            [Test]
            public void SHA1Hash_OnStringWithBase64Encoding_HashesProperly()
            {
                var testString = "1234";
                var knownHash = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220"; // http://www.fileformat.info/tool/hash.htm?text=1234
                
                Assert.That(() => testString.SHA1Hash(ExtendString.OutputFormat.Base64), Is.EqualTo(knownHash));
            }

        }
    }
}