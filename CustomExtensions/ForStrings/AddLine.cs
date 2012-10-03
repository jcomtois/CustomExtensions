﻿using System;
using System.Diagnostics;
using System.Text;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendStringBuilder
    {
        private class ConsoleLineWriter : ILineWriter
        {
            private static readonly ConsoleLineWriter _consoleLineWriter;

            static ConsoleLineWriter()
            {
                _consoleLineWriter = new ConsoleLineWriter();
            }

            private ConsoleLineWriter()
            {
            }

            #region ILineWriter Members

            public void WriteLine()
            {
                Console.WriteLine();
            }

            public void WriteLine(string value)
            {
                Console.WriteLine(value);
            }

            #endregion

            public static ConsoleLineWriter GetWriter()
            {
                return _consoleLineWriter;
            }
        }

        /// <summary>
        /// Appends a line to given string builder and outputs that line to the console.
        /// </summary>
        /// <param name="stringBuilder"><see cref="StringBuilder"/> to append the line to</param>
        /// <param name="text">Line of text to append and output.  Default null will append blank line.</param>
        /// <param name="lineWriter">Will use <see cref="System.Console"/> if none provided</param>
        /// <returns><paramref name="stringBuilder"/> with line appended.</returns>
        public static StringBuilder AddLine(this StringBuilder stringBuilder, string text = null, ILineWriter lineWriter = null)
        {
            Validate.Begin()
                .IsNotNull(stringBuilder, "stringBuilder")
                .CheckForExceptions();

            var lineWriterToUse = lineWriter ?? ConsoleLineWriter.GetWriter();

            return AddLineImplementation(stringBuilder, text, lineWriterToUse);
        }

        private static StringBuilder AddLineImplementation(StringBuilder stringBuilder, string text, ILineWriter lineWriter)
        {
            Debug.Assert(stringBuilder != null, "stringBuilder != null");
            Debug.Assert(lineWriter != null, "lineWriter != null");

            if (text.IsNullOrEmpty())
            {
                lineWriter.WriteLine();
                return stringBuilder.AppendLine();
            }
            lineWriter.WriteLine(text);
            return stringBuilder.AppendLine(text);
        }
    }
}