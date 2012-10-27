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

namespace CustomExtensions.Validation
{
    // Inspired by
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/

    /// <summary>
    /// Class that can be used to store a list of <see cref="Exception"/> to validate parameters
    /// </summary>
    public sealed class Validator
    {
        private readonly List<Exception> _exceptions;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Validator()
        {
            _exceptions = new List<Exception>(1); // optimize for only having 1 exception
        }

        /// <summary>
        /// Exceptions contained in this <see cref="Validator"/>
        /// </summary>
        public IEnumerable<Exception> Exceptions
        {
            get
            {
                return _exceptions.AsReadOnly();
            }
        }

        /// <summary>
        /// Thread-safe addition of <see cref="Exception"/> to this <see cref="Validator"/>
        /// </summary>
        /// <param name="exception">Exception to add</param>
        /// <returns>Reference to this <see cref="Validator"/></returns>
        public Validator AddException(Exception exception)
        {
            lock (_exceptions)
            {
                _exceptions.Add(exception);
            }

            return this;
        }       
    }
}