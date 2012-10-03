using System;
using System.Text;
using CustomExtensions.ForStrings;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;
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
                _lineWriter = new TestLineWriter();
                _stringBuilder = new StringBuilder();
            }

            #endregion

            private TestLineWriter _lineWriter;
            private StringBuilder _stringBuilder;

            private class TestLineWriter : ILineWriter
            {
                public string Ouput { get; private set; }

                #region ILineWriter Members

                public void WriteLine()
                {
                    Ouput = Environment.NewLine;
                }

                public void WriteLine(string value)
                {
                    Ouput = string.Format("{0}{1}", value, Environment.NewLine);
                }

                #endregion
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyStringNoLineWriter_ReturnsStringBuilder()
            {
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_ReturnsStringBuilder()
            {
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_StringBuilderContainsNewLine()
            {
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _stringBuilder.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithEmptyString_WritesNewLine()
            {
                string testText = string.Empty;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _lineWriter.Ouput, Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodStringNoLineWriter_ReturnsStringBuilder()
            {
                string testText = "TEST";
                var output = _stringBuilder.AddLine(testText);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_ReturnsStringBuilder()
            {
                string testText = "TEST";
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_StringBuilderContainsString()
            {
                string testText = "TEST";
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _stringBuilder.ToString(), Is.EqualTo(testText + Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithGoodString_WritesString()
            {
                string testText = "TEST";
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _lineWriter.Ouput, Is.EqualTo(testText + Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_ReturnsStringBuilder()
            {
                string testText = null;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => output, Is.EqualTo(_stringBuilder));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_StringBuilderContainsNewLine()
            {
                string testText = null;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _stringBuilder.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnGoodStringBuilderWithNullString_WritesNewLine()
            {
                string testText = null;
                var output = _stringBuilder.AddLine(testText, _lineWriter);
                Assert.That(() => _lineWriter.Ouput, Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void AddLine_OnNullStringBuilderWithGoodString_ThrowsValidationException()
            {
                string testText = "TEST";
                StringBuilder testBuilder = null;
                Assert.That(() => testBuilder.AddLine(testText, _lineWriter), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}