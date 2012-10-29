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
        public class MaxOrDefaultTest
        {
            [Test]
            public void MaxOrDefault_OnDecimalArray_ReturnsMax()
            {
                Assert.That(DecimalArray.MaxOrDefault(), Is.EqualTo(DecimalArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnDecimalArray_WithTestDecimalValue_ReturnsMax()
            {
                Assert.That(DecimalArray.MaxOrDefault(TestDecimalValue), Is.EqualTo(DecimalArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnDoubleArray_ReturnsDoubleArrayMax()
            {
                Assert.That(DoubleArray.MaxOrDefault(), Is.EqualTo(DoubleArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnDoubleArray_WithTestDoubleValue_ReturnsDoubleArrayMax()
            {
                Assert.That(DoubleArray.MaxOrDefault(TestDoubleValue), Is.EqualTo(DoubleArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyDecimalSequence.MaxOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyDecimalSequence.MaxOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyDoubleSequence.MaxOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnEmptyDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyDoubleSequence.MaxOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyFloatSequence.MaxOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnEmptyFloatSequence_WithTestFloatValue_ReturnsTestFloatvalue()
            {
                Assert.That(EmptyFloatSequence.MaxOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableDuoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyIntegerSequence.MaxOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyLongSequence.MaxOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnEmptyLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyLongSequence.MaxOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(EmptyNullableDecimalSequence.MaxOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(EmptyNullableDecimalSequence.MaxOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(EmptyNullableDoubleSequence.MaxOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(EmptyNullableDoubleSequence.MaxOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(EmptyNullableFloatSequence.MaxOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(EmptyNullableFloatSequence.MaxOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(EmptyNullableIntegerSequence.MaxOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(EmptyNullableIntegerSequence.MaxOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(EmptyNullableLongSequence.MaxOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnEmptyNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(EmptyNullableLongSequence.MaxOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnFloatArray_ReturnsFloatArrayMax()
            {
                Assert.That(FloatArray.MaxOrDefault(), Is.EqualTo(FloatArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnFloatArray_WithTestFloatValue_ReturnsFloatArrayMax()
            {
                Assert.That(FloatArray.MaxOrDefault(TestFloatValue), Is.EqualTo(FloatArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_ReturnsIntegerArrayMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(), Is.EqualTo(IntegerArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithDecimalFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(DecimalFunc), Is.EqualTo(IntegerArray.Select(DecimalFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithDecimalFunc_WithTestDecimalvalue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(DecimalFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithDoubleFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(DoubleFunc), Is.EqualTo(IntegerArray.Select(DoubleFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithDoubleFunc_WithTestDoubleValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(DoubleFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithFloatFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(FloatFunc), Is.EqualTo(IntegerArray.Select(FloatFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithFloatFunc_WithTestFloatValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(FloatFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithIntFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(IntFunc), Is.EqualTo(IntegerArray.Select(IntFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithIntFunc_WithTestIntegerValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(IntFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithLongFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(LongFunc), Is.EqualTo(IntegerArray.Select(LongFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableDecimalFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableDecimalFunc), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(IntegerArray.Select(NullableDecimalFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableDoubleFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableDoubleFunc), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(IntegerArray.Select(NullableDoubleFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableFloatFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableFloatFunc), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableFloatFunc_WithTestFloatValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(IntegerArray.Select(NullableFloatFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableIntFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableIntFunc), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableIntFunc_WithTestIntegerValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(IntegerArray.Select(NullableIntFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableLongFunc_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableLongFunc), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithNullableLongFunc_WithTestLongValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(NullableLongFunc).Max()));
            }

            [Test]
            public void MaxOrDefault_OnIntegerArray_WithTestIntegerValue_ReturnsIntegerArrayMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(TestIntegerValue), Is.EqualTo(IntegerArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnLongArray_ReturnsLongArrayMax()
            {
                Assert.That(LongArray.MaxOrDefault(), Is.EqualTo(LongArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnLongArray_WithTestLongValue_ReturnsLongArrayMax()
            {
                Assert.That(LongArray.MaxOrDefault(TestLongValue), Is.EqualTo(LongArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullDecimalSequence.MaxOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnNullDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullDecimalSequence.MaxOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullDoubleSequence.MaxOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnNullDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullDoubleSequence.MaxOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullFloatSequence.MaxOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnNullFloatSequence_WithTestFloatValue_RetursTestFloatValue()
            {
                Assert.That(NullFloatSequence.MaxOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(DecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(DecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(DoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(DoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(FloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(FloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(IntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(IntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(LongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(LongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_ReturnsDefaultDecimal()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableDecimalFunc), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableDecimalFunc_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableDecimalFunc, TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_ReturnsDefaultDouble()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableDoubleFunc), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableDoubleFunc_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableDoubleFunc, TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_ReturnsDefaultFloat()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableFloatFunc), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableFloatFunc_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableFloatFunc, TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableIntFunc_ReturnsDefaultInteger()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableIntFunc), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableIntFunc_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableIntFunc, TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithNullableLongFunc_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableLongFunc, TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnNullIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnNullLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullLongSequence.MaxOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnNullLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullLongSequence.MaxOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDecimalSequence_ReturnsDefaultDecimal()
            {
                Assert.That(NullNullableDecimalSequence.MaxOrDefault(), Is.EqualTo(DefaultDecimal));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDecimalSequence_WithTestDecimalValue_ReturnsTestDecimalValue()
            {
                Assert.That(NullNullableDecimalSequence.MaxOrDefault(TestDecimalValue), Is.EqualTo(TestDecimalValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDoubleSequence_ReturnsDefaultDouble()
            {
                Assert.That(NullNullableDoubleSequence.MaxOrDefault(), Is.EqualTo(DefaultDouble));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableDoubleSequence_WithTestDoubleValue_ReturnsTestDoubleValue()
            {
                Assert.That(NullNullableDoubleSequence.MaxOrDefault(TestDoubleValue), Is.EqualTo(TestDoubleValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableFloatSequence_ReturnsDefaultFloat()
            {
                Assert.That(NullNullableFloatSequence.MaxOrDefault(), Is.EqualTo(DefaultFloat));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableFloatSequence_WithTestFloatValue_ReturnsTestFloatValue()
            {
                Assert.That(NullNullableFloatSequence.MaxOrDefault(TestFloatValue), Is.EqualTo(TestFloatValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableIntegerSequence_ReturnsDefaultInteger()
            {
                Assert.That(NullNullableIntegerSequence.MaxOrDefault(), Is.EqualTo(DefaultInteger));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableIntegerSequence_WithTestIntegerValue_ReturnsTestIntegerValue()
            {
                Assert.That(NullNullableIntegerSequence.MaxOrDefault(TestIntegerValue), Is.EqualTo(TestIntegerValue));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableLongSequence_ReturnsDefaultLong()
            {
                Assert.That(NullNullableLongSequence.MaxOrDefault(), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxOrDefault_OnNullNullableLongSequence_WithTestLongValue_ReturnsTestLongValue()
            {
                Assert.That(NullNullableLongSequence.MaxOrDefault(TestLongValue), Is.EqualTo(TestLongValue));
            }

            [Test]
            public void MaxOrDefault_OnNullableDecimalArray_ReturnsNullableDecimalArrayMax()
            {
                Assert.That(NullableDecimalArray.MaxOrDefault(), Is.EqualTo(NullableDecimalArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableDecimalArray_WithTestDecimalValue_REturnsNullableDecimalArrayMax()
            {
                Assert.That(NullableDecimalArray.MaxOrDefault(TestDecimalValue), Is.EqualTo(NullableDecimalArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableDoubleArray_ReturnsNullableDoubleArrayMax()
            {
                Assert.That(NullableDoubleArray.MaxOrDefault(), Is.EqualTo(NullableDoubleArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableDoubleArray_WithTestDoubleValue_ReturnsNullableDoubleArrayMax()
            {
                Assert.That(NullableDoubleArray.MaxOrDefault(TestDoubleValue), Is.EqualTo(NullableDoubleArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableFloatArray_ReturnsNullableFloatArrayMax()
            {
                Assert.That(NullableFloatArray.MaxOrDefault(), Is.EqualTo(NullableFloatArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableFloatArray_WithTestFloatValue_ReturnsNullableFloatArrayMax()
            {
                Assert.That(NullableFloatArray.MaxOrDefault(TestFloatValue), Is.EqualTo(NullableFloatArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableIntegerArray_RetunrsNullableIntegerArrayMax()
            {
                Assert.That(NullableIntegerArray.MaxOrDefault(), Is.EqualTo(NullableIntegerArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableIntegerArray_WithTestIntegerValue_ReturnsNullableIntegerArrayMax()
            {
                Assert.That(NullableIntegerArray.MaxOrDefault(TestIntegerValue), Is.EqualTo(NullableIntegerArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableLongArray_ReturnsNullableLongArrayMax()
            {
                Assert.That(NullableLongArray.MaxOrDefault(), Is.EqualTo(NullableLongArray.Max()));
            }

            [Test]
            public void MaxOrDefault_OnNullableLongArray_WithTestLongValue_ReturnsNullableLongArrayMax()
            {
                Assert.That(NullableLongArray.MaxOrDefault(TestLongValue), Is.EqualTo(NullableLongArray.Max()));
            }

            [Test]
            public void MaxOrDefault_onNullIntegerSequence_WithNullableLongFunc_ReturnsDefaultLong()
            {
                Assert.That(NullIntegerSequence.MaxOrDefault(NullableLongFunc), Is.EqualTo(DefaultLong));
            }

            [Test]
            public void MaxorDefault_OnIntegerArray_WithLongfunc_WithTestLongValue_ReturnsMax()
            {
                Assert.That(IntegerArray.MaxOrDefault(LongFunc, TestLongValue), Is.EqualTo(IntegerArray.Select(LongFunc).Max()));
            }
        }
    }
}