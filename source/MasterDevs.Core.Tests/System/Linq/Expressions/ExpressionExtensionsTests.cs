using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace MasterDevs.Core.Tests.System.Linq.Expressions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        public int MyField;
        public int MyProperty { get; set; }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyName_ExpressionIsNull_Throws()
        {
            // Assemble
            Expression<Func<int>> exp = null;

            // Act
            exp.GetPropertyName();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyNamePassingInViewModel_ExpressionIsNull_Throws()
        {
            // Assemble
            Expression<Func<object, int>> exp = null;

            // Act
            exp.GetPropertyName();
        }
    }
}