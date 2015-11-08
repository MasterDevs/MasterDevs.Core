using MasterDevs.Core.Tasks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MasterDevs.Core.Tests.Tasks
{
    [TestFixture]
    public class AsyncManualResetEventTests
    {
        [Test]
        public async Task WaitAsync_EventHasBeenClosedMultipleTimesAndOpenedAgain_DoesNotBlock()
        {
            // Assemble
            var mre = new AsyncManualResetEvent();

            // Act
            mre.Reset();
            mre.Reset();
            mre.Set();
            await mre.WaitAsync();

            // Assert
            Assert.Pass("Call to WaitAsync did not block");
        }

        [Test]
        public async Task WaitAsync_EventHasBeenOpenedClosedAndOpenedAgain_DoesNotBlock()
        {
            // Assemble
            var mre = new AsyncManualResetEvent();

            // Act
            mre.Set();
            mre.Reset();
            mre.Set();
            await mre.WaitAsync();

            // Assert
            Assert.Pass("Call to WaitAsync did not block");
        }

        [Test]
        public void WaitAsync_EventIsClosed_WaitsUntilEventIsOpened()
        {
            // Assemble
            var mre = new AsyncManualResetEvent();
            bool isWaiting = false;
            bool isWaitingOver = false;

            // Act
            var waiter = Task.Factory.StartNew(async () =>
            {
                isWaiting = true;
                await mre.WaitAsync();
                isWaitingOver = true;
            });

            while (!isWaiting)
            {
                // Do nothing
            }

            // Assert
            Assert.IsFalse(isWaitingOver);
            mre.Set();

            while (!isWaitingOver) { }
            Assert.IsTrue(isWaitingOver);
        }

        [Test]
        public async Task WaitAsync_EventIsOpen_DoesNotBlock()
        {
            // Assemble
            var mre = new AsyncManualResetEvent();

            // Act
            mre.Set();
            await mre.WaitAsync();

            // Assert
            Assert.Pass("Call to WaitAsync did not block");
        }
    }
}