using System;
using System.Collections.Generic;

namespace Task_3_2
{
    /// <summary>
    /// Implementation of the top-down, recursive merge sort. This has a time
    /// complexity of O(nlog n)
    /// </summary>
    class MergeSortTopDown : ISorter
    {
        /// <summary>
        /// Sorts an array of generic elements according to the rules 
        /// of a defined IComparer. The implementation uses the top-down
        /// MergeSort with O(nlog n).
        /// </summary>
        /// <param name="sequence">The sequence of elements to sort</param>
        /// <param name="comparer">The IComparer to use for sorting</param>
        /// <typeparam name="K">The type of the elements of the array</typeparam>
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence is null) throw new ArgumentNullException();
            if (sequence.Length < 2) return;
            if (comparer is null) comparer = Comparer<K>.Default;

            int mid = sequence.Length / 2;
            K[] left = sequence[0..mid];
            K[] right = sequence[mid..sequence.Length];

            Sort(left, comparer);
            Sort(right, comparer);
            Merge(left, right, sequence, comparer);
        }

        /// <summary>
        /// Merges two arrays in order required by the rules of the IComparer
        /// </summary>
        /// <param name="left">One array of elements to merge</param>
        /// <param name="right">Second array of elements to merge</param>
        /// <param name="sequence">The sequence to merge into</param>
        /// <param name="comparer">The IComparer to use for sorting</param>
        /// <typeparam name="K">The type of the elements in the arrays</typeparam>
        private void Merge<K>(K[] left, K[] right, K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0;
            int j = 0;
            while (i + j < sequence.Length)
            {
                if (j == right.Length || (i < left.Length && comparer.Compare(left[i], right[j]) < 0))
                    sequence[i + j] = left[i++];
                else
                    sequence[i + j] = right[j++];
            }
        }
    }
}
