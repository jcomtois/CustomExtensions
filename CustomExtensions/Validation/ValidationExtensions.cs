#region License and Terms

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
using System.Globalization;
using System.Linq;
using CustomExtensions.ForIEnumerable;

namespace CustomExtensions.Validation
{
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/

    /// <summary>
    /// Provides for validation of parameters in a fluent syntax
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Used to add any <see cref="Exception"/> to Validator
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="exception">Instance of <see cref="Exception"/> or derived classes.  If null, <see cref="ArgumentNullException"/> will be added</param>
        /// <returns><see cref="Validator"/> reference</returns>
        public static Validator AddCustomException(this Validator validator, Exception exception)
        {
            return (validator ?? new Validator()).AddException(exception ?? new ArgumentNullException("exception"));
        }

        /// <summary>
        /// This method will throw any exceptions contained in <paramref name="validator"/>.  This method must be called 
        /// otherwise exceptions will not be thrown.
        /// </summary>
        /// <param name="validator">Will be null if no exceptions found, otherwise will contain exceptions</param>
        /// <returns>Either an instance or null reference to <see cref="Validator"/></returns>
        public static Validator CheckForExceptions(this Validator validator)
        {
            if (validator == null ||
                !validator.Exceptions.Any())
            {
                return null;
            }

            if (validator.Exceptions.Take(2).Count() == 1) // Ensures exactly one
            {
                throw new ValidationException("Single validation failure.", validator.Exceptions.First());
            }
            throw new ValidationException("Multiple validation failure.", new MultiException(validator.Exceptions));
        }

        /// <summary>
        /// Adds exception to Validator if <paramref name="value"/> is equal to <paramref name="other"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual {T} parameter to be used as a value.</param>
        /// <param name="other">Actual {T} parameter to be used as a compared value.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <typeparam name="T"><see cref="IEquatable{T}"/></typeparam>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator DoesNotEqual <T>(this Validator validator, T value, T other, string parameterName) where T : IEquatable<T>
        {
            return !value.Equals(other)
                ? validator
                : validator.AddCustomException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} is equal to {1}", value, other), parameterName));
        }

        /// <summary>
        /// Adds exception to Validator if string is null or less than <paramref name="length"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="length">Minimum length of string.</param>
        /// <param name="value">String to check.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator HasAtLeast(this Validator validator, int length, string value, string parameterName)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "length must be >= 0");
            }

            return (value == null || value.Length < length)
                ? validator.AddCustomException(new ArgumentOutOfRangeException(parameterName, "Must not be null or < " + length))
                : validator;
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual {T} parameter to be used as a minimum value.</param>
        /// <param name="value">Actual {T} parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast <T>(this Validator validator, T minimumValue, T value, string parameterName) where T : IComparable<T>
        {
            return value.CompareTo(minimumValue) >= 0
                ? validator
                : validator.AddCustomException(new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.InvariantCulture, "Must be >= {0}, but was {1}", minimumValue, value)));
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="long"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="long"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, long minimumValue, long value, string parameterName)
        {
            return validator.IsAtLeast<long>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="int"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="int"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, int minimumValue, int value, string parameterName)
        {
            return validator.IsAtLeast<int>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="double"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="double"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, double minimumValue, double value, string parameterName)
        {
            return validator.IsAtLeast<double>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="decimal"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="decimal"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, decimal minimumValue, decimal value, string parameterName)
        {
            return validator.IsAtLeast<decimal>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="short"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="short"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, short minimumValue, short value, string parameterName)
        {
            return validator.IsAtLeast<short>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="float"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="float"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, float minimumValue, float value, string parameterName)
        {
            return validator.IsAtLeast<float>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="uint"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="uint"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, uint minimumValue, uint value, string parameterName)
        {
            return validator.IsAtLeast<uint>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="byte"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="byte"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, byte minimumValue, byte value, string parameterName)
        {
            return validator.IsAtLeast<byte>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="ushort"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="ushort"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, ushort minimumValue, ushort value, string parameterName)
        {
            return validator.IsAtLeast<ushort>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to <paramref name="minimumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="minimumValue">Actual <see cref="ulong"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="ulong"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtLeast(this Validator validator, ulong minimumValue, ulong value, string parameterName)
        {
            return validator.IsAtLeast<ulong>(minimumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual {T} parameter to be used as a minimum value.</param>
        /// <param name="value">Actual {T} parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost <T>(this Validator validator, T maximumValue, T value, string parameterName) where T : IComparable<T>
        {
            return value.CompareTo(maximumValue) <= 0
                ? validator
                : validator.AddCustomException(new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.InvariantCulture, "Must be <= {0}, but was {1}", maximumValue, value)));
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="long"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="long"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, long maximumValue, long value, string parameterName)
        {
            return validator.IsAtMost<long>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="int"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="int"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, int maximumValue, int value, string parameterName)
        {
            return validator.IsAtMost<int>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="double"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="double"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, double maximumValue, double value, string parameterName)
        {
            return validator.IsAtMost<double>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="decimal"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="decimal"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, decimal maximumValue, decimal value, string parameterName)
        {
            return validator.IsAtMost<decimal>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="short"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="short"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, short maximumValue, short value, string parameterName)
        {
            return validator.IsAtMost<short>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="float"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="float"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, float maximumValue, float value, string parameterName)
        {
            return validator.IsAtMost<float>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="uint"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="uint"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, uint maximumValue, uint value, string parameterName)
        {
            return validator.IsAtMost<uint>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="byte"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="byte"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, byte maximumValue, byte value, string parameterName)
        {
            return validator.IsAtMost<byte>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="ushort"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="ushort"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, ushort maximumValue, ushort value, string parameterName)
        {
            return validator.IsAtMost<ushort>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not less than or equal to <paramref name="maximumValue"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="maximumValue">Actual <see cref="ulong"/> parameter to be used as a minimum value.</param>
        /// <param name="value">Actual <see cref="ulong"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsAtMost(this Validator validator, ulong maximumValue, ulong value, string parameterName)
        {
            return validator.IsAtMost<ulong>(maximumValue, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if <paramref name="value"/> does not equal <paramref name="other"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual {T} parameter to be used as a value.</param>
        /// <param name="other">Actual {T} parameter to be used as a compared value.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <typeparam name="T"><see cref="IEquatable{T}"/></typeparam>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsEqualTo <T>(this Validator validator, T value, T other, string parameterName) where T : IEquatable<T>
        {
            return value.Equals(other)
                ? validator
                : validator.AddCustomException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} does not equal {1}", value, other), parameterName));
        }

        /// <summary>
        /// Adds exception to Validator if <paramref name="value"/> less than or equal to <paramref name="other"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual {T} parameter to be used as a value.</param>
        /// <param name="other">Actual {T} parameter to be used as a compared value.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <typeparam name="T"><see cref="IComparable{T}"/></typeparam>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsGreaterThan <T>(this Validator validator, T value, T other, string parameterName) where T : IComparable<T>
        {
            return value.CompareTo(other) > 0
                ? validator
                : validator.AddCustomException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} not greater than {1}", value, other), parameterName));
        }

        /// <summary>
        /// Adds exception to Validator if <paramref name="value"/> greater than or equal to <paramref name="other"/>
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual {T} parameter to be used as a value.</param>
        /// <param name="other">Actual {T} parameter to be used as a compared value.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <typeparam name="T"><see cref="IComparable{T}"/></typeparam>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsLessThan <T>(this Validator validator, T value, T other, string parameterName) where T : IComparable<T>
        {
            return value.CompareTo(other) < 0
                ? validator
                : validator.AddCustomException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} not less than {1}", value, other), parameterName));
        }

        /// <summary>
        /// Adds exception to Validator if sequence is empty
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="sequence">Actual <see cref="IEnumerable{T}"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotEmpty <T>(this Validator validator, IEnumerable<T> sequence, string parameterName)
        {
            return (sequence == null || sequence.IsEmpty())
                ? validator.AddCustomException(new ArgumentException("Sequence cannot be empty.", parameterName))
                : validator;
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="long"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, long value, string parameterName)
        {
            return validator.IsAtLeast<long>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="short"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, short value, string parameterName)
        {
            return validator.IsAtLeast<short>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="int"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, int value, string parameterName)
        {
            return validator.IsAtLeast<int>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="float"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, float value, string parameterName)
        {
            return validator.IsAtLeast<float>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="double"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, double value, string parameterName)
        {
            return validator.IsAtLeast<double>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if value is not greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="decimal"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, decimal value, string parameterName)
        {
            return validator.IsAtLeast<decimal>(0, value, parameterName);
        }

        /// <summary>
        /// Adds exception to Validator if object is null.
        /// </summary>
        /// <typeparam name="T">Type of object <paramref name="theObject"/>.  Must be a class.</typeparam>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="theObject">Actual parameter being checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNull <T>(this Validator validator, T theObject, string parameterName) where T : class
        {
            return theObject != null
                ? validator
                : validator.AddCustomException(new ArgumentNullException(parameterName));
        }
    }
}