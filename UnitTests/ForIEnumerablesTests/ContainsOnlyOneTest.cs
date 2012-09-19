using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ContainsOnlyOneTest
        {
            [Test]
            public void InputContainsOnlyOneElment()
            {
                var sequence = Enumerable.Repeat(default(int), 1);
                Assert.That(sequence.ContainsOnlyOne(), Is.True);
            }

            [Test]
            public void InputContainsMoreThanOneElment()
            {
                var sequence = Enumerable.Repeat(default(int), 2);
                Assert.That(sequence.ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void InputContainsLessThanOneElment()
            {
                var sequence = Enumerable.Repeat(default(int), 0);
                Assert.That(sequence.ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void InputEmpty()
            {
                var sequence = Enumerable.Empty<int>();
                Assert.That(sequence.ContainsOnlyOne(), Is.False);
            }

            [Test]
            public void InputNull()
            {
                Assert.That(() => ((IEnumerable<int>)null).ContainsOnlyOne(), Throws.TypeOf<ValidationException>());
            }
        }
    }
}