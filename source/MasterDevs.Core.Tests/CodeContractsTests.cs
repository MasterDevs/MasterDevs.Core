using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests
{
    [TestFixture]
    public class CodeContractsTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireHasValue_DoesNotHaveValue_Throws()
        {
            // Assemble
            int? me = null;

            // Act
            me.RequireHasValue("null");
        }

        [Test]
        public void RequireHasValue_HasValue_ReturnsParametersValue()
        {
            // Assemble
            int? expected = 5;

            // Act
            var actual = expected.RequireHasValue("null");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNoNullOrtEmpty_Null_Throws()
        {
            // Assemble
            string me = null;

            // Act
            me.RequireNotNullOrEmpty("null");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNoNullOrWhiteSpace_IsEmpty_Throws()
        {
            // Act
            string.Empty.RequireNotNullOrWhiteSpace("null");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNoNullOrWhiteSpace_Null_Throws()
        {
            // Assemble
            string me = null;

            // Act
            me.RequireNotNullOrWhiteSpace("null");
        }

        [Test]
        public void RequireNotNull_IsNotNull_ReturnsParameter()
        {
            // Assemble
            object expected = new object();

            // Act
            var actual = expected.RequireNotNull("null");

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNotNull_IsNull_Throws()
        {
            // Assemble
            object me = null;

            // Act
            me.RequireNotNull("null");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNotNullOrEmpty_IsEmpty_Throws()
        {
            string.Empty.RequireNotNullOrEmpty("empty string");
        }

        [Test]
        public void RequireNotNullOrEmpty_NotEmpty_ReturnsParameter()
        {
            // Assemble
            string expected = "some value";

            // Act
            var actual = expected.RequireNotNullOrEmpty("value");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequireNotNullOrWhiteSpace_IsWhiteSpace_Throws()
        {
            "    ".RequireNotNullOrWhiteSpace("whitespace string");
        }

        [Test]
        public void RequireNotNullOrWhiteSpace_NotEmpty_ReturnsParameter()
        {
            // Assemble
            string expected = "some value";

            // Act
            var actual = expected.RequireNotNullOrWhiteSpace("value");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}