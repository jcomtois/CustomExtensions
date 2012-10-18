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
using System.Diagnostics;
using System.Linq;
using CustomExtensions.ForStrings;
using NUnit.Framework;

namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {      
        [TestFixture]
        public class Right
        {
            private const string TestString = "abc123ABC456Test";

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Right(5);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LengthZero()
            {
                var expected = string.Empty;
                var actual = TestString.Right(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Right(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerString()
            {
                const string expected = TestString;
                var actual = TestString.Right(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void RightString()
            {
                const string right = "Right";
                const string testString = TestString + right;
                const string expected = right;
                var actual = testString.Right(right.Length);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class ToNameValueCollection
        {
            private const string TestString = "param1=hello;param2=goodbye;param3=end;";

            [Test]
            public void InValidInput()
            {
                var testString = TestString + "=invalid";
                var actual = testString.ToNameValueCollection(';', '=');

                Assert.AreNotEqual(3, actual.Count);
            }

            [Test]
            public void SameSeperators()
            {
                Assert.Throws<ArgumentException>(() => TestString.ToNameValueCollection(';', ';'));
            }

            [Test]
            public void ValidInput()
            {
                var actual = TestString.ToNameValueCollection(';', '=');

                Assert.AreEqual(3, actual.Count);
                Assert.AreEqual("param1", actual.Keys[0]);
                Assert.AreEqual("param2", actual.Keys[1]);
                Assert.AreEqual("param3", actual.Keys[2]);
                Assert.AreEqual("hello", actual.GetValues("param1").First());
                Assert.AreEqual("goodbye", actual.GetValues("param2").First());
                Assert.AreEqual("end", actual.GetValues("param3").First());
            }
        }

        [TestFixture]
        public class Truncate
        {
            private const string TestString = "abc123";

            [Test]
            public void EmptyString()
            {
                var expected = string.Empty;
                var actual = string.Empty.Truncate(5);

                Assert.AreEqual(expected, actual);

                expected = null;
                actual = expected.Truncate(5);

                Assert.IsNull(actual);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LengthZero()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(0);

                Assert.AreEqual(expected, actual);

                actual = TestString.Truncate(-1);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LongerThanString()
            {
                const string expected = TestString;
                var actual = TestString.Truncate(TestString.Length * 2);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void TruncateString()
            {
                var expected = TestString;
                var actual = TestString.Truncate(1);

                Assert.AreEqual(expected, actual);

                expected = TestString;
                actual = TestString.Truncate(2);

                Assert.AreEqual(expected, actual);

                expected = TestString;
                actual = TestString.Truncate(3);

                Assert.AreEqual(expected, actual);

                expected = "a...";
                actual = TestString.Truncate(4);
                Assert.AreEqual(expected, actual);

                expected = "ab...";
                actual = TestString.Truncate(5);
                Assert.AreEqual(expected, actual);
            }
        }

        protected const string EmptyTestString = "";
        protected const string NullTestString = null;
        protected static readonly string TestStringLatin;

        static StringTests()
        {
            TestStringLatin = new string(Enumerable.Range(0, 256).Select(i => (char)i).ToArray());
            Debug.Assert(TestStringLatin.Length == 256);
        }
    }
}