using System;
using System.Globalization;

namespace CustomExtensions.ForDateTime
{   
    public static partial class ExtendDateTime
    {
        /// <summary>
        /// Formats <paramref name="source"/> to a string in yyyyMMdd pattern.  Uses en-US for <see cref="CultureInfo"/>
        /// </summary>
        /// <param name="source"><see cref="DateTime"/> to parse.</param>
        /// <returns><see cref="string"/> representing date as yyyyMMdd</returns>
        public static string FormatyyyyMMdd(this DateTime source)
        {            
            var dateTimeFormatInfo = new CultureInfo("en-US", false).DateTimeFormat;
            return source.ToString("yyyyMMdd", dateTimeFormatInfo);
        }
    }
}