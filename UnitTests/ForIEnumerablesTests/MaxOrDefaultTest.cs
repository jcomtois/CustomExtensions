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
        public class MaxOrDefaultTest
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
                Assert.That(() => _stringArray.MaxOrDefault(s => s.First(), 'Z'), Is.EqualTo('C'));
            }

            [Test]
            public void SequenceGoodSelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => _stringArray.MaxOrDefault(s => s.First()), Is.EqualTo('C'));
            }

            [Test]
            public void SequenceEmptySelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault(s => s.First()), Is.EqualTo(default(char)));
            }

            [Test]
            public void SequenceEmptySelectorGoodDefaultValueGood()
            {
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault(s => s.First(), 'Z'), Is.EqualTo('Z'));
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault(s => s, null), Is.Null);
            }

            [Test]
            public void SequenceNullSelectorGoodDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(s => s.First(), 'Z'), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(s => s.First(), 'Z'), Is.EqualTo('Z'));
            }

            [Test]
            public void SequenceNullSelectorGoodDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(s => s.First()), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(s => s.First()), Is.EqualTo(default(char)));
            }

            [Test]
            public void SequenceNullSelectorNullDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(null, 'Z'), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceNullSelectorNullDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault((Func<string, char>)null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void SequenceGoodDefaultValueGood()
            {
                Assert.That(() => _stringArray.MaxOrDefault("Z"), Is.EqualTo("C"));
            }

            [Test]
            public void SequenceGoodDefaultValueEmpty()
            {
                Assert.That(() => _stringArray.MaxOrDefault(), Is.EqualTo("C"));
            }

            [Test]
            public void SequenceEmptyDefaultValueEmpty()
            {
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault(), Is.EqualTo(default(string)));
            }

            [Test]
            public void SequenceEmptyDefaultValueGood()
            {
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault("Z"), Is.EqualTo("Z"));
                Assert.That(() => Enumerable.Empty<string>().MaxOrDefault((string)null), Is.Null);
            }

            [Test]
            public void SequenceNullDefaultValueGood()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault("Z"), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault("Z"), Is.EqualTo("Z"));
            }

            [Test]
            public void SequenceNullDefaultValueEmpty()
            {
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(), Throws.Nothing);
                Assert.That(() => NullSequence.Of<string>().MaxOrDefault(), Is.EqualTo(default(string)));
            }

          

            #region Integer
            [Test]
            public void IntegerGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(), Is.EqualTo(_intArray.Max()));
            }

            [Test]
            public void IntegerGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(DefaultIntValue), Is.EqualTo(_intArray.Max()));
            }

            [Test]
            public void IntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void IntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void IntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(), Is.EqualTo(default(int)));
            }
            #endregion

            #region Nullable Integer
            [Test]
            public void NullableIntegerGoodInputNoDefault()
            {
                Assert.That(_nullableIntArray.MaxOrDefault(), Is.EqualTo(_nullableIntArray.Max()));
            }

            [Test]
            public void NullableIntegerGoodInputDefault()
            {
                Assert.That(_nullableIntArray.MaxOrDefault(DefaultIntValue), Is.EqualTo(_nullableIntArray.Max()));
            }

            [Test]
            public void NullableIntegerEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int?>().MaxOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerEmptyInputNoDefault()
            {
                Assert.That(() => Enumerable.Empty<int?>().MaxOrDefault(), Is.EqualTo(default(int)));
            }

            [Test]
            public void NullableIntegerNullInputDefault()
            {
                Assert.That(NullSequence.Of<int?>().MaxOrDefault(DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void NullableIntegerNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int?>().MaxOrDefault(), Is.EqualTo(default(int)));
            }
            #endregion

            #region Decimal
            [Test]
            public void DecimalGoodInputNoDefault()
            {
                Assert.That(_decimalArray.MaxOrDefault(), Is.EqualTo(_decimalArray.Max()));
            }

            [Test]
            public void DecimalGoodInputDefault()
            {
                Assert.That(_decimalArray.MaxOrDefault(DefaultDecimalValue), Is.EqualTo(_decimalArray.Max()));
            }

            [Test]
            public void DecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().MaxOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal>().MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void DecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal>().MaxOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void DecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal>().MaxOrDefault(), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Nullable Decimal
            [Test]
            public void NullableDecimalGoodInputNoDefault()
            {
                Assert.That(_nullableDecimalArray.MaxOrDefault(), Is.EqualTo(_nullableDecimalArray.Max()));
            }

            [Test]
            public void NullableDecimalGoodInputDefault()
            {
                Assert.That(_nullableDecimalArray.MaxOrDefault(DefaultDecimalValue), Is.EqualTo(_nullableDecimalArray.Max()));
            }

            [Test]
            public void NullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().MaxOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<decimal?>().MaxOrDefault(), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void NullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().MaxOrDefault(DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void NullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<decimal?>().MaxOrDefault(), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Double
            [Test]
            public void DoubleGoodInputNoDefault()
            {
                Assert.That(_doubleArray.MaxOrDefault(), Is.EqualTo(_doubleArray.Max()));
            }

            [Test]
            public void DoubleGoodInputDefault()
            {
                Assert.That(_doubleArray.MaxOrDefault(DefaultDoubleValue), Is.EqualTo(_doubleArray.Max()));
            }

            [Test]
            public void DoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double>().MaxOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double>().MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void DoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double>().MaxOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void DoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double>().MaxOrDefault(), Is.EqualTo(default(double)));
            }
            #endregion

            #region Nullable Double
            [Test]
            public void NullableDoubleGoodInputNoDefault()
            {
                Assert.That(_nullableDoubleArray.MaxOrDefault(), Is.EqualTo(_nullableDoubleArray.Max()));
            }

            [Test]
            public void NullableDoubleGoodInputDefault()
            {
                Assert.That(_nullableDoubleArray.MaxOrDefault(DefaultDoubleValue), Is.EqualTo(_nullableDoubleArray.Max()));
            }

            [Test]
            public void NullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<double?>().MaxOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<double?>().MaxOrDefault(), Is.EqualTo(default(double)));
            }

            [Test]
            public void NullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<double?>().MaxOrDefault(DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void NullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<double?>().MaxOrDefault(), Is.EqualTo(default(double)));
            }
            #endregion

            #region Long
            [Test]
            public void LongGoodInputNoDefault()
            {
                Assert.That(_longArray.MaxOrDefault(), Is.EqualTo(_longArray.Max()));
            }

            [Test]
            public void LongGoodInputDefault()
            {
                Assert.That(_longArray.MaxOrDefault(DefaultLongValue), Is.EqualTo(_longArray.Max()));
            }

            [Test]
            public void LongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long>().MaxOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long>().MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void LongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long>().MaxOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void LongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long>().MaxOrDefault(), Is.EqualTo(default(long)));
            }
            #endregion

            #region Nullable Long
            [Test]
            public void NullableLongGoodInputNoDefault()
            {
                Assert.That(_nullableLongArray.MaxOrDefault(), Is.EqualTo(_nullableLongArray.Max()));
            }

            [Test]
            public void NullableLongGoodInputDefault()
            {
                Assert.That(_nullableLongArray.MaxOrDefault(DefaultLongValue), Is.EqualTo(_nullableLongArray.Max()));
            }

            [Test]
            public void NullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<long?>().MaxOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<long?>().MaxOrDefault(), Is.EqualTo(default(long)));
            }

            [Test]
            public void NullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<long?>().MaxOrDefault(DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void NullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<long?>().MaxOrDefault(), Is.EqualTo(default(long)));
            }
            #endregion

            #region Float
            [Test]
            public void FloatGoodInputNoDefault()
            {
                Assert.That(_floatArray.MaxOrDefault(), Is.EqualTo(_floatArray.Max()));
            }

            [Test]
            public void FloatGoodInputDefault()
            {
                Assert.That(_floatArray.MaxOrDefault(DefaultFloatValue), Is.EqualTo(_floatArray.Max()));
            }

            [Test]
            public void FloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float>().MaxOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float>().MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void FloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float>().MaxOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void FloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float>().MaxOrDefault(), Is.EqualTo(default(float)));
            }
            #endregion

            #region Nullable Float
            [Test]
            public void NullableFloatGoodInputNoDefault()
            {
                Assert.That(_nullableFloatArray.MaxOrDefault(), Is.EqualTo(_nullableFloatArray.Max()));
            }

            [Test]
            public void NullableFloatGoodInputDefault()
            {
                Assert.That(_nullableFloatArray.MaxOrDefault(DefaultFloatValue), Is.EqualTo(_nullableFloatArray.Max()));
            }

            [Test]
            public void NullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<float?>().MaxOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<float?>().MaxOrDefault(), Is.EqualTo(default(float)));
            }

            [Test]
            public void NullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<float?>().MaxOrDefault(DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void NullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<float?>().MaxOrDefault(), Is.EqualTo(default(float)));
            }
            #endregion

            #region Projection Decimal
            [Test]
            public void ProjectionDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_decimalFunc), Is.EqualTo(_intArray.Select(_decimalFunc).Max()));
            }

            [Test]
            public void ProjectionDecimalGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_decimalFunc).Max()));
            }

            [Test]
            public void ProjectionDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_decimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_decimalFunc), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Projection Nullable Decimal
            [Test]
            public void ProjectionNullableDecimalGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableDecimalFunc), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Max()));
            }

            [Test]
            public void ProjectionNullableDecimalGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(_intArray.Select(_nullableDecimalFunc).Max()));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableDecimalFunc, DefaultDecimalValue), Is.EqualTo(DefaultDecimalValue));
            }

            [Test]
            public void ProjectionNullableDecimalNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableDecimalFunc), Is.EqualTo(default(decimal)));
            }
            #endregion

            #region Projection Double
            [Test]
            public void ProjectionDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_doubleFunc), Is.EqualTo(_intArray.Select(_doubleFunc).Max()));
            }

            [Test]
            public void ProjectionDoubleGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_doubleFunc).Max()));
            }

            [Test]
            public void ProjectionDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_doubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_doubleFunc), Is.EqualTo(default(double)));
            }
            #endregion

            #region Projection Nullable Double
            [Test]
            public void ProjectionNullableDoubleGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableDoubleFunc), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Max()));
            }

            [Test]
            public void ProjectionNullableDoubleGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(_intArray.Select(_nullableDoubleFunc).Max()));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableDoubleFunc, DefaultDoubleValue), Is.EqualTo(DefaultDoubleValue));
            }

            [Test]
            public void ProjectionNullableDoubleNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableDoubleFunc), Is.EqualTo(default(double)));

            }
            #endregion

            #region Projection Int
            [Test]
            public void ProjectionIntGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_intFunc), Is.EqualTo(_intArray.Select(_intFunc).Max()));
            }

            [Test]
            public void ProjectionIntGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_intFunc).Max()));
            }

            [Test]
            public void ProjectionIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_intFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_intFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_intFunc), Is.EqualTo(default(int)));
            }
            #endregion

            #region Projection Nullable Int
            [Test]
            public void ProjectionNullableIntGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableIntFunc), Is.EqualTo(_intArray.Select(_nullableIntFunc).Max()));
            }

            [Test]
            public void ProjectionNullableIntGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(_intArray.Select(_nullableIntFunc).Max()));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }

            [Test]
            public void ProjectionNullableIntNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableIntFunc, DefaultIntValue), Is.EqualTo(DefaultIntValue));
            }

            [Test]
            public void ProjectionNullableIntNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableIntFunc), Is.EqualTo(default(int)));
            }
            #endregion

            #region Projection Long
            [Test]
            public void ProjectionLongGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_longFunc), Is.EqualTo(_intArray.Select(_longFunc).Max()));
            }

            [Test]
            public void ProjectionLongGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_longFunc).Max()));
            }

            [Test]
            public void ProjectionLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_longFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_longFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_longFunc), Is.EqualTo(default(long)));
            }
            #endregion

            #region Projection Nullable Long
            [Test]
            public void ProjectionNullableLongGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableLongFunc), Is.EqualTo(_intArray.Select(_nullableLongFunc).Max()));
            }

            [Test]
            public void ProjectionNullableLongGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(_intArray.Select(_nullableLongFunc).Max()));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }

            [Test]
            public void ProjectionNullableLongNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableLongFunc, DefaultLongValue), Is.EqualTo(DefaultLongValue));
            }

            [Test]
            public void ProjectionNullableLongNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableLongFunc), Is.EqualTo(default(long)));
            }
            #endregion

            #region Projection Float
            [Test]
            public void ProjectionFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_floatFunc), Is.EqualTo(_intArray.Select(_floatFunc).Max()));
            }

            [Test]
            public void ProjectionFloatGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_floatFunc).Max()));
            }

            [Test]
            public void ProjectionFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_floatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_floatFunc), Is.EqualTo(default(float)));
            }
            #endregion

            #region Projection Nullable Float
            [Test]
            public void ProjectionNullableFloatGoodInputNoDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableFloatFunc), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Max()));
            }

            [Test]
            public void ProjectionNullableFloatGoodInputDefault()
            {
                Assert.That(_intArray.MaxOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(_intArray.Select(_nullableFloatFunc).Max()));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatEmptyInputNoDefault()
            {
                Assert.That(Enumerable.Empty<int>().MaxOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }

            [Test]
            public void ProjectionNullableFloatNullInputDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableFloatFunc, DefaultFloatValue), Is.EqualTo(DefaultFloatValue));
            }

            [Test]
            public void ProjectionNullableFloatNullInputNoDefault()
            {
                Assert.That(NullSequence.Of<int>().MaxOrDefault(_nullableFloatFunc), Is.EqualTo(default(float)));
            }
            #endregion

        }

    }
}