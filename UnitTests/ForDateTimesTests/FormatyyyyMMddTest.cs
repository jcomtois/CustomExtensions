using System;
using CustomExtensions.ForDateTime;
using NUnit.Framework;

namespace UnitTests.ForDateTimesTests
{
    [TestFixture]
    public class FormatyyyyMMddTest
    {
        [Test]
        public void FormatyyyMMddCorrectOutput()
        {
            Assert.That(new DateTime(2000, 1, 1).FormatyyyyMMdd(), Is.EqualTo("20000101"));
            Assert.That(new DateTime(1999, 12, 31).FormatyyyyMMdd(), Is.EqualTo("19991231"));
        }
    }
}