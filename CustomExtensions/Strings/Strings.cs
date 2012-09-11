using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CustomExtensions.IEnumerables;
using CustomExtensions.PInvoke;

namespace CustomExtensions.Strings
{
    public static class Strings
    {
        /// <summary>
        /// Readability improvement for String.IsNullOrEmpty()
        /// </summary>
        /// <param name="Input">The string to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string Input)
        {
            return string.IsNullOrEmpty(Input);
        }

        /// <summary>
        /// Attempts to convert a string to a guid.
        /// </summary>
        /// <param name="Input">The string to try to convert</param>
        /// <param name="ResultGuid">Upon return will contain the Guid</param>
        /// <returns>Returns true if successful, otherwise false</returns>
        public static bool TryToGuid(this string Input, out Guid ResultGuid)
        {
            //ClsidFromString returns the empty guid for null strings   
            if (Input.IsNullOrEmpty())
            {
                ResultGuid = Guid.Empty;
                return false;
            }

            var hresult = COMInterop.CLSIDFromString(Input, out ResultGuid);
            if (hresult >= 0)
            {
                return true;
            }
            ResultGuid = Guid.Empty;
            return false;
        }

        /// <summary>
        /// Checks input string for any occurence of given character
        /// </summary>
        /// <param name="Input">String to check</param>
        /// <param name="Character">Character to look for</param>
        /// <returns>True if character found</returns>
        public static bool ContainsAny(this string Input, char Character)
        {
            return Input.ContainsAny(Character.ToEnumerable());
        }

        /// <summary>
        /// Checks input stringfor any occurence of given character(s)
        /// </summary>
        /// <param name="Input">String to check</param>
        /// <param name="Characters">Character(s) to look for</param>
        /// <returns>True if any character(s) found</returns>
        public static bool ContainsAny(this string Input, IEnumerable<char> Characters)
        {
            return !Input.IsNullOrEmpty() && Characters != null && Input.Any(Characters.Contains);
        }

        /// <summary>
        /// Strips Input string of all occurences of specified character(s)
        /// </summary>
        /// <param name="Input">String to strip</param>
        /// <param name="StripCharacters">IEnumerable containing characters to be stripped</param>
        /// <returns>Stripped string</returns>
        public static string Strip(this string Input, IEnumerable<char> StripCharacters)
        {
            return Input.IsNullOrEmpty() || StripCharacters == null ? Input : new string(Input.Where(c => !StripCharacters.Contains(c)).ToArray());
        }

        /// <summary>
        /// Strips Input string of all occurences of specified character
        /// </summary>
        /// <param name="Input">String to strip</param>
        /// <param name="StripCharacter">Character to strip from Input</param>
        /// <returns>Stripped string</returns>
        public static string Strip(this string Input, char StripCharacter)
        {
            return Input.Strip(StripCharacter.ToEnumerable());
        }

        /// <summary>
        /// Strips Input sting of all occurences of specified substring
        /// </summary>
        /// <param name="Input">String to strip</param>
        /// <param name="SubString">SubString to strip from Input</param>
        /// <returns>Stripped String</returns>
        public static string Strip(this string Input, string SubString)
        {
            if (Input.IsNullOrEmpty() || SubString.IsNullOrEmpty())
            {
                return Input;
            }
            return Input.Replace(SubString, string.Empty);
        }
        
        /// <summary>
        /// Attempts to parse a string into specified type.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="value">Input.  Null or empty returns Default for T</param>
        /// <returns>Instance of T as represented by value</returns>
        public static T Parse<T>(this string value)
        {
            var result = default(T);
            if (!value.IsNullOrEmpty())
            {
                var tc = TypeDescriptor.GetConverter(typeof (T));
                result = (T)tc.ConvertFrom(value);
            }
            return result;
        }

        /// <summary>
        /// Decrypts a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="StringToDecrypt"> String that must be decrypted. </param>
        /// <param name="Key"> Decryptionkey. </param>
        /// <returns> The decrypted string or null if decryption failed. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string StringToDecrypt, string Key)
        {
            if (StringToDecrypt.IsNullOrEmpty())
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (Key.IsNullOrEmpty())
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
        /// Encrypts a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="StringToEncrypt"> String that must be encrypted. </param>
        /// <param name="Key"> Encryptionkey. </param>
        /// <returns> A string representing a byte array separated by a minus sign. </returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string StringToEncrypt, string Key)
        {
            if (StringToEncrypt.IsNullOrEmpty())
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (Key.IsNullOrEmpty())
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
            if (!Text.IsNullOrEmpty())
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
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="Text"> string that will be truncated </param>
        /// <param name="MaxLength"> total length of characters to maintain before the truncate happens </param>
        /// <returns> truncated string </returns>
        public static string Truncate(this string Text, int MaxLength)
        {
            if (MaxLength <= 0 || Text.IsNullOrEmpty() || Text.Length <= MaxLength)
            {
                return Text;
            }

            const string suffix = "...";

            var strLength = MaxLength - suffix.Length;
            return strLength <= 0 ? Text : string.Format("{0}{1}", Text.Substring(0, strLength), suffix);
        }
    }
}