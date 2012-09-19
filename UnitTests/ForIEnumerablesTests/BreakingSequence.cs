using System;
using System.Collections;
using System.Collections.Generic;

namespace UnitTests
{
    /// <summary>
    /// Used to test for lazy evaluation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BreakingSequence<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}