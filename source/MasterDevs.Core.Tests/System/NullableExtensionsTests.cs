using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class NullableExtensionsTests
    {
        [Test]
        public void SafeGet_NotNull_ReturnsValue()
        {
            // Assemble
            int? nullable = 7;

            // Act
            var actual = nullable.SafeGet(4);

            // Assert
            Assert.AreEqual(7, actual);
        }

        [Test]
        public void SafeGet_Null_ReturnsDefault()
        {
            // Assemble
            int? nullable = null;

            // Act
            var actual = nullable.SafeGet(4);

            // Assert
            Assert.AreEqual(4, actual);
        }
    }
}