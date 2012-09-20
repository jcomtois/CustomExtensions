namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Readability improvement for String.IsNullOrEmpty()
        /// </summary>
        /// <param name="Input">The string to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string Input)
        {
            return string.IsNullOrEmpty(Input);
        }
    }
}