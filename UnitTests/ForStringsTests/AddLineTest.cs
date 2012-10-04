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
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_CallsWriteLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_StringBuilderContainsNewLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodStringNoLineWriter_ReturnsStringBuilder()
            {
                string testText = "TEST";
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_CallsWriteLineWithString()
            {
                string testText = "TEST";
                var mockLineWriter = new Mock<ILineWriter>();
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);

                mockLineWriter.Verify(m => m.WriteLine(testText), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                mockLineWriter.Setup(m => m.WriteLine(It.IsAny<string>()));
                var output = _stringBuilder.AddLine(string.Empty, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_StringBuilderContainsStringAndNewLine()
            {
                string testText = "TEST";
                var mockLineWriter = new Mock<ILineWriter>();
                mockLineWriter.Setup(m => m.WriteLine(testText));
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(testText + Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_CallsWriteLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = null;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                mockLineWriter.Verify(m => m.WriteLine(), Times.Once());
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_ReturnsStringBuilder()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = null;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_StringBuilderContainsNewLine()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = null;
                var output = _stringBuilder.AddLine(testText, mockLineWriter.Object);
                Assert.That(() => output.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnNullStringBuilderWithGoodString_ThrowsValidationException()
            {
                var mockLineWriter = new Mock<ILineWriter>();
                string testText = "TEST";
                StringBuilder testBuilder = null;
                Assert.That(() => testBuilder.AddLine(testText, mockLineWriter.Object),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}