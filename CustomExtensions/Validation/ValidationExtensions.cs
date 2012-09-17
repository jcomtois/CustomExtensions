using System;
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
        /// This method will throw any exceptions contained in <paramref name="validation"/>.  This method must be called 
        /// otherwise exceptions will not be thrown.
        /// </summary>
        /// <param name="validation">Will be null if no exceptions found, otherwise will contain exceptions</param>
        /// <returns>Either an instance or null reference to <see cref="Validation"/></returns>
        public static Validation CheckForExceptions(this Validation validation)
        {
            if (validation == null)
            {
                return null;
            }
            if (validation.Exceptions.Take(2).Count() == 1) // Ensures exactly one
            {
                throw new ValidationException("Single validation failure.", validation.Exceptions.First()); 
            }
            throw new ValidationException("Multiple validation failure.", new MultiException(validation.Exceptions));
        }

        /// <summary>
        /// Adds exception to validation if object is null.
        /// </summary>
        /// <typeparam name="T">Type of object <paramref name="theObject"/>.  Must be a class.</typeparam>
        /// <param name="validation">Reference to <see cref="Validation"/>.  May be null.</param>
        /// <param name="theObject">Actual parameter being checked.</param>
        /// <param name="paramterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validation"/> reference or null.</returns>
        public static Validation IsNotNull <T>(this Validation validation, T theObject, string paramterName) where T : class
        {
            return theObject != null 
                ? validation 
                : (validation ?? new Validation()).AddException(new ArgumentNullException(paramterName));
        }

        /// <summary>
        /// Adds exception to validation if value is greater than or equal to 0
        /// </summary>
        /// <param name="validation">Reference to <see cref="Validation"/>.  May be null.</param>
        /// <param name="value">Actual <see cref="long"/> parameter to be checked.</param>
        /// <param name="parameterName">Name of parameter to include in exception message if necessary.</param>
        /// <returns><see cref="Validation"/> reference or null.</returns>
        public static Validation IsNonNegative(this Validation validation, long value, string parameterName)
        {
            return value >= 0 
                ? validation 
                : (validation ?? new Validation()).AddException(new ArgumentOutOfRangeException(parameterName, string.Format("Must be >= 0, but was {0}", value)));
        }
    }
}