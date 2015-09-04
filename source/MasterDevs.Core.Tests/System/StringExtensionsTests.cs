using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class StringExtensionsTests
    {
        /// <remarks>
        /// Because we need to construct new datetimes we can't pass all the parameters
        /// into the attribute.  Meaning, we can't use the TestCaseAttribute.
        /// </remarks>
        private static object[] ToDateTimeSafeTestCases =
        {
            new object[] { null, DateTime.MinValue, DateTime.MinValue },
            new object[] { "invalid datetime", DateTime.MinValue, DateTime.MinValue },
            new object[] { "7/4/1776", DateTime.MinValue, new DateTime(1776, 7, 4) },
            new object[] { "7/4/1776 9:30:45 AM", DateTime.MinValue, new DateTime(1776, 7, 4, 9, 30, 45) },
        };

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
        [TestCase(null, "", "", "", Description = "string.Empty and string.Empty backups")]
        [TestCase(null, "", Description = "Null and no backups")]
        [TestCase("a", "a", Description = "Value provided, and no backups")]
        [TestCase("a", "a", "", "", Description = "Value provided, and string.Empty backups")]
        [TestCase("a", "a", "b", Description = "Value and backup provided")]
        [TestCase("a", "a", "b", "c", Description = "Value and multiple backups provided")]
        [TestCase("a", "a", "", "b", "", "c", "", Description = "Value and multiple backups (some string.Empty) provided")]
        [TestCase("b", "", "b", Description = "Value is string.Empty but backup provided")]
        [TestCase("b", "", "b", "c", Description = "Value is string.Empty but multiple backups provided")]
        [TestCase("b", "", "", "b", "", "c", "", Description = "Value is string.Empty but multiple backups (some string.Empty) provided")]
        [TestCase(null, " ", " ", " ", Description = "WhiteSpace and WhiteSpace backups")]
        [TestCase(null, " ", Description = "Null and no backups")]
        [TestCase("a", "a", Description = "Value provided, and no backups")]
        [TestCase("a", "a", " ", " ", Description = "Value provided, and WhiteSpace backups")]
        [TestCase("a", "a", "b", Description = "Value and backup provided")]
        [TestCase("a", "a", "b", "c", Description = "Value and multiple backups provided")]
        [TestCase("a", "a", " ", "b", " ", "c", " ", Description = "Value and multiple backups (some WhiteSpace) provided")]
        [TestCase("b", " ", "b", Description = "Value is WhiteSpace but backup provided")]
        [TestCase("b", " ", "b", "c", Description = "Value is WhiteSpace but multiple backups provided")]
        [TestCase("b", " ", " ", "b", " ", "c", " ", Description = "Value is WhiteSpace but multiple backups (some WhiteSpace) provided")]
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

        [Test]
        [TestCase(null, false, false)]
        [TestCase(null, true, true)]
        [TestCase("invalid bool", false, false)]
        [TestCase("invalid bool", true, true)]
        [TestCase("true", true, true)]
        [TestCase("TRUE", true, true)]
        [TestCase("True", true, true)]
        [TestCase("  true   ", true, true)]
        [TestCase("true", false, true)]
        [TestCase("TRUE", false, true)]
        [TestCase("True", false, true)]
        [TestCase("  true   ", false, true)]
        [TestCase("false", true, false)]
        [TestCase("FALSE", true, false)]
        [TestCase("False", true, false)]
        [TestCase("  false  ", true, false)]
        [TestCase("false", false, false)]
        [TestCase("FALSE", false, false)]
        [TestCase("False", false, false)]
        [TestCase("  false  ", false, false)]
        public void ToBoolSafe(string me, bool defaultValue, bool expected)
        {
            // Act
            var actual = me.ToBoolSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource("ToDateTimeSafeTestCases")]
        public void ToDateTimeSafe(string me, DateTime defaultValue, DateTime expected)
        {
            // Act
            var actual = me.ToDateTimeSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(null, 4, 4)]
        [TestCase("invalid int", 4, 4)]
        [TestCase("27", 4, 27)]
        [TestCase("  27  ", 4, 27)]
        public void ToIntSafe(string me, int defaultValue, int expected)
        {
            // Act
            var actual = me.ToIntSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(null, 4L, 4L)]
        [TestCase("invalid long", 4L, 4L)]
        [TestCase("27", 4L, 27L)]
        [TestCase("  27  ", 4L, 27L)]
        public void ToLongSafe(string me, long defaultValue, long expected)
        {
            // Act
            var actual = me.ToLongSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }



        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase(" ", "")]
        [TestCase("\t", "")]
        [TestCase("   \t   ", "")]
        [TestCase("   \twords\t   ", "words")]
        [TestCase("words", "words")]
        public void TrimSafe(string me, string expected)
        {
            // Act
            var actual = me.TrimSafe();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}