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

                // Clean up
                Debug.Flush();
                tw.Flush();
                listener.Flush();
                //Debug.Listeners.Remove(listener);
            }

            // Assert
            StringAssert.Contains(message, traces.ToString());
        }

        [Test]
        public void Start_NullAction_Throws()
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => DisposeWatch.Start((Action<TimeSpan>)null));
        }
    }
}