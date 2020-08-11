using System;
using System.Collections.Generic;

namespace Task_3_2
{
    /// <summary>
    /// Sorts an array of generic items using rules provided in a comparer
    /// </summary>
    class RandomizedQuickSort: ISorter
    {
        private Random Random { get; set; } = new Random();
        private int RandomPivot(int a, int b) => Random.Next(a, b);

       /// <summary>
       /// Sorts a sequence of 2 or more generic elements
       /// </summary>
       /// <param name="sequence">The array of generic elements to sort</param>
       /// <param name="comparer">IComparer to use for comparison</param>
       /// <typeparam name="K">The type of the elements</typeparam>
       /// <exception cref="System.ArgumentNullException">Thrown if the sequence
       /// of elements is null</exception>
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (sequence == null) throw new ArgumentNullException();
            if (sequence.Length < 2) return; // Nothing to do if fewer than 2 elements
            if (comparer == null) comparer = Comparer<K>.Default;
            Sort(sequence, comparer, 0, sequence.Length - 1);
        }

        /// <summary>
        /// Recursively quick sorts an array of elements in place, using a random
        /// pivot selection
        /// </summary>
        /// <param name="sequence">The sequence of elements</param>
        /// <param name="a">The index of one element to swap</param>
        /// <typeparam name="K">The index of the other element to swap</typeparam>
        private void Swap<K>(K[] sequence, int a, int b)
        {
            K temp = sequence[a];
            sequence[a] = sequence[b];
            sequence[b] = temp;
        }

        /// <summary>
        /// Recursively quick sorts an array of elements in place, using a random
        /// pivot selection
        /// </summary>
        /// <param name="sequence">The sequence of the elements to sort</param>
        /// <param name="comparer">The IComparer to use</param>
        /// <param name="a">The left index of the part to sort</param>
        /// <param name="b">The right index of the part to sort</param>
        /// <typeparam name="K">The type of the elements in the array</typeparam>
        private void Sort<K>(K[] sequence, IComparer<K> comparer,int a,int b) where K : IComparable<K>
        {
            if (a >= b) return;

            int left = a;
            int right = b - 1;

            Swap(sequence, RandomPivot(a, b), b);
            K pivot = sequence[b];

            while(left <= right)
            {
                while (left <= right && comparer.Compare(sequence[left], pivot) < 0) left++;
                while (left <= right && comparer.Compare(sequence[right], pivot) > 0) right--;
                if(left <= right)
                {
                    Swap(sequence, left, right);
                    left++; 
                    right--;
                }
            }

            Swap(sequence, left, b);

            Sort(sequence, comparer, a, left - 1);
            Sort(sequence, comparer, left + 1, b);
        }
    }
}
