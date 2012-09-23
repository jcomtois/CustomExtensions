using System;
using System.Linq;
using CustomExtensions.Validation;
using NUnit.Framework;
using UnitTests.ForIEnumerablesTests;

namespace UnitTests.ValidationsTests
{
    public partial class ValidataionTests
    {
        [TestFixture]
        public class MultiExceptionTest
        {
            [Test]
            public void MultiExceptionEmptyConstructor()
            {
                Assert.That(() => new MultiException(), Throws.Nothing);
                Assert.That(() => new MultiException().InnerException, Is.Null);
                Assert.That(() => new MultiException().InnerExceptions, Is.Empty);
            }

            [Test]
            public void MultiExceptionExceptionsConstructor()
            {
                var exceptionList = new[] {new ArgumentNullException(), new Exception(), new InvalidCastException()};

                Assert.That(() => new MultiException(exceptionList), Throws.Nothing);
                Assert.That(() => new MultiException(exceptionList).InnerException, Is.Not.Null);
                Assert.That(() => new MultiException(exceptionList).InnerExceptions, Is.Not.Empty);
                Assert.That(() => new MultiException(NullSequence.Of<Exception>()).InnerExceptions, Is.Not.Empty);
                Assert.That(() => new MultiException(NullSequence.Of<Exception>()).InnerExceptions.Single(), Is.TypeOf<ArgumentNullException>());
                Assert.That(() => new MultiException(exceptionList).InnerException, Is.TypeOf<ArgumentNullException>());
                Assert.That(() => new MultiException(exceptionList).Message, Is.EqualTo(new MultiException().Message));
            }

            [Test]
            public void MultiExceptionMessageConstructor()
            {
                Assert.That(() => new MultiException("Test Message"), Throws.Nothing);
                Assert.That(() => new MultiException("Test Message").InnerException, Is.Null);
                Assert.That(() => new MultiException("Test Message").InnerExceptions, Is.Empty);
                Assert.That(() => new MultiException("Test Message").Message, Is.EqualTo("Test Message"));
                Assert.That(() => new MultiException((string)null).Message, Is.EqualTo(new MultiException().Message));
            }

            [Test]
            public void MultiExceptionMessageExceptionConstructor()
            {
                Assert.That(() => new MultiException("Test Message", new Exception()), Throws.Nothing);
                Assert.That(() => new MultiException("Test Message", new Exception()).InnerException, Is.Not.Null);
                Assert.That(() => new MultiException("Test Message", new Exception()).InnerExceptions, Is.Not.Empty);
                Assert.That(() => new MultiException("Test Message", new ArgumentNullException()).InnerException, Is.TypeOf<ArgumentNullException>());
                Assert.That(() => new MultiException("Test Message", new Exception("Different Message")).Message, Is.EqualTo("Test Message"));
                Assert.That(() => new MultiException(null, new Exception("Has message")).Message, Is.EqualTo(new MultiException().Message));
            }

            [Test]
            public void MultiExceptionToString()
            {
                Assert.That(new MultiException().ToString(), Is.Empty);
                var exceptionList = new Exception[] {new ArgumentNullException()};
                Assert.That(new MultiException(exceptionList).ToString(), Is.Not.Empty);
                Assert.That(new MultiException(exceptionList).ToString(), Is.EqualTo(new ArgumentNullException().Message));
                exceptionList = new Exception[] {new ArgumentNullException(), new InvalidOperationException()};
                var message = string.Format("{0}{1}{2}", new ArgumentNullException().Message, Environment.NewLine, new InvalidOperationException().Message);
                Assert.That(new MultiException(exceptionList).ToString(), Is.EquivalentTo(message));
            }
        }
    }
}