using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions.Strings
{
    public static class Strings
    {
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
                using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters) {
                                                                                                      PersistKeyInCsp = true
                                                                                                  })
                {
                    var decryptArray = StringToDecrypt.Split(new[] {"-"}, StringSplitOptions.None);
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

        /// <summary>
        ///   Encryptes a string using the supplied key. Encoding is done using RSA encryption.
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
                return
                    BitConverter.ToString(rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(StringToEncrypt), true));
            }
        }

        /// <summary>
        /// Returns bool indicating whether provided string is is valide as absolute Uri
        /// </summary>
        /// <param name="Text"> The string to check </param>
        /// <returns></returns>
        public static bool IsValidUrl(this string Text)
        {
            return Uri.IsWellFormedUriString(Text, UriKind.Absolute);
        }

        /// <summary>
        /// Returns the first few characters of the string with a length specified by the given parameter. If the string's length is less than the given length the complete string is returned. If length is zero or less an empty string is returned
        /// </summary>
        /// <param name="Text"> the string to process </param>
        /// <param name="Length"> Number of characters to return </param>
        /// <returns> </returns>
        public static string Left(this string Text, int Length)
        {
            Length = Math.Max(Length, 0);
            return Text.Length > Length ? Text.Substring(0, Length) : Text;
        }

        /// <summary>
        /// Returns the last few characters of the string with a length specified by the given parameter. If the string's length is less than the given length the complete string is returned. If length is zero or less an empty string is returned
        /// </summary>
        /// <param name="s"> the string to process </param>
        /// <param name="Length"> Number of characters to return </param>
        /// <returns> </returns>
        public static string Right(this string s, int Length)
        {
            Length = Math.Max(Length, 0);

            return s.Length > Length ? s.Substring(s.Length - Length, Length) : s;
        }

        /// <summary>
        /// Splits a string into a NameValueCollection, where each "namevalue" is separated by
        /// the "OuterSeparator". The parameter "NameValueSeparator" sets the split between Name and Value.
        /// Example: 
        ///             String str = "param1=value1;param2=value2";
        ///             NameValueCollection nvOut = str.ToNameValueCollection(';', '=');
        ///             
        /// The result is a NameValueCollection where:
        ///             key[0] is "param1" and value[0] is "value1"
        ///             key[1] is "param2" and value[1] is "value2"
        /// </summary>
        /// <param name="Text">String to process</param>
        /// <param name="OuterSeparator">Separator for each "NameValue"</param>
        /// <param name="NameValueSeparator">Separator for Name/Value splitting</param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection(this string Text, char OuterSeparator, char NameValueSeparator)
        {
            if (OuterSeparator == NameValueSeparator)
            {
                throw new ArgumentException("Seperators must be different values.");
            }

            var nameValueCollection = new NameValueCollection();
            if (!string.IsNullOrEmpty(Text))
            {
                var arrStrings = Text.TrimEnd(OuterSeparator).Split(OuterSeparator);

                foreach (var strings in arrStrings.Select(s => s.Split(NameValueSeparator)))
                {
                    nameValueCollection.Add(strings.First(), strings.Last());
                }
            }
            return nameValueCollection;
        }

        /// <summary>
        ///   Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="Text"> string that will be truncated </param>
        /// <param name="MaxLength"> total length of characters to maintain before the truncate happens </param>
        /// <returns> truncated string </returns>
        public static string Truncate(this string Text, int MaxLength)
        {
            if (MaxLength <= 0 || string.IsNullOrEmpty(Text) || Text.Length <= MaxLength)
            {
                return Text;
            }

            const string suffix = "...";

            var strLength = MaxLength - suffix.Length;
            return strLength <= 0 ? Text : string.Format("{0}{1}", Text.Substring(0, strLength), suffix);
        }
    }
}