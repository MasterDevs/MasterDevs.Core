using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void In_InSource_ReturnsTrue()
        {
            // Assemble
            var source = Enumerable.Range(0, 5);

            // Act
            var result = 1.In(source);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void In_InSourceComparerSpecified_ReturnsTrue()
        {
            // Assemble
            var source = new List<string>() { "a" };

            // Act
            var result = "A".In(source, StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void In_NotInSource_ReturnsFalse()
        {
            // Assemble
            var source = Enumerable.Range(0, 5);

            // Act
            var result = 50.In(source);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void In_NotInSourceComparerSpecified_ReturnsFalse()
        {
            // Assemble
            var source = new List<string>() { "a" };

            // Act
            var result = "B".In(source, StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void In_SourceIsNull_Throws()
        {
            5.In(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void In_SourceIsNullAndComparerSpecified_Throws()
        {
            5.In(null, EqualityComparer<int>.Default);
        }

        [Test]
        [TestCase(null, "me was null", "me was null")]
        [TestCase("object not null", "me was null", "object not null")]
        public void ToStringSafe(object me, string defaultValue, string expected)
        {
            // Act
            var actual = me.ToStringSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}