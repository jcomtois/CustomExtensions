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
        public class AddLineTest
        {
            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_WithLineWriter_ReturnsStringBuilder()
            {
                var fixture = new LatinStringFixture();
                var testString = fixture.CreateAnonymous<string>();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(testString, lineWriter);

                Assert.That(() => actual, Is.EqualTo(stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithEmptyString_NoLineWriter_ReturnsStringBuilder()
            {
                var fixture = new BaseFixture();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var emptyString = string.Empty;

                var actual = stringBuilder.AddLine(emptyString);

                Assert.That(() => actual, Is.EqualTo(stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithEmptyString_WithLineWriter_CallsWriteLine()
            {
                var mockLineWriter = new Mock<ILineWriter>(MockBehavior.Strict);
                var emptyString = string.Empty;
                var fixture = new BaseFixture();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                mockLineWriter.Setup(m => m.WriteLine());
                ILineWriter lineWriter = mockLineWriter.Object;
                stringBuilder.AddLine(emptyString, lineWriter);

                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithEmptyString_WithLineWriter_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                var emptyString = string.Empty;
                var fixture = new BaseFixture();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(emptyString, lineWriter);

                Assert.That(() => actual, Is.EqualTo(stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithEmptyString_WithLineWriter_StringBuilderContainsNewLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                var emptyString = string.Empty;
                var stringBuilder = new StringBuilder();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(emptyString, lineWriter).ToString();

                Assert.That(() => actual, Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithGoodString_NoLineWriter_ReturnsStringBuilder()
            {
                var fixture = new LatinStringFixture();
                var testString = fixture.CreateAnonymous<string>();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var actual = stringBuilder.AddLine(testString);

                Assert.That(() => actual, Is.EqualTo(stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithGoodString_WithLineWriter_CallsWriteLineWithString()
            {
                var fixture = new LatinStringFixture();
                var testString = fixture.CreateAnonymous<string>();
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                stringBuilder.AddLine(testString, lineWriter);

                mockLineWriter.Verify(m => m.WriteLine(testString), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithGoodString_WithLineWriter_StringBuilderContainsStringAndNewLine()
            {
                var fixture = new LatinStringFixture();
                var testString = fixture.CreateAnonymous<string>();
                var stringBuilder = new StringBuilder();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(testString, lineWriter);

                Assert.That(() => actual.ToString(), Is.EqualTo(testString + Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithNullString_WithLineWriter_CallsWriteLine()
            {
                var fixture = new BaseFixture();
                string nullString = null;
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                stringBuilder.AddLine(nullString, lineWriter);

                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithNullString_WithLineWriter_ReturnsStringBuilder()
            {
                var fixture = new BaseFixture();
                string nullString = null;
                var stringBuilder = fixture.CreateAnonymous<StringBuilder>();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(nullString, lineWriter);

                Assert.That(() => actual, Is.EqualTo(stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilder_WithNullString_WithLineWriter_StringBuilderContainsNewLine()
            {
                string nullString = null;
                var stringBuilder = new StringBuilder();
                var mockLineWriter = new Mock<ILineWriter>();
                ILineWriter lineWriter = mockLineWriter.Object;
                var actual = stringBuilder.AddLine(nullString, lineWriter).ToString();

                Assert.That(() => actual, Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnNullStringBuilder_WithGoodString_WithLineWriter_ThrowsValidationException()
            {
                var fixture = new LatinMultipleMockingFixture();
                var testString = fixture.CreateAnonymous<string>();
                ILineWriter lineWriter = fixture.CreateAnonymous<ILineWriter>();
                StringBuilder testBuilder = null;
                Assert.That(() => testBuilder.AddLine(testString, lineWriter), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}