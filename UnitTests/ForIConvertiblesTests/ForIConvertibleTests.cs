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

namespace UnitTests.ForIConvertiblesTests
{
    public partial class ForIConvertibleTests
    {
        private const int DefaultInteger = default(int);
        private const double MaxDouble = double.MaxValue;
        private const string NonNumericString = "ABC";
        private const string NullString = null;
        private const decimal TestDecimal = 1.1m;
        private const float TestFloat = (float)TestDecimal;
        private const int TestInteger = 1;
        private static readonly string EmptyString = string.Empty;
        private static readonly string IntegerString = TestInteger.ToString();
        private static readonly int? NonNullNullableInteger = TestInteger;
        private static readonly int? NullNullableInteger;
        private static readonly object TestObject = new object();
    }
}