#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2013 Jonathan Comtois. All rights reserved.
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

namespace CustomExtensions.UnitTests.ValidationsTests
{
    public partial class ValidationTests
    {
        [TestFixture]
        public class ValidatorTest
        {
            [Test]
            public void ValidatorAddException()
            {
                var validator = new Validator();
                Assert.That(() => validator.AddException(new Exception()), Throws.Nothing);
                Assert.That(validator.Exceptions, Has.Count.EqualTo(1));
                Assert.That(() => new Validator().Exceptions, Is.Empty);
            }

            [Test]
            public void ValidatorConstructor()
            {
                Assert.That(() => new Validator(), Throws.Nothing);
                Assert.That(() => new Validator().Exceptions, Is.Empty);
            }
        }
    }
}