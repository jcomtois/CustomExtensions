using System;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidatorTest
        {
            [Test]
            public void ValidatorAddException()
            {
                var validator = new Validator();
                Assert.That(() => validator.AddException(new Exception()), Throws.Nothing);
                Assert.That(validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(() => new Validator().Exceptions, Is.Empty);
            }

            [Test]
            public void ValidatorConstructor()
            {
                Assert.That(() => new Validator(), Throws.Nothing);
                Assert.That(() => new Validator().Exceptions, Is.Empty);
            }
        }
    }
}