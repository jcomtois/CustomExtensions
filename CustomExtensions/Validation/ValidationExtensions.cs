using System;
using System.Globalization;
using System.Linq;

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