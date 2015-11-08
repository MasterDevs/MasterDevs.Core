using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class EventArgsTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("value")]
        public void CTOR_SingleTypeArg_ValueIsSet(string value)
        {
            // Act
            var args = new EventArgs<string>(value);

            // Assert
            Assert.AreEqual(value, args.Value);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase(null, "value2")]
        [TestCase("", null)]
        [TestCase("", "")]
        [TestCase("", "value2")]
        [TestCase("value1", null)]
        [TestCase("value1", "")]
        [TestCase("value1", "value2")]
        public void CTOR_TwoTypeArgs_ValuesAreSet(string value1, string value2)
        {
            // Act
            var args = new EventArgs<string, string>(value1, value2);

            // Assert
            Assert.AreEqual(value1, args.Value1);
            Assert.AreEqual(value2, args.Value2);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("value")]
        public void ImplicitCastFromEventArgs_ReturnsNewEventArgsWithValueSet(string value)
        {
            // Assemble
            var args = new EventArgs<string>(value);

            // Act
            string actual = args;

            // Assert
            Assert.AreEqual(value, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("value")]
        public void ImplicitCastToEventArgs_ReturnsNewEventArgsWithValueSet(string value)
        {
            // Act
            EventArgs<string> args = value;

            // Assert
            Assert.AreEqual(value, args.Value);
        }
    }
}