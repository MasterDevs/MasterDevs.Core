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
        public void FirstOrDefault_EmptyList_ReturnsDefault()
        {
            // Assemble
            var source = Enumerable.Empty<string>();

            // Act
            var actual = source.FirstOrDefault("a");

            // Assert
            Assert.AreEqual("a", actual);
        }

        [Test]
        public void FirstOrDefault_EmptyListDefaultIsNull_ReturnsNull()
        {
            // Assemble
            var source = Enumerable.Empty<string>();

            // Act
            var actual = source.FirstOrDefault((string)null);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void FirstOrDefault_ListContainsElements_ReturnsFirstElementInList()
        {
            // Assemble
            var source = new List<string> { "a", "b" };

            // Act
            var actual = source.FirstOrDefault("c");

            // Assert
            Assert.AreEqual("a", actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstOrDefault_NullSource_Throws()
        {
            // Assemble
            IEnumerable<string> source = null;

            // Act
            source.FirstOrDefault("a");
        }

        [Test]
        public void FirstOrDefaultWithPredicate_EmptyList_ReturnsDefault()
        {
            // Assemble
            var source = Enumerable.Empty<string>();

            // Act
            var actual = source.FirstOrDefault(_ => true, "a");

            // Assert
            Assert.AreEqual("a", actual);
        }

        [Test]
        public void FirstOrDefaultWithPredicate_EmptyListDefaultIsNull_ReturnsNull()
        {
            // Assemble
            var source = Enumerable.Empty<string>();

            // Act
            var actual = source.FirstOrDefault(_ => true, (string)null);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void FirstOrDefaultWithPredicate_ListContainsElements_ReturnsFirstElementInListThatPassesPredicate()
        {
            // Assemble
            var source = new List<string> { "a", "b" };

            // Act
            var actual = source.FirstOrDefault(s => s == "b", "c");

            // Assert
            Assert.AreEqual("b", actual);
        }

        [Test]
        public void FirstOrDefaultWithPredicate_ListContainsNoElementsThatPassPredicate_ReturnsDefault()
        {
            // Assemble
            var source = new List<string> { "a", "b" };

            // Act
            var actual = source.FirstOrDefault(_ => false, "c");

            // Assert
            Assert.AreEqual("c", actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstOrDefaultWithPredicate_NullPredicate_Throws()
        {
            // Assemble
            var source = new List<string> { "a" };

            // Act
            source.FirstOrDefault(null, "a");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstOrDefaultWithPredicate_NullSource_Throws()
        {
            // Assemble
            IEnumerable<string> source = null;

            // Act
            source.FirstOrDefault(_ => true, "a");
        }

        [Test]
        public void GetPages_CollectionContainsElements_ReturnsCorrectPages()
        {
            // Assemble
            var source = Enumerable.Range(1, 7);
            var expected0 = new List<int> { 1, 2, 3, 4, 5 };
            var expected1 = new List<int> { 6, 7 };

            // Act
            var actual = source.GetPages(5).ToArray();

            // Assert
            Assert.AreEqual(2, actual.Length, "Incorrect number of pages returned");
            Assert.AreEqual(expected0, actual[0]);
            Assert.AreEqual(expected1, actual[1]);
        }

        [Test]
        public void GetPages_CollectionSizeDivisibleByPageSize_ReturnsOnlyFullPages()
        {
            // Assemble
            var source = Enumerable.Range(1, 10);

            // Act
            var actual = source.GetPages(5).ToArray();

            // Assert
            Assert.AreEqual(2, actual.Length, "Incorrect number of pages returned");
            Assert.AreEqual(5, actual[0].Count());
            Assert.AreEqual(5, actual[1].Count());
        }

        [Test]
        public void GetPages_CollectionSizeNotDivisibleByPageSize_ReturnsIncompleteFinalPage()
        {
            // Assemble
            var source = Enumerable.Range(1, 7);

            // Act
            var actual = source.GetPages(5).ToArray();

            // Assert
            Assert.AreEqual(2, actual.Length, "Incorrect number of pages returned");
            Assert.AreEqual(5, actual[0].Count());
            Assert.AreEqual(2, actual[1].Count());
        }

        [Test]
        public void GetPages_EmptyCollection_ReturnsEmptyEnumerableOfPages()
        {
            // Assemble
            var source = Enumerable.Empty<int>();

            // Act
            var actual = source.GetPages(5);

            // Assert
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPages_Null_Throws()
        {
            // Assemble
            IEnumerable<int> source = null;

            // Act
            source.GetPages(5).ToArray();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void GetPages_PageSizeTooSmall_Throws(int pageSize)
        {
            // Assemble
            var source = Enumerable.Range(1, 10);

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => source.GetPages(pageSize).ToArray());
        }

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
            var enumerable = Enumerable.Empty<int>();

            // Act/Assert
            Assert.IsTrue(enumerable.None());
        }

        [Test]
        public void None_NonEmptyEnumerable_ReturnsFalse()
        {
            // Assemble
            var enumerable = Enumerable.Range(0, 10);

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
            var enumerable = Enumerable.Range(0, 10);

            // Act
            var result = enumerable.None(null);
        }

        [Test]
        public void None_PredicateAlwaysReturnsFalse_ReturnsTrue()
        {
            // Assemble
            var enumerable = Enumerable.Range(0, 10);

            // Act
            var result = enumerable.None(_ => false);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void None_PredicateAlwaysReturnsTrue_ReturnsFalse()
        {
            // Assemble
            var enumerable = Enumerable.Range(0, 10);

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