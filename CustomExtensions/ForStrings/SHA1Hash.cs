using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CustomExtensions.ForIEnumerable;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Returns SHA1 Digest of ASCII reprensentation of input string
        /// </summary>
        /// <param name="source">String that will use ASCII endcoding</param>
        /// <returns>SHA1 digest</returns>
        public static string SHA1Hash(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            using (SHA1 sha = new SHA1Managed())
            {
                return sha.ComputeHash(Encoding.ASCII.GetBytes(source)).Select(x => string.Format("{0:x2}", x)).FlattenStrings();
            }
        }
    }
}