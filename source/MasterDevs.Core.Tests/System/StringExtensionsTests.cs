using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        [TestCase(null, null, null, null, Description = "Null and null backups")]
        [TestCase(null, null, Description = "Null and no backups")]
        [TestCase("a", "a", Description = "Value provided, and no backups")]
        [TestCase("a", "a", null, null, Description = "Value provided, and null backups")]
        [TestCase("a", "a", "b", Description = "Value and backup provided")]
        [TestCase("a", "a", "b", "c", Description = "Value and multiple backups provided")]
        [TestCase("a", "a", null, "b", null, "c", null, Description = "Value and multiple backups (some null) provided")]
        [TestCase("b", null, "b", Description = "Value is null but backup provided")]
        [TestCase("b", null, "b", "c", Description = "Value is null but multiple backups provided")]
        [TestCase("b", null, null, "b", null, "c", null, Description = "Value is null but multiple backups (some null) provided")]
        public void Coalesce(string expected, string me, params string[] backups)
        {
            // Act
            var actual = me.Coalesce(backups);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Coalesce_NonNullMeAnBackupListWithASingleNullEntry_ReturnsMe()
        {
            // Assemble
            string me = "hello";

            // Act
            var actual = me.Coalesce(null);

            // Assert
            Assert.AreEqual("hello", actual);
        }

        [Test]
        public void Coalesce_NonNullMeAndNullBackupList_ReturnsMe()
        {
            // Assemble
            string me = "hello";
            string[] backups = null;

            // Act
            var actual = me.Coalesce(backups);

            // Assert
            Assert.AreEqual("hello", actual);
        }

        [Test]
        public void Coalesce_NullMeAnBackupListWithASingleNullEntry_ReturnsNull()
        {
            // Assemble
            string me = null;

            // Act
            var actual = me.Coalesce(null);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Coalesce_NullMeAndNullBackupList_ReturnsNull()
        {
            // Assemble
            string me = null;
            string[] backups = null;

            // Act
            var actual = me.Coalesce(backups);

            // Assert
            Assert.IsNull(actual);
        }
    }
}