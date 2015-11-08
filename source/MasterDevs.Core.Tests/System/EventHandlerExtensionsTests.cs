using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.System
{
    [TestFixture]
    public class EventHandlerExtensionsTests
    {
        private EventArgs _eventArgs = new EventArgs();
        private EventArgs<string> _genericEventArgs = new EventArgs<string>("helo world");
        private object _sender = new object();

        [Test]
        public void SafeInvokeNoEventArgs_NonNullEventHandler_RaisesEventWithEmptyArgs()
        {
            // Assemble
            bool ran = false;
            Eventy eventy = new Eventy();
            eventy.Handler += (s, e) =>
            {
                ran = true;
                Assert.AreEqual(_sender, s);
                Assert.AreEqual(EventArgs.Empty, e);
            };

            // Act
            eventy.Raise(_sender);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeNoEventArgs_NullEventHandler_DoesNothing()
        {
            // Act
            EventHandlerExtensions.SafeInvoke(null, _sender);
        }

        [Test]
        public void SafeInvokeWithEventArgs_ArgsNull_RaisesEventWithNullArgs()
        {
            // Assemble
            bool ran = false;
            var eventy = new Eventy();
            eventy.Handler += (s, e) =>
            {
                ran = true;
                Assert.AreEqual(_sender, s);
                Assert.IsNull(e);
            };

            // Act
            eventy.Raise(_sender, null);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithEventArgs_ArgsSpecified_RaisesEventWithArgs()
        {
            // Assemble
            bool ran = false;
            var eventy = new Eventy();
            eventy.Handler += (s, e) =>
            {
                ran = true;
                Assert.AreEqual(_sender, s);
                Assert.AreEqual(_eventArgs, e);
            };

            // Act
            eventy.Raise(_sender, _eventArgs);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithEventArgs_NullEventHandler_DoesNothing()
        {
            // Act
            EventHandlerExtensions.SafeInvoke((EventHandler)null, _sender, _eventArgs);
        }

        [Test]
        public void SafeInvokeWithGenericArgs_ArgsNull_RaisesEventWithNullArgs()
        {
            // Assemble
            bool ran = false;
            var eventy = new GenericEventy();
            eventy.Handler += (s, e) =>
            {
                ran = true;
                Assert.AreEqual(_sender, s);
                Assert.IsNull(e);
            };

            // Act
            eventy.Raise(_sender, null);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithGenericArgs_ArgsSpecified_RaisesEventWithArgs()
        {
            // Assemble
            bool ran = false;
            var eventy = new GenericEventy();
            eventy.Handler += (s, e) =>
            {
                ran = true;
                Assert.AreEqual(_sender, s);
                Assert.AreEqual(_genericEventArgs.Value, e);
            };

            // Act
            eventy.Raise(_sender, _genericEventArgs);

            // Assert
            Assert.IsTrue(ran);
        }

        [Test]
        public void SafeInvokeWithGenericArgs_NullEventHandler_DoesNothing()
        {
            // Act
            EventHandlerExtensions.SafeInvoke(null, _sender, _genericEventArgs);
        }

        public class Eventy
        {
            public event EventHandler Handler;

            public void Raise(object sender)
            {
                Handler.SafeInvoke(sender);
            }

            public void Raise(object sender, EventArgs args)
            {
                Handler.SafeInvoke(sender, args);
            }
        }

        public class GenericEventy
        {
            public event EventHandler<string> Handler;

            public void Raise(object sender, string args)
            {
                Handler.SafeInvoke(sender, args);
            }
        }
    }
}