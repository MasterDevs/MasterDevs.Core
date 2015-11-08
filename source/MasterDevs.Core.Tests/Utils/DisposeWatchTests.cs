using MasterDevs.Core.Utils;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MasterDevs.Core.Tests.Utils
{
    [TestFixture]
    public class DisposeWatchTests
    {
        [Test]
        public void Dispose_ActionSupplied_InvokesAction()
        {
            // Assemble
            bool isCalled = false;
            var watch = DisposeWatch.Start(_ => isCalled = true);

            // Act
            watch.Dispose();

            // Assert
            Assert.IsTrue(isCalled);
        }

        [Test]
        public void Dispose_CalledSecondTime_DoesNotInvokeAction()
        {
            // Assemble
            int calledCount = 0;
            var watch = DisposeWatch.Start(_ => calledCount++);

            // Act
            watch.Dispose();
            watch.Dispose();

            // Assert
            Assert.AreEqual(1, calledCount);
        }

#if DEBUG
        /// <summary>
        /// When using the default implementation, nothing is printed out when DEBUG is not defined.
        /// </summary>
        [Test]
        public void Dispose_MessageSupplied_LogsOutMessage()
        {
            // Assemble
            string message = $"Hello World {StringUtils.GenerateRandom(5)}";
            var traces = new StringBuilder();
            using (var tw = new StringWriter(traces))
            using (TraceListener listener = new TextWriterTraceListener(tw))
            {
                Debug.Listeners.Add(listener);
                var watch = DisposeWatch.Start(message);

                // Act
                watch.Dispose();

                // Assert
                Debug.Listeners.Remove(listener);
                StringAssert.Contains(message, traces.ToString());
            }
        }
#endif

        [Test]
        public void Start_NullAction_Throws()
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => DisposeWatch.Start((Action<TimeSpan>)null));
        }
    }
}