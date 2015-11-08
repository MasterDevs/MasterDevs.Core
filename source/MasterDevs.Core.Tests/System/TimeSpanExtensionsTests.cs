using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class TimeSpanExtensionsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1.0, 1.0)]
        [TestCase(-1, 1)]
        [TestCase(-1.0, 1.0)]
        public void AbsoluteValue(double ms, double expectedMs)
        {
            // Assemble
            var me = TimeSpan.FromMilliseconds(ms);
            var expected = TimeSpan.FromMilliseconds(expectedMs);

            // Act
            var actual = me.AbsoluteValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AbsoluteValue_MaxValue_ReturnsMaxValue()
        {
            // Act
            var actual = TimeSpan.MaxValue.AbsoluteValue();

            // Assert
            Assert.AreEqual(TimeSpan.MaxValue, actual);
        }

        [Test]
        [ExpectedException(typeof(OverflowException))]
        public void AbsoluteValue_MinValue_ReturnsMaxValue()
        {
            // Act
            var actual = TimeSpan.MinValue.AbsoluteValue();
        }
    }
}