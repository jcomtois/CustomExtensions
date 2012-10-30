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
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        private static readonly int[] IntegerArray = new[] { 10, 20, 30 };
        private static readonly int?[] NullableIntegerArray = IntegerArray.Select(x => (int?)x).ToArray();
        private static readonly float?[] NullableFloatArray = IntegerArray.Select(x => (float?)x).ToArray();
        private static readonly float[] FloatArray = IntegerArray.Select(x => (float)x).ToArray();
        private static readonly double?[] NullableDoubleArray = IntegerArray.Select(x => (double?)x).ToArray();
        private static readonly long[] LongArray = IntegerArray.Select(x => (long)x).ToArray();
        private static readonly long?[] NullableLongArray = IntegerArray.Select(x => (long?)x).ToArray();
        private static readonly double[] DoubleArray = IntegerArray.Select(x => (double)x).ToArray();
        private static readonly decimal[] DecimalArray = IntegerArray.Select(x => (decimal)x).ToArray();
        private static readonly decimal?[] NullableDecimalArray = IntegerArray.Select(x => (decimal?)x).ToArray();
        private static readonly IEnumerable<string> EmptyStringSequence = Enumerable.Empty<string>();
        private static readonly IEnumerable<string> NullStringSequence = NullSequence.Of<string>();
        private static readonly IEnumerable<int> SequenceOneTwoThree = Enumerable.Range(1, 3);
        private static readonly IEnumerable<int> SequenceOfOne = Enumerable.Range(0, 1);
        private static readonly IEnumerable<int> SequenceOneOneOne = Enumerable.Repeat(1, 3);
        private const int TestIntegerValue = 9999;
        private const double TestDoubleValue = TestIntegerValue;
        private const decimal TestDecimalValue = TestIntegerValue;
        private const long TestLongValue = TestIntegerValue;
        private const float TestFloatValue = TestIntegerValue;
        private const decimal DefaultDecimal = default(decimal);
        private const double DefaultDouble = default(double);
        private const float DefaultFloat = default(float);
        private const int DefaultInteger = default(int);
        private const long DefaultLong = default(long);
        private const string DefaultString = default(string);
        private const string SingleLetterString = "A";
        private const string NullString = null;
        private static readonly IFixture Fixture = new Fixture().Customize(new AutoMoqCustomization());
        private static readonly Func<int, decimal> DecimalFunc = Fixture.CreateAnonymous<Func<int, decimal>>();
        private static readonly Func<int, decimal?> NullableDecimalFunc = Fixture.CreateAnonymous<Func<int, decimal?>>();
        private static readonly Func<int, double> DoubleFunc = Fixture.CreateAnonymous<Func<int, double>>();
        private static readonly Func<int, double?> NullableDoubleFunc = Fixture.CreateAnonymous<Func<int, double?>>();
        private static readonly Func<int, long> LongFunc = Fixture.CreateAnonymous<Func<int, long>>();
        private static readonly Func<int, long?> NullableLongFunc = Fixture.CreateAnonymous<Func<int, long?>>();
        private static readonly Func<int, float> FloatFunc = Fixture.CreateAnonymous<Func<int, float>>();
        private static readonly Func<int, float?> NullableFloatFunc = Fixture.CreateAnonymous<Func<int, float?>>();
        private static readonly Func<int, int> IntFunc = Fixture.CreateAnonymous<Func<int, int>>();
        private static readonly Func<int, int?> NullableIntFunc = Fixture.CreateAnonymous<Func<int, int?>>();
        private static readonly Func<string, string> StringFunc = Fixture.CreateAnonymous<Func<string, string>>();
        private static readonly IEnumerable<decimal> EmptyDecimalSequence = Enumerable.Empty<decimal>();
        private static readonly IEnumerable<double> EmptyDoubleSequence = Enumerable.Empty<double>();
        private static readonly IEnumerable<float> EmptyFloatSequence = Enumerable.Empty<float>();
        private static readonly IEnumerable<int> EmptyIntegerSequence = Enumerable.Empty<int>();
        private static readonly IEnumerable<long> EmptyLongSequence = Enumerable.Empty<long>();
        private static readonly IEnumerable<decimal?> EmptyNullableDecimalSequence = Enumerable.Empty<decimal?>();
        private static readonly IEnumerable<double?> EmptyNullableDoubleSequence = Enumerable.Empty<double?>();
        private static readonly IEnumerable<float?> EmptyNullableFloatSequence = Enumerable.Empty<float?>();
        private static readonly IEnumerable<int?> EmptyNullableIntegerSequence = Enumerable.Empty<int?>();
        private static readonly IEnumerable<long?> EmptyNullableLongSequence = Enumerable.Empty<long?>();
        private static readonly IEnumerable<decimal> NullDecimalSequence = NullSequence.Of<decimal>();
        private static readonly IEnumerable<double> NullDoubleSequence = NullSequence.Of<double>();
        private static readonly IEnumerable<float> NullFloatSequence = NullSequence.Of<float>();
        private static readonly IEnumerable<int> NullIntegerSequence = NullSequence.Of<int>();
        private static readonly IEnumerable<long> NullLongSequence = NullSequence.Of<long>();
        private static readonly IEnumerable<decimal?> NullNullableDecimalSequence = NullSequence.Of<decimal?>();
        private static readonly IEnumerable<double?> NullNullableDoubleSequence = NullSequence.Of<double?>();
        private static readonly IEnumerable<float?> NullNullableFloatSequence = NullSequence.Of<float?>();
        private static readonly IEnumerable<int?> NullNullableIntegerSequence = NullSequence.Of<int?>();
        private static readonly IEnumerable<long?> NullNullableLongSequence = NullSequence.Of<long?>();
    }
}