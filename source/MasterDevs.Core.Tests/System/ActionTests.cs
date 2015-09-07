using MasterDevs.Core.Common.Service;
using Moq;
using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class ActionTests
    {
        private Mock<ILogger> _mockLogger;

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
        }

        #endregion

        [Test]
        public void SafeCatchInvoke_ActionRuns_ActionRuns()
        {
            // Assemble
            bool ran = false;
            Action act = () => { ran = true; };

            // Act
            act.SafeCatchInvoke(_mockLogger.Object);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeCatchInvoke_ActionThrows_LoggsException()
        {
            // Assemble
            var ex = new Exception();
            Action act = () => { throw ex; };

            // Act
            act.SafeCatchInvoke(_mockLogger.Object);

            // Assert
            _mockLogger.Verify(l => l.Error(ex), Times.Once());
        }

        [Test]
        public void SafeCatchInvoke_NullAction_DoesNothing()
        {
            // Act
            ActionExtensions.SafeCatchInvoke(null, _mockLogger.Object);

            // Assert
            _mockLogger.Verify(l => l.Error(It.IsAny<Exception>()), Times.Never());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "logger", MatchType = MessageMatch.Contains)]
        public void SafeCatchInvoke_NullLogger_Throws()
        {
            // Act
            ActionExtensions.SafeCatchInvoke(new Action(() => { }), null);
        }

        [Test]
        public void SafeInvoke_ActionIsNull_RunningActionDoesNothing()
        {
            // Assemble
            Action act = null;

            // Act
            Assert.DoesNotThrow(() => act.SafeInvoke());
        }

        [Test]
        public void SafeInvoke_ActionRuns_ActionRuns()
        {
            // Assemble
            bool ran = false;
            Action act = () => { ran = true; };

            // Act
            act.SafeInvoke();

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithOneArgument_ActionRuns_ActionRuns()
        {
            // Assemble
            bool ran = false;
            Action<int> act = _ => { ran = true; };

            // Act
            act.SafeInvoke(0);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        [TestCase(null)]
        [TestCase("hello world")]
        public void SafeInvokeWithOneArgument_ArgumentsPassedToAction(string expected)
        {
            // Assemble
            bool ran = false;
            Action<string> act = arg =>
            {
                ran = true;
                Assert.AreEqual(expected, arg);
            };

            // Act
            act.SafeInvoke(expected);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithOneArgument_NullAction_DoesNothing()
        {
            // Act
            ActionExtensions.SafeInvoke((Action<int>)null, 0);
        }

        [Test]
        public void SafeInvokeWithTwoArguments_ActionRuns_ActionRuns()
        {
            // Assemble
            bool ran = false;
            Action<int, int> act = (_, __) => { ran = true; };

            // Act
            act.SafeInvoke(0, 0);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("hello", null)]
        [TestCase(null, "world")]
        [TestCase("hello", "world")]
        public void SafeInvokeWithTwoArguments_ArgumentsPassedToAction(string expected1, string expected2)
        {
            // Assemble
            bool ran = false;
            Action<string, string> act = (arg1, arg2) =>
             {
                 ran = true;
                 Assert.AreEqual(expected1, arg1);
                 Assert.AreEqual(expected2, arg2);
             };

            // Act
            act.SafeInvoke(expected1, expected2);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithTwoArguments_NullAction_DoesNothing()
        {
            // Act
            ActionExtensions.SafeInvoke(null, 0, 0);
        }

        [Test]
        public void ToSafe_ActionIsNotNull_RunningReturnedActionRuns()
        {
            // Assemble
            bool called = false;
            Action act = () => called = true;

            // Act
            act.ToSafe()();

            // Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void ToSafe_ActionIsNotNull_SameAction()
        {
            // Assemble
            Action act = () => Console.WriteLine("hello world");

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.AreEqual(act, actual);
        }

        [Test]
        public void ToSafe_ActionIsNull_ReturnsNonNullAction()
        {
            // Assemble
            Action act = null;

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ToSafe_ActionIsNull_RunningReturnDoesNothing()
        {
            // Assemble
            Action act = null;

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.DoesNotThrow(() => actual());
        }

        [Test]
        public void ToSafeOneArgument_ActionIsNotNull_SameAction()
        {
            // Assemble
            Action<string> act = s => Console.WriteLine(s);

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.AreEqual(act, actual);
        }

        [Test]
        public void ToSafeOneArgument_ActionIsNull_ReturnsNonNullAction()
        {
            // Assemble
            Action<string> act = null;

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void ToSafeOneArgument_ActionIsNull_RunningActionDoesNothing()
        {
            // Assemble
            Action<string> act = null;

            // Act
            var actual = act.ToSafe();

            // Assert
            Assert.DoesNotThrow(() => actual("hello world"));
        }
    }
}