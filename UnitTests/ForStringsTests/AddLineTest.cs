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
        public class AddLineTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _stringBuilder = new StringBuilder();
            }

            #endregion

            private StringBuilder _stringBuilder;

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyStringNoLineWriter_ReturnsStringBuilder()
            {
                string testText = EmptyTestString;
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_CallsWriteLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = EmptyTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = EmptyTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_StringBuilderContainsNewLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = EmptyTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodStringNoLineWriter_ReturnsStringBuilder()
            {
                string testText = TestStringLatin;
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_CallsWriteLineWithString()
            {
                string testText = TestStringLatin;
                var mockLineWriter = new Mock<ILineWriter>();
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);

                mockLineWriter.Verify(m => m.WriteLine(testText), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                mockLineWriter.Setup(m => m.WriteLine(It.IsAny<string>()));
                string testText = TestStringLatin;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_StringBuilderContainsStringAndNewLine()
            {
                string testText = TestStringLatin;
                var mockLineWriter = new Mock<ILineWriter>();
                mockLineWriter.Setup(m => m.WriteLine(testText));
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(testText + Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_CallsWriteLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = NullTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = NullTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_StringBuilderContainsNewLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = NullTestString;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnNullStringBuilderWithGoodString_ThrowsValidationException()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = TestStringLatin;
                StringBuilder testBuilder = null;
                Assert.That(() => testBuilder.AddLine(testText, mockLineWriter.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}