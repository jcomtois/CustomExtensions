using System;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidationExceptionTest
        {
            [Test]
            public void ValidationExceptionIsSerializable()
            {
                Assert.That(new ValidationException(), Is.BinarySerializable);
            }

            [Test]
            public void ValidationExceptionEmptyConstructor()
            {
                Assert.That(() => new ValidationException(), Throws.Nothing);
                Assert.That(() => new ValidationException().InnerException, Is.Null);
            }

            [Test]
            public void ValidationExceptionMessageConstructor()
            {
                Assert.That(() => new ValidationException("Test Message"), Throws.Nothing);
                Assert.That(() => new ValidationException("Test Message").InnerException, Is.Null);
                Assert.That(() => new ValidationException("Test Message").Message, Is.EqualTo("Test Message"));
                Assert.That(() => new ValidationException(null).Message, Is.EqualTo(new ValidationException().Message));
            }

            [Test]
            public void ValidationExceptionMessageExceptionConstructor()
            {
                Assert.That(() => new ValidationException("Test Message", new Exception()), Throws.Nothing);
                Assert.That(() => new ValidationException("Test Message", new Exception()).InnerException, Is.Not.Null);
                Assert.That(() => new ValidationException("Test Message", new ArgumentNullException()).InnerException, Is.TypeOf<ArgumentNullException>());
                Assert.That(() => new ValidationException("Test Message", new Exception("Different Message")).Message, Is.EqualTo("Test Message"));
                Assert.That(() => new ValidationException(null, new Exception("Has message")).Message, Is.EqualTo(new ValidationException().Message));
            }
        }
    }
}