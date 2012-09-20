using System;
using System.Collections.Specialized;
using System.Linq;

namespace CustomExtensions.ForStrings
{
    public static partial class ExtendString
    {
        /// <summary>
        /// Splits a string into a NameValueCollection, where each "namevalue" is separated by
        /// the "outerSeparator". The parameter "nameValueSeparator" sets the split between Name and Value.
        /// Example: 
        ///             String str = "param1=value1;param2=value2";
        ///             NameValueCollection nvOut = str.ToNameValueCollection(';', '=');
        ///             
        /// The result is a NameValueCollection where:
        ///             key[0] is "param1" and value[0] is "value1"
        ///             key[1] is "param2" and value[1] is "value2"
        /// </summary>
        /// <param name="source">String to process</param>
        /// <param name="outerSeparator">Separator for each "NameValue"</param>
        /// <param name="nameValueSeparator">Separator for Name/Value splitting</param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection(this string source, char outerSeparator, char nameValueSeparator)
        {
            if (outerSeparator == nameValueSeparator)
            {
                throw new ArgumentException("Seperators must be different values.");
            }

            var nameValueCollection = new NameValueCollection();
            if (!source.IsNullOrEmpty())
            {
                var arrStrings = source.TrimEnd(outerSeparator).Split(outerSeparator);

                foreach (var strings in arrStrings.Select(s => s.Split(nameValueSeparator)))
                {
                    nameValueCollection.Add(strings.First(), strings.Last());
                }
            }
            return nameValueCollection;
        }
    }
}