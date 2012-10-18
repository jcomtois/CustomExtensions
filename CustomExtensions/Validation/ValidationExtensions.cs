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
                       ? (validator ?? new Validator()).AddException(new ArgumentOutOfRangeException(parameterName, "Must not be null or < " + length))
                       : validator;
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
                       ? (validator ?? new Validator()).AddException(new ArgumentException("Sequence cannot be empty.", parameterName))
                       : validator;
        }

        /// <summary>
        /// Adds exception to Validator if value is greater than or equal to 0
        /// </summary>
        /// <param name="validator">Reference to <see cref="Validator"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="long"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validator"/> reference or null.</returns>
        public static Validator IsNotNegative(this Validator validator, long value, string parameterName)
        {
            return value >= 0
                       ? validator
                       : (validator ?? new Validator()).AddException(new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.InvariantCulture, "Must be >= 0, but was {0}", value)));
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
                       : (validator ?? new Validator()).AddException(new ArgumentNullException(parameterName));
        }
    }
}