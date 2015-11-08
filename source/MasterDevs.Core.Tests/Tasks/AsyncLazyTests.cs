using MasterDevs.Core.Tasks;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MasterDevs.Core.Tests.Tasks
{
    [TestFixture]
    [Timeout(500)]
    public class AsyncLazyTests
    {
        [Test]
        public async Task Await_FuncInCtor_FunctionCalled()
        {
            // Assemble
            var lazy = new AsyncLazy<int>(() => 5);

            // Act
            var value = await lazy.Value;

            // Assert
            Assert.AreEqual(5, value);
        }

        [Test]
        public async Task Await_FuncInCtorSecondTime_FunctionNotCalled()
        {
            // Assemble
            int count = 0;
            var lazy = new AsyncLazy<int>(() =>
            {
                count++;
                return 5;
            });

            // Act
            await lazy.Value;
            await lazy.Value;

            // Assert
            Assert.AreEqual(1, count);
        }

        [Test]
        public async Task Await_TaskInCtor_FunctionCalled()
        {
            // Assemble
            var lazy = new AsyncLazy<int>(() => Task.Factory.StartNew<int>(() => 5));

            // Act
            var value = await lazy.Value;

            // Assert
            Assert.AreEqual(5, value);
        }

        [Test]
        public async Task Await_TaskInCtorSecondTime_FunctionNotCalled()
        {
            // Assemble
            int count = 0;
            var lazy = new AsyncLazy<int>(() => Task.Factory.StartNew<int>(() =>
            {
                count++;
                return 5;
            }));

            // Act
            await lazy.Value;
            await lazy.Value;

            // Assert
            Assert.AreEqual(1, count);
        }

        [Test]
        public void Ctor_Func_DoesNotInvokeFunc()
        {
            // Assemble
            bool called = false;
            var func = new Func<int>(() =>
            {
                called = true;
                return 0;
            });

            // Act
            var lazy = new AsyncLazy<int>(func);

            // Assert
            Assert.False(called);
        }

        [Test]
        public void Ctor_FuncTask_DoesNotInvokeFuncInCtor()
        {
            // Assemble
            bool called = false;
            var task = new Task<int>(() =>
            {
                called = true;
                return 0;
            });
            var func = new Func<Task<int>>(() => task);

            // Act
            var lazy = new AsyncLazy<int>(func);

            // Assert
            Assert.False(called);
        }
    }
}