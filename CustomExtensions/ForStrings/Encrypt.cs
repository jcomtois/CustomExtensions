using System;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions.ForStrings
{
    public static partial class ForStrings
    {
        /// <summary>
        /// Encrypts a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="source"> String that must be encrypted. </param>
        /// <param name="key"> Encryptionkey. </param>
        /// <returns> A string representing a byte array separated by a minus sign. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string source, string key)
        {
            if (source.IsNullOrEmpty())
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (key.IsNullOrEmpty())
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            var cspParameters = new CspParameters {KeyContainerName = key};
            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters) {PersistKeyInCsp = true})
            {
                return
                    BitConverter.ToString(rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(source), true));
            }
        }
    }
}