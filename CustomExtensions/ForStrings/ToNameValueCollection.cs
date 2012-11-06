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