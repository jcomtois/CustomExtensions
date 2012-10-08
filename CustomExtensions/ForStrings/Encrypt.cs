using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        private class RSAEncryptor : IEncrypt
        {
            private readonly CspParameters _cspParameters;

            public RSAEncryptor(string key)
            {
                Debug.Assert(key != null, "key != null");
                Debug.Assert(key.Length > 0, "key cannot be empty");

                _cspParameters = new CspParameters {KeyContainerName = key};
            }

            #region IEncrypt Members

            public string Encrypt(string source)
            {
                Debug.Assert(source != null, "source != null");
                Debug.Assert(source.Length > 0, "source cannot be empty");

                using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(_cspParameters) {PersistKeyInCsp = true})
                {
                    return BitConverter.ToString(rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(source), true));
                }
            }

            #endregion
        }

        /// <summary>
        /// Encrypts a string using the supplied key. Default encoding is done using RSA encryption and UTF8 encoding.
        /// </summary>
        /// <param name="source"> String that must be encrypted.</param>
        /// <param name="key"> Encryption key. </param>
        /// <param name="encryptor">If none provided, RSACryptoServiceProvider will be used</param>
        /// <returns> A hexadecimal string representing a byte array separated by a minus sign. </returns>
        /// <exception cref="ValidationException">Occurs when <paramref name="source"/> or <paramref name="key"/> is null or empty.</exception>
        public static string Encrypt(this string source, string key, IEncrypt encryptor = null)
        {
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .IsNotNull(key, "key")
                .IsNotEmpty(key, "key")
                .CheckForExceptions();

            var encryptorToUse = encryptor ?? new RSAEncryptor(key);

            return EncryptImplementation(source, encryptorToUse);
        }

        private static string EncryptImplementation(string source, IEncrypt encryptor)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0, "source cannot be empty");
            Debug.Assert(encryptor != null, "encryptor != null");

            return encryptor.Encrypt(source);
        }
    }
}