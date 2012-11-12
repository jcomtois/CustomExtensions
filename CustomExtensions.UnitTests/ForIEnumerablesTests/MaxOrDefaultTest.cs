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
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class MaxOrDefaultTest
        {
            [Test]
            public void MaxOrDefault_OnDecimalArray_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.CreateAnonymous<decimal[]>();
                var decimalArrayMax = decimalArray.Max();

                Assert.That(() => decimalArray.MaxOrDefault(), Is.EqualTo(decimalArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnDecimalArray_WithDecimalValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.CreateAnonymous<decimal[]>();
                var decimalArrayMax = decimalArray.Max();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => decimalArray.MaxOrDefault(decimalValue), Is.EqualTo(decimalArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnDoubleArray_ReturnsDoubleArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.CreateAnonymous<double[]>();
                var doubleArrayMax = doubleArray.Max();

                Assert.That(() => doubleArray.MaxOrDefault(), Is.EqualTo(doubleArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnDoubleArray_WithDoubleValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.CreateAnonymous<double[]>();
                var doubleArrayMax = doubleArray.Max();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => doubleArray.MaxOrDefault(doubleValue), Is.EqualTo(doubleArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();

                Assert.That(() => emtpyDecimalSequence.MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emtpyDecimalSequence.MaxOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyDoubleSequence = Enumerable.Empty<double>();

                Assert.That(() => emptyDoubleSequence.MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyDoubleSequence = Enumerable.Empty<double>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyDoubleSequence.MaxOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                var emptyFloatSequence = Enumerable.Empty<float>();

                Assert.That(() => emptyFloatSequence.MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyFloatSequence_WithFloatValue_ReturnsFloatvalue()
            {
                var fixture = new RandomNumberFixture();
                var emptyFloatSequence = Enumerable.Empty<float>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyFloatSequence.MaxOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_ReturnsDefault()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithFunc_ReturnsDefault()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(comparableFunc), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithNullValue_ReturnsNull()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var nullComparable = (GenericComparable)null;
                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(nullComparable), Is.Null);
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithNullValue_WithFunc_ReturnsNull()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                GenericComparable nullComparable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(comparableFunc, nullComparable), Is.Null);
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithValue_ReturnsValue()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithValue_WithFunc_ReturnsValue()
            {
                var fixture = new BaseFixture();
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new BaseFixture();
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => emptyGenericEnumerable.MaxOrDefault(null, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_ReturnsDefaultInt()
            {
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(doubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableDuoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyIntSequence.MaxOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                var emptyLongSequence = Enumerable.Empty<long>();

                Assert.That(() => emptyLongSequence.MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyLongSequence = Enumerable.Empty<long>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyLongSequence.MaxOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();

                Assert.That(() => emptyNullableDecimalSequence.MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyNullableDecimalSequence.MaxOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();

                Assert.That(() => emptyNullableDoubleSequence.MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyNullableDoubleSequence.MaxOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();

                Assert.That(() => emptyNullableFloatSequence.MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyNullableFloatSequence.MaxOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableIntSequence_ReturnsDefaultInt()
            {
                var emptyNullableIntSequence = Enumerable.Empty<int?>();

                Assert.That(() => emptyNullableIntSequence.MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableIntSequence = Enumerable.Empty<int?>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyNullableIntSequence.MaxOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();

                Assert.That(() => emptyNullableLongSequnce.MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyNullableLongSequnce.MaxOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnFloatArray_ReturnsFloatArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.CreateAnonymous<float[]>();
                var floatArrayMax = floatArray.Max();

                Assert.That(() => floatArray.MaxOrDefault(), Is.EqualTo(floatArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnFloatArray_WithFloatValue_ReturnsFloatArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.CreateAnonymous<float[]>();
                var floatArrayMax = floatArray.Max();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => floatArray.MaxOrDefault(floatValue), Is.EqualTo(floatArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableArrayMax = comparableArray.Max();

                Assert.That(() => comparableArray.MaxOrDefault(), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithFunc_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMax = comparableArray.Max(comparableFunc);

                Assert.That(() => comparableArray.MaxOrDefault(comparableFunc), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MaxOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithNullValue_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                var comparableArrayMax = comparableArray.Max();

                Assert.That(() => comparableArray.MaxOrDefault(nullComparable), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithNullValue_WithFunc_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMax = comparableArray.Max(comparableFunc);

                Assert.That(() => comparableArray.MaxOrDefault(comparableFunc, nullComparable), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MaxOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithValue_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableArrayMax = comparableArray.Max();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => comparableArray.MaxOrDefault(comparableValue), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithValue_WithFunc_ReturnsGenericEnumerableMax()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMax = comparableArray.Max(comparableFunc);

                Assert.That(() => comparableArray.MaxOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MaxOrDefault(nullFunc, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnIntArray_ReturnsIntArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intArrayMax = intArray.Max();

                Assert.That(() => intArray.MaxOrDefault(), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithDecimalFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var intArrayMax = intArray.Max(decimalFunc);

                Assert.That(() => intArray.MaxOrDefault(decimalFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithDecimalFunc_WithDecimalvalue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var intArrayMax = intArray.Max(decimalFunc);
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => intArray.MaxOrDefault(decimalFunc, decimalValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithDoubleFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var intArrayMax = intArray.Max(doubleFunc);

                Assert.That(() => intArray.MaxOrDefault(doubleFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithDoubleFunc_WithDoubleValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var intArrayMax = intArray.Max(doubleFunc);
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => intArray.MaxOrDefault(doubleFunc, doubleValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithFloatFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var intArrayMax = intArray.Max(floatFunc);

                Assert.That(() => intArray.MaxOrDefault(floatFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithFloatFunc_WithFloatValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var intArrayMax = intArray.Max(floatFunc);
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => intArray.MaxOrDefault(floatFunc, floatValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithIntFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intArrayMax = intArray.Max(intFunc);

                Assert.That(() => intArray.MaxOrDefault(intFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithIntFunc_WithIntValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intArrayMax = intArray.Max(intFunc);
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => intArray.MaxOrDefault(intFunc, intValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithIntValue_ReturnsIntArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intValue = fixture.CreateAnonymous<int>();
                var intArrayMax = intArray.Max();

                Assert.That(() => intArray.MaxOrDefault(intValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithLongFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var intArrayMax = intArray.Max(longFunc);

                Assert.That(() => intArray.MaxOrDefault(longFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithLongfunc_WithLongValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();
                var intArrayMax = intArray.Max(longFunc);

                Assert.That(() => intArray.MaxOrDefault(longFunc, longValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableDecimalFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var intArrayMax = intArray.Max(nullableDecimalFunc);

                Assert.That(() => intArray.MaxOrDefault(nullableDecimalFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableDecimalFunc_WithDecimalValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var intArrayMax = intArray.Max(nullableDecimalFunc);
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => intArray.MaxOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableDoubleFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var intArrayMax = intArray.Max(nullableDoubleFunc);

                Assert.That(() => intArray.MaxOrDefault(nullableDoubleFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableDoubleFunc_WithDoubleValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var intArrayMax = intArray.Max(nullableDoubleFunc);
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => intArray.MaxOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableFloatFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var intArrayMax = intArray.Max(nullableFloatFunc);

                Assert.That(() => intArray.MaxOrDefault(nullableFloatFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableFloatFunc_WithFloatValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var intArrayMax = intArray.Max(nullableFloatFunc);
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => intArray.MaxOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableIntFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intArrayMax = intArray.Max(nullableIntFunc);

                Assert.That(() => intArray.MaxOrDefault(nullableIntFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableIntFunc_WithIntValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intArrayMax = intArray.Max(nullableIntFunc);
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => intArray.MaxOrDefault(nullableIntFunc, intValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableLongFunc_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var intArrayMax = intArray.Max(nullableLongFunc);

                Assert.That(() => intArray.MaxOrDefault(nullableLongFunc), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnIntArray_WithNullableLongFunc_WithLongValue_ReturnsMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var intArrayMax = intArray.Max(nullableLongFunc);
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => intArray.MaxOrDefault(nullableLongFunc, longValue), Is.EqualTo(intArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnLongArray_ReturnsLongArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.CreateAnonymous<long[]>();
                var longArrayMax = longArray.Max();

                Assert.That(() => longArray.MaxOrDefault(), Is.EqualTo(longArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnLongArray_WithLongValue_ReturnsLongArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.CreateAnonymous<long[]>();
                var longArrayMax = longArray.Max();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => longArray.MaxOrDefault(longValue), Is.EqualTo(longArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnNullDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal> nullDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullDecimalSequence.MaxOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double> nullDoubleSequence = null;

                Assert.That(() => nullDoubleSequence.MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnNullDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double> nullDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullDoubleSequence.MaxOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float> nullFloatSequence = null;

                Assert.That(() => nullFloatSequence.MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnNullFloatSequence_WithFloatValue_RetursFloatValue()
            {
                IEnumerable<float> nullFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullFloatSequence.MaxOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithFunc_ReturnsDefault()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(comparableFunc), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithNullValue_ReturnsNull()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(nullComparable), Is.Null);
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithNullValue_WithFunc_ReturnsNull()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(comparableFunc, nullComparable), Is.Null);
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithValue_ReturnsValue()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithValue_WithFunc_ReturnsValue()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MaxOrDefault_OnNullGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MaxOrDefault(nullFunc, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;

                Assert.That(() => nullIntSequence.MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullIntSequence.MaxOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var doubeValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullIntSequence.MaxOrDefault(doubleFunc, doubeValue), Is.EqualTo(doubeValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullIntSequence.MaxOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MaxOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MaxOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullIntSequence.MaxOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                IEnumerable<int> nullIntSequence = null;
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnNullIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullIntSequence.MaxOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long> nullLongSequence = null;

                Assert.That(() => nullLongSequence.MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnNullLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long> nullLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullLongSequence.MaxOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal?> nullNullableDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullNullableDecimalSequence.MaxOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;

                Assert.That(() => nullNullableDoubleSequence.MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullNullableDoubleSequence.MaxOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;

                Assert.That(() => nullNullableFloatSequence.MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullNullableFloatSequence.MaxOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int?> nullNullableIntSequence = null;

                Assert.That(() => nullNullableIntSequence.MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int?> nullNullableIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullNullableIntSequence.MaxOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long?> nullNullableLongSequence = null;

                Assert.That(() => nullNullableLongSequence.MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long?> nullNullableLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullNullableLongSequence.MaxOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MaxOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.CreateAnonymous<decimal?[]>();
                var nullableDecimalArrayMax = nullableDecimalArray.Max();

                Assert.That(() => nullableDecimalArray.MaxOrDefault(), Is.EqualTo(nullableDecimalArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableDecimalArray_WithDecimalValue_ReturnsNullableDecimalArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.CreateAnonymous<decimal?[]>();
                var decimalValue = fixture.CreateAnonymous<decimal>();
                var nullableDecimalArrayMax = nullableDecimalArray.Max();

                Assert.That(() => nullableDecimalArray.MaxOrDefault(decimalValue), Is.EqualTo(nullableDecimalArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.CreateAnonymous<double?[]>();
                var nullableDoubleArrayMax = nullableDoubleArray.Max();

                Assert.That(() => nullableDoubleArray.MaxOrDefault(), Is.EqualTo(nullableDoubleArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableDoubleArray_WithDoubleValue_ReturnsNullableDoubleArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.CreateAnonymous<double?[]>();
                var nullableDoubleArrayMax = nullableDoubleArray.Max();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullableDoubleArray.MaxOrDefault(doubleValue), Is.EqualTo(nullableDoubleArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.CreateAnonymous<float?[]>();
                var nullableFloatArrayMax = nullableFloatArray.Max();

                Assert.That(() => nullableFloatArray.MaxOrDefault(), Is.EqualTo(nullableFloatArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableFloatArray_WithFloatValue_ReturnsNullableFloatArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.CreateAnonymous<float?[]>();
                var nullableFloatArrayMax = nullableFloatArray.Max();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullableFloatArray.MaxOrDefault(floatValue), Is.EqualTo(nullableFloatArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableIntArray_RetunrsNullableIntArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.CreateAnonymous<int?[]>();
                var nullableIntArrayMax = nullableIntArray.Max();

                Assert.That(() => nullableIntArray.MaxOrDefault(), Is.EqualTo(nullableIntArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableIntArray_WithIntValue_ReturnsNullableIntArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.CreateAnonymous<int?[]>();
                var nullableIntArrayMax = nullableIntArray.Max();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullableIntArray.MaxOrDefault(intValue), Is.EqualTo(nullableIntArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableLongArray_ReturnsNullableLongArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.CreateAnonymous<long?[]>();
                var nullableLongArrayMax = nullableLongArray.Max();

                Assert.That(() => nullableLongArray.MaxOrDefault(), Is.EqualTo(nullableLongArrayMax));
            }

            [Test]
            public void MaxOrDefault_OnNullableLongArray_WithLongValue_ReturnsNullableLongArrayMax()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.CreateAnonymous<long?[]>();
                var nullableLongArrayMax = nullableLongArray.Max();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullableLongArray.MaxOrDefault(longValue), Is.EqualTo(nullableLongArrayMax));
            }
        }
    }
}