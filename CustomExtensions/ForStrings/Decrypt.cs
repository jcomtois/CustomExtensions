using System.Diagnostics;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Provides simple AES decryption via a key for an encrypted Message.
        /// Must be encrypted with corresponding <see cref="Encrypt"/> method
        /// </summary>
        /// <param name="source">Encrypted string to be decrypted</param>
        /// <param name="key">Password to be used for decryption.  Default MinimumLength of 12 for default decryptor</param>
        /// <param name="decryptor">Optional <see cref="IDecrypt"/> to use.  Uses default implementation if none supplied.</param>
        /// <returns>Decrypted string.</returns>
        /// <exception cref="ValidationException">Occurs when <paramref name="source"/>is null or empty, when <paramref name="key"/> 
        /// is null or empty, when <paramref name="key"/> length is less than MinimumPasswordLength for <see cref="IEncrypt"/> to be used.
        /// </exception>
        public static string Decrypt(this string source, string key, IDecrypt decryptor = null)
        {
            var decryptorToUse = decryptor ?? new AESEncryption();
            
            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .IsNotNull(key, "key")
                .IsNotEmpty(key, "key")
                .HasAtLeast(decryptorToUse.MinimumPasswordLength, key, "key")
                .CheckForExceptions();

            return DecryptImplementation(source, key, decryptorToUse);
        }

        private static string DecryptImplementation(string source, string key, IDecrypt decryptor)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0, "source cannot be empty");
            Debug.Assert(decryptor != null, "decryptor != null");
            Debug.Assert(key != null, "key != null");
            Debug.Assert(key.Length >= decryptor.MinimumPasswordLength, "key too short"); 

            return decryptor.DecryptAES(source, key);
        }
    }
}