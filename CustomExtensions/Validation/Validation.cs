using System;
using System.Collections.Generic;

namespace CustomExtensions.Validation
{
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/


    public sealed class Validation
    {
        private readonly List<Exception> _exceptions;

        public Validation()
        {
            _exceptions = new List<Exception>(1); // optimize for only having 1 exception
        }

        public Exception[] Exceptions
        {
            get
            {
                return _exceptions.ToArray();
            }
        }

        public Validation AddException(Exception ex)
        {
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }

            return this;
        }
    }
}