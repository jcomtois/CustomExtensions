using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CustomExtensions.Validation;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Returns random element from sequence
        /// </summary>
        /// <param name="source">Source sequence</param>
        /// <param name="random">Random class instance</param>
        /// <typeparam name="T">Type conained in source</typeparam>
        /// <returns>Random Elelemnt from sequence</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static T RandomElement <T>(this IEnumerable<T> source, Random random)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .IsNotNull(random, "random")
                .CheckForExceptions();

            return RandomElementImplementation(source, random);
        }

        private static T RandomElementImplementation <T>(IEnumerable<T> source, Random random)
        {
            Debug.Assert(random != null, "random != null");
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source != null && source.Any(), "source cannot be empty");

            var collection = source as ICollection;
            if (collection != null)
            {
                var count = collection.Count;
                var index = random.Next(count);
                return source.ElementAt(index);
            }
            using (var iterator = source.GetEnumerator())
            {
                var start = iterator.MoveNext();
                Debug.Assert(start, "source cannot be empty");
                var countSoFar = 1;
                var current = iterator.Current;
                while (iterator.MoveNext())
                {
                    countSoFar++;
                    if (random.Next(countSoFar) == 0)
                    {
                        current = iterator.Current;
                    }
                }
                return current;
            }
        }
    }
}