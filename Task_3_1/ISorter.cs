using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1
{
    public interface ISorter
    {
        void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>;
    }
}
