using System;

namespace CustomExtensions.ForStrings
{
    public static partial class ForStrings
    {
        /// <summary>
        /// Returns bool indicating whether provided string is is valide as absolute Uri
        /// </summary>
        /// <param name="source"> The string to check </param>
        /// <returns></returns>
        public static bool IsValidUrl(this string source)
        {
            return Uri.IsWellFormedUriString(source, UriKind.Absolute);
        }
    }
}