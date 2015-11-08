using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDevs.Core.Tests.System.Collection.Generic
{
    [TestFixture]
    public class IDictionaryExtensionsTests
    {
        [Test]
        public void Merge_Dupes_IgnoreDupes_ReturnsNewDictionaryWithNewValuesOverwritingSource()
        {
            // Assemble
            var source = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
                {3 , "three" },
            };
            var values = new Dictionary<int, string> {
                {3 , "III" },
                {4 , "four" },
            };

            var expected = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
                {3 , "III" },
                {4 , "four" },
            };

            // Act
            var actual = source.Merge(values, true);

            // Assert
            Assert.AreNotSame(source, actual);
            Assert.AreNotSame(values, actual);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Merge_Dupes_Throws()
        {
            // Assemble
            var source = new Dictionary<int, string> {
                {3 , "three" },
            };
            var values = new Dictionary<int, string> {
                {3 , "III" },
            };

            // Act
            var actual = source.Merge(values);
        }

        [Test]
        public void Merge_NoDupes_ReturnsNewDictionaryWithSourceAndNewValues()
        {
            // Assemble
            var source = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
            };
            var values = new Dictionary<int, string> {
                {3 , "three" },
                {4 , "four" },
            };

            var expected = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
                {3 , "three" },
                {4 , "four" },
            };

            // Act
            var actual = source.Merge(values);

            // Assert
            Assert.AreNotSame(source, actual);
            Assert.AreNotSame(values, actual);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void Merge_SourceIsNotNullButNewValuesAreNull_ReturnsNewDictionaryWithSourceValues()
        {
            // Assemble
            var source = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
            };
            IDictionary<int, string> values = null;

            // Act
            var actual = source.Merge(values);

            // Assert
            Assert.AreNotSame(source, actual);
            Assert.AreNotSame(values, actual);
            CollectionAssert.AreEquivalent(source, actual);
        }

        [Test]
        public void Merge_SourceIsNullAndNewValuesAreNull_ReturnsNull()
        {
            // Assemble
            IDictionary<int, int> source = null;
            IDictionary<int, int> values = null;

            // Act
            var actual = source.Merge(values);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Merge_SourceIsNullButNewValuesAreNotNull_ReturnsNewDictionaryWithNewValues()
        {
            // Assemble
            IDictionary<int, string> source = null;
            var values = new Dictionary<int, string> {
                {1 , "one" },
                {2 , "two" },
            };

            // Act
            var actual = source.Merge(values);

            // Assert
            Assert.AreNotSame(source, actual);
            Assert.AreNotSame(values, actual);
            CollectionAssert.AreEquivalent(values, actual);
        }

        [Test]
        public void ToDictionary_EmptyDictionary_ReturnsNewEmptyDictionary()
        {
            // Assemble
            var source = new Dictionary<int, int>();

            // Act
            var actual = source.ToDictionary();

            // Assert
            Assert.AreNotSame(source, actual);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToDictionary_NullDictionary_Throws()
        {
            // Assemble
            IDictionary<int, int> source = null;

            // Act
            source.ToDictionary();
        }

        [Test]
        public void ToDictionary_PopulatedDictionary_ReturnsNewDictionaryWithSameKeysAndValues()
        {
            // Assemble
            var source = new Dictionary<int, string>
            {
                {1 , "one" },
                {2 , "two" },
            };

            // Act
            var actual = source.ToDictionary();

            // Assert
            Assert.AreNotSame(source, actual);
            CollectionAssert.AreEquivalent(source, actual);
        }
    }
}
