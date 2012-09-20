using System;
using CustomExtensions.COMInterop;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Attempts to convert a string to a guid.
        /// </summary>
        /// <param name="source">The string to try to convert</param>
        /// <param name="resultGuid">Upon return will contain the Guid</param>
        /// <returns>Returns true if successful, otherwise false</returns>
        public static bool TryToGuid(this string source, out Guid resultGuid)
        {
            //ClsidFromString returns the empty guid for null strings   
            if (source.IsNullOrEmpty())
            {
                resultGuid = Guid.Empty;
                return false;
            }

            var hresult = NativeMethods.CLSIDFromString(source, out resultGuid);
            if (hresult >= 0)
            {
                return true;
            }
            resultGuid = Guid.Empty;
            return false;
        }
    }
}