using System;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        /// <summary>
        /// Used to test a class implementing IConvertible that always throws InvalidCastExceptions
        /// </summary>
        private class TestObject : IConvertible
        {
            #region IConvertible Members

            public TypeCode GetTypeCode()
            {
                return String.Empty.GetTypeCode();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            #endregion
        }
    }
}