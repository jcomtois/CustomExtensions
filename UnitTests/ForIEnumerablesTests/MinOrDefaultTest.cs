using System;
using System.Linq;
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class MinOrDefaultTest
        {
            private int[] _intArray;
            private string[] _stringArray;
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

            [SetUp]
            public void SetUp()
            {
                _intArray = new[] { 10, 20, 30 };
                _stringArray = new[] { "A", "B", "C" };
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

            [Test]
            public void SequenceGoodSelectorGoodDefaultValueGood()
            {
                Assert.That(() => _stringArray.MinOrDefault(s => s.First(), 'Z'), Is.EqualTo('A'));
            }

            [Test]
            public void SequenceGoodSelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => _stringArray.MinOrDefault(s => s.First()), Is.EqualTo('A'));
            }

            [Test]
            public void SequenceEmptySelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault(s => s.First()), Is.EqualTo(default(char)));
            }

            [Test]
            public void SequenceEmptySelectorGoodDefaultValueGood()
            {
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault(s => s.First(), 'Z'), Is.EqualTo('Z'));
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault(s => s, null), Is.Null);
            }

            [Test]
            public void SequenceNullSelectorGoodDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(s => s.First(), 'Z'), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(s => s.First(), 'Z'), Is.EqualTo('Z'));
            }

            [Test]
            public void SequenceNullSelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(s => s.First()), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(s => s.First()), Is.EqualTo(default(char)));
            }

            [Test]
            public void SequenceNullSelectorNullDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(null, 'Z'), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorNullDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault((Func<string, char>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodDefaultValueGood()
            {
                Assert.That(() => _stringArray.MinOrDefault("Z"), Is.EqualTo("A"));
            }

            [Test]
            public void SequenceGoodDefaultValueEmpty()
            {
                Assert.That(() => _stringArray.MinOrDefault(), Is.EqualTo("A"));
            }

            [Test]
            public void SequenceEmptyDefaultValueEmpty()
            {
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault(), Is.EqualTo(default(string)));
            }

            [Test]
            public void SequenceEmptyDefaultValueGood()
            {
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault("Z"), Is.EqualTo("Z"));
                Assert.That(() => Enumerable.Empty<string>().MinOrDefault((string)null), Is.Null);
            }

            [Test]
            public void SequenceNullDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault("Z"), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MinOrDefault("Z"), Is.EqualTo("Z"));
            }

            [Test]
            public void SequenceNullDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MinOrDefault(), Is.EqualTo(default(string)));
            }



            #region Integer
            [Test]
            public void IntegerGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(), Is.EqualTo(_intArray.Min()));
            }

            [Test]
            public void IntegerGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(DefaultIntValue), Is.EqualTo(_intArray.Min()));
            }

            [Test]
            public void IntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void IntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(), Is.EqualTo(default(int)));
            }
            #endregion

            #region Nullable Integer
            [Test]
            public void NullableIntegerGoodInputNoDefault()
            {
                Assert.That(_nullableIntArray.MinOrDefault(), Is.EqualTo(_nullableIntArray.Min()));
            }

            [Test]
            public void NullableIntegerGoodInputDefault()
            {
                Assert.That(_nullableIntArray.MinOrDefault(DefaultIntValue), Is.EqualTo(_nullableIntArray.Min()));
            }

            [Test]
            public void NullableIntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int?>().MinOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerEmptyInputNoDefault()
            {
                Assert.That(() => Enumerable.Empty<int?>().MinOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void NullableIntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int?>().MinOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int?>().MinOrDefault(), Is.EqualTo(default(int)));
            }
            #endregion

            #region Decimal
            [Test]
            public void DecimalGoodInputNoDefault()
            {
                Assert.That(_decimalArray.MinOrDefault(), Is.EqualTo(_decimalArray.Min()));
            }

            [Test]
            public void DecimalGoodInputDefault()
            {
                Assert.That(_decimalArray.MinOrDefault(DefaultDecimalValue), Is.EqualTo(_decimalArray.Min()));
            }

            [Test]
            public void DecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().MinOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void DecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal>().MinOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal>().MinOrDefault(), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Nullable Decimal
            [Test]
            public void NullableDecimalGoodInputNoDefault()
            {
                Assert.That(_nullableDecimalArray.MinOrDefault(), Is.EqualTo(_nullableDecimalArray.Min()));
            }

            [Test]
            public void NullableDecimalGoodInputDefault()
            {
                Assert.That(_nullableDecimalArray.MinOrDefault(DefaultDecimalValue), Is.EqualTo(_nullableDecimalArray.Min()));
            }

            [Test]
            public void NullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().MinOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().MinOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void NullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().MinOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().MinOrDefault(), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Double
            [Test]
            public void DoubleGoodInputNoDefault()
            {
                Assert.That(_doubleArray.MinOrDefault(), Is.EqualTo(_doubleArray.Min()));
            }

            [Test]
            public void DoubleGoodInputDefault()
            {
                Assert.That(_doubleArray.MinOrDefault(DefaultDoubleValue), Is.EqualTo(_doubleArray.Min()));
            }

            [Test]
            public void DoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double>().MinOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double>().MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void DoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double>().MinOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double>().MinOrDefault(), Is.EqualTo(default(double)));
            }
            #endregion

            #region Nullable Double
            [Test]
            public void NullableDoubleGoodInputNoDefault()
            {
                Assert.That(_nullableDoubleArray.MinOrDefault(), Is.EqualTo(_nullableDoubleArray.Min()));
            }

            [Test]
            public void NullableDoubleGoodInputDefault()
            {
                Assert.That(_nullableDoubleArray.MinOrDefault(DefaultDoubleValue), Is.EqualTo(_nullableDoubleArray.Min()));
            }

            [Test]
            public void NullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double?>().MinOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double?>().MinOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void NullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double?>().MinOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double?>().MinOrDefault(), Is.EqualTo(default(double)));
            }
            #endregion

            #region Long
            [Test]
            public void LongGoodInputNoDefault()
            {
                Assert.That(_longArray.MinOrDefault(), Is.EqualTo(_longArray.Min()));
            }

            [Test]
            public void LongGoodInputDefault()
            {
                Assert.That(_longArray.MinOrDefault(DefaultLongValue), Is.EqualTo(_longArray.Min()));
            }

            [Test]
            public void LongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long>().MinOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long>().MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void LongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long>().MinOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long>().MinOrDefault(), Is.EqualTo(default(long)));
            }
            #endregion

            #region Nullable Long
            [Test]
            public void NullableLongGoodInputNoDefault()
            {
                Assert.That(_nullableLongArray.MinOrDefault(), Is.EqualTo(_nullableLongArray.Min()));
            }

            [Test]
            public void NullableLongGoodInputDefault()
            {
                Assert.That(_nullableLongArray.MinOrDefault(DefaultLongValue), Is.EqualTo(_nullableLongArray.Min()));
            }

            [Test]
            public void NullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long?>().MinOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long?>().MinOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void NullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long?>().MinOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long?>().MinOrDefault(), Is.EqualTo(default(long)));
            }
            #endregion

            #region Float
            [Test]
            public void FloatGoodInputNoDefault()
            {
                Assert.That(_floatArray.MinOrDefault(), Is.EqualTo(_floatArray.Min()));
            }

            [Test]
            public void FloatGoodInputDefault()
            {
                Assert.That(_floatArray.MinOrDefault(DefaultFloatValue), Is.EqualTo(_floatArray.Min()));
            }

            [Test]
            public void FloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float>().MinOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float>().MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void FloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float>().MinOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float>().MinOrDefault(), Is.EqualTo(default(float)));
            }
            #endregion

            #region Nullable Float
            [Test]
            public void NullableFloatGoodInputNoDefault()
            {
                Assert.That(_nullableFloatArray.MinOrDefault(), Is.EqualTo(_nullableFloatArray.Min()));
            }

            [Test]
            public void NullableFloatGoodInputDefault()
            {
                Assert.That(_nullableFloatArray.MinOrDefault(DefaultFloatValue), Is.EqualTo(_nullableFloatArray.Min()));
            }

            [Test]
            public void NullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float?>().MinOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float?>().MinOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void NullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float?>().MinOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float?>().MinOrDefault(), Is.EqualTo(default(float)));
            }
            #endregion

            #region Projection Decimal
            [Test]
            public void ProjectionDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_decimalFunc), Is.EqualTo(_intArray.Select(_decimalFunc).Min()));
            }

            [Test]
            public void ProjectionDecimalGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_decimalFunc).Min()));
            }

            [Test]
            public void ProjectionDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Projection Nullable Decimal
            [Test]
            public void ProjectionNullableDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableDecimalFunc), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Min()));
            }

            [Test]
            public void ProjectionNullableDecimalGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Min()));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Projection Double
            [Test]
            public void ProjectionDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_doubleFunc), Is.EqualTo(_intArray.Select(_doubleFunc).Min()));
            }

            [Test]
            public void ProjectionDoubleGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_doubleFunc).Min()));
            }

            [Test]
            public void ProjectionDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }
            #endregion

            #region Projection Nullable Double
            [Test]
            public void ProjectionNullableDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableDoubleFunc), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Min()));
            }

            [Test]
            public void ProjectionNullableDoubleGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Min()));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));

            }
            #endregion

            #region Projection Int
            [Test]
            public void ProjectionIntGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_intFunc), Is.EqualTo(_intArray.Select(_intFunc).Min()));
            }

            [Test]
            public void ProjectionIntGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_intFunc).Min()));
            }

            [Test]
            public void ProjectionIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_intFunc), Is.EqualTo(default(int)));
            }
            #endregion

            #region Projection Nullable Int
            [Test]
            public void ProjectionNullableIntGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableIntFunc), Is.EqualTo(_intArray.Select(_nullableIntFunc).Min()));
            }

            [Test]
            public void ProjectionNullableIntGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_nullableIntFunc).Min()));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionNullableIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }
            #endregion

            #region Projection Long
            [Test]
            public void ProjectionLongGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_longFunc), Is.EqualTo(_intArray.Select(_longFunc).Min()));
            }

            [Test]
            public void ProjectionLongGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_longFunc).Min()));
            }

            [Test]
            public void ProjectionLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_longFunc), Is.EqualTo(default(long)));
            }
            #endregion

            #region Projection Nullable Long
            [Test]
            public void ProjectionNullableLongGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableLongFunc), Is.EqualTo(_intArray.Select(_nullableLongFunc).Min()));
            }

            [Test]
            public void ProjectionNullableLongGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_nullableLongFunc).Min()));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionNullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }
            #endregion

            #region Projection Float
            [Test]
            public void ProjectionFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_floatFunc), Is.EqualTo(_intArray.Select(_floatFunc).Min()));
            }

            [Test]
            public void ProjectionFloatGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_floatFunc).Min()));
            }

            [Test]
            public void ProjectionFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }
            #endregion

            #region Projection Nullable Float
            [Test]
            public void ProjectionNullableFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableFloatFunc), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Min()));
            }

            [Test]
            public void ProjectionNullableFloatGoodInputDefault()
            {
                Assert.That(_intArray.MinOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Min()));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MinOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionNullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MinOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }
            #endregion

        }

    }
}