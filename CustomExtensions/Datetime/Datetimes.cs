using System.Globalization;

namespace CustomExtensions.DateTimes
{
    /// <summary>
    /// Extensions for System.DateTime
    /// </summary>
    public static class DateTimes
    {
        /// <summary>
        /// Formats to a string in yyyyMMdd pattern
        /// </summary>
        /// <param name="InputDateTime"></param>
        /// <returns></returns>
        public static string FormatyyyyMMdd(this System.DateTime InputDateTime)
        {
            var dateTimeFormatInfo = new CultureInfo("en-US", false).DateTimeFormat;
            return InputDateTime.ToString("yyyyMMdd", dateTimeFormatInfo);
        }
    }
}