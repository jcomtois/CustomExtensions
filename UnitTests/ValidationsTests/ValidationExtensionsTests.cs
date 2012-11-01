#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Linq;
using CustomExtensions.Validation;
using NUnit.Framework;
using UnitTests.ForIEnumerablesTests;

namespace UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidationExtensionsTest
        {
            #region Setup/Teardown

            [SetUp]
            public void SetupValidator()
            {
                _validator = new Validator();
            }

            [TearDown]
            public void TearDownValidator()
            {
                _validator = null;
            }

            #endregion

            private Validator _validator;
            private const string GoodTestString = "Test";
            private const string EmptyTestString = "";
            private const string NullTestString = null;
            private const string SingleCharacterTestString = "T";
            private const string TestParameterName = "TestParameter";

            [Test]
            public void CheckForExceptionsValidatorGoodMoreThanOneException()
            {
                _validator.AddException(new ArgumentNullException());
                _validator.AddException(new InvalidOperationException());
                Assert.That(() => _validator.CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
                Assert.That(() => _validator.Exceptions, Is.Not.Empty);
                Assert.That(() => _validator.Exceptions, Has.Count.EqualTo(2));
            }

            [Test]
            public void CheckForExceptionsValidatorGoodNoExceptions()
            {
                Assert.That(() => _validator.CheckForExceptions(), Throws.Nothing);
                Assert.That(() => _validator.CheckForExceptions(), Is.Null);
            }

            [Test]
            public void CheckForExceptionsValidatorGoodOneException()
            {
                _validator.AddException(new ArgumentNullException());
                Assert.That(() => _validator.CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
                Assert.That(() => _validator.Exceptions, Is.Not.Empty);
                Assert.That(() => _validator.Exceptions, Has.Count.EqualTo(1));
            }

            [Test]
            public void CheckForExceptionsValidatorNull()
            {
                Assert.That(() => ((Validator)null).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => ((Validator)null).CheckForExceptions(), Is.Null);
            }

            [Test]
            public void HasAtLeast_EmptyParameterName_ThrowsNothing()
            {
                Assert.That(() => _validator.HasAtLeast(1, GoodTestString, TestParameterName), Throws.Nothing);
            }

            [Test]
            public void HasAtLeast_InputLengthEqualToStringLength_NoException()
            {
                var length = GoodTestString.Length;
                Assert.That(() => _validator.HasAtLeast(length, GoodTestString, TestParameterName).Exceptions, Is.Empty);
            }

            [Test]
            public void HasAtLeast_InputLengthGreaterThanStringLength_AddsArgumentOutOfRangeException()
            {
                var length = GoodTestString.Length + 1;
                Assert.That(() => _validator.HasAtLeast(length, GoodTestString, TestParameterName).Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void HasAtLeast_InputLengthLessThanStringLength_NoException()
            {
                Assert.That(() => _validator.HasAtLeast(1, GoodTestString, TestParameterName).Exceptions, Is.Empty);
            }

            [Test]
            public void HasAtLeast_InputLength_AcceptsPositive()
            {
                Assert.That(() => _validator.HasAtLeast(1, GoodTestString, TestParameterName).Exceptions, Is.Empty);
            }

            [Test]
            public void HasAtLeast_InputLength_AcceptsZero()
            {
                Assert.That(() => _validator.HasAtLeast(0, GoodTestString, TestParameterName).Exceptions, Is.Empty);
            }

            [Test]
            public void HasAtLeast_InputLength_NegativeThrowsArgumentOutOfRangeException()
            {
                Assert.That(() => _validator.HasAtLeast(-1, GoodTestString, TestParameterName), Throws.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void HasAtLeast_InputOneEmptyString_AddsArgumentOutOfRangeException()
            {
                Assert.That(() => _validator.HasAtLeast(1, EmptyTestString, TestParameterName).Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void HasAtLeast_InputZeroEmptyString_NoException()
            {
                Assert.That(() => _validator.HasAtLeast(0, EmptyTestString, TestParameterName).Exceptions, Is.Empty);
            }

            [Test]
            public void HasAtLeast_NullParameterName_ThrowsNothing()
            {
                Assert.That(() => _validator.HasAtLeast(1, GoodTestString, TestParameterName), Throws.Nothing);
            }

            [Test]
            public void HasAtLeast_ValueIsNull_AddsArgumentOutOfRangeException()
            {
                Assert.That(() => _validator.HasAtLeast(1, NullTestString, TestParameterName).Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void IsNotEmptySequenceEmptyParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Empty<int>(), string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

            [Test]
            public void IsNotEmptySequenceEmptyParameterNameGood()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Empty<int>(), "goodName"), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("goodName"));
            }

            [Test]
            public void IsNotEmptySequenceEmptyParameterNameNull()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Empty<int>(), null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }

            [Test]
            public void IsNotEmptySequenceGoodParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Repeat(1, 2), "goodName"), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotEmptySequenceGoodParameterNameGood()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Repeat(1, 2), "goodName"), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotEmptySequenceGoodParameterNameNull()
            {
                Assert.That(() => _validator.IsNotEmpty(Enumerable.Repeat(1, 2), null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotEmptySequenceNullParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotEmpty<int>(null, string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

            [Test]
            public void IsNotEmptySequenceNullParameterNameGood()
            {
                Assert.That(() => _validator.IsNotEmpty<int>(null, "goodName"), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("goodName"));
            }

            [Test]
            public void IsNotEmptySequenceNullParameterNameNull()
            {
                Assert.That(() => _validator.IsNotEmpty<int>(null, null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentException>());
                var ex = (ArgumentException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }

            [Test]
            public void IsNotNegativeFalseParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotNegative(-1, string.Empty).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

            [Test]
            public void IsNotNegativeFalseParameterNameGood()
            {
                Assert.That(() => _validator.IsNotNegative(-1, "negativeOne").Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("negativeOne"));
            }

            [Test]
            public void IsNotNegativeFalseParameterNameNull()
            {
                Assert.That(() => _validator.IsNotNegative(-1, null).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentOutOfRangeException>());
                var ex = (ArgumentOutOfRangeException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameEmpty()
            {
                Assert.That(() => _validator.IsNotNegative(1, string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameGood()
            {
                Assert.That(_validator.IsNotNegative(1, "numberOne").Exceptions, Is.Empty);
                Assert.That(_validator.IsNotNegative(0, "numberZero").Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNegativeTrueParameterNameNull()
            {
                Assert.That(() => _validator.IsNotNegative(1, null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNullFalseParameterNameEmpty()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, string.Empty).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Empty);
            }

            [Test]
            public void IsNotNullFalseParameterNameGood()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, "isNull").Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.EqualTo("isNull"));
            }

            [Test]
            public void IsNotNullFalseParameterNameNull()
            {
                object isNull = null;
                Assert.That(() => _validator.IsNotNull(isNull, null).Exceptions, Throws.Nothing);
                Assert.That(_validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(_validator.Exceptions.Single(), Is.TypeOf<ArgumentNullException>());
                var ex = (ArgumentNullException)_validator.Exceptions.Single();
                Assert.That(ex.ParamName, Is.Null);
            }

            [Test]
            public void IsNotNullTrueParameterNameEmpty()
            {
                var notNull = new object();
                Assert.That(() => _validator.IsNotNull(notNull, string.Empty), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNullTrueParameterNameGood()
            {
                var notNull = new object();
                Assert.That(_validator.IsNotNull(notNull, "notNull").Exceptions, Is.Empty);
            }

            [Test]
            public void IsNotNullTrueParameterNameNull()
            {
                var notNull = new object();
                Assert.That(() => _validator.IsNotNull(notNull, null), Throws.Nothing);
                Assert.That(_validator.Exceptions, Is.Empty);
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimum_AddsException()
            {
                const string parameterName = "someParameter";
                Assert.That(() => _validator.IsAtLeast(0, -1, parameterName).CheckForExceptions(),
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                    .With.InnerException.Property("ParamName").EqualTo(parameterName));
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimumNullParameterName_AddsExceptionWithNullParameterName()
            {
                Assert.That(() => _validator.IsAtLeast(0, -1, NullTestString).CheckForExceptions(),
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                    .With.InnerException.Property("ParamName").EqualTo(NullTestString));
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimumEmptyParameterName_AddsExceptionWithNullParameterName()
            {
                Assert.That(() => _validator.IsAtLeast(0, -1, EmptyTestString).CheckForExceptions(),
                    Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                    .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
            }

            [Test]
            public void IsAtLeast_OnNumberEqualsMinimum_AddsNothing()
            {
                Assert.That(() => _validator.IsAtLeast(0, 0, GoodTestString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsAtLeast_OnNumberGreaterThanMinimum_AddsNothing()
            {
                Assert.That(() => _validator.IsAtLeast(0, 1, GoodTestString).CheckForExceptions(), Throws.Nothing);
            }
        }
    }
}