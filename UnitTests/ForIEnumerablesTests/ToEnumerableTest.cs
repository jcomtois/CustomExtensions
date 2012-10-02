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
            #region Setup/Teardown

            [SetUp]
            public void Setup()
            {
                _theObject = new object();
            }

            #endregion

            private object _theObject;
            private readonly object _nullObject;

            [Test]
            public void ToEnumerable_OnNullObject_CreatesEnumerable()
            {
                Assert.That(() => _nullObject.ToEnumerable(), Is.EquivalentTo(Enumerable.Repeat(_nullObject, 1)));
            }

            [Test]
            public void ToEnumerable_OnObject_CreatesEnumerable()
            {
                Assert.That(() => _theObject.ToEnumerable(), Is.EquivalentTo(Enumerable.Repeat(_theObject, 1)));
            }

            [Test]
            public void ToEnumerable_OnObject_EnumeratingThrowsNothing()
            {
                Assert.That(() => _theObject.ToEnumerable().ToList(), Throws.Nothing);
            }
        }
    }
}