using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace MasterDevs.Core.Tests.System.IO
{
    [TestFixture]
    public class StreamExtensionsTests
    {
        [Test]
        public void AsStream_ByteArray_ReturnsStreamWithSourceAsContent()
        {
            // Assemble
            byte[] source = new byte[] { 1, 2, 3, 4, 5 };
            var expected = "12345";

            // Act
            using (var actual = source.AsStream())

            {
                // Assert
                var actualBytes = actual.ToByteArray()
                                        .Select(b => ((int)b).ToString());
                var actualBytesAsString = string.Join(string.Empty, actualBytes);
                Assert.AreEqual(expected, actualBytesAsString);
            }
        }

        [Test]
        public void AsStream_EmptyByteArray_ReturnsEmptyStream()
        {
            // Assemble
            byte[] source = new byte[] { };

            // Act
            using (var actual = source.AsStream())

            {
                // Assert
                var actualBytes = actual.ToByteArray();
                CollectionAssert.IsEmpty(actualBytes);
            }
        }

        [Test]
        public void AsStream_NullByteArray_ReturnsNull()
        {
            // Assemble
            byte[] source = null;

            // Act
            using (var actual = source.AsStream())
            {
                // Assert
                Assert.IsNull(actual);
            }
        }

        [Test]
        public void AsStream_NullString_ReturnsNull()
        {
            // Assemble
            string source = null;

            // Act
            using (var actual = source.AsStream())
            {
                // Assert
                Assert.IsNull(actual);
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("A simple string")]
        [TestCase("A string with tabs <\t\t>")]
        [TestCase("A string with newlines <\r\n>")]
        [TestCase("A string with special characters <!@#$%^&*()_>")]
        public void AsStream_StringParameter_ReturnsStreamWithSourceAsContent(string source)
        {
            // Act
            using (var actual = source.AsStream())
            using (var reader = new StreamReader(actual))
            {
                // Assert
                var actualText = reader.ReadToEnd();
                Assert.AreEqual(source, actualText);
            }
        }

        [Test]
        public void GetLength_NullStream_ReturnsZero()
        {
            // Assemble
            Stream strem = null;

            // Act/Assert
            Assert.AreEqual(0, strem.GetLength());
        }

        [Test]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void GetLength_StreamCanNotReadOrSeek_ReturnsZero(bool canRead, bool canSeek)
        {
            // Assemble
            var stream = Mock.Of<Stream>(s => s.CanRead == canRead && s.CanSeek == canSeek);

            // Act/Assert
            Assert.AreEqual(0, stream.GetLength());
        }

        [Test]
        [TestCase("")]
        [TestCase("A simple string")]
        [TestCase("A string with tabs <\t\t>")]
        [TestCase("A string with newlines <\r\n>")]
        [TestCase("A string with special characters <!@#$%^&*()_>")]
        public void GetLength_ValidStream_ReturnsLength(string source)
        {
            // Assemble
            var expected = source.Count();
            using (var stream = source.AsStream())
            {
                // Act
                var actual = stream.GetLength();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void ToByteArray_NullStream_ReturnsNull()
        {
            // Assemble
            Stream stream = null;

            // Act
            var arr = stream.ToByteArray();

            // Assert
            Assert.IsNull(arr);
        }

        [Test]
        public void ToByteArray_UnreadableStream_ReturnsNull()
        {
            // Assemble
            var stream = Mock.Of<Stream>(s => s.CanRead == false);

            // Act
            var arr = stream.ToByteArray();

            // Assert
            Assert.IsNull(arr);
        }

        [Test]
        [TestCase("")]
        [TestCase("A simple string")]
        [TestCase("A string with tabs <\t\t>")]
        [TestCase("A string with newlines <\r\n>")]
        [TestCase("A string with special characters <!@#$%^&*()_>")]
        public void ToByteArray_ValidStream_ReturnsByteArray(string source)
        {
            // Assemble
            var expected = source.Select(c => Convert.ToByte(c)).ToArray();
            using (var stream = source.AsStream())
            {
                // Act
                var actual = stream.ToByteArray();

                // Assert
                Assert.AreEqual(expected.Length, actual.Length, "Arrays do not match:  they have different lenghts");

                for (int i = 0; i < expected.Length; i++)
                {
                    var e = expected[i];
                    var a = actual[i];
                    Assert.AreEqual(e, a, $"Arrays do not match at index {i}, expected {e} but was {a}");
                }
            }
        }
    }
}