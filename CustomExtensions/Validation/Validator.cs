using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions.Validation
{
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/


    public sealed class Validator
    {
        private readonly List<Exception> _exceptions;

        public Validator()
        {
            _exceptions = new List<Exception>(1); // optimize for only having 1 exception
        }

        public IEnumerable<Exception> Exceptions
        {
            get
            {
                return _exceptions.AsReadOnly();
            }
        }

        public Validator AddException(Exception ex)
        {
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }

            return this;
        }
    }
}