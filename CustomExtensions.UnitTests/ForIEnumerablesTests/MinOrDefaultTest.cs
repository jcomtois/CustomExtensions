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
        public class MinOrDefaultTest
        {
            [Test]
            public void MinOrDefault_OnDecimalArray_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.CreateAnonymous<decimal[]>();
                var decimalArrayMin = decimalArray.Min();

                Assert.That(() => decimalArray.MinOrDefault(), Is.EqualTo(decimalArrayMin));
            }

            [Test]
            public void MinOrDefault_OnDecimalArray_WithDecimalValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.CreateAnonymous<decimal[]>();
                var decimalArrayMin = decimalArray.Min();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => decimalArray.MinOrDefault(decimalValue), Is.EqualTo(decimalArrayMin));
            }

            [Test]
            public void MinOrDefault_OnDoubleArray_ReturnsDoubleArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.CreateAnonymous<double[]>();
                var doubleArrayMin = doubleArray.Min();

                Assert.That(() => doubleArray.MinOrDefault(), Is.EqualTo(doubleArrayMin));
            }

            [Test]
            public void MinOrDefault_OnDoubleArray_WithDoubleValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.CreateAnonymous<double[]>();
                var doubleArrayMin = doubleArray.Min();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => doubleArray.MinOrDefault(doubleValue), Is.EqualTo(doubleArrayMin));
            }

            [Test]
            public void MinOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();

                Assert.That(() => emtpyDecimalSequence.MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnEmptyDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emtpyDecimalSequence.MinOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyDoubleSequence = Enumerable.Empty<double>();

                Assert.That(() => emptyDoubleSequence.MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnEmptyDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyDoubleSequence = Enumerable.Empty<double>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyDoubleSequence.MinOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                var emptyFloatSequence = Enumerable.Empty<float>();

                Assert.That(() => emptyFloatSequence.MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnEmptyFloatSequence_WithFloatValue_ReturnsFloatvalue()
            {
                var fixture = new RandomNumberFixture();
                var emptyFloatSequence = Enumerable.Empty<float>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyFloatSequence.MinOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_ReturnsDefault()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                Assert.That(() => emptyGenericEnumerable.MinOrDefault(), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithFunc_ReturnsDefault()
            {
                //BUG: NCrunch
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(comparableFunc), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithNullValue_ReturnsNull()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var nullComparable = (GenericComparable)null;
                Assert.That(() => emptyGenericEnumerable.MinOrDefault(nullComparable), Is.Null);
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithNullValue_WithFunc_ReturnsNull()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                GenericComparable nullComparable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(comparableFunc, nullComparable), Is.Null);
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithValue_ReturnsValue()
            {
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithValue_WithFunc_ReturnsValue()
            {
                var fixture = new BaseFixture();
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new BaseFixture();
                var emptyGenericEnumerable = Enumerable.Empty<GenericComparable>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => emptyGenericEnumerable.MinOrDefault(null, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_ReturnsDefaultInt()
            {
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyIntSequence.MinOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.MinOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyIntSequence.MinOrDefault(doubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyIntSequence.MinOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MinOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MinOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyIntSequence.MinOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableDuoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyIntSequence.MinOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                var emptyLongSequence = Enumerable.Empty<long>();

                Assert.That(() => emptyLongSequence.MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnEmptyLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyLongSequence = Enumerable.Empty<long>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyLongSequence.MinOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();

                Assert.That(() => emptyNullableDecimalSequence.MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => emptyNullableDecimalSequence.MinOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();

                Assert.That(() => emptyNullableDoubleSequence.MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => emptyNullableDoubleSequence.MinOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();

                Assert.That(() => emptyNullableFloatSequence.MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => emptyNullableFloatSequence.MinOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableIntSequence_ReturnsDefaultInt()
            {
                var emptyNullableIntSequence = Enumerable.Empty<int?>();

                Assert.That(() => emptyNullableIntSequence.MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableIntSequence = Enumerable.Empty<int?>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => emptyNullableIntSequence.MinOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();

                Assert.That(() => emptyNullableLongSequnce.MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => emptyNullableLongSequnce.MinOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnFloatArray_ReturnsFloatArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.CreateAnonymous<float[]>();
                var floatArrayMin = floatArray.Min();

                Assert.That(() => floatArray.MinOrDefault(), Is.EqualTo(floatArrayMin));
            }

            [Test]
            public void MinOrDefault_OnFloatArray_WithFloatValue_ReturnsFloatArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.CreateAnonymous<float[]>();
                var floatArrayMin = floatArray.Min();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => floatArray.MinOrDefault(floatValue), Is.EqualTo(floatArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableArrayMin = comparableArray.Min();

                Assert.That(() => comparableArray.MinOrDefault(), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithFunc_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMin = comparableArray.Min(comparableFunc);

                Assert.That(() => comparableArray.MinOrDefault(comparableFunc), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MinOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithNullValue_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                var comparableArrayMin = comparableArray.Min();

                Assert.That(() => comparableArray.MinOrDefault(nullComparable), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithNullValue_WithFunc_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMin = comparableArray.Min(comparableFunc);

                Assert.That(() => comparableArray.MinOrDefault(comparableFunc, nullComparable), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MinOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithValue_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableArrayMin = comparableArray.Min();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => comparableArray.MinOrDefault(comparableValue), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithValue_WithFunc_ReturnsGenericEnumerableMin()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();
                var comparableArrayMin = comparableArray.Min(comparableFunc);

                Assert.That(() => comparableArray.MinOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableArrayMin));
            }

            [Test]
            public void MinOrDefault_OnGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var comparableArray = fixture.CreateAnonymous<GenericComparable[]>();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => comparableArray.MinOrDefault(nullFunc, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnIntArray_ReturnsIntArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intArrayMin = intArray.Min();

                Assert.That(() => intArray.MinOrDefault(), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithDecimalFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var intArrayMin = intArray.Min(decimalFunc);

                Assert.That(() => intArray.MinOrDefault(decimalFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithDecimalFunc_WithDecimalvalue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var intArrayMin = intArray.Min(decimalFunc);
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => intArray.MinOrDefault(decimalFunc, decimalValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithDoubleFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var intArrayMin = intArray.Min(doubleFunc);

                Assert.That(() => intArray.MinOrDefault(doubleFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithDoubleFunc_WithDoubleValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var intArrayMin = intArray.Min(doubleFunc);
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => intArray.MinOrDefault(doubleFunc, doubleValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithFloatFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var intArrayMin = intArray.Min(floatFunc);

                Assert.That(() => intArray.MinOrDefault(floatFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithFloatFunc_WithFloatValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var intArrayMin = intArray.Min(floatFunc);
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => intArray.MinOrDefault(floatFunc, floatValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithIntFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intArrayMin = intArray.Min(intFunc);

                Assert.That(() => intArray.MinOrDefault(intFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithIntFunc_WithIntValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intArrayMin = intArray.Min(intFunc);
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => intArray.MinOrDefault(intFunc, intValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithIntValue_ReturnsIntArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var intValue = fixture.CreateAnonymous<int>();
                var intArrayMin = intArray.Min();

                Assert.That(() => intArray.MinOrDefault(intValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithLongFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var intArrayMin = intArray.Min(longFunc);

                Assert.That(() => intArray.MinOrDefault(longFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithLongfunc_WithLongValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();
                var intArrayMin = intArray.Min(longFunc);

                Assert.That(() => intArray.MinOrDefault(longFunc, longValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableDecimalFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var intArrayMin = intArray.Min(nullableDecimalFunc);

                Assert.That(() => intArray.MinOrDefault(nullableDecimalFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableDecimalFunc_WithDecimalValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var intArrayMin = intArray.Min(nullableDecimalFunc);
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => intArray.MinOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableDoubleFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var intArrayMin = intArray.Min(nullableDoubleFunc);

                Assert.That(() => intArray.MinOrDefault(nullableDoubleFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableDoubleFunc_WithDoubleValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var intArrayMin = intArray.Min(nullableDoubleFunc);
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => intArray.MinOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableFloatFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var intArrayMin = intArray.Min(nullableFloatFunc);

                Assert.That(() => intArray.MinOrDefault(nullableFloatFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableFloatFunc_WithFloatValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var intArrayMin = intArray.Min(nullableFloatFunc);
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => intArray.MinOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableIntFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intArrayMin = intArray.Min(nullableIntFunc);

                Assert.That(() => intArray.MinOrDefault(nullableIntFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableIntFunc_WithIntValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intArrayMin = intArray.Min(nullableIntFunc);
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => intArray.MinOrDefault(nullableIntFunc, intValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableLongFunc_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var intArrayMin = intArray.Min(nullableLongFunc);

                Assert.That(() => intArray.MinOrDefault(nullableLongFunc), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnIntArray_WithNullableLongFunc_WithLongValue_ReturnsMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.CreateAnonymous<int[]>();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var intArrayMin = intArray.Min(nullableLongFunc);
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => intArray.MinOrDefault(nullableLongFunc, longValue), Is.EqualTo(intArrayMin));
            }

            [Test]
            public void MinOrDefault_OnLongArray_ReturnsLongArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.CreateAnonymous<long[]>();
                var longArrayMin = longArray.Min();

                Assert.That(() => longArray.MinOrDefault(), Is.EqualTo(longArrayMin));
            }

            [Test]
            public void MinOrDefault_OnLongArray_WithLongValue_ReturnsLongArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.CreateAnonymous<long[]>();
                var longArrayMin = longArray.Min();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => longArray.MinOrDefault(longValue), Is.EqualTo(longArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnNullDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal> nullDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullDecimalSequence.MinOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double> nullDoubleSequence = null;

                Assert.That(() => nullDoubleSequence.MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnNullDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double> nullDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullDoubleSequence.MinOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float> nullFloatSequence = null;

                Assert.That(() => nullFloatSequence.MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnNullFloatSequence_WithFloatValue_RetursFloatValue()
            {
                IEnumerable<float> nullFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullFloatSequence.MinOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithFunc_ReturnsDefault()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MinOrDefault(comparableFunc), Is.EqualTo(default(GenericComparable)));
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MinOrDefault(nullFunc), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithNullValue_ReturnsNull()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;

                Assert.That(() => nullComparableEnumerable.MinOrDefault(nullComparable), Is.Null);
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithNullValue_WithFunc_ReturnsNull()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;
                var fixture = new BaseFixture();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MinOrDefault(comparableFunc, nullComparable), Is.Null);
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithNullValue_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                GenericComparable nullComparable = null;
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MinOrDefault(nullFunc, nullComparable), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithValue_ReturnsValue()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();

                Assert.That(() => nullComparableEnumerable.MinOrDefault(comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithValue_WithFunc_ReturnsValue()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                var comparableFunc = fixture.CreateAnonymous<Func<GenericComparable, GenericComparable>>();

                Assert.That(() => nullComparableEnumerable.MinOrDefault(comparableFunc, comparableValue), Is.EqualTo(comparableValue));
            }

            [Test]
            public void MinOrDefault_OnNullGenericEnumerable_WithValue_WithNullFunc_ThrowsValidationException()
            {
                IEnumerable<GenericComparable> nullComparableEnumerable = null;
                var fixture = new BaseFixture();
                var comparableValue = fixture.CreateAnonymous<GenericComparable>();
                Func<GenericComparable, GenericComparable> nullFunc = null;

                Assert.That(() => nullComparableEnumerable.MinOrDefault(nullFunc, comparableValue), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;

                Assert.That(() => nullIntSequence.MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();

                Assert.That(() => nullIntSequence.MinOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalFunc = fixture.CreateAnonymous<Func<int, decimal>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullIntSequence.MinOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();

                Assert.That(() => nullIntSequence.MinOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.CreateAnonymous<Func<int, double>>();
                var doubeValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullIntSequence.MinOrDefault(doubleFunc, doubeValue), Is.EqualTo(doubeValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();

                Assert.That(() => nullIntSequence.MinOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var floatFunc = fixture.CreateAnonymous<Func<int, float>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullIntSequence.MinOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();

                Assert.That(() => nullIntSequence.MinOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intFunc = fixture.CreateAnonymous<Func<int, int>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MinOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MinOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();

                Assert.That(() => nullIntSequence.MinOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var longFunc = fixture.CreateAnonymous<Func<int, long>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullIntSequence.MinOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDecimalFunc = fixture.CreateAnonymous<Func<int, decimal?>>();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDoubleFunc = fixture.CreateAnonymous<Func<int, double?>>();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableFloatFunc = fixture.CreateAnonymous<Func<int, float?>>();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableIntFunc = fixture.CreateAnonymous<Func<int, int?>>();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                IEnumerable<int> nullIntSequence = null;
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnNullIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableLongFunc = fixture.CreateAnonymous<Func<int, long?>>();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullIntSequence.MinOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long> nullLongSequence = null;

                Assert.That(() => nullLongSequence.MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnNullLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long> nullLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullLongSequence.MinOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal?> nullNullableDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.CreateAnonymous<decimal>();

                Assert.That(() => nullNullableDecimalSequence.MinOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;

                Assert.That(() => nullNullableDoubleSequence.MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullNullableDoubleSequence.MinOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;

                Assert.That(() => nullNullableFloatSequence.MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void MinOrDefault_OnNullNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullNullableFloatSequence.MinOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int?> nullNullableIntSequence = null;

                Assert.That(() => nullNullableIntSequence.MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void MinOrDefault_OnNullNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int?> nullNullableIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullNullableIntSequence.MinOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long?> nullNullableLongSequence = null;

                Assert.That(() => nullNullableLongSequence.MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void MinOrDefault_OnNullNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long?> nullNullableLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullNullableLongSequence.MinOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void MinOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.CreateAnonymous<decimal?[]>();
                var nullableDecimalArrayMin = nullableDecimalArray.Min();

                Assert.That(() => nullableDecimalArray.MinOrDefault(), Is.EqualTo(nullableDecimalArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableDecimalArray_WithDecimalValue_ReturnsNullableDecimalArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.CreateAnonymous<decimal?[]>();
                var decimalValue = fixture.CreateAnonymous<decimal>();
                var nullableDecimalArrayMin = nullableDecimalArray.Min();

                Assert.That(() => nullableDecimalArray.MinOrDefault(decimalValue), Is.EqualTo(nullableDecimalArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.CreateAnonymous<double?[]>();
                var nullableDoubleArrayMin = nullableDoubleArray.Min();

                Assert.That(() => nullableDoubleArray.MinOrDefault(), Is.EqualTo(nullableDoubleArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableDoubleArray_WithDoubleValue_ReturnsNullableDoubleArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.CreateAnonymous<double?[]>();
                var nullableDoubleArrayMin = nullableDoubleArray.Min();
                var doubleValue = fixture.CreateAnonymous<double>();

                Assert.That(() => nullableDoubleArray.MinOrDefault(doubleValue), Is.EqualTo(nullableDoubleArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.CreateAnonymous<float?[]>();
                var nullableFloatArrayMin = nullableFloatArray.Min();

                Assert.That(() => nullableFloatArray.MinOrDefault(), Is.EqualTo(nullableFloatArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableFloatArray_WithFloatValue_ReturnsNullableFloatArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.CreateAnonymous<float?[]>();
                var nullableFloatArrayMin = nullableFloatArray.Min();
                var floatValue = fixture.CreateAnonymous<float>();

                Assert.That(() => nullableFloatArray.MinOrDefault(floatValue), Is.EqualTo(nullableFloatArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableIntArray_RetunrsNullableIntArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.CreateAnonymous<int?[]>();
                var nullableIntArrayMin = nullableIntArray.Min();

                Assert.That(() => nullableIntArray.MinOrDefault(), Is.EqualTo(nullableIntArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableIntArray_WithIntValue_ReturnsNullableIntArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.CreateAnonymous<int?[]>();
                var nullableIntArrayMin = nullableIntArray.Min();
                var intValue = fixture.CreateAnonymous<int>();

                Assert.That(() => nullableIntArray.MinOrDefault(intValue), Is.EqualTo(nullableIntArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableLongArray_ReturnsNullableLongArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.CreateAnonymous<long?[]>();
                var nullableLongArrayMin = nullableLongArray.Min();

                Assert.That(() => nullableLongArray.MinOrDefault(), Is.EqualTo(nullableLongArrayMin));
            }

            [Test]
            public void MinOrDefault_OnNullableLongArray_WithLongValue_ReturnsNullableLongArrayMin()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.CreateAnonymous<long?[]>();
                var nullableLongArrayMin = nullableLongArray.Min();
                var longValue = fixture.CreateAnonymous<long>();

                Assert.That(() => nullableLongArray.MinOrDefault(longValue), Is.EqualTo(nullableLongArrayMin));
            }
        }
    }
}