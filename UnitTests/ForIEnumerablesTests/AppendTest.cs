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
                Assert.DoesNotThrow(() => new BreakingSequence<string>().Append(ToAppend));
            }

            [Test]
            public void GoodInputAppendedToEmptySequence()
            {
                const string toAppend = ToAppend;
                var expected = new[] {toAppend};
                var actual = Enumerable.Empty<string>().Append(toAppend);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }

            [Test]
            public void GoodInputAppendedToGoodSequence()
            {
                const string toAppend = ToAppend;
                var expected = new[] {"10", "20", toAppend};
                var actual = _stringArray.Append(toAppend);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }

            [Test]
            public void GoodInputAppendedToNullSequence()
            {
                const string toAppend = ToAppend;
                string[] sequence = null;
                Assert.Catch<ValidationException>(() => sequence.Append(toAppend));
            }

            [Test]
            public void NullInputAppendedToEmptySequence()
            {
                const string toAppend = null;
                var expected = new[] {toAppend};
                var actual = Enumerable.Empty<string>().Append(toAppend);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }

            [Test]
            public void NullInputAppendedToGoodSequence()
            {
                const string toAppend = null;
                var expected = new[] {"10", "20", toAppend};
                var actual = _stringArray.Append(toAppend);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }

            [Test]
            public void NullInputAppendedToNullSequence()
            {
                const string toAppend = null;
                string[] sequence = null;
                Assert.Catch<ValidationException>(() => sequence.Append(toAppend));
            }
        }
    }
}