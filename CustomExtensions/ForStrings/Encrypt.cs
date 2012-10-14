#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Diagnostics;
using CustomExtensions.Interfaces;
using CustomExtensions.Validation;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Provides simple AES encryption via a key for a UTF8 Message.
        /// Must be decrypted with corresponding <see cref="Decrypt"/> method
        /// </summary>
        /// <param name="source">UTF8 Encoded string to be encrypted</param>
        /// <param name="key">Password to be used for encryption.  Default MinimumLength of 12 for default encryptor</param>
        /// <param name="encryptor">Optional <see cref="IEncrypt"/> to use.  Uses default implementation if none supplied.</param>
        /// <returns>Encrypted string.</returns>
        /// <exception cref="ValidationException">Occurs when <paramref name="source"/>is null or empty, when <paramref name="key"/> 
        /// is null or empty, when <paramref name="key"/> length is less than MinimumPasswordLength for <see cref="IEncrypt"/> to be used.
        /// </exception>
        public static string Encrypt(this string source, string key, IEncrypt encryptor = null)
        {
            var encryptorToUse = encryptor ?? new AESEncryption();

            Validate.Begin()
                .IsNotNull(source, "source")
                .IsNotEmpty(source, "source")
                .IsNotNull(key, "key")
                .IsNotEmpty(key, "key")
                .HasAtLeast(encryptorToUse.MinimumPasswordLength, key, "key")
                .CheckForExceptions();

            return EncryptImplementation(source, key, encryptorToUse);
        }

        private static string EncryptImplementation(string source, string key, IEncrypt encryptor)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(source.Length > 0, "source cannot be empty");
            Debug.Assert(encryptor != null, "encryptor != null");
            Debug.Assert(key != null, "key != null");
            Debug.Assert(key.Length >= encryptor.MinimumPasswordLength, "key too short");

            return encryptor.EncryptAES(source, key);
        }
    }
}