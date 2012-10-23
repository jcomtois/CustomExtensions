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
        public class LeftTest
        {
            [Test]
            public void Left_OnEmptyString_ReturnsEmptyString()
            {
                Assert.That(() => EmptyTestString.Left(5), Is.Empty);
            }

            [Test]
            public void Left_OnGoodStringWithNegativeLength_ThrowsValidationExceptions()
            {
                Assert.That(() => TestStringLatin.Left(-5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void Left_OnNullStringWithNegativeLength_ThrowsValidationExceptions()
            {
                Assert.That(() => NullTestString.Left(-5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Left_OnNullString_ThrowsValidationException()
            {
                Assert.That(() => NullTestString.Left(5), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void Left_OnValidStringLengthEqualToStringLength_ReturnsCorrectSubstring()
            {
                var testlength = TestStringLatin.Length;
                Assert.That(() => TestStringLatin.Left(testlength), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Left_OnValidStringLengthGreaterThanStringLength_ReturnsCorrectSubstring()
            {
                var testlength = TestStringLatin.Length + 1;
                Assert.That(() => TestStringLatin.Left(testlength), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Left_OnValidStringLengthLessThanStringLength_ReturnsCorrectSubstring()
            {
                var testlength = TestStringLatin.Length - 1;
                var expected = TestStringLatin.Substring(0, testlength);
                Assert.That(() => TestStringLatin.Left(testlength), Is.EqualTo(expected));
            }
        }
    }
}