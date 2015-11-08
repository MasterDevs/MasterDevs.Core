using MasterDevs.Core.Error;
using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.Error
{
    [TestFixture]
    public class UserVisibleExceptionTests
    {
        private const string DefaultMessage = "Exception of type 'MasterDevs.Core.Error.UserVisibleException' was thrown.";

        [Test]
        public void Ctor_MessageAndINnerExceptionSupplied_HasMessageAndInnerException()
        {
            // Assemble
            var inner = new Exception();

            // Act
            var ex = new UserVisibleException("my message", inner);

            // Assert
            Assert.AreEqual("my message", ex.Message);
            Assert.AreEqual(inner, ex.InnerException);
        }

        [Test]
        public void Ctor_MessageSupplied_HasMessageButNoInnerException()
        {
            // Act
            var ex = new UserVisibleException("my message");

            // Assert
            Assert.AreEqual("my message", ex.Message);
            Assert.IsNull(ex.InnerException);
        }

        [Test]
        public void Ctor_NonNullMessageNullInner_HasMessageButNoInnerException()
        {
            // Act
            var ex = new UserVisibleException("my message", null);

            // Assert
            Assert.AreEqual("my message", ex.Message);
            Assert.IsNull(ex.InnerException);
        }

        [Test]
        public void Ctor_NoParams_HasDefaultMessageButNoInnerException()
        {
            // Act
            var ex = new UserVisibleException();

            // Assert
            Assert.AreEqual(DefaultMessage, ex.Message);
            Assert.IsNull(ex.InnerException);
        }

        [Test]
        public void Ctor_NullMessage_HasDefaultMessageButNoInnerException()
        {
            // Act
            var ex = new UserVisibleException(null);

            // Assert
            Assert.AreEqual(DefaultMessage, ex.Message);
            Assert.IsNull(ex.InnerException);
        }

        [Test]
        public void Ctor_NullMessageNonNullInner_HasDefaultMessageAndInnerException()
        {
            // Assemble
            var inner = new Exception();

            // Act
            var ex = new UserVisibleException(null, inner);

            // Assert
            Assert.AreEqual(DefaultMessage, ex.Message);
            Assert.AreEqual(inner, ex.InnerException);
        }
    }
}