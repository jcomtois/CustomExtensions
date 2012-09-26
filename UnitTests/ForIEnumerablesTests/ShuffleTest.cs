using System;
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
        public class ShuffleTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _random = new Random(seed);
            }

            #endregion

            private Random _random;
            private const int seed = 1;
            private readonly IList<int> _first10RandomIntegers;

            public ShuffleTest()
            {
                var rand = new Random(seed);
                _first10RandomIntegers = Enumerable.Range(0, 10).Select(i => rand.Next(10)).ToList();
            }

            [Test]
            public void SequenceEmpty()
            {
                Assert.That(() => Enumerable.Empty<int>().Shuffle(_random), Throws.Nothing);
                Assert.That(() => Enumerable.Empty<int>().Shuffle(_random), Is.Empty);
            }

            [Test]
            public void SequenceEmptyRandomNull()
            {
                Assert.That(() => Enumerable.Empty<int>().Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodRandomGood()
            {
                var checkList = Enumerable.Range(0, 10).ToList();
                Assert.That(() => checkList.Shuffle(_random), Is.EquivalentTo(checkList));
                Assert.That(() => checkList, Is.Ordered);
                Assert.That(() => checkList.Shuffle(_random), Is.Not.Ordered);
            }

            [Test]
            public void SequenceGoodRandomNull()
            {
                Assert.That(() => Enumerable.Range(1, 10).Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullRandomGood()
            {
                Assert.That(() => NullSequence.Of<int>().Shuffle(_random), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullRandomNull()
            {
                Assert.That(() => NullSequence.Of<int>().Shuffle(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                try
                {
                    NullSequence.Of<int>().Shuffle(null);
                    Assert.Fail();
                }
                catch (ValidationException vex)
                {
                    var multiException = vex.InnerException as MultiException;
                    if (multiException == null)
                    {
                        Assert.Fail();
                    }
                    Assert.That(() => multiException.InnerExceptions.ToList(), Has.Count.EqualTo(2));
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentNullException>());
                    Assert.That(() => multiException.InnerExceptions, Has.Some.InstanceOf<ArgumentException>());
                }
            }
        }
    }
}