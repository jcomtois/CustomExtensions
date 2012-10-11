using System;
using CustomExtensions.ForStrings;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class ContainsAnyTest
        {
            [Test]
            public void ContainsAnyCharacter_OnEmptyString_ReturnsFalse()
            {
                string sourceString = EmptyTestString;
                char toFind = 'Z';
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyCharacter_OnGoodString_FindsManyReturnsTrue()
            {
                string sourceString = "TEST";
                char toFind = 'T';
                Assert.That(() => sourceString.ContainsAny(toFind), Is.True);
            }

            [Test]
            public void ContainsAnyCharacter_OnGoodString_FindsNoneReturnsFalse()
            {
                string sourceString = "TEST";
                char toFind = 'Z';
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyCharacter_OnGoodString_FindsOneReturnsTrue()
            {
                string sourceString = "TEST";
                char toFind = 'E';
                Assert.That(() => sourceString.ContainsAny(toFind), Is.True);
            }

            [Test]
            public void ContainsAnyCharacter_OnGoodString_IsCaseSensitive()
            {
                string sourceString = "TEST";
                char toFind = 'e';
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyCharacter_OnNullString_ThrowsValidationException()
            {
                string sourceString = NullTestString;
                char toFind = 'Z';
                Assert.That(() => sourceString.ContainsAny(toFind), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAnyCharacters_OnEmptyString_ReturnsFalse()
            {
                string sourceString = EmptyTestString;
                char[] toFind = {'t', 'e'};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyCharacters_OnGoodString_FindsManyReturnsTrue()
            {
                string sourceString = "TEST";
                char[] toFind = {'T', 'Z'};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.True);
            }

            [Test]
            public void ContainsAnyCharacters_OnGoodString_FindsMultipleReturnsTrue()
            {
                string sourceString = "TEST";
                char[] toFind = {'T', 'E'};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.True);
            }

            [Test]
            public void ContainsAnyCharacters_OnGoodString_FindsNoneReturnsFalse()
            {
                string sourceString = "TEST";
                char[] toFind = {'t', 'e'};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyCharacters_OnGoodString_FindsOneReturnsTrue()
            {
                string sourceString = "TEST";
                char[] toFind = {'E', 'Z'};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.True);
            }

            [Test]
            public void ContainsAnyCharacters_OnNullString_ThrowsValidationException()
            {
                string sourceString = NullTestString;
                char[] toFind = {'t', 'e'};
                Assert.That(() => sourceString.ContainsAny(toFind), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAnyEmptyCharacters_OnEmptyString_ReturnsFalse()
            {
                string sourceString = EmptyTestString;
                char[] toFind = {};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyEmptyCharacters_OnGoodString_ReturnsFalse()
            {
                string sourceString = TestStringLatin;
                char[] toFind = {};
                Assert.That(() => sourceString.ContainsAny(toFind), Is.False);
            }

            [Test]
            public void ContainsAnyNullCharacters_OnGoodString_ThrowsValidationException()
            {
                string sourceString = TestStringLatin;
                char[] toFind = null;
                Assert.That(() => sourceString.ContainsAny(toFind), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ContainsAnyNullCharacters_OnNullString_ThrowsValidationException()
            {
                string sourceString = NullTestString;
                char[] toFind = null;
                Assert.That(() => sourceString.ContainsAny(toFind), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }
        }
    }
}