using System.Collections.Generic;

namespace UnitTests.ForIEnumerablesTests
{
    /// <summary>
    /// Helper class for testing
    /// </summary>
    internal static class NullSequence
    {
        /// <summary>
        /// Returns null 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
         public static IEnumerable<T> Of <T>()
         {
             return null;
         }
    }
}