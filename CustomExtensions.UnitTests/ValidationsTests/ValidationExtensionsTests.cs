#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
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
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidationExtensionsTest
        {
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

            private Validator _validator;
            private const string GoodTestString = "Test";
            private const string EmptyTestString = "";
            private const string NullTestString = null;
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
            public void IsAtLeast_OnNumberEqualsMinimum_AddsNothing()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<int>(numberInt, numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberLong, numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<long>(numberLong, numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<short>(numberShort, numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberShort, numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<byte>(numberByte, numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberByte, numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ulong>(numberULong, numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberULong, numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ushort>(numberUShort, numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUShort, numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<uint>(numberUInt, numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUInt, numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<double>(numberDouble, numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDouble, numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<float>(numberFloat, numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberFloat, numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<decimal>(numberDecimal, numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDecimal, numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsAtLeast_OnNumberGreaterThanMinimum_AddsNothing()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, ++numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<int>(numberInt, ++numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<long>(numberLong, ++numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberLong, ++numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<short>(numberShort, ++numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberShort, ++numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<byte>(numberByte, ++numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberByte, ++numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ulong>(numberULong, ++numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberULong, ++numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ushort>(numberUShort, ++numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUShort, ++numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<uint>(numberUInt, ++numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUInt, ++numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<double>(numberDouble, ++numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDouble, ++numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<float>(numberFloat, ++numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberFloat, ++numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<decimal>(numberDecimal, ++numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDecimal, ++numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimumEmptyParameterName_AddsExceptionWithEmptyParameterName()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();

                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberLong, --numberLong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberShort, --numberShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberByte, --numberByte, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberULong, --numberULong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUShort, --numberUShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUInt, --numberUInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDouble, --numberDouble, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberFloat, --numberFloat, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDecimal, --numberDecimal, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<int>(numberInt, --numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<long>(numberLong, --numberLong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<short>(numberShort, --numberShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<byte>(numberByte, --numberByte, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ulong>(numberULong, --numberULong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ushort>(numberUShort, --numberUShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<uint>(numberUInt, --numberUInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<double>(numberDouble, --numberDouble, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<float>(numberFloat, --numberFloat, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<decimal>(numberDecimal, --numberDecimal, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimumNullParameterName_AddsExceptionWithNullParameterName()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();

                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberLong, --numberLong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberShort, --numberShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberByte, --numberByte, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberULong, --numberULong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUShort, --numberUShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUInt, --numberUInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDouble, --numberDouble, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberFloat, --numberFloat, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDecimal, --numberDecimal, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<int>(numberInt, --numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<long>(numberLong, --numberLong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<short>(numberShort, --numberShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<byte>(numberByte, --numberByte, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ulong>(numberULong, --numberULong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ushort>(numberUShort, --numberUShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<uint>(numberUInt, --numberUInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<double>(numberDouble, --numberDouble, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<float>(numberFloat, --numberFloat, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<decimal>(numberDecimal, --numberDecimal, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
            }

            [Test]
            public void IsAtLeast_OnNumberLessThanMinimum_AddsException()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberInt, --numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberLong, --numberLong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberShort, --numberShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberByte, --numberByte, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberULong, --numberULong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUShort, --numberUShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberUInt, --numberUInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDouble, --numberDouble, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberFloat, --numberFloat, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast(numberDecimal, --numberDecimal, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<int>(numberInt, --numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<long>(numberLong, --numberLong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<short>(numberShort, --numberShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<byte>(numberByte, --numberByte, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ulong>(numberULong, --numberULong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<ushort>(numberUShort, --numberUShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<uint>(numberUInt, --numberUInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<double>(numberDouble, --numberDouble, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<float>(numberFloat, --numberFloat, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtLeast<decimal>(numberDecimal, --numberDecimal, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
            }

            [Test]
            public void IsAtMost_OnNumberEqualsMaximum_AddsNothing()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<int>(numberInt, numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberLong, numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<long>(numberLong, numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<short>(numberShort, numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberShort, numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<byte>(numberByte, numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberByte, numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ulong>(numberULong, numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberULong, numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ushort>(numberUShort, numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUShort, numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<uint>(numberUInt, numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUInt, numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<double>(numberDouble, numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDouble, numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<float>(numberFloat, numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberFloat, numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<decimal>(numberDecimal, numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDecimal, numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsAtMost_OnNumberGreaterThanMaximumEmptyParameterName_AddsExceptionWithEmptyParameterName()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();

                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberLong, ++numberLong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberShort, ++numberShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberByte, ++numberByte, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberULong, ++numberULong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUShort, ++numberUShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUInt, ++numberUInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDouble, ++numberDouble, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberFloat, ++numberFloat, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDecimal, ++numberDecimal, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<int>(numberInt, ++numberInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<long>(numberLong, ++numberLong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<short>(numberShort, ++numberShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<byte>(numberByte, ++numberByte, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ulong>(numberULong, ++numberULong, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ushort>(numberUShort, ++numberUShort, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<uint>(numberUInt, ++numberUInt, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<double>(numberDouble, ++numberDouble, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<float>(numberFloat, ++numberFloat, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<decimal>(numberDecimal, ++numberDecimal, EmptyTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(EmptyTestString));
            }

            [Test]
            public void IsAtMost_OnNumberGreaterThanMaximumNullParameterName_AddsExceptionWithNullParameterName()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();

                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberLong, ++numberLong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberShort, ++numberShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberByte, ++numberByte, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberULong, ++numberULong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUShort, ++numberUShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUInt, ++numberUInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDouble, ++numberDouble, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberFloat, ++numberFloat, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDecimal, ++numberDecimal, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<int>(numberInt, ++numberInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<long>(numberLong, ++numberLong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<short>(numberShort, ++numberShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<byte>(numberByte, ++numberByte, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ulong>(numberULong, ++numberULong, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ushort>(numberUShort, ++numberUShort, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<uint>(numberUInt, ++numberUInt, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<double>(numberDouble, ++numberDouble, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<float>(numberFloat, ++numberFloat, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<decimal>(numberDecimal, ++numberDecimal, NullTestString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(NullTestString));
            }

            [Test]
            public void IsAtMost_OnNumberGreaterThanMaximum_AddsException()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, ++numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberLong, ++numberLong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberShort, ++numberShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberByte, ++numberByte, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberULong, ++numberULong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUShort, ++numberUShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUInt, ++numberUInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDouble, ++numberDouble, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberFloat, ++numberFloat, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDecimal, ++numberDecimal, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<int>(numberInt, ++numberInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<long>(numberLong, ++numberLong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<short>(numberShort, ++numberShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<byte>(numberByte, ++numberByte, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ulong>(numberULong, ++numberULong, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ushort>(numberUShort, ++numberUShort, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<uint>(numberUInt, ++numberUInt, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<double>(numberDouble, ++numberDouble, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<float>(numberFloat, ++numberFloat, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsAtMost<decimal>(numberDecimal, ++numberDecimal, testString).CheckForExceptions(),
                            Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                  .With.InnerException.Property("ParamName").EqualTo(testString));
            }

            [Test]
            public void IsAtMost_OnNumberLessThanMaximum_AddsNothing()
            {
                var fixture = new Fixture();

                var numberInt = fixture.Create<int>();
                var numberLong = fixture.Create<long>();
                var numberShort = fixture.Create<short>();
                var numberByte = fixture.Create<byte>();
                var numberULong = fixture.Create<ulong>();
                var numberUShort = fixture.Create<ushort>();
                var numberUInt = fixture.Create<uint>();
                var numberDouble = fixture.Create<double>();
                var numberFloat = fixture.Create<float>();
                var numberDecimal = fixture.Create<decimal>();
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberInt, --numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<int>(numberInt, --numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<long>(numberLong, --numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberLong, --numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<short>(numberShort, --numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberShort, --numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<byte>(numberByte, --numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberByte, --numberByte, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ulong>(numberULong, --numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberULong, --numberULong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<ushort>(numberUShort, --numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUShort, --numberUShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<uint>(numberUInt, --numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberUInt, --numberUInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<double>(numberDouble, --numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDouble, --numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<float>(numberFloat, --numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberFloat, --numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost<decimal>(numberDecimal, --numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsAtMost(numberDecimal, --numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
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
            public void IsNotNegative_OnNumberEqualsZero_AddsNothing()
            {
                var fixture = new Fixture();

                const int numberInt = 0;
                const long numberLong = 0;
                const short numberShort = 0;
                const double numberDouble = 0;
                const float numberFloat = 0;
                const decimal numberDecimal = 0;
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsNotNegative_OnNumberGreaterThanZero_AddsNothing()
            {
                var fixture = new Fixture();

                const int numberInt = 1;
                const long numberLong = 1;
                const short numberShort = 1;
                const double numberDouble = 1;
                const float numberFloat = 1;
                const decimal numberDecimal = 1;
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberInt, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberLong, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberShort, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDouble, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberFloat, testString).CheckForExceptions(), Throws.Nothing);
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDecimal, testString).CheckForExceptions(), Throws.Nothing);
            }

            [Test]
            public void IsNotNegative_OnNumberLessThanZero_AddsException()
            {
                var fixture = new Fixture();

                const int numberInt = -1;
                const long numberLong = -1;
                const short numberShort = -1;
                const double numberDouble = -1;
                const float numberFloat = -1;
                const decimal numberDecimal = -1;
                var testString = fixture.Create<string>();

                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberInt, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                               .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberLong, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberShort, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                 .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDouble, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                  .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberFloat, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                 .With.InnerException.Property("ParamName").EqualTo(testString));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDecimal, testString).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                   .With.InnerException.Property("ParamName").EqualTo(testString));
            }

            [Test]
            public void IsNotNegative_OnNumberLessThanZero_WithEmptyParemeterName_AddsExceptionWithEmptyParameterName()
            {
                var fixture = new Fixture();

                const int numberInt = -1;
                const long numberLong = -1;
                const short numberShort = -1;
                const double numberDouble = -1;
                const float numberFloat = -1;
                const decimal numberDecimal = -1;

                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberInt, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                 .With.InnerException.Property("ParamName").EqualTo(string.Empty));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberLong, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                  .With.InnerException.Property("ParamName").EqualTo(string.Empty));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberShort, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                   .With.InnerException.Property("ParamName").EqualTo(string.Empty));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDouble, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                    .With.InnerException.Property("ParamName").EqualTo(string.Empty));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberFloat, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                   .With.InnerException.Property("ParamName").EqualTo(string.Empty));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDecimal, string.Empty).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                                     .With.InnerException.Property("ParamName").EqualTo(string.Empty));
            }

            [Test]
            public void IsNotNegative_OnNumberLessThanZero_WithNullParemeterName_AddsExceptionWithNullParameterName()
            {
                var fixture = new Fixture();

                const int numberInt = -1;
                const long numberLong = -1;
                const short numberShort = -1;
                const double numberDouble = -1;
                const float numberFloat = -1;
                const decimal numberDecimal = -1;

                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberInt, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                         .With.InnerException.Property("ParamName").EqualTo(null));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberLong, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                          .With.InnerException.Property("ParamName").EqualTo(null));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberShort, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                           .With.InnerException.Property("ParamName").EqualTo(null));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDouble, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                            .With.InnerException.Property("ParamName").EqualTo(null));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberFloat, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                           .With.InnerException.Property("ParamName").EqualTo(null));
                Assert.That(() => fixture.Create<Validator>().IsNotNegative(numberDecimal, null).CheckForExceptions(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentOutOfRangeException>()
                                                                                                                             .With.InnerException.Property("ParamName").EqualTo(null));
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
        }
    }
}