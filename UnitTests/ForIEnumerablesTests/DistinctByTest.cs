using System;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class DistinctByTest
        {
            [Test]
            public void DistinctByIsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().DistinctBy(s => s.Length), Throws.Nothing);
            }
        }
    }
}