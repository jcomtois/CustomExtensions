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
using CustomExtensions.ForIEnumerable;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace UnitTests.ForIEnumerablesTests
{
    public partial class ForIEnumerablesTests
    {
        [TestFixture]
        public class ForEachTest
        {
            public interface IDoSomething <T>
            {
                void Do(T t);
            }

            [Test]
            public void ForEach_OnEmptyStringSequence_PerformsNoActions()
            {
                var mock = new Mock<IDoSomething<string>>();
                mock.Setup(m => m.Do(It.IsAny<string>()));
                EmptyStringSequence.ForEach(mock.Object.Do);
                mock.Verify(m => m.Do(It.IsAny<string>()), Times.Never());
            }

            [Test]
            public void ForEach_OnEmptyStringSequence_WithNullAction_ThrowsValidationException()
            {
                Assert.That(() => EmptyStringSequence.ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ForEach_OnNullStringSequence_WithAction_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ForEach(Fixture.CreateAnonymous<Action<string>>()), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ForEach_OnNullStringSequence_WithNullAction_ThrowsValidationException()
            {
                Assert.That(() => NullStringSequence.ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ForEach_OnSequence_PerformsActionForEach()
            {
                var mock = new Mock<IDoSomething<object>>();
                mock.Setup(m => m.Do(It.IsAny<object>()));
                const int callCount = 3;
                Fixture.CreateMany<object>(callCount).ForEach(mock.Object.Do);
                mock.Verify(m => m.Do(It.IsAny<object>()), Times.Exactly(callCount));
            }

            [Test]
            public void ForEach_OnSequence_PerformsActionWithEach()
            {
                var list = new List<string>();
                var guids = Fixture.CreateMany<Guid>(3).ToList();
                var expected = guids.Select(g => g.ToString());
                guids.ForEach(g => list.Add(g.ToString()));
                Assert.That(() => list, Is.EqualTo(expected));
            }

            [Test]
            public void ForEach_OnSequence_WithNullAction_ThrowsValidationException()
            {
                Assert.That(() => Fixture.CreateMany<string>().ForEach(null), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}