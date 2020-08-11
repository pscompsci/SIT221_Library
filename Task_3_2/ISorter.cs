using System;
using System.Collections.Generic;

namespace Task_3_2
{
    public interface ISorter
    {
        void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>;
    }
}
