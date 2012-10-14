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

using System;
using CustomExtensions.ForIConvertible;
using Moq;
using NUnit.Framework;

namespace UnitTests.ForIConvertablesTests
{
    public partial class ForIConvertibleTests
    {
        [TestFixture]
        public class ToOrNullTest
        {
            [Test]
            public void ToOrNullBadConvertible_OnInteger_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                int number = 0;
                var outParameter = mockConvertible.Object;
                Assert.That(() => number.ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNullBadConvertible_OnInteger_ReturnsNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                int number = 0;
                var outParameter = mockConvertible.Object;
                var output = number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullObject_OnEmptyString_ReturnsObject()
            {
                string testString = string.Empty;
                Assert.That(() => testString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                Assert.That(() => number.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNullObject_OnNullString_ReturnsNull()
            {
                string testString = null;
                Assert.That(() => testString.ToOrNull<object>(), Is.Null);
            }

            [Test]
            public void ToOrNullObject_OnString_ReturnsObject()
            {
                string testString = "1";
                Assert.That(() => testString.ToOrNull<object>(), Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutInteger_OnNullString_ReturnsNull()
            {
                string testString = null;
                object outParameter;
                testString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutObject_OnDouble_ReturnsObject()
            {
                double number = double.MaxValue;
                object outParameter;
                number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutObject_OnDouble_ReturnsTrue()
            {
                double number = double.MaxValue;
                object outParameter;
                Assert.That(() => number.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutObject_OnEmptyString_ReturnsObject()
            {
                string testString = string.Empty;
                object outParameter;
                testString.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.InstanceOf<object>());
            }

            [Test]
            public void ToOrNullOutObject_OnNullNullableInteger_ReturnsNull()
            {
                int? number = null;
                object outParameter;
                number.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutObject_OnNullNullableInteger_ReturnsTrue()
            {
                int? number = null;
                object outParameter;
                Assert.That(() => number.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutObject_OnNullString_ReturnsTrue()
            {
                string testString = null;
                object outParameter;
                Assert.That(() => testString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullOutString_OnBadConvertible_CallsToString()
            {
                var mockConvertible = new Mock<IConvertible>(MockBehavior.Strict);
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                var output = mockConvertible.Object.ToOrNull(out outParameter);
                mockConvertible.Verify(m => m.ToString(It.IsAny<IFormatProvider>()), Times.Once());
            }

            [Test]
            public void ToOrNullOutString_OnBadConvertible_ReturnsFalse()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrNull(out outParameter), Is.False);
            }

            [Test]
            public void ToOrNullOutString_OnBadConvertible_ReturnsNull()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<InvalidCastException>();
                string outParameter;
                var output = mockConvertible.Object.ToOrNull(out outParameter);
                Assert.That(() => outParameter, Is.Null);
            }

            [Test]
            public void ToOrNullOutString_OnBadConvertible_ThrowsUnexpectedExceptionType()
            {
                var mockConvertible = new Mock<IConvertible>();
                mockConvertible.Setup(m => m.ToString(It.IsAny<IFormatProvider>())).Throws<Exception>();
                string outParameter;
                Assert.That(() => mockConvertible.Object.ToOrNull(out outParameter), Throws.Exception);
            }

            [Test]
            public void ToOrNullOutString_OnEmptyString_ReturnsTrue()
            {
                string testString = string.Empty;
                object outParameter;
                Assert.That(() => testString.ToOrNull(out outParameter), Is.True);
            }

            [Test]
            public void ToOrNullString_OnDouble_ReturnsString()
            {
                double number = 1d;
                Assert.That(() => number.ToOrNull<string>(), Is.EqualTo("1"));
            }
        }
    }
}