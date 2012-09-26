using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomExtensions.Validation;
using MoreLinq;

namespace CustomExtensions.ForIEnumerable
{
    public static partial class ExtendIEnumerable
    {
        /// <summary>
        /// Wrapper for Morelinq.ForEach
        /// Performs an action on each element in <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">Type contained in <paramref name="source"/></typeparam>
        /// <param name="source">Sequence of type <typeparamref name="T"/></param>
        /// <param name="action"><see cref="Action"/> to be immediately applied to each element in <paramref name="source"/></param>
        /// <exception cref="ValidationException"> if <paramref name="source"/> is null or <paramref name="action"/> is null</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotNull(action, "action")
                .CheckForExceptions();

            ForEachImplementation(source, action);
        }

        private static void ForEachImplementation <T>(IEnumerable<T> source, Action<T> action)
        {
            Debug.Assert(action != null, "action != null");
            Debug.Assert(source != null, "source != null");

            MoreEnumerable.ForEach(source, action);
        }
    }
}