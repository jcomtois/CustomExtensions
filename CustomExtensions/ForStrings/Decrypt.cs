using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Decrypts a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="source"> String that must be decrypted. </param>
        /// <param name="key"> Decryptionkey. </param>
        /// <returns> The decrypted string or null if decryption failed. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string source, string key)
        {
            if (source.IsNullOrEmpty())
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (key.IsNullOrEmpty())
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            var cspParameters = new CspParameters {KeyContainerName = key};
            try
            {
                using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters) {
                                                                                                      PersistKeyInCsp = true
                                                                                                  })
                {
                    var decryptArray = source.Split(new[] {"-"}, StringSplitOptions.None);
                    var decryptByteArray = Array.ConvertAll(decryptArray,
                                                            (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));
                    return Encoding.UTF8.GetString(rsaCryptoServiceProvider.Decrypt(decryptByteArray, true));
                }
            }
            catch (CryptographicException)
            {
                return null;
            }
        }
    }
}