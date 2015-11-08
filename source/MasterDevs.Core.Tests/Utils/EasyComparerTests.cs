using MasterDevs.Core.Utils;
using NUnit.Framework;
using System;

namespace MasterDevs.Core.Tests.Utils
{
    [TestFixture]
    public class EasyComparerTests
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void Compare_InvokesFuncAndComparesResultingInts(int x, int y)
        {
            // Assemble
            Func<string, int> converter = s => s.ToIntSafe();
            var comparer = new EasyComparer<string>(converter);
            var expected = x.CompareTo(y);

            // Act
            var actual = comparer.Compare(x.ToString(), y.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_NullFunc_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new EasyComparer<string>((Func<string, int>)null));
        }
    }
}