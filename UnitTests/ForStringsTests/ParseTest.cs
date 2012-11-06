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
using CustomExtensions.ForStrings;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class ParseTest
        {
            private const int PositiveInteger = 123;
            private const int NegativeInteger = -123;
            private const float PositiveFloat = 123.4f;
            private const decimal PositiveDecimal = 123.4m;
            private const double PositiveDouble = 123.4d;
            private const float NegativeFloat = -123.4f;
            private const decimal NegativeDecimal = -123.4m;
            private const double NegativeDouble = -123.4d;

            private const string PositiveIntegerString = "123";
            private const string NegativeIntegerString = "-123";
            private const string ZeroIntegerString = "0";
            private const string PositiveDecimalString = "123.4";
            private const string NegativeDecimalString = "-123.4";
            private const string ZeroDecimalString = "0.0";

            [Test]
            public void Parse_OnEmptyString_ThrowsValidationError()
            {
                Assert.That(() => EmptyTestString.Parse<int>(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Parse_OnNullString_ThrowsValidationError()
            {
                Assert.That(() => NullTestString.Parse<int>(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Parse_ToDecimalOnNegativeDecimal_ReturnsDecimal()
            {
                Assert.That(() => NegativeDecimalString.Parse<decimal>(), Is.EqualTo(NegativeDecimal));
            }

            [Test]
            public void Parse_ToDecimalOnNegativeInteger_ReturnsDecimal()
            {
                Assert.That(() => NegativeIntegerString.Parse<decimal>(), Is.EqualTo(NegativeInteger));
            }

            [Test]
            public void Parse_ToDecimalOnPositiveDecimal_ReturnsDecimal()
            {
                Assert.That(() => PositiveDecimalString.Parse<decimal>(), Is.EqualTo(PositiveDecimal));
            }

            [Test]
            public void Parse_ToDecimalOnPositiveInteger_ReturnsDecimal()
            {
                Assert.That(() => PositiveIntegerString.Parse<decimal>(), Is.EqualTo(PositiveInteger));
            }

            [Test]
            public void Parse_ToDecimalOnZeroDecimal_ReturnsDecimal()
            {
                Assert.That(() => ZeroDecimalString.Parse<decimal>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToDecimalOnZeroInteger_ReturnsDecimal()
            {
                Assert.That(() => ZeroIntegerString.Parse<decimal>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToDoubleOnNegativeDecimal_ReturnsDouble()
            {
                Assert.That(() => NegativeDecimalString.Parse<double>(), Is.EqualTo(NegativeDouble));
            }

            [Test]
            public void Parse_ToDoubleOnNegativeInteger_ReturnsDouble()
            {
                Assert.That(() => NegativeIntegerString.Parse<double>(), Is.EqualTo(NegativeInteger));
            }

            [Test]
            public void Parse_ToDoubleOnPositiveDecimal_ReturnsDouble()
            {
                Assert.That(() => PositiveDecimalString.Parse<double>(), Is.EqualTo(PositiveDouble));
            }

            [Test]
            public void Parse_ToDoubleOnPositiveInteger_ReturnsDouble()
            {
                Assert.That(() => PositiveIntegerString.Parse<double>(), Is.EqualTo(PositiveInteger));
            }

            [Test]
            public void Parse_ToDoubleOnZeroDecimal_ReturnsDouble()
            {
                Assert.That(() => ZeroDecimalString.Parse<double>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToDoubleOnZeroInteger_ReturnsDouble()
            {
                Assert.That(() => ZeroIntegerString.Parse<double>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToFloatOnNegativeDecimal_ReturnsFloat()
            {
                Assert.That(() => NegativeDecimalString.Parse<float>(), Is.EqualTo(NegativeFloat));
            }

            [Test]
            public void Parse_ToFloatOnNegativeInteger_ReturnsFloat()
            {
                Assert.That(() => NegativeIntegerString.Parse<float>(), Is.EqualTo(NegativeInteger));
            }

            [Test]
            public void Parse_ToFloatOnPositiveDecimal_ReturnsFloat()
            {
                Assert.That(() => PositiveDecimalString.Parse<float>(), Is.EqualTo(PositiveFloat));
            }

            [Test]
            public void Parse_ToFloatOnPositiveInteger_ReturnsFloat()
            {
                Assert.That(() => PositiveIntegerString.Parse<float>(), Is.EqualTo(PositiveInteger));
            }

            [Test]
            public void Parse_ToFloatOnZeroDecimal_ReturnsFloat()
            {
                Assert.That(() => ZeroDecimalString.Parse<float>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToFloatOnZeroInteger_ReturnsFloat()
            {
                Assert.That(() => ZeroIntegerString.Parse<float>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToIntegerOnBogusString_ThrowsNotSupportedException()
            {
                Assert.That(() => TestStringLatin.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToIntegerOnNegativeDecimal_ThrowsNotSupportedException()
            {
                Assert.That(() => NegativeDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToIntegerOnNegativeInteger_ReturnsInteger()
            {
                Assert.That(() => NegativeIntegerString.Parse<int>(), Is.EqualTo(NegativeInteger));
            }

            [Test]
            public void Parse_ToIntegerOnPositiveDecimal_ThrowsNotSupportedException()
            {
                Assert.That(() => PositiveDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToIntegerOnPositiveInteger_ReturnsInteger()
            {
                Assert.That(() => PositiveIntegerString.Parse<int>(), Is.EqualTo(PositiveInteger));
            }

            [Test]
            public void Parse_ToIntegerOnZeroDecimal_ThrowsNotSupportedException()
            {
                Assert.That(() => ZeroDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToIntegerOnZeroInteger_ReturnsInteger()
            {
                Assert.That(() => ZeroIntegerString.Parse<int>(), Is.EqualTo(0));
            }

            [Test]
            public void Parse_ToString_ReturnsSameString()
            {
                Assert.That(() => TestStringLatin.Parse<string>(), Is.EqualTo(TestStringLatin));
            }

            [Test]
            public void Parse_UnsupportedConversionTypeOnBogusString_ThrowsNotSupportedException()
            {
                Assert.That(() => TestStringLatin.Parse<ParseTest>(), Throws.TypeOf<NotSupportedException>());
            }
        }
    }
}