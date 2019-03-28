using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Collections
{
    public interface IEnumCount<T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
        T[] ToArray();
    }
}
