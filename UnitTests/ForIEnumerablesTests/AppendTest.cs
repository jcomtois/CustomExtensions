﻿using System;
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
            [Test]
            public void AppendIsLazy()
            {
                Assert.That(() => new BreakingSequence<string>().Append("A"), Throws.Nothing);
            }

            [Test]
            public void SequenceEmptyElementGood()
            {
                Assert.That(Enumerable.Empty<string>().Append("A"), Is.EqualTo(Enumerable.Repeat("A", 1)));
            }

            [Test]
            public void SequenceEmptyElementNull()
            {
                Assert.That(Enumerable.Empty<string>().Append(null), Is.EqualTo(Enumerable.Repeat<string>(null, 1)));
            }

            [Test]
            public void SequenceGoodElementGood()
            {
                Assert.That(Enumerable.Repeat("A", 2).Append("A"), Is.EqualTo(Enumerable.Repeat("A", 3)));
            }

            [Test]
            public void SequenceGoodElementNull()
            {
                Assert.That(Enumerable.Repeat("A", 2).Append(null), Is.EqualTo(new[] {"A", "A", null}));
            }

            [Test]
            public void SequenceNullElelmentNull()
            {
                Assert.That(() => NullSequence.Of<string>().Append(null), Throws.TypeOf<ValidationException>());
            }

            [Test]
            public void SequenceNullElementGood()
            {
                Assert.That(() => NullSequence.Of<string>().Append("A"), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}