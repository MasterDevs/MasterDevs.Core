using NUnit.Framework;
using System;
using System.Text;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class ClassExtensionsTests
    {
        [Test]
        public void MaybeDefaultValue_NotNull_ReturnsValueFromFunction()
        {
            // Assemble
            var expected = "not null string";
            var input = new StringBuilder(expected);

            // Act
            string actual = input.Maybe(i => i.ToString(), "default value");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaybeDefaultValue_Null_ReturnsDefaultValueu()
        {
            // Assemble
            object input = null;
            var expected = "default value";

            // Act
            string actual = input.Maybe(i => i.ToString(), expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaybeNoDefaultValue_NotNull_ReturnsValueFromFunction()
        {
            // Assemble
            var expected = "not null string";
            var input = new StringBuilder(expected);

            // Act
            string actual = input.Maybe(i => i.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaybeNoDefaultValue_Null_ReturnsNull()
        {
            // Assemble
            object input = null;

            // Act
            string actual = input.Maybe(i => i.ToString());

            // Assert
            Assert.IsNull(actual);
        }
    }
}