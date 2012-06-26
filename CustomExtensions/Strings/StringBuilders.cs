using System;
using System.Text;

namespace CustomExtensions.Strings
{
    public static class StringBuilders
    {
        public static StringBuilder AddLine(this StringBuilder sb, string NewText = null)
        {
            if (sb == null)
            {
                throw new ArgumentNullException();
            }
            if (NewText.IsNullOrEmpty())
            {
                Console.WriteLine();
                return sb.AppendLine();
            }
            Console.WriteLine(NewText);
            return sb.AppendLine(NewText);
        }
    }
}