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
        public class MinOrDefaultTest
        {
            [Test]
            public void MinOrDefault_OnDecimalArray_ReturnsMin()
            {
                Assert.That(DecimalArray.MinOrDefault(), Is.EqualTo(DecimalArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnDecimalArray_WithTestDecimalValue_ReturnsMin()
            {
                Assert.That(DecimalArray.MinOrDefault(TestDecimalValue), Is.EqualTo(DecimalArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnDoubleArray_ReturnsDoubleArrayMin()
            {
                Assert.That(DoubleArray.MinOrDefault(), Is.EqualTo(DoubleArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnDoubleArray_WithTestDoubleValue_ReturnsDoubleArrayMin()
            {
                Assert.That(DoubleArray.MinOrDefault(TestDoubleValue), Is.EqualTo(DoubleArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyDecimalSequence.MinOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnEmptyDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyDecimalSequence.MinOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyDoubleSequence.MinOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnEmptyDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyDoubleSequence.MinOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyFloatSequence.MinOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnEmptyFloatSequence_WithTestFloatValue_ReturnsTestFloatvalue()
            {
                Assert.That(EmptyFloatSequence.MinOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableDuoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MinOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyLongSequence.MinOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnEmptyLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyLongSequence.MinOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyNullableDecimalSequence.MinOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyNullableDecimalSequence.MinOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyNullableDoubleSequence.MinOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyNullableDoubleSequence.MinOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyNullableFloatSequence.MinOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyNullableFloatSequence.MinOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyNullableIntegerSequence.MinOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyNullableIntegerSequence.MinOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyNullableLongSequence.MinOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnEmptyNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyNullableLongSequence.MinOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnFloatArray_ReturnsFloatArrayMin()
            {
                Assert.That(FloatArray.MinOrDefault(), Is.EqualTo(FloatArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnFloatArray_WithTestFloatValue_ReturnsFloatArrayMin()
            {
                Assert.That(FloatArray.MinOrDefault(TestFloatValue), Is.EqualTo(FloatArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_ReturnsIntegerArrayMin()
            {
                Assert.That(IntegerArray.MinOrDefault(), Is.EqualTo(IntegerArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithDecimalFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(DecimalFunc), Is.EqualTo(IntegerArray.Select(DecimalFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithDecimalFunc_WithTestDecimalvalue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(DecimalFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithDoubleFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(DoubleFunc), Is.EqualTo(IntegerArray.Select(DoubleFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithDoubleFunc_WithTestDoubleValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(DoubleFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithFloatFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(FloatFunc), Is.EqualTo(IntegerArray.Select(FloatFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithFloatFunc_WithTestFloatValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(FloatFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithIntFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(IntFunc), Is.EqualTo(IntegerArray.Select(IntFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithIntFunc_WithTestIntegerValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(IntFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithLongFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(LongFunc), Is.EqualTo(IntegerArray.Select(LongFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableDecimalFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableDecimalFunc), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableDoubleFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableDoubleFunc), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableFloatFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableFloatFunc), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableFloatFunc_WithTestFloatValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableIntFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableIntFunc), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableIntFunc_WithTestIntegerValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableLongFunc_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableLongFunc), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithNullableLongFunc_WithTestLongValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Min()));
            }

            [Test]
            public void MinOrDefault_OnIntegerArray_WithTestIntegerValue_ReturnsIntegerArrayMin()
            {
                Assert.That(IntegerArray.MinOrDefault(TestIntegerValue), Is.EqualTo(IntegerArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnLongArray_ReturnsLongArrayMin()
            {
                Assert.That(LongArray.MinOrDefault(), Is.EqualTo(LongArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnLongArray_WithTestLongValue_ReturnsLongArrayMin()
            {
                Assert.That(LongArray.MinOrDefault(TestLongValue), Is.EqualTo(LongArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullDecimalSequence.MinOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnNullDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullDecimalSequence.MinOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullDoubleSequence.MinOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnNullDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullDoubleSequence.MinOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullFloatSequence.MinOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnNullFloatSequence_WithTestFloatValue_RetursTestFloatValue()
            {
                Assert.That(NullFloatSequence.MinOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnNullIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullLongSequence.MinOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnNullLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullLongSequence.MinOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullNullableDecimalSequence.MinOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullNullableDecimalSequence.MinOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullNullableDoubleSequence.MinOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MinOrDefault_OnNullNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullNullableDoubleSequence.MinOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullNullableFloatSequence.MinOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MinOrDefault_OnNullNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullNullableFloatSequence.MinOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullNullableIntegerSequence.MinOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MinOrDefault_OnNullNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullNullableIntegerSequence.MinOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MinOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullNullableLongSequence.MinOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinOrDefault_OnNullNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullNullableLongSequence.MinOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MinOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayMin()
            {
                Assert.That(NullableDecimalArray.MinOrDefault(), Is.EqualTo(NullableDecimalArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableDecimalArray_WithTestDecimalValue_REturnsNullableDecimalArrayMin()
            {
                Assert.That(NullableDecimalArray.MinOrDefault(TestDecimalValue), Is.EqualTo(NullableDecimalArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayMin()
            {
                Assert.That(NullableDoubleArray.MinOrDefault(), Is.EqualTo(NullableDoubleArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableDoubleArray_WithTestDoubleValue_ReturnsNullableDoubleArrayMin()
            {
                Assert.That(NullableDoubleArray.MinOrDefault(TestDoubleValue), Is.EqualTo(NullableDoubleArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayMin()
            {
                Assert.That(NullableFloatArray.MinOrDefault(), Is.EqualTo(NullableFloatArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableFloatArray_WithTestFloatValue_ReturnsNullableFloatArrayMin()
            {
                Assert.That(NullableFloatArray.MinOrDefault(TestFloatValue), Is.EqualTo(NullableFloatArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableIntegerArray_RetunrsNullableIntegerArrayMin()
            {
                Assert.That(NullableIntegerArray.MinOrDefault(), Is.EqualTo(NullableIntegerArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableIntegerArray_WithTestIntegerValue_ReturnsNullableIntegerArrayMin()
            {
                Assert.That(NullableIntegerArray.MinOrDefault(TestIntegerValue), Is.EqualTo(NullableIntegerArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableLongArray_ReturnsNullableLongArrayMin()
            {
                Assert.That(NullableLongArray.MinOrDefault(), Is.EqualTo(NullableLongArray.Min()));
            }

            [Test]
            public void MinOrDefault_OnNullableLongArray_WithTestLongValue_ReturnsNullableLongArrayMin()
            {
                Assert.That(NullableLongArray.MinOrDefault(TestLongValue), Is.EqualTo(NullableLongArray.Min()));
            }

            [Test]
            public void MinOrDefault_onNullIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.MinOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MinorDefault_OnIntegerArray_WithLongfunc_WithTestLongValue_ReturnsMin()
            {
                Assert.That(IntegerArray.MinOrDefault(LongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(LongFunc).Min()));
            }
        }
    }
}