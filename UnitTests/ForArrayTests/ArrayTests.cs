﻿#region License and Terms

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

using System.Linq;

namespace UnitTests.ForArrayTests
{
    public partial class ArrayTests
    {
        private static readonly byte[] NullByteArray = null;
        private static readonly byte[] EmptyByteArray = new byte[]{};
        internal static readonly byte[] ValidByteArray = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();
        private static readonly byte[] SingleLowByteArray = new byte[] {0};
        private static readonly byte[] SingleHighByteArray = new byte[] {255};

    }
}