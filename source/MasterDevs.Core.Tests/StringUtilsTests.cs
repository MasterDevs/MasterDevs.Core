using MasterDevs.Core.Utils;
using NUnit.Framework;

namespace MasterDevs.Core.Tests
{
    [TestFixture]
    public class StringUtilsTests
    {
        [Test]
        public void GenerateRandom_CalledTwice_ReturnsDifferentStrings()
        {
            // Act
            var rand1 = StringUtils.GenerateRandom(5);
            var rand2 = StringUtils.GenerateRandom(5);

            // Assert
            Assert.AreNotEqual(rand1, rand2);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(-1000)]
        public void GenerateRandom_InvalidLength_ReturnsEmptytring(int len)
        {
            // Act
            var actual = StringUtils.GenerateRandom(len);

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void GenerateRandom_ValidLength_ReturnsStringOfThatLength(int len)
        {
            // Act
            var actual = StringUtils.GenerateRandom(len);

            // Assert
            Assert.AreEqual(len, actual.Length);
        }
    }
}