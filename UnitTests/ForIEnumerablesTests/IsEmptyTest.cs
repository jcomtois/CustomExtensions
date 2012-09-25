﻿using System;
using System.Collections;
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
        public class IsEmptyTest
        {
            //Class to test non-Generic ICollection
            private sealed class TestObj <T> : ArrayList, IEnumerable<T>
            {
                #region IEnumerable<T> Members

                IEnumerator<T> IEnumerable<T>.GetEnumerator()
                {
                    return this.OfType<T>().GetEnumerator();
                }

                #endregion
            }

            [Test]
            public void IsEmptySequenceNull()
            {
                Assert.That(() => NullSequence.Of<int>().IsEmpty(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void IsEmptySourceContainsOneItem()
            {
                Assert.That(() => Enumerable.Repeat(1, 1).IsEmpty(), Is.False); // IEnumerable
                Assert.That(() => Enumerable.Repeat(1, 1).ToList().IsEmpty(), Is.False); // Generic collection
                var testObj = new TestObj<int> {1};
                Assert.That(() => testObj.IsEmpty(), Is.False); // Non-Generic collection
            }

            [Test]
            public void IsEmptySourceContainsZeroItems()
            {
                Assert.That(() => Enumerable.Empty<int>().IsEmpty(), Is.True); // IEnumerable
                Assert.That(() => Enumerable.Empty<int>().ToList().IsEmpty(), Is.True); // Generic collection
                var testObj = new TestObj<int>();
                Assert.That(() => testObj.IsEmpty(), Is.True); // Non-Generic collection
            }

            [Test]
            public void TestTestObj()
            {
                var testObj = new TestObj<int> {1};
                Assert.That(() => testObj.ToList(), Throws.Nothing);
            }
        }
    }
}