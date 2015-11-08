using MasterDevs.Core.Utils;
using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.Utils
{
    [TestFixture]
    public class DisposerTests
    {
        [Test]
        public void Ctor_ActionNotNull_ActionNotInvoked()
        {
            // Assemble
            bool called = false;

            // Act
            var disposer = new Disposer(() => called = true);

            // Assert
            Assert.False(called);
        }

        [Test]
        public void Ctor_ActionNotNull_Throws()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => new Disposer(null));
        }

        [Test]
        public void Dispose_CtorActionNotNull_CtorActionInvoked()
        {
            // Assemble
            bool called = false;
            var disposer = new Disposer(() => called = true);

            // Act
            disposer.Dispose();

            // Assert
            Assert.True(called);
        }
    }
}