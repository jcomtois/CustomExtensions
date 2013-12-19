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
using CustomExtensions.ForStrings;
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        [TestFixture]
        public class ParseTest
        {
            [Test]
            public void Parse_OnEmptyString_ThrowsValidationError()
            {
                var emptyString = string.Empty;

                Assert.That(() => emptyString.Parse<object>(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentException>());
            }

            [Test]
            public void Parse_OnNullString_ThrowsValidationError()
            {
                string nullString = null;

                Assert.That(() => nullString.Parse<object>(), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void Parse_ToDecimal_OnNegativeDecimal_ReturnsDecimal()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var negativeDecimal = -decimalValue / (decimalValue + 1);
                var negativeDecimalString = negativeDecimal.ToString("F");
                var converted = Convert.ToDecimal(negativeDecimalString);

                Assert.That(() => negativeDecimalString.Parse<decimal>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDecimal_OnNegativeInteger_ReturnsDecimal()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var negativeInt = -intValue / (intValue + 1);
                var negativeIntString = negativeInt.ToString();
                var converted = Convert.ToDecimal(negativeIntString);

                Assert.That(() => negativeIntString.Parse<decimal>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDecimal_OnPositiveDecimal_ReturnsDecimal()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var positiveDecimal = decimalValue / (decimalValue + 1);
                var positiveDecimalString = positiveDecimal.ToString("F");
                var converted = Convert.ToDecimal(positiveDecimalString);

                Assert.That(() => positiveDecimalString.Parse<decimal>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDecimal_OnPositiveInteger_ReturnsDecimal()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var positiveInt = intValue / (intValue + 1);
                var positiveIntString = positiveInt.ToString();
                var converted = Convert.ToDecimal(positiveIntString);

                Assert.That(() => positiveIntString.Parse<decimal>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDecimal_OnZeroDecimal_ReturnsDecimal()
            {
                decimal zero = 0m;
                var zeroDecimalString = zero.ToString("F");

                Assert.That(() => zeroDecimalString.Parse<decimal>(), Is.EqualTo(zero));
            }

            [Test]
            public void Parse_ToDecimal_OnZeroInteger_ReturnsDecimal()
            {
                decimal zero = 0m;
                int intZero = 0;
                var zeroIntString = intZero.ToString();

                Assert.That(() => zeroIntString.Parse<decimal>(), Is.EqualTo(zero));
            }

            [Test]
            public void Parse_ToDouble_OnNegativeDecimal_ReturnsDouble()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var negativeDecimal = -decimalValue / (decimalValue + 1);
                var negativeDecimalString = negativeDecimal.ToString("F");
                var converted = Convert.ToDouble(negativeDecimalString);

                Assert.That(() => negativeDecimalString.Parse<double>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDouble_OnNegativeInteger_ReturnsDouble()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var negativeInt = -intValue / (intValue + 1);
                var negativeIntString = negativeInt.ToString();
                var converted = Convert.ToDouble(negativeIntString);

                Assert.That(() => negativeIntString.Parse<double>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDouble_OnPositiveDecimal_ReturnsDouble()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var positiveDecimal = decimalValue / (decimalValue + 1);
                var positiveDecimalString = positiveDecimal.ToString("F");
                var converted = Convert.ToDouble(positiveDecimalString);

                Assert.That(() => positiveDecimalString.Parse<double>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDouble_OnPositiveInteger_ReturnsDouble()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var positiveInt = intValue / (intValue + 1);
                var positiveIntString = positiveInt.ToString();
                var converted = Convert.ToDouble(positiveIntString);

                Assert.That(() => positiveIntString.Parse<double>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToDouble_OnZeroDecimal_ReturnsDouble()
            {
                decimal zero = 0m;
                double doubleZero = 0d;
                var zeroDecimalString = zero.ToString("F");

                Assert.That(() => zeroDecimalString.Parse<double>(), Is.EqualTo(doubleZero));
            }

            [Test]
            public void Parse_ToDouble_OnZeroInteger_ReturnsDouble()
            {
                int zero = 0;
                double doubleZero = 0d;
                var zeroIntString = zero.ToString();

                Assert.That(() => zeroIntString.Parse<double>(), Is.EqualTo(doubleZero));
            }

            [Test]
            public void Parse_ToFloat_OnNegativeDecimal_ReturnsFloat()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var negativeDecimal = -decimalValue / (decimalValue + 1);
                var negativeDecimalString = negativeDecimal.ToString("F");
                var converted = Convert.ToSingle(negativeDecimalString);

                Assert.That(() => negativeDecimalString.Parse<float>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToFloat_OnNegativeInteger_ReturnsFloat()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var negativeInt = -intValue / (intValue + 1);
                var negativeIntString = negativeInt.ToString();
                var converted = Convert.ToSingle(negativeIntString);

                Assert.That(() => negativeIntString.Parse<float>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToFloat_OnPositiveDecimal_ReturnsFloat()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var positiveDecimal = decimalValue / (decimalValue + 1);
                var positiveDecimalString = positiveDecimal.ToString("F");
                var converted = Convert.ToSingle(positiveDecimalString);

                Assert.That(() => positiveDecimalString.Parse<float>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToFloat_OnPositiveInteger_ReturnsFloat()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var positiveInt = intValue / (intValue + 1);
                var positiveIntString = positiveInt.ToString();
                var converted = Convert.ToSingle(positiveIntString);

                Assert.That(() => positiveIntString.Parse<float>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToFloat_OnZeroDecimal_ReturnsFloat()
            {
                decimal zero = 0m;
                float floatZero = 0f;
                var zeroDecimalString = zero.ToString("F");

                Assert.That(() => zeroDecimalString.Parse<float>(), Is.EqualTo(floatZero));
            }

            [Test]
            public void Parse_ToFloat_OnZeroInteger_ReturnsFloat()
            {
                int zero = 0;
                float floatZero = 0f;
                var zeroIntString = zero.ToString();

                Assert.That(() => zeroIntString.Parse<float>(), Is.EqualTo(floatZero));
            }

            [Test]
            public void Parse_ToInteger_OnBogusString_ThrowsNotSupportedException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToInteger_OnNegativeDecimal_ThrowsNotSupportedException()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var negativeDecimal = -decimalValue / (decimalValue + 1);
                var negativeDecimalString = negativeDecimal.ToString("F");

                Assert.That(() => negativeDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToInteger_OnNegativeInteger_ReturnsInteger()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var negativeInt = -intValue / (intValue + 1);
                var negativeIntString = negativeInt.ToString();
                var converted = Convert.ToInt32(negativeIntString);

                Assert.That(() => negativeIntString.Parse<int>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToInteger_OnPositiveDecimal_ThrowsNotSupportedException()
            {
                var fixture = new RandomNumberFixture();
                var decimalValue = Math.Abs(fixture.Create<decimal>());
                decimalValue++;
                var positiveDecimal = decimalValue / (decimalValue + 1);
                var positiveDecimalString = positiveDecimal.ToString("F");

                Assert.That(() => positiveDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToInteger_OnPositiveInteger_ReturnsInteger()
            {
                var fixture = new RandomNumberFixture();
                var intValue = Math.Abs(fixture.Create<int>());
                intValue++;
                var positiveInt = intValue / (intValue + 1);
                var positiveIntString = positiveInt.ToString();
                var converted = Convert.ToInt32(positiveIntString);

                Assert.That(() => positiveIntString.Parse<int>(), Is.EqualTo(converted));
            }

            [Test]
            public void Parse_ToInteger_OnZeroDecimal_ThrowsNotSupportedException()
            {
                decimal zero = 0m;
                var zeroDecimalString = zero.ToString("F");

                Assert.That(() => zeroDecimalString.Parse<int>(), Throws.TypeOf<NotSupportedException>());
            }

            [Test]
            public void Parse_ToInteger_OnZeroInteger_ReturnsInteger()
            {
                int zero = 0;
                var zeroIntString = zero.ToString();

                Assert.That(() => zeroIntString.Parse<int>(), Is.EqualTo(zero));
            }

            [Test]
            public void Parse_ToString_ReturnsSameString()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.Parse<string>(), Is.EqualTo(stringValue));
            }

            [Test]
            public void Parse_UnsupportedConversionType_OnBogusString_ThrowsNotSupportedException()
            {
                var fixture = new LatinStringFixture();
                var stringValue = fixture.Create<string>();

                Assert.That(() => stringValue.Parse<ParseTest>(), Throws.TypeOf<NotSupportedException>());
            }
        }
    }
}