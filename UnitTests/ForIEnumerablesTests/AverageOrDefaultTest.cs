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
            #region Setup/Teardown

            [SetUp]
            public void SetUp()
            {
                _intArray = new[] {10, 20, 30};
                _nullableIntArray = _intArray.Select(x => (int?)x).ToArray();
                _nullableFloatArray = _intArray.Select(x => (float?)x).ToArray();
                _floatArray = _intArray.Select(x => (float)x).ToArray();
                _nullableDecimalArray = _intArray.Select(x => (decimal?)x).ToArray();
                _decimalArray = _intArray.Select(x => (decimal)x).ToArray();
                _nullableDoubleArray = _intArray.Select(x => (double?)x).ToArray();
                _doubleArray = _intArray.Select(x => (double)x).ToArray();
                _nullableLongArray = _intArray.Select(x => (long?)x).ToArray();
                _longArray = _intArray.Select(x => (long)x).ToArray();
            }

            #endregion

            private int[] _intArray;
            private int?[] _nullableIntArray;
            private const int DefaultIntValue = 9999;
            private const double DefaultDoubleValue = DefaultIntValue;
            private const decimal DefaultDecimalValue = DefaultIntValue;
            private const long DefaultLongValue = DefaultIntValue;
            private const float DefaultFloatValue = DefaultIntValue;
            private long[] _longArray;
            private long?[] _nullableLongArray;
            private double[] _doubleArray;
            private double?[] _nullableDoubleArray;
            private decimal[] _decimalArray;
            private decimal?[] _nullableDecimalArray;
            private float[] _floatArray;
            private float?[] _nullableFloatArray;
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

            [Test]
            public void DecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().AverageOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void DecimalGoodInputDefault()
            {
                Assert.That(_decimalArray.AverageOrDefault(DefaultDecimalValue), Is.EqualTo(_decimalArray.Average()));
            }

            [Test]
            public void DecimalGoodInputNoDefault()
            {
                Assert.That(_decimalArray.AverageOrDefault(), Is.EqualTo(_decimalArray.Average()));
            }

            [Test]
            public void DecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal>().AverageOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal>().AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void DoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double>().AverageOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double>().AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void DoubleGoodInputDefault()
            {
                Assert.That(_doubleArray.AverageOrDefault(DefaultDoubleValue), Is.EqualTo(_doubleArray.Average()));
            }

            [Test]
            public void DoubleGoodInputNoDefault()
            {
                Assert.That(_doubleArray.AverageOrDefault(), Is.EqualTo(_doubleArray.Average()));
            }

            [Test]
            public void DoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double>().AverageOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double>().AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void FloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float>().AverageOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float>().AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void FloatGoodInputDefault()
            {
                Assert.That(_floatArray.AverageOrDefault(DefaultFloatValue), Is.EqualTo(_floatArray.Average()));
            }

            [Test]
            public void FloatGoodInputNoDefault()
            {
                Assert.That(_floatArray.AverageOrDefault(), Is.EqualTo(_floatArray.Average()));
            }

            [Test]
            public void FloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float>().AverageOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float>().AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void IntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void IntegerGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(DefaultIntValue), Is.EqualTo(_intArray.Average()));
            }

            [Test]
            public void IntegerGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(), Is.EqualTo(_intArray.Average()));
            }

            [Test]
            public void IntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void LongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long>().AverageOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long>().AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void LongGoodInputDefault()
            {
                Assert.That(_longArray.AverageOrDefault(DefaultLongValue), Is.EqualTo(_longArray.Average()));
            }

            [Test]
            public void LongGoodInputNoDefault()
            {
                Assert.That(_longArray.AverageOrDefault(), Is.EqualTo(_longArray.Average()));
            }

            [Test]
            public void LongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long>().AverageOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long>().AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void NullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().AverageOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void NullableDecimalGoodInputDefault()
            {
                Assert.That(_nullableDecimalArray.AverageOrDefault(DefaultDecimalValue), Is.EqualTo(_nullableDecimalArray.Average()));
            }

            [Test]
            public void NullableDecimalGoodInputNoDefault()
            {
                Assert.That(_nullableDecimalArray.AverageOrDefault(), Is.EqualTo(_nullableDecimalArray.Average()));
            }

            [Test]
            public void NullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().AverageOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().AverageOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void NullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double?>().AverageOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double?>().AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void NullableDoubleGoodInputDefault()
            {
                Assert.That(_nullableDoubleArray.AverageOrDefault(DefaultDoubleValue), Is.EqualTo(_nullableDoubleArray.Average()));
            }

            [Test]
            public void NullableDoubleGoodInputNoDefault()
            {
                Assert.That(_nullableDoubleArray.AverageOrDefault(), Is.EqualTo(_nullableDoubleArray.Average()));
            }

            [Test]
            public void NullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double?>().AverageOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double?>().AverageOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void NullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float?>().AverageOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float?>().AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void NullableFloatGoodInputDefault()
            {
                Assert.That(_nullableFloatArray.AverageOrDefault(DefaultFloatValue), Is.EqualTo(_nullableFloatArray.Average()));
            }

            [Test]
            public void NullableFloatGoodInputNoDefault()
            {
                Assert.That(_nullableFloatArray.AverageOrDefault(), Is.EqualTo(_nullableFloatArray.Average()));
            }

            [Test]
            public void NullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float?>().AverageOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float?>().AverageOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void NullableIntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int?>().AverageOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int?>().AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void NullableIntegerGoodInputDefault()
            {
                Assert.That(_nullableIntArray.AverageOrDefault(DefaultIntValue), Is.EqualTo(_nullableIntArray.Average()));
            }

            [Test]
            public void NullableIntegerGoodInputNoDefault()
            {
                Assert.That(_nullableIntArray.AverageOrDefault(), Is.EqualTo(_nullableIntArray.Average()));
            }

            [Test]
            public void NullableIntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int?>().AverageOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int?>().AverageOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void NullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long?>().AverageOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long?>().AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void NullableLongGoodInputDefault()
            {
                Assert.That(_nullableLongArray.AverageOrDefault(DefaultLongValue), Is.EqualTo(_nullableLongArray.Average()));
            }

            [Test]
            public void NullableLongGoodInputNoDefault()
            {
                Assert.That(_nullableLongArray.AverageOrDefault(), Is.EqualTo(_nullableLongArray.Average()));
            }

            [Test]
            public void NullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long?>().AverageOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long?>().AverageOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionDecimalGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_decimalFunc).Average()));
            }

            [Test]
            public void ProjectionDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_decimalFunc), Is.EqualTo(_intArray.Select(_decimalFunc).Average()));
            }

            [Test]
            public void ProjectionDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionDoubleGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_doubleFunc).Average()));
            }

            [Test]
            public void ProjectionDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_doubleFunc), Is.EqualTo(_intArray.Select(_doubleFunc).Average()));
            }

            [Test]
            public void ProjectionDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionFloatGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_floatFunc).Average()));
            }

            [Test]
            public void ProjectionFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_floatFunc), Is.EqualTo(_intArray.Select(_floatFunc).Average()));
            }

            [Test]
            public void ProjectionFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionIntGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_intFunc).Average()));
            }

            [Test]
            public void ProjectionIntGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_intFunc), Is.EqualTo(_intArray.Select(_intFunc).Average()));
            }

            [Test]
            public void ProjectionIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionLongGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_longFunc).Average()));
            }

            [Test]
            public void ProjectionLongGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_longFunc), Is.EqualTo(_intArray.Select(_longFunc).Average()));
            }

            [Test]
            public void ProjectionLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionNullableDecimalGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Average()));
            }

            [Test]
            public void ProjectionNullableDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableDecimalFunc), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Average()));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionNullableDoubleGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Average()));
            }

            [Test]
            public void ProjectionNullableDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableDoubleFunc), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Average()));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionNullableFloatGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Average()));
            }

            [Test]
            public void ProjectionNullableFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableFloatFunc), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Average()));
            }

            [Test]
            public void ProjectionNullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionNullableIntGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_nullableIntFunc).Average()));
            }

            [Test]
            public void ProjectionNullableIntGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableIntFunc), Is.EqualTo(_intArray.Select(_nullableIntFunc).Average()));
            }

            [Test]
            public void ProjectionNullableIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().AverageOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionNullableLongGoodInputDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_nullableLongFunc).Average()));
            }

            [Test]
            public void ProjectionNullableLongGoodInputNoDefault()
            {
                Assert.That(_intArray.AverageOrDefault(_nullableLongFunc), Is.EqualTo(_intArray.Select(_nullableLongFunc).Average()));
            }

            [Test]
            public void ProjectionNullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().AverageOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }
        }
    }
}