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
        public class AppendTest
        {
            private readonly string[] _stringArray = new[] {"10", "20"};
            private const string ToAppend = "30";

            [Test]
            public void AppendIsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().Append(ToAppend), Throws.Nothing);
            }

            [Test]
            public void GoodInputAppendedToEmptySequence()
            {
                var expected = Enumerable.Repeat(ToAppend, 1);
                var actual = Enumerable.Empty<string>().Append(ToAppend);
                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void GoodInputAppendedToGoodSequence()
            {
                var expected = new[] {"10", "20", ToAppend};
                var actual = _stringArray.Append(ToAppend);
                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void GoodInputAppendedToNullSequence()
            {
                Assert.That(() => ((IEnumerable<string>)null).Append(ToAppend), Throws.TypeOf<ValidationException>());
            }

            [Test]
            public void NullInputAppendedToEmptySequence()
            {
                var actual = Enumerable.Empty<string>().Append(null);

                Assert.That(actual, Is.EqualTo(Enumerable.Repeat((string)null, 1)));
            }

            [Test]
            public void NullInputAppendedToGoodSequence()
            {
                var expected = new[] {"10", "20", null};
                var actual = _stringArray.Append(null);
                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void NullInputAppendedToNullSequence()
            {
                Assert.That(() => ((IEnumerable<string>)null).Append(null), Throws.TypeOf<ValidationException>());
            }
        }
    }
}