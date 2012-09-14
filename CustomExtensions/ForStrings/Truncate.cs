namespace CustomExtensions.ForStrings
{
    public static partial class ForStrings
    {
        /// <summary>
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="source"> string that will be truncated </param>
        /// <param name="maxLength"> total length of characters to maintain before the truncate happens </param>
        /// <returns> truncated string </returns>
        public static string Truncate(this string source, int maxLength)
        {
            if (maxLength <= 0 || source.IsNullOrEmpty() || source.Length <= maxLength)
            {
                return source;
            }

            const string suffix = "...";

            var strLength = maxLength - suffix.Length;
            return strLength <= 0 ? source : string.Format("{0}{1}", source.Substring(0, strLength), suffix);
        }
    }
}