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
            #region Setup/Teardown

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

            #endregion

            private Validator _validator;

            [Test]
            public void CheckForExceptionsValidatorGoodMoreThanOneException()
            {
                _validator.AddException(new ArgumentNullException());
                _validator.AddException(new InvalidOperationException());
                Assert.That(() => _validator.CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                Assert.That(() => _validator.Exceptions, Is.Not.Empty);
                Assert.That(() => _validator.Exceptions, Has.Count.EqualTo(2));
            }

            [Test]
            public void CheckForExceptionsValidatorGoodNoExceptions()
            {
                Assert.That(() => _validator.CheckForExceptions(), Throws.Nothing);
                Assert.That(() => _validator.CheckForExceptions(), Is.Null);
            }

            [Test]
            public void CheckForExceptionsValidatorGoodOneException()
            {
                _validator.AddException(new ArgumentNullException());
                Assert.That(() => _validator.CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
                Assert.That(() => _validator.Exceptions, Is.Not.Empty);
                Assert.That(() => _validator.Exceptions, Has.Count.EqualTo(1));
            }

            [Test]
            public void CheckForExceptionsValidatorNull()
            {
                Assert.That(() => ((Validator)null).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => ((Validator)null).CheckForExceptions(), Is.Null);
            }

            [Test]
            public void IsNotNegativeFalseParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotNegative(-1, string.Empty).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

            [Test]
            public void IsNotNegativeFalseParameterNameGood()
            {
                Assert.That(() => _validator.IsNotNegative(-1, "negativeOne").Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("negativeOne"));
            }

            [Test]
            public void IsNotNegativeFalseParameterNameNull()
            {
                Assert.That(() => _validator.IsNotNegative(-1, null).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotNegative(1, string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameGood()
            {
                Assert.That(_validator.IsNotNegative(1, "numberOne").Exceptions, Is.Empty);
                Assert.That(_validator.IsNotNegative(0, "numberZero").Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameNull()
            {
                Assert.That(() => _validator.IsNotNegative(1, null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNullFalseParameterNameEmpty()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, string.Empty).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

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
            public void IsNotNullTrueParameterNameEmpty()
            {
                var notNull = new object();
                Assert.That(() => _validator.IsNotNull(notNull, string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
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
        }
    }
}