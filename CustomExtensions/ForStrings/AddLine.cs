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
using System.Diagnostics;
using System.Text;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendStringBuilder
    {
        private sealed class ConsoleLineWriter : ILineWriter
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