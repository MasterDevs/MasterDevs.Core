using System;
using System.Collections.Generic;

namespace MasterDevs.Lib.Common.Infrastructure
{
    /// <summary>
    /// Simple implementation of an <seealso cref="IComparer"/> which accepts a function on the constructor to convert the <typeparamref name="T"/> to an int
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EasyComparer<T> : IComparer<T>
    {
        private readonly Func<T, int> _toInt;

        public EasyComparer(Func<T, int> toInt)
        {
            _toInt = CodeContract.RequireNotNull(toInt, "toInt");
        }

        public int Compare(T x, T y)
        {
            int xInt = _toInt(x);
            int yInt = _toInt(y);

            return yInt.CompareTo(xInt);
        }
    }
}