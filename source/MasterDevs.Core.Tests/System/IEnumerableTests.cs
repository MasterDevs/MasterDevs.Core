using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class IEnumerableTests
    {
        [Test]
        public void IsNullOrEmpty_IsEmpty_ReturnsTrue()
        {
            // Assemble
            var enumerable = new List<int>();

            // Act
            var actual = enumerable.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsNullOrEmpty_IsNotEmpty_ReturnsFalse()
        {
            // Assemble
            var enumerable = new List<int> { 1 };

            // Act
            var actual = enumerable.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsNullOrEmpty_IsNull_ReturnsTrue()
        {
            // Assemble
            IEnumerable<int> enumerable = null;

            // Act
            var actual = enumerable.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void None_EmptyEnumerable_ReturnsTrue()
        {
            // Assemble
            IEnumerable<int> enumerable = Enumerable.Empty<int>();

            // Act/Assert
            Assert.IsTrue(enumerable.None());
        }

        [Test]
        public void None_NonEmptyEnumerable_ReturnsFalse()
        {
            // Assemble
            IEnumerable<int> enumerable = Enumerable.Range(0, 10);

            // Act/Assert
            Assert.IsFalse(enumerable.None());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void None_NullEnumerable_Throws()
        {
            // Assemble
            IEnumerable<string> enumerable = null;

            // Act
            enumerable.None();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void None_NullPredicate_Throws()
        {
            // Assemble
            IEnumerable<int> enumerable = Enumerable.Range(0, 10);

            // Act
            var result = enumerable.None(null);
        }

        [Test]
        public void None_PredicateAlwaysReturnsFalse_ReturnsTrue()
        {
            // Assemble
            IEnumerable<int> enumerable = Enumerable.Range(0, 10);

            // Act
            var result = enumerable.None(_ => false);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void None_PredicateAlwaysReturnsTrue_ReturnsFalse()
        {
            // Assemble
            IEnumerable<int> enumerable = Enumerable.Range(0, 10);

            // Act
            var result = enumerable.None(_ => true);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SafeCount_IsEmpty_ReturnsZero()
        {
            // Assemble
            var enumerable = new List<int>();

            // Act
            var actual = enumerable.SafeCount();

            // Assert
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void SafeCount_IsNotEmpty_ReturnsFalse()
        {
            // Assemble
            var enumerable = new List<int> { 1 };

            // Act
            var actual = enumerable.SafeCount();

            // Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void SafeCount_IsNull_ReturnsTrue()
        {
            // Assemble
            IEnumerable<int> enumerable = null;

            // Act
            var actual = enumerable.SafeCount();

            // Assert
            Assert.AreEqual(0, actual);
        }
    }
}