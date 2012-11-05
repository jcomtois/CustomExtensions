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
using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        private class GenericComparable : IComparable<GenericComparable>
        {
            private readonly Guid _id;

            public GenericComparable()
            {
                _id = Guid.NewGuid();
            }

            #region IComparable<GenericComparable> Members

            public int CompareTo(GenericComparable other)
            {
                return _id.CompareTo(other._id);
            }

            #endregion
        }

        private struct GenericComparableStruct : IComparable<GenericComparableStruct>
        {
            private int _id;

            public GenericComparableStruct(int id)
            {
                _id = id;
            }

            public int CompareTo(GenericComparableStruct other)
            {
                return _id.CompareTo(other._id);
            }
        }


        private static readonly IEnumerable<string> EmptyStringSequence = Enumerable.Empty<string>();
        private static readonly IEnumerable<string> NullStringSequence;
        private const string NullString = null;
        private static readonly IFixture Fixture = new Fixture().Customize(new CompositeCustomization(new MultipleCustomization(), new AutoMoqCustomization()));
        private static readonly IEnumerable<int> EmptyIntegerSequence = Enumerable.Empty<int>();
    }
}