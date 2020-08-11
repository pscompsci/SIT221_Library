using System;
using System.Collections.Generic;

namespace Task_3_2
{
    /// <summary>
    /// An iterative, bottom-up implementation of MergeSort
    /// </summary>
    class MergeSortBottomUp: ISorter
    {
        /// <summary>
        /// Sorts an array of generic elements in an array according to 
        /// rules defined in an IComparer.
        /// </summary>
        /// <param name="sequence">The sequence of generic elements to sort</param>
        /// <param name="comparer">The IComparer to use for sorting rules</param>
        /// <typeparam name="K">The type of the elements</typeparam>
        /// <exception cref="System.ArgumentNullException">Thrown when the sequence
        /// is null</exception>
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence is null) throw new ArgumentNullException();
            if (sequence.Length < 2) return;
            if (comparer is null) comparer = Comparer<K>.Default;

            K[] nonr = sequence;
            K[] dest = new K[sequence.Length];
            K[] temp;

            for (int i = 1; i < sequence.Length; i *= 2)
            {
                for (int j = 0; j < sequence.Length; j += 2 * i) Merge(nonr, dest, comparer, j, i);
                temp = nonr;
                nonr = dest;
                dest = temp;
            }
            if (sequence != nonr)
                Array.Copy(nonr, 0, sequence, 0, sequence.Length);
        }

        /// <summary>
        /// Sorts and merges values from two arrays
        /// </summary>
        /// <param name="ins">First array to merge elements of</param>
        /// <param name="outs">Second array to merge elements of</param>
        /// <param name="comparer">THe rules for sorting as an IComparer</param>
        /// <param name="start">The start index to merge</param>
        /// <param name="inc">The number of elements to merge</param>
        /// <typeparam name="K">The type of the elements in the arrays</typeparam>
        private void Merge<K>(K[] ins, K[] outs, IComparer<K> comparer, int start, int inc) where K : IComparable<K>
        {
            int end1 = Math.Min(start + inc, ins.Length);
            int end2 = Math.Min(start + 2 * inc, ins.Length);

            int x = start;
            int y = start + inc;
            int z = start;

            while (x < end1 && y < end2)
                if (comparer.Compare(ins[x], ins[y]) < 0)
                    outs[z++] = ins[x++];
                else
                    outs[z++] = ins[y++];
            if (x < end1)
                Array.Copy(ins, x, outs, z, end1 - x);
            else if (y < end2)
                Array.Copy(ins, y, outs, z, end2 - y);
        }
    }
}
