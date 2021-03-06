﻿#region License and Terms

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
using System.Collections.Generic;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.UnitTests.Customization.Fixtures;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class AverageOrDefaultTest
        {
            [Test]
            public void AverageOrDefault_OnDecimalArray_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.Create<decimal[]>();
                var decimalArrayAverage = decimalArray.Average();

                Assert.That(() => decimalArray.AverageOrDefault(), Is.EqualTo(decimalArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnDecimalArray_WithDecimalValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var decimalArray = fixture.Create<decimal[]>();
                var decimalArrayAverage = decimalArray.Average();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => decimalArray.AverageOrDefault(decimalValue), Is.EqualTo(decimalArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnDoubleArray_ReturnsDoubleArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.Create<double[]>();
                var doubleArrayAverage = doubleArray.Average();

                Assert.That(() => doubleArray.AverageOrDefault(), Is.EqualTo(doubleArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnDoubleArray_WithDoubleValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var doubleArray = fixture.Create<double[]>();
                var doubleArrayAverage = doubleArray.Average();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => doubleArray.AverageOrDefault(doubleValue), Is.EqualTo(doubleArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();

                Assert.That(() => emtpyDecimalSequence.AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emtpyDecimalSequence = Enumerable.Empty<decimal>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => emtpyDecimalSequence.AverageOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyDoubleSequence = Enumerable.Empty<double>();

                Assert.That(() => emptyDoubleSequence.AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyDoubleSequence = Enumerable.Empty<double>();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => emptyDoubleSequence.AverageOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                var emptyFloatSequence = Enumerable.Empty<float>();

                Assert.That(() => emptyFloatSequence.AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyFloatSequence_WithFloatValue_ReturnsFloatvalue()
            {
                var fixture = new RandomNumberFixture();
                var emptyFloatSequence = Enumerable.Empty<float>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => emptyFloatSequence.AverageOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_ReturnsDefaultInt()
            {
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.Create<Func<int, decimal>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var decimalFunc = fixture.Create<Func<int, decimal>>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var doubleFunc = fixture.Create<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.Create<Func<int, double>>();
                var emptyIntSequence = Enumerable.Empty<int>();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(doubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.Create<Func<int, float>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var floatFunc = fixture.Create<Func<int, float>>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.Create<Func<int, int>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intFunc = fixture.Create<Func<int, int>>();
                var intValue = fixture.Create<int>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var intValue = fixture.Create<int>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.Create<Func<int, long>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var longFunc = fixture.Create<Func<int, long>>();
                var longValue = fixture.Create<long>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableDuoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();
                var intValue = fixture.Create<int>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.Create<Func<int, long?>>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyIntSequence = Enumerable.Empty<int>();
                var nullableLongFunc = fixture.Create<Func<int, long?>>();
                var longValue = fixture.Create<long>();

                Assert.That(() => emptyIntSequence.AverageOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                var emptyLongSequence = Enumerable.Empty<long>();

                Assert.That(() => emptyLongSequence.AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyLongSequence = Enumerable.Empty<long>();
                var longValue = fixture.Create<long>();

                Assert.That(() => emptyLongSequence.AverageOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();

                Assert.That(() => emptyNullableDecimalSequence.AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDecimalSequence = Enumerable.Empty<decimal?>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => emptyNullableDecimalSequence.AverageOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();

                Assert.That(() => emptyNullableDoubleSequence.AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableDoubleSequence = Enumerable.Empty<double?>();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => emptyNullableDoubleSequence.AverageOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();

                Assert.That(() => emptyNullableFloatSequence.AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableFloatSequence = Enumerable.Empty<float?>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => emptyNullableFloatSequence.AverageOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableIntSequence_ReturnsDefaultInt()
            {
                var emptyNullableIntSequence = Enumerable.Empty<int?>();

                Assert.That(() => emptyNullableIntSequence.AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableIntSequence = Enumerable.Empty<int?>();
                var intValue = fixture.Create<int>();

                Assert.That(() => emptyNullableIntSequence.AverageOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();

                Assert.That(() => emptyNullableLongSequnce.AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                var fixture = new RandomNumberFixture();
                var emptyNullableLongSequnce = Enumerable.Empty<long?>();
                var longValue = fixture.Create<long>();

                Assert.That(() => emptyNullableLongSequnce.AverageOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnFloatArray_ReturnsFloatArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.Create<float[]>();
                var floatArrayAverage = floatArray.Average();

                Assert.That(() => floatArray.AverageOrDefault(), Is.EqualTo(floatArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnFloatArray_WithFloatValue_ReturnsFloatArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var floatArray = fixture.Create<float[]>();
                var floatArrayAverage = floatArray.Average();
                var floatValue = fixture.Create<float>();

                Assert.That(() => floatArray.AverageOrDefault(floatValue), Is.EqualTo(floatArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_ReturnsIntArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var intArrayAverage = intArray.Average();

                Assert.That(() => intArray.AverageOrDefault(), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithDecimalFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var decimalFunc = fixture.Create<Func<int, decimal>>();
                var intArrayAverage = intArray.Average(decimalFunc);

                Assert.That(() => intArray.AverageOrDefault(decimalFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithDecimalFunc_WithDecimalvalue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var decimalFunc = fixture.Create<Func<int, decimal>>();
                var intArrayAverage = intArray.Average(decimalFunc);
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => intArray.AverageOrDefault(decimalFunc, decimalValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithDoubleFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var doubleFunc = fixture.Create<Func<int, double>>();
                var intArrayAverage = intArray.Average(doubleFunc);

                Assert.That(() => intArray.AverageOrDefault(doubleFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithDoubleFunc_WithDoubleValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var doubleFunc = fixture.Create<Func<int, double>>();
                var intArrayAverage = intArray.Average(doubleFunc);
                var doubleValue = fixture.Create<double>();

                Assert.That(() => intArray.AverageOrDefault(doubleFunc, doubleValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithFloatFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var floatFunc = fixture.Create<Func<int, float>>();
                var intArrayAverage = intArray.Average(floatFunc);

                Assert.That(() => intArray.AverageOrDefault(floatFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithFloatFunc_WithFloatValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var floatFunc = fixture.Create<Func<int, float>>();
                var intArrayAverage = intArray.Average(floatFunc);
                var floatValue = fixture.Create<float>();

                Assert.That(() => intArray.AverageOrDefault(floatFunc, floatValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithIntFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var intFunc = fixture.Create<Func<int, int>>();
                var intArrayAverage = intArray.Average(intFunc);

                Assert.That(() => intArray.AverageOrDefault(intFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithIntFunc_WithIntValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var intFunc = fixture.Create<Func<int, int>>();
                var intArrayAverage = intArray.Average(intFunc);
                var intValue = fixture.Create<int>();

                Assert.That(() => intArray.AverageOrDefault(intFunc, intValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithIntValue_ReturnsIntArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var intValue = fixture.Create<int>();
                var intArrayAverage = intArray.Average();

                Assert.That(() => intArray.AverageOrDefault(intValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithLongFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var longFunc = fixture.Create<Func<int, long>>();
                var intArrayAverage = intArray.Average(longFunc);

                Assert.That(() => intArray.AverageOrDefault(longFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithLongfunc_WithLongValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var longFunc = fixture.Create<Func<int, long>>();
                var longValue = fixture.Create<long>();
                var intArrayAverage = intArray.Average(longFunc);

                Assert.That(() => intArray.AverageOrDefault(longFunc, longValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableDecimalFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();
                var intArrayAverage = intArray.Average(nullableDecimalFunc);

                Assert.That(() => intArray.AverageOrDefault(nullableDecimalFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableDecimalFunc_WithDecimalValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();
                var intArrayAverage = intArray.Average(nullableDecimalFunc);
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => intArray.AverageOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableDoubleFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();
                var intArrayAverage = intArray.Average(nullableDoubleFunc);

                Assert.That(() => intArray.AverageOrDefault(nullableDoubleFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableDoubleFunc_WithDoubleValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();
                var intArrayAverage = intArray.Average(nullableDoubleFunc);
                var doubleValue = fixture.Create<double>();

                Assert.That(() => intArray.AverageOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableFloatFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();
                var intArrayAverage = intArray.Average(nullableFloatFunc);

                Assert.That(() => intArray.AverageOrDefault(nullableFloatFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableFloatFunc_WithFloatValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();
                var intArrayAverage = intArray.Average(nullableFloatFunc);
                var floatValue = fixture.Create<float>();

                Assert.That(() => intArray.AverageOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableIntFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();
                var intArrayAverage = intArray.Average(nullableIntFunc);

                Assert.That(() => intArray.AverageOrDefault(nullableIntFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableIntFunc_WithIntValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();
                var intArrayAverage = intArray.Average(nullableIntFunc);
                var intValue = fixture.Create<int>();

                Assert.That(() => intArray.AverageOrDefault(nullableIntFunc, intValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableLongFunc_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableLongFunc = fixture.Create<Func<int, long?>>();
                var intArrayAverage = intArray.Average(nullableLongFunc);

                Assert.That(() => intArray.AverageOrDefault(nullableLongFunc), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnIntArray_WithNullableLongFunc_WithLongValue_ReturnsAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var intArray = fixture.Create<int[]>();
                var nullableLongFunc = fixture.Create<Func<int, long?>>();
                var intArrayAverage = intArray.Average(nullableLongFunc);
                var longValue = fixture.Create<long>();

                Assert.That(() => intArray.AverageOrDefault(nullableLongFunc, longValue), Is.EqualTo(intArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnLongArray_ReturnsLongArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.Create<long[]>();
                var longArrayAverage = longArray.Average();

                Assert.That(() => longArray.AverageOrDefault(), Is.EqualTo(longArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnLongArray_WithLongValue_ReturnsLongArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var longArray = fixture.Create<long[]>();
                var longArrayAverage = longArray.Average();
                var longValue = fixture.Create<long>();

                Assert.That(() => longArray.AverageOrDefault(longValue), Is.EqualTo(longArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnNullDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal> nullDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => nullDecimalSequence.AverageOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double> nullDoubleSequence = null;

                Assert.That(() => nullDoubleSequence.AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnNullDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double> nullDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => nullDoubleSequence.AverageOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float> nullFloatSequence = null;

                Assert.That(() => nullFloatSequence.AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnNullFloatSequence_WithFloatValue_RetursFloatValue()
            {
                IEnumerable<float> nullFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.Create<float>();

                Assert.That(() => nullFloatSequence.AverageOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;

                Assert.That(() => nullIntSequence.AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var decimalFunc = fixture.Create<Func<int, decimal>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalFunc = fixture.Create<Func<int, decimal>>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => nullIntSequence.AverageOrDefault(decimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var doubleFunc = fixture.Create<Func<int, double>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleFunc = fixture.Create<Func<int, double>>();
                var doubeValue = fixture.Create<double>();

                Assert.That(() => nullIntSequence.AverageOrDefault(doubleFunc, doubeValue), Is.EqualTo(doubeValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var floatFunc = fixture.Create<Func<int, float>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var floatFunc = fixture.Create<Func<int, float>>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => nullIntSequence.AverageOrDefault(floatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var intFunc = fixture.Create<Func<int, int>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intFunc = fixture.Create<Func<int, int>>();
                var intValue = fixture.Create<int>();

                Assert.That(() => nullIntSequence.AverageOrDefault(intFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();

                Assert.That(() => nullIntSequence.AverageOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithLongFunc_ReturnsDefaultLong()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var longFunc = fixture.Create<Func<int, long>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var longFunc = fixture.Create<Func<int, long>>();
                var longValue = fixture.Create<long>();

                Assert.That(() => nullIntSequence.AverageOrDefault(longFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableDecimalFunc_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDecimalFunc = fixture.Create<Func<int, decimal?>>();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableDecimalFunc, decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableDoubleFunc_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableDoubleFunc = fixture.Create<Func<int, double?>>();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableDoubleFunc, doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableFloatFunc_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableFloatFunc = fixture.Create<Func<int, float?>>();
                var floatValue = fixture.Create<float>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableFloatFunc, floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableIntFunc_ReturnsDefaultInt()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new BaseFixture();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableIntFunc_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableIntFunc = fixture.Create<Func<int, int?>>();
                var intValue = fixture.Create<int>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableIntFunc, intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                var fixture = new BaseFixture();
                IEnumerable<int> nullIntSequence = null;
                var nullableLongFunc = fixture.Create<Func<int, long?>>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnNullIntSequence_WithNullableLongFunc_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<int> nullIntSequence = null;
                var fixture = new RandomNumberFixture();
                var nullableLongFunc = fixture.Create<Func<int, long?>>();
                var longValue = fixture.Create<long>();

                Assert.That(() => nullIntSequence.AverageOrDefault(nullableLongFunc, longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long> nullLongSequence = null;

                Assert.That(() => nullLongSequence.AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnNullLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long> nullLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.Create<long>();

                Assert.That(() => nullLongSequence.AverageOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                IEnumerable<decimal> nullDecimalSequence = null;

                Assert.That(() => nullDecimalSequence.AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDecimalSequence_WithDecimalValue_ReturnsDecimalValue()
            {
                IEnumerable<decimal?> nullNullableDecimalSequence = null;
                var fixture = new RandomNumberFixture();
                var decimalValue = fixture.Create<decimal>();

                Assert.That(() => nullNullableDecimalSequence.AverageOrDefault(decimalValue), Is.EqualTo(decimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;

                Assert.That(() => nullNullableDoubleSequence.AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDoubleSequence_WithDoubleValue_ReturnsDoubleValue()
            {
                IEnumerable<double?> nullNullableDoubleSequence = null;
                var fixture = new RandomNumberFixture();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => nullNullableDoubleSequence.AverageOrDefault(doubleValue), Is.EqualTo(doubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;

                Assert.That(() => nullNullableFloatSequence.AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableFloatSequence_WithFloatValue_ReturnsFloatValue()
            {
                IEnumerable<float?> nullNullableFloatSequence = null;
                var fixture = new RandomNumberFixture();
                var floatValue = fixture.Create<float>();

                Assert.That(() => nullNullableFloatSequence.AverageOrDefault(floatValue), Is.EqualTo(floatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableIntSequence_ReturnsDefaultInt()
            {
                IEnumerable<int?> nullNullableIntSequence = null;

                Assert.That(() => nullNullableIntSequence.AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableIntSequence_WithIntValue_ReturnsIntValue()
            {
                IEnumerable<int?> nullNullableIntSequence = null;
                var fixture = new RandomNumberFixture();
                var intValue = fixture.Create<int>();

                Assert.That(() => nullNullableIntSequence.AverageOrDefault(intValue), Is.EqualTo(intValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                IEnumerable<long?> nullNullableLongSequence = null;

                Assert.That(() => nullNullableLongSequence.AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableLongSequence_WithLongValue_ReturnsLongValue()
            {
                IEnumerable<long?> nullNullableLongSequence = null;
                var fixture = new RandomNumberFixture();
                var longValue = fixture.Create<long>();

                Assert.That(() => nullNullableLongSequence.AverageOrDefault(longValue), Is.EqualTo(longValue));
            }

            [Test]
            public void AverageOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.Create<decimal?[]>();
                var nullableDecimalArrayAverage = nullableDecimalArray.Average();

                Assert.That(() => nullableDecimalArray.AverageOrDefault(), Is.EqualTo(nullableDecimalArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableDecimalArray_WithDecimalValue_ReturnsNullableDecimalArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDecimalArray = fixture.Create<decimal?[]>();
                var decimalValue = fixture.Create<decimal>();
                var nullableDecimalArrayAverage = nullableDecimalArray.Average();

                Assert.That(() => nullableDecimalArray.AverageOrDefault(decimalValue), Is.EqualTo(nullableDecimalArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.Create<double?[]>();
                var nullableDoubleArrayAverage = nullableDoubleArray.Average();

                Assert.That(() => nullableDoubleArray.AverageOrDefault(), Is.EqualTo(nullableDoubleArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableDoubleArray_WithDoubleValue_ReturnsNullableDoubleArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableDoubleArray = fixture.Create<double?[]>();
                var nullableDoubleArrayAverage = nullableDoubleArray.Average();
                var doubleValue = fixture.Create<double>();

                Assert.That(() => nullableDoubleArray.AverageOrDefault(doubleValue), Is.EqualTo(nullableDoubleArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.Create<float?[]>();
                var nullableFloatArrayAverage = nullableFloatArray.Average();

                Assert.That(() => nullableFloatArray.AverageOrDefault(), Is.EqualTo(nullableFloatArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableFloatArray_WithFloatValue_ReturnsNullableFloatArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableFloatArray = fixture.Create<float?[]>();
                var nullableFloatArrayAverage = nullableFloatArray.Average();
                var floatValue = fixture.Create<float>();

                Assert.That(() => nullableFloatArray.AverageOrDefault(floatValue), Is.EqualTo(nullableFloatArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableIntArray_RetunrsNullableIntArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.Create<int?[]>();
                var nullableIntArrayAverage = nullableIntArray.Average();

                Assert.That(() => nullableIntArray.AverageOrDefault(), Is.EqualTo(nullableIntArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableIntArray_WithIntValue_ReturnsNullableIntArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableIntArray = fixture.Create<int?[]>();
                var nullableIntArrayAverage = nullableIntArray.Average();
                var intValue = fixture.Create<int>();

                Assert.That(() => nullableIntArray.AverageOrDefault(intValue), Is.EqualTo(nullableIntArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableLongArray_ReturnsNullableLongArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.Create<long?[]>();
                var nullableLongArrayAverage = nullableLongArray.Average();

                Assert.That(() => nullableLongArray.AverageOrDefault(), Is.EqualTo(nullableLongArrayAverage));
            }

            [Test]
            public void AverageOrDefault_OnNullableLongArray_WithLongValue_ReturnsNullableLongArrayAverage()
            {
                var fixture = new RandomMultipleMockingFixture();
                var nullableLongArray = fixture.Create<long?[]>();
                var nullableLongArrayAverage = nullableLongArray.Average();
                var longValue = fixture.Create<long>();

                Assert.That(() => nullableLongArray.AverageOrDefault(longValue), Is.EqualTo(nullableLongArrayAverage));
            }
        }
    }
}