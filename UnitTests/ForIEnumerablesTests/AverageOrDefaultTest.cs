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

using System.Linq;
using CustomExtensions.ForIEnumerable;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class AverageOrDefaultTest
        {            
            [Test]
            public void AverageOrDefault_OnDecimalArray_ReturnsAverage()
            {
                Assert.That(DecimalArray.AverageOrDefault(), Is.EqualTo(DecimalArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnDecimalArray_WithTestDecimalValue_ReturnsAverage()
            {
                Assert.That(DecimalArray.AverageOrDefault(TestDecimalValue), Is.EqualTo(DecimalArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnDoubleArray_ReturnsDoubleArrayAverage()
            {
                Assert.That(DoubleArray.AverageOrDefault(), Is.EqualTo(DoubleArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnDoubleArray_WithTestDoubleValue_ReturnsDoubleArrayAverage()
            {
                Assert.That(DoubleArray.AverageOrDefault(TestDoubleValue), Is.EqualTo(DoubleArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyDecimalSequence.AverageOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyDecimalSequence.AverageOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyDoubleSequence.AverageOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnEmptyDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyDoubleSequence.AverageOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyFloatSequence.AverageOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnEmptyFloatSequence_WithTestFloatValue_ReturnsTestFloatvalue()
            {
                Assert.That(EmptyFloatSequence.AverageOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableDuoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.AverageOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyLongSequence.AverageOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnEmptyLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyLongSequence.AverageOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyNullableDecimalSequence.AverageOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyNullableDecimalSequence.AverageOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyNullableDoubleSequence.AverageOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyNullableDoubleSequence.AverageOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyNullableFloatSequence.AverageOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyNullableFloatSequence.AverageOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyNullableIntegerSequence.AverageOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyNullableIntegerSequence.AverageOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyNullableLongSequence.AverageOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnEmptyNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyNullableLongSequence.AverageOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnFloatArray_ReturnsFloatArrayAverage()
            {
                Assert.That(FloatArray.AverageOrDefault(), Is.EqualTo(FloatArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnFloatArray_WithTestFloatValue_ReturnsFloatArrayAverage()
            {
                Assert.That(FloatArray.AverageOrDefault(TestFloatValue), Is.EqualTo(FloatArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_ReturnsIntegerArrayAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(), Is.EqualTo(IntegerArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithDecimalFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(DecimalFunc), Is.EqualTo(IntegerArray.Select(DecimalFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithDecimalFunc_WithTestDecimalvalue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(DecimalFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithDoubleFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(DoubleFunc), Is.EqualTo(IntegerArray.Select(DoubleFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithDoubleFunc_WithTestDoubleValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(DoubleFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithFloatFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(FloatFunc), Is.EqualTo(IntegerArray.Select(FloatFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithFloatFunc_WithTestFloatValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(FloatFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithIntFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(IntFunc), Is.EqualTo(IntegerArray.Select(IntFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithIntFunc_WithTestIntegerValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(IntFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithLongFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(LongFunc), Is.EqualTo(IntegerArray.Select(LongFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableDecimalFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableDecimalFunc), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableDoubleFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableDoubleFunc), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableFloatFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableFloatFunc), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableFloatFunc_WithTestFloatValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableIntFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableIntFunc), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableIntFunc_WithTestIntegerValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableLongFunc_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableLongFunc), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithNullableLongFunc_WithTestLongValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Average()));
            }

            [Test]
            public void AverageOrDefault_OnIntegerArray_WithTestIntegerValue_ReturnsIntegerArrayAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(TestIntegerValue), Is.EqualTo(IntegerArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnLongArray_ReturnsLongArrayAverage()
            {
                Assert.That(LongArray.AverageOrDefault(), Is.EqualTo(LongArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnLongArray_WithTestLongValue_ReturnsLongArrayAverage()
            {
                Assert.That(LongArray.AverageOrDefault(TestLongValue), Is.EqualTo(LongArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullDecimalSequence.AverageOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnNullDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullDecimalSequence.AverageOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullDoubleSequence.AverageOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnNullDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullDoubleSequence.AverageOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullFloatSequence.AverageOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnNullFloatSequence_WithTestFloatValue_RetursTestFloatValue()
            {
                Assert.That(NullFloatSequence.AverageOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnNullIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullLongSequence.AverageOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnNullLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullLongSequence.AverageOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullNullableDecimalSequence.AverageOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullNullableDecimalSequence.AverageOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullNullableDoubleSequence.AverageOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullNullableDoubleSequence.AverageOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullNullableFloatSequence.AverageOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullNullableFloatSequence.AverageOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullNullableIntegerSequence.AverageOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullNullableIntegerSequence.AverageOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullNullableLongSequence.AverageOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageOrDefault_OnNullNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullNullableLongSequence.AverageOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void AverageOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayAverage()
            {
                Assert.That(NullableDecimalArray.AverageOrDefault(), Is.EqualTo(NullableDecimalArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableDecimalArray_WithTestDecimalValue_REturnsNullableDecimalArrayAverage()
            {
                Assert.That(NullableDecimalArray.AverageOrDefault(TestDecimalValue), Is.EqualTo(NullableDecimalArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayAverage()
            {
                Assert.That(NullableDoubleArray.AverageOrDefault(), Is.EqualTo(NullableDoubleArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableDoubleArray_WithTestDoubleValue_ReturnsNullableDoubleArrayAverage()
            {
                Assert.That(NullableDoubleArray.AverageOrDefault(TestDoubleValue), Is.EqualTo(NullableDoubleArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayAverage()
            {
                Assert.That(NullableFloatArray.AverageOrDefault(), Is.EqualTo(NullableFloatArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableFloatArray_WithTestFloatValue_ReturnsNullableFloatArrayAverage()
            {
                Assert.That(NullableFloatArray.AverageOrDefault(TestFloatValue), Is.EqualTo(NullableFloatArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableIntegerArray_RetunrsNullableIntegerArrayAverage()
            {
                Assert.That(NullableIntegerArray.AverageOrDefault(), Is.EqualTo(NullableIntegerArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableIntegerArray_WithTestIntegerValue_ReturnsNullableIntegerArrayAverage()
            {
                Assert.That(NullableIntegerArray.AverageOrDefault(TestIntegerValue), Is.EqualTo(NullableIntegerArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableLongArray_ReturnsNullableLongArrayAverage()
            {
                Assert.That(NullableLongArray.AverageOrDefault(), Is.EqualTo(NullableLongArray.Average()));
            }

            [Test]
            public void AverageOrDefault_OnNullableLongArray_WithTestLongValue_ReturnsNullableLongArrayAverage()
            {
                Assert.That(NullableLongArray.AverageOrDefault(TestLongValue), Is.EqualTo(NullableLongArray.Average()));
            }

            [Test]
            public void AverageOrDefault_onNullIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.AverageOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void AverageorDefault_OnIntegerArray_WithLongfunc_WithTestLongValue_ReturnsAverage()
            {
                Assert.That(IntegerArray.AverageOrDefault(LongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(LongFunc).Average()));
            }
        }
    }
}