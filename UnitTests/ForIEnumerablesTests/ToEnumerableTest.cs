using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ToEnumerableTest
        {
            [Test]
            public void ElementGood()
            {
                Assert.That(() => new object().ToEnumerable(), Throws.Nothing);
                Assert.That(() => new object().ToEnumerable().ToList(), Throws.Nothing);
                Assert.That(() => ((object)null).ToEnumerable(), Throws.Nothing);
                Assert.That(() => new object().ToEnumerable(), Is.AssignableTo<IEnumerable<object>>());
            }
        }
    }
}