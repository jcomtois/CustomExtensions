using System;
using System.Text;

namespace CustomExtensions.ForStrings
{
    public static partial class ForStringBuilders
    {
        /// <summary>
        /// Appends a line to given string builder and outputs that line to the console.
        /// </summary>
        /// <param name="stringBuilder"><see cref="StringBuilder"/> to append the line to</param>
        /// <param name="text">Line of text to append and output.  Default null will append blank line.</param>
        /// <returns><paramref name="stringBuilder"/> with line appended.</returns>
        public static StringBuilder AddLine(this StringBuilder stringBuilder, string text = null)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException();
            }
            if (text.IsNullOrEmpty())
            {
                Console.WriteLine();
                return stringBuilder.AppendLine();
            }
            Console.WriteLine(text);
            return stringBuilder.AppendLine(text);
        }
    }
}