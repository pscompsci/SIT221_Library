using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_1
{
    class SelectionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence is null) throw new ArgumentNullException();
            if (sequence.Length <= 1) return;
            
            if (comparer == null) comparer = Comparer<K>.Default;

            // Iterative approach
            // Same as the algorithm on Page 107 of the SIT221 Workbook
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if(comparer.Compare(sequence[smallest], sequence[j]) > 0)
                    {
                        smallest = j;
                    }
                }
                K temp = sequence[smallest];
                sequence[smallest] = sequence[i];
                sequence[i] = temp;
            }
        }
    }
}
