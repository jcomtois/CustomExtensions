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
using System.Linq;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.Customization.Fixtures
{
    public class LatinStringFixture : MultipleMockingFixture
    {
        private static readonly string _latinString = new string(Enumerable.Range(0, 256).Select(i => Convert.ToChar(Convert.ToByte(i))).ToArray());

        public LatinStringFixture() : this(3)
        {
        }

        public LatinStringFixture(int repeatCount) : base(repeatCount)
        {
            this.Register(() => LatinString);
        }

        public static string LatinString
        {
            get
            {
                return _latinString;
            }
        }
    }
}