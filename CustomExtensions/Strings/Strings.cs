using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions.Strings
{
    public static class Strings
    {
        /// <summary>
        /// Encryptes a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="StringToEncrypt"> String that must be encrypted. </param>
        /// <param name="Key"> Encryptionkey. </param>
        /// <returns> A string representing a byte array separated by a minus sign. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string StringToEncrypt, string Key)
        {
            if (string.IsNullOrEmpty(StringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            var cspParameters = new CspParameters {KeyContainerName = Key};
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters) {PersistKeyInCsp = true})
            {
                return BitConverter.ToString(rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(StringToEncrypt), true));
            }
        }

        /// <summary>
        /// Decryptes a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="StringToDecrypt"> String that must be decrypted. </param>
        /// <param name="Key"> Decryptionkey. </param>
        /// <returns> The decrypted string or null if decryption failed. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string StringToDecrypt, string Key)
        {
            if (string.IsNullOrEmpty(StringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            var cspParameters = new CspParameters {KeyContainerName = Key};
            try
            {
                using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters)
                {
                    PersistKeyInCsp = true
                })
                {
                    var decryptArray = StringToDecrypt.Split(new[] { "-" }, StringSplitOptions.None);
                    var decryptByteArray = Array.ConvertAll(decryptArray, (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));
                    return Encoding.UTF8.GetString(rsaCryptoServiceProvider.Decrypt(decryptByteArray, true));
                }
            }
            catch (CryptographicException)
            {
                return null;
            }
            
        }

        /// <summary>
        ///   Returns the last few characters of the string with a length specified by the given parameter. If the string's length is less than the given length the complete string is returned. If length is zero or less an empty string is returned
        /// </summary>
        /// <param name="s"> the string to process </param>
        /// <param name="Length"> Number of characters to return </param>
        /// <returns> </returns>
        public static string Right(this string s, int Length)
        {
            Length = Math.Max(Length, 0);

            return s.Length > Length ? s.Substring(s.Length - Length, Length) : s;
        }
    }
}