using MasterDevs.Core.System.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.Tests.System.Linq
{
    [TestFixture]
    public class IEnumerableTests
    {
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
    }
}