using System;
using System.Linq;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidationExtensionsTest
        {
            private Validator _validator;

            [SetUp]
            public void SetupValidator()
            {
                _validator = new Validator();
            }

            [TearDown]
            public void TearDownValidator()
            {
                _validator = null;
            }

            
            [Test]
            public void IsNotNullTrueParameterNameGood()
            {
                var notNull = new object();
                Assert.That(_validator.IsNotNull(notNull, "notNull").Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNullTrueParameterNameNull()
            {
                var notNull = new object();
                Assert.That(() => _validator.IsNotNull(notNull, null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            // TODO Pick up here
            [Test]
            public void IsNotNullFalseParameterNameGood()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, "isNull").Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("isNull"));
            }

            [Test]
            public void IsNotNullFalseParameterNameNull()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, null).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }



            [Test]
            public void IsNotNull()
            {
                
                object isNull = null;
                Assert.That(_validator.IsNotNull(isNull, "isNull").Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("isNull"));
            }

            [Test]
            public void IsNotNullParameterNameNull()
            {
                var notNull = new object();
                Assert.That(_validator.IsNotNull(notNull, null).Exceptions, Is.Empty);
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, null), Throws.Nothing);
            }


            
            
            [Test]
            public void ValidatorAddException()
            {
                var validator = new Validator();
                Assert.That(() => validator.AddException(new Exception()), Throws.Nothing);
                Assert.That(validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(() => new Validator().Exceptions, Is.Empty);
            }

        }
    }
}