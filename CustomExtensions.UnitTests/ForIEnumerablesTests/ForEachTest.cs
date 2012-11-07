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
using CustomExtensions.UnitTests.Customization.Fixtures;
using CustomExtensions.Validation;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CustomExtensions.UnitTests.ForIEnumerablesTests
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
            public void ForEach_OnEmptySequence_PerformsNoActions()
            {
                var mock = new Mock<IDoSomething<object>>();
                var emptySequence = Enumerable.Empty<object>();
                emptySequence.ForEach(mock.Object.Do);

                mock.Verify(m => m.Do(It.IsAny<object>()), Times.Never());
            }

            [Test]
            public void ForEach_OnEmptySequence_WithNullAction_ThrowsValidationException()
            {
                var emptySequence = Enumerable.Empty<object>();
                Action<object> nullAction = null;

                Assert.That(() => emptySequence.ForEach(nullAction), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ForEach_OnNullSequence_WithAction_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                var fixture = new MultipleMockingFixture();
                var action = fixture.CreateAnonymous<Action<object>>();

                Assert.That(() => nullSequence.ForEach(action), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }

            [Test]
            public void ForEach_OnNullSequence_WithNullAction_ThrowsValidationException()
            {
                IEnumerable<object> nullSequence = null;
                Action<object> nullAction = null;

                Assert.That(() => nullSequence.ForEach(nullAction), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<MultiException>());
            }

            [Test]
            public void ForEach_OnSequence_PerformsActionForEach()
            {
                var mock = new Mock<IDoSomething<object>>();
                const int callCount = 3;
                var fixture = new MultipleMockingFixture(callCount);
                fixture.CreateMany<object>(callCount).ForEach(mock.Object.Do);

                mock.Verify(m => m.Do(It.IsAny<object>()), Times.Exactly(callCount));
            }

            [Test]
            public void ForEach_OnSequence_PerformsActionWithEach()
            {
                var list = new List<string>();
                var fixture = new MultipleMockingFixture();
                var guids = fixture.CreateAnonymous<IList<Guid>>();
                var expected = guids.Select(g => g.ToString());
                guids.ForEach(g => list.Add(g.ToString()));

                Assert.That(() => list, Is.EqualTo(expected));
            }

            [Test]
            public void ForEach_OnSequence_WithNullAction_ThrowsValidationException()
            {
                var fixture = new MultipleMockingFixture();
                var sequence = fixture.CreateAnonymous<IEnumerable<object>>();
                Action<object> nullAction = null;

                Assert.That(() => sequence.ForEach(nullAction), Throws.TypeOf<ValidationException>().With.InnerException.TypeOf<ArgumentNullException>());
            }
        }
    }
}