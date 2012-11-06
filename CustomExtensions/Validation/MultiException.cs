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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CustomExtensions.Validation
{
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/

    /// <summary>
    /// This exception class can contain mutliple innter exceptions
    /// </summary>
    [Serializable]
    public sealed class MultiException : Exception
    {
        private readonly Exception[] _innerExceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// </summary>
        public MultiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MultiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public MultiException(string message, Exception innerException)
            : this(message, innerException != null ? new[] {innerException} : new[] {new ArgumentNullException("innerException")})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class with a reference to the inner exception(s) that is/are the cause(s) of this exception.
        /// </summary>
        /// <param name="innerExceptions">The inner exception(s) that is/are the cause(s) of this exception.</param>
        public MultiException(IEnumerable<Exception> innerExceptions) : this(null, innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class with a reference to the inner exception(s) that is/are the cause(s) of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerExceptions">The inner exception(s) that is/are the cause(s) of this exception.</param>
        public MultiException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions != null ? innerExceptions.FirstOrDefault() : new ArgumentNullException("innerExceptions"))
        {
            if (innerExceptions == null)
            {
                try
                {
                    throw new ArgumentNullException("innerExceptions");
                }
                catch (ArgumentNullException ex)
                {
                    innerExceptions = new[] {ex};
                }
            }
            _innerExceptions = innerExceptions.Where(x => x != null).ToArray();
        }

        private MultiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Provides an <see cref="IEnumerable{Exception}"/> of all inner exceptions associated with this exception instance
        /// </summary>
        public IEnumerable<Exception> InnerExceptions
        {
            get
            {
                if (_innerExceptions != null)
                {
                    foreach (var t in _innerExceptions)
                    {
                        yield return t;
                    }
                }
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("InnerExceptions", _innerExceptions);
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, InnerExceptions.Select(x => x.Message).ToArray());
        }
    }
}