using System;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ValidationsTests
{
    public partial class ValidataionTests
    {
        [TestFixture]
        public class ValidateTest
        {
            [Test]
            public void ValidateBegin()
            {
                Assert.That(Validate.Begin(), Is.Null);
            }

            
        }
    }
}