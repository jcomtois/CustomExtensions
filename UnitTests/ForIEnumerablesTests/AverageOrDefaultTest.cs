using System;
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
            private readonly int[] _intArray = new[] { 10, 20, 30 };
            private readonly int?[] _nullableIntArray;
            private const int DefaultIntValue = 9999;
            private const double DefaultDoubleValue = DefaultIntValue;
            private const decimal DefaultDecimalValue = DefaultIntValue;
            private const long DefaultLongValue = DefaultIntValue;
            private const float DefaultFloatValue = DefaultIntValue;
            private readonly long[] _longArray;
            private readonly long?[] _nullableLongArray;
            private readonly double[] _doubleArray;
            private readonly double?[] _nullableDoubleArray;
            private readonly decimal[] _decimalArray;
            private readonly decimal?[] _nullableDecimalArray;
            private readonly float[] _floatArray;
            private readonly float?[] _nullableFloatArray;
            private readonly Func<int, decimal> _decimalFunc = x => (decimal)x;
            private readonly Func<int, decimal?> _nullableDecimalFunc = x => (decimal?)x;
            private readonly Func<int, double> _doubleFunc = x => (double)x;
            private readonly Func<int, double?> _nullableDoubleFunc = x => (double?)x;
            private readonly Func<int, long> _longFunc = x => (long)x;
            private readonly Func<int, long?> _nullableLongFunc = x => (long?)x;
            private readonly Func<int, float> _floatFunc = x => (float)x;
            private readonly Func<int, float?> _nullableFloatFunc = x => (float?)x;
            private readonly Func<int, int> _intFunc = x => x + x;
            private readonly Func<int, int?> _nullableIntFunc = x => (int?)(x + x);

            public AverageOrDefaultTest()
            {
                _nullableIntArray = _intArray.Select(x => (int?)x).ToArray();
                _nullableFloatArray = _intArray.Select(x => (float?)x).ToArray();
                _floatArray = _intArray.Select(x => (float)x).ToArray();
                _nullableDecimalArray =_intArray.Select(x => (decimal?)x).ToArray();
                _decimalArray = _intArray.Select(x => (decimal)x).ToArray();
                _nullableDoubleArray = _intArray.Select(x => (double?)x).ToArray();
                _doubleArray = _intArray.Select(x => (double)x).ToArray();
                _nullableLongArray = _intArray.Select(x => (long?)x).ToArray();
                _longArray = _intArray.Select(x => (long)x).ToArray();
               
            }

            #region Integer
            [Test]
            public void IntegerGoodInputNoDefault()
            {
                var expected = _intArray.Average();
                var actual = _intArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IntegerGoodInputDefault()
            {
                var expected = _intArray.Average();
                var actual = _intArray.AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IntegerEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IntegerEmptyInputNoDefault()
            {
                const double expected = default(int);
                var actual = Enumerable.Empty<int>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IntegerNullInputDefault()
            {
                var expected = DefaultDoubleValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IntegerNullInputNoDefault()
            {
                const double expected = default(int);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            } 
            #endregion

            #region Nullable Integer
            [Test]
            public void NullableIntegerGoodInputNoDefault()
            {
                var expected = _nullableIntArray.Average();
                var actual = _nullableIntArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableIntegerGoodInputDefault()
            {
                var expected = _nullableIntArray.Average();
                var actual = _nullableIntArray.AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableIntegerEmptyInputDefault()
            {
                double? expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int?>().AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableIntegerEmptyInputNoDefault()
            {
                double? expected = default(int);
                var actual = Enumerable.Empty<int?>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableIntegerNullInputDefault()
            {
                double? expected = DefaultDoubleValue;
                int?[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableIntegerNullInputNoDefault()
            {
                double? expected = default(int);
                int?[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            } 
            #endregion

            #region Decimal
            [Test]
            public void DecimalGoodInputNoDefault()
            {
                var expected = _decimalArray.Average();
                var actual = _decimalArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DecimalGoodInputDefault()
            {
                var expected = _decimalArray.Average();
                var actual = _decimalArray.AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DecimalEmptyInputDefault()
            {
                const decimal expected = DefaultDecimalValue;
                var actual = Enumerable.Empty<decimal>().AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DecimalEmptyInputNoDefault()
            {
                const decimal expected = default(decimal);
                var actual = Enumerable.Empty<decimal>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DecimalNullInputDefault()
            {
                const decimal expected = DefaultDecimalValue;
                decimal[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DecimalNullInputNoDefault()
            {
                const decimal expected = default(decimal);
                decimal[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }          
            #endregion

            #region Nullable Decimal
            [Test]
            public void NullableDecimalGoodInputNoDefault()
            {
                var expected = _nullableDecimalArray.Average();
                var actual = _nullableDecimalArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDecimalGoodInputDefault()
            {
                var expected = _nullableDecimalArray.Average();
                var actual = _nullableDecimalArray.AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDecimalEmptyInputDefault()
            {
                decimal? expected = DefaultDecimalValue;
                var actual = Enumerable.Empty<decimal?>().AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDecimalEmptyInputNoDefault()
            {
                decimal? expected = default(decimal);
                var actual = Enumerable.Empty<decimal?>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDecimalNullInputDefault()
            {
                decimal? expected = DefaultDecimalValue;
                decimal?[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDecimalNullInputNoDefault()
            {
                decimal? expected = default(decimal);
                decimal?[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Double
            [Test]
            public void DoubleGoodInputNoDefault()
            {
                var expected = _doubleArray.Average();
                var actual = _doubleArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DoubleGoodInputDefault()
            {
                var expected = _doubleArray.Average();
                var actual = _doubleArray.AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DoubleEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<double>().AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DoubleEmptyInputNoDefault()
            {
                const double expected = default(double);
                var actual = Enumerable.Empty<double>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DoubleNullInputDefault()
            {
                const double expected = DefaultDoubleValue;
                double[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DoubleNullInputNoDefault()
            {
                const double expected = default(double);
                double[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Nullable Double
            [Test]
            public void NullableDoubleGoodInputNoDefault()
            {
                var expected = _nullableDoubleArray.Average();
                var actual = _nullableDoubleArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDoubleGoodInputDefault()
            {
                var expected = _nullableDoubleArray.Average();
                var actual = _nullableDoubleArray.AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDoubleEmptyInputDefault()
            {
                double? expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<double?>().AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDoubleEmptyInputNoDefault()
            {
                double? expected = default(double);
                var actual = Enumerable.Empty<double?>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDoubleNullInputDefault()
            {
                double? expected = DefaultDoubleValue;
                double?[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableDoubleNullInputNoDefault()
            {
                double? expected = default(double);
                double?[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Long
            [Test]
            public void LongGoodInputNoDefault()
            {
                var expected = _longArray.Average();
                var actual = _longArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongGoodInputDefault()
            {
                var expected = _longArray.Average();
                var actual = _longArray.AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<long>().AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongEmptyInputNoDefault()
            {
                const double expected = default(long);
                var actual = Enumerable.Empty<long>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongNullInputDefault()
            {
                var expected = DefaultDoubleValue;
                long[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongNullInputNoDefault()
            {
                const double expected = default(long);
                long[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Nullable Long
            [Test]
            public void NullableLongGoodInputNoDefault()
            {
                var expected = _nullableLongArray.Average();
                var actual = _nullableLongArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableLongGoodInputDefault()
            {
                var expected = _nullableLongArray.Average();
                var actual = _nullableLongArray.AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableLongEmptyInputDefault()
            {
                double? expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<long?>().AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableLongEmptyInputNoDefault()
            {
                double? expected = default(long);
                var actual = Enumerable.Empty<long?>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableLongNullInputDefault()
            {
                double? expected = DefaultDoubleValue;
                long?[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableLongNullInputNoDefault()
            {
                double? expected = default(long);
                long?[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Float
            [Test]
            public void FloatGoodInputNoDefault()
            {
                var expected = _floatArray.Average();
                var actual = _floatArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void FloatGoodInputDefault()
            {
                var expected = _floatArray.Average();
                var actual = _floatArray.AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void FloatEmptyInputDefault()
            {
                const float expected = DefaultFloatValue;
                var actual = Enumerable.Empty<float>().AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void FloatEmptyInputNoDefault()
            {
                const float expected = default(float);
                var actual = Enumerable.Empty<float>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void FloatNullInputDefault()
            {
                var expected = DefaultFloatValue;
                float[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void FloatNullInputNoDefault()
            {
                const float expected = default(float);
                float[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Nullable Float
            [Test]
            public void NullableFloatGoodInputNoDefault()
            {
                var expected = _nullableFloatArray.Average();
                var actual = _nullableFloatArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableFloatGoodInputDefault()
            {
                var expected = _nullableFloatArray.Average();
                var actual = _nullableFloatArray.AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableFloatEmptyInputDefault()
            {
                float? expected = DefaultFloatValue;
                var actual = Enumerable.Empty<float?>().AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableFloatEmptyInputNoDefault()
            {
                float? expected = default(float);
                var actual = Enumerable.Empty<float?>().AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableFloatNullInputDefault()
            {
                float? expected = DefaultFloatValue;
                float?[] nullArray = null;
                var actual = nullArray.AverageOrDefault(DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void NullableFloatNullInputNoDefault()
            {
                float? expected = default(float);
                float?[] nullArray = null;
                var actual = nullArray.AverageOrDefault();
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Decimal
            [Test]
            public void ProjectionDecimalGoodInputNoDefault()
            {
                var expected = _intArray.Select(_decimalFunc).Average();
                var actual = _intArray.AverageOrDefault(_decimalFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDecimalGoodInputDefault()
            {
                var expected = _intArray.Select(_decimalFunc).Average();
                var actual = _intArray.AverageOrDefault(_decimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDecimalEmptyInputDefault()
            {
                const decimal expected = DefaultDecimalValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_decimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDecimalEmptyInputNoDefault()
            {
                const decimal expected = default(decimal);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_decimalFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDecimalNullInputDefault()
            {
                const decimal expected = DefaultDecimalValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_decimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDecimalNullInputNoDefault()
            {
                const decimal expected = default(decimal);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_decimalFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Nullable Decimal
            [Test]
            public void ProjectionNullableDecimalGoodInputNoDefault()
            {
                var expected = _intArray.Select(_nullableDecimalFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableDecimalFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDecimalGoodInputDefault()
            {
                var expected = _intArray.Select(_nullableDecimalFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputDefault()
            {
                decimal? expected = DefaultDecimalValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputNoDefault()
            {
                decimal? expected = default(decimal);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableDecimalFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDecimalNullInputDefault()
            {
                decimal? expected = DefaultDecimalValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDecimalNullInputNoDefault()
            {
                decimal? expected = default(decimal);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableDecimalFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Double
            [Test]
            public void ProjectionDoubleGoodInputNoDefault()
            {
                var expected = _intArray.Select(_doubleFunc).Average();
                var actual = _intArray.AverageOrDefault(_doubleFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDoubleGoodInputDefault()
            {
                var expected = _intArray.Select(_doubleFunc).Average();
                var actual = _intArray.AverageOrDefault(_doubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDoubleEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_doubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDoubleEmptyInputNoDefault()
            {
                const double expected = default(double);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_doubleFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDoubleNullInputDefault()
            {
                const double expected = DefaultDoubleValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_doubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionDoubleNullInputNoDefault()
            {
                const double expected = default(double);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_doubleFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Nullable Double
            [Test]
            public void ProjectionNullableDoubleGoodInputNoDefault()
            {
                var expected = _intArray.Select(_nullableDoubleFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableDoubleFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDoubleGoodInputDefault()
            {
                var expected = _intArray.Select(_nullableDoubleFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputDefault()
            {
                double? expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputNoDefault()
            {
                double? expected = default(double);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableDoubleFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDoubleNullInputDefault()
            {
                double? expected = DefaultDoubleValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableDoubleNullInputNoDefault()
            {
                double? expected = default(double);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableDoubleFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Int
            [Test]
            public void ProjectionIntGoodInputNoDefault()
            {
                var expected = _intArray.Select(_intFunc).Average();
                var actual = _intArray.AverageOrDefault(_intFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionIntGoodInputDefault()
            {
                var expected = _intArray.Select(_intFunc).Average();
                var actual = _intArray.AverageOrDefault(_intFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionIntEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_intFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionIntEmptyInputNoDefault()
            {
                const double expected = default(int);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_intFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionIntNullInputDefault()
            {
                const double expected = DefaultDoubleValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_intFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionIntNullInputNoDefault()
            {
                const double expected = default(int);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_intFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Nullable Int
            [Test]
            public void ProjectionNullableIntGoodInputNoDefault()
            {
                var expected = _intArray.Select(_nullableIntFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableIntFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableIntGoodInputDefault()
            {
                var expected = _intArray.Select(_nullableIntFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableIntFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableIntEmptyInputDefault()
            {
                double? expected = DefaultIntValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableIntFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableIntEmptyInputNoDefault()
            {
                double? expected = default(int);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableIntFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableIntNullInputDefault()
            {
                double? expected = DefaultIntValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableIntFunc, DefaultIntValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableIntNullInputNoDefault()
            {
                double? expected = default(int);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableIntFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Long
            [Test]
            public void ProjectionLongGoodInputNoDefault()
            {
                var expected = _intArray.Select(_longFunc).Average();
                var actual = _intArray.AverageOrDefault(_longFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionLongGoodInputDefault()
            {
                var expected = _intArray.Select(_longFunc).Average();
                var actual = _intArray.AverageOrDefault(_longFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionLongEmptyInputDefault()
            {
                const double expected = DefaultDoubleValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_longFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionLongEmptyInputNoDefault()
            {
                const double expected = default(long);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_longFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionLongNullInputDefault()
            {
                const double expected = DefaultDoubleValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_longFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionLongNullInputNoDefault()
            {
                const double expected = default(long);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_longFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Nullable Long
            [Test]
            public void ProjectionNullableLongGoodInputNoDefault()
            {
                var expected = _intArray.Select(_nullableLongFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableLongFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableLongGoodInputDefault()
            {
                var expected = _intArray.Select(_nullableLongFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableLongFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableLongEmptyInputDefault()
            {
                double? expected = DefaultLongValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableLongFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableLongEmptyInputNoDefault()
            {
                double? expected = default(long);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableLongFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableLongNullInputDefault()
            {
                double? expected = DefaultLongValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableLongFunc, DefaultLongValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableLongNullInputNoDefault()
            {
                double? expected = default(long);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableLongFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Float
            [Test]
            public void ProjectionFloatGoodInputNoDefault()
            {
                var expected = _intArray.Select(_floatFunc).Average();
                var actual = _intArray.AverageOrDefault(_floatFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionFloatGoodInputDefault()
            {
                var expected = _intArray.Select(_floatFunc).Average();
                var actual = _intArray.AverageOrDefault(_floatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionFloatEmptyInputDefault()
            {
                const float expected = DefaultFloatValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_floatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionFloatEmptyInputNoDefault()
            {
                const float expected = default(float);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_floatFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionFloatNullInputDefault()
            {
                const float expected = DefaultFloatValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_floatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionFloatNullInputNoDefault()
            {
                const float expected = default(float);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_floatFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

            #region Projection Nullable Float
            [Test]
            public void ProjectionNullableFloatGoodInputNoDefault()
            {
                var expected = _intArray.Select(_nullableFloatFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableFloatFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableFloatGoodInputDefault()
            {
                var expected = _intArray.Select(_nullableFloatFunc).Average();
                var actual = _intArray.AverageOrDefault(_nullableFloatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputDefault()
            {
                float? expected = DefaultFloatValue;
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableFloatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputNoDefault()
            {
                float? expected = default(float);
                var actual = Enumerable.Empty<int>().AverageOrDefault(_nullableFloatFunc);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableFloatNullInputDefault()
            {
                float? expected = DefaultFloatValue;
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableFloatFunc, DefaultFloatValue);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProjectionNullableFloatNullInputNoDefault()
            {
                float? expected = default(float);
                int[] nullArray = null;
                var actual = nullArray.AverageOrDefault(_nullableFloatFunc);
                Assert.AreEqual(expected, actual);
            }
            #endregion

        }
    }
}