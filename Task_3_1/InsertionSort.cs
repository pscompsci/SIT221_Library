using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_1
{
    class InsertionSort : ISorter
    {
        public InsertionSort() { }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence is null) throw new ArgumentNullException();
            if (sequence.Length <= 1) return;
            
            if (comparer == null) comparer = Comparer<K>.Default;

            // Iterative approach
            // Same as the algorithm on Page 108 of the SIT221 Workbook
            for (int i = 1; i < sequence.Length; i++)
            {
                int j;
                K hold = sequence[i];
                for (j = i - 1; j >= 0 && (comparer.Compare(sequence[j], hold) > 0); j--)
                {
                    sequence[j + 1] = sequence[j];
                }
                sequence[j + 1] = hold;
            }
        }
    }
}
