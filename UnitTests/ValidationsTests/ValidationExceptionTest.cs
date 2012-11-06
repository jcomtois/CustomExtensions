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
using CustomExtensions.Validation;
using NUnit.Framework;

namespace UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidationExceptionTest
        {
            [Test]
            public void ValidationExceptionEmptyConstructor()
            {
                Assert.That(() => new ValidationException(), Throws.Nothing);
                Assert.That(() => new ValidationException().InnerException, Is.Null);
            }

            [Test]
            public void ValidationExceptionIsSerializable()
            {
                Assert.That(new ValidationException(), Is.BinarySerializable);
            }

            [Test]
            public void ValidationExceptionMessageConstructor()
            {
                Assert.That(() => new ValidationException("Test Message"), Throws.Nothing);
                Assert.That(() => new ValidationException("Test Message").InnerException, Is.Null);
                Assert.That(() => new ValidationException("Test Message").Message, Is.EqualTo("Test Message"));
                Assert.That(() => new ValidationException(null).Message, Is.EqualTo(new ValidationException().Message));
            }

            [Test]
            public void ValidationExceptionMessageExceptionConstructor()
            {
                Assert.That(() => new ValidationException("Test Message", new Exception()), Throws.Nothing);
                Assert.That(() => new ValidationException("Test Message", new Exception()).InnerException, Is.Not.Null);
                Assert.That(() => new ValidationException("Test Message", new ArgumentNullException()).InnerException, Is.TypeOf<ArgumentNullException>());
                Assert.That(() => new ValidationException("Test Message", new Exception("Different Message")).Message, Is.EqualTo("Test Message"));
                Assert.That(() => new ValidationException(null, new Exception("Has message")).Message, Is.EqualTo(new ValidationException().Message));
            }
        }
    }
}