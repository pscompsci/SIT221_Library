using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_1
{
    class BubbleSort : ISorter
    {
        public BubbleSort() { }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence is null) throw new ArgumentNullException();
            if (sequence.Length <= 1) return;
            
            if (comparer == null) comparer = Comparer<K>.Default;

            // Iterative approach using Bubble-Up
            // (ie. smallest element in the array bubbled to the start)
            // This version is the same as the algorithm on Page 105
            // of the SIT221 Workbook
            for(int i = -1; i < sequence.Length - 1; i++)
            {
                for(int j = sequence.Length - 2; j > i; j--)
                {
                    if(comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        K temp = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = temp;
                    }
                }
            }

            // Iterative approach using Bubble-Down
            // (ie. largest element bubbled to the end of the array)

            // for (int i = sequence.Length; i > 0; i--)
            // {
            //    for (int j = 0; j < sequence.Length - 1; j++)
            //    {
            //        if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
            //        {
            //            K temp = sequence[j];
            //            sequence[j] = sequence[j + 1];
            //            sequence[j + 1] = temp;
            //        }
            //    }
            // }
        }
    }
}
