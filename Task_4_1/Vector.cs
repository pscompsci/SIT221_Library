using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_4_1
{
    public class Vector<T> : IEnumerable<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // Returns a string representation of the elements of the Vector
        public override string ToString() => "[" + string.Join(", ", data[0..Count]) + "]";

        public ISorter Sorter { set; get; } = new DefaultSorter();

        internal class DefaultSorter : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;
                Array.Sort(sequence, comparer);
            }
        }

        public void Sort()
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            Sorter.Sort(data, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            if (comparer == null) Sorter.Sort(data, null);
            else Sorter.Sort(data, comparer);
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        /// <summary>
        /// Conducts a BinarySearch on the sorted data using a default comparerand returns 
        /// the index of the element or -1 if the element does not exist in the data
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>The 0 based index of the element, or -1 if it doesn't exist</returns>
        public int BinarySearch(T element)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            return BinarySearch(element, comparer);
        }

        /// <summary>
        /// Conducts a BinarySearch on the sorted data and returns the index of the element or -1 if the
        /// element does not exist in the data
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <param name="comparer">The IComparer to use for comparison</param>
        /// <returns>The 0 based index of the element, or -1 if it doesn't exist</returns>
        public int BinarySearch(T element, IComparer<T> comparer)
        {
            if (Count is 0) return -1;
            if (comparer is null) comparer = Comparer<T>.Default;
            return BinarySearch(element, comparer, 0, data.Length - 1);
        }

        /// <summary>
        /// Recursively searches the vector for the required element by dividing the data into
        /// smaller and smaller sections until the element is found. If the element is not
        /// present, -1 is returned
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <param name="comparer">The IComparer to use for comparison</param>
        /// <param name="lower">The lower index of the section to search</param>
        /// <param name="upper">The upper index of the section to search</param>
        /// <returns>The 0 based index of the element, or -1 if it does not exist</returns>
        private int BinarySearch(T element, IComparer<T> comparer, int lower, int upper)
        {
            if (lower > upper) return -1;
            int mid = (int)(upper + lower) / 2;
            if (comparer.Compare(element, data[mid]) < 0)
                return BinarySearch(element, comparer, lower, mid - 1);
            else if (comparer.Compare(element, data[mid]) == 0) return mid;
            else return BinarySearch(element, comparer, mid + 1, upper);
        }
        
        /// <summary>
        /// Returns a new IEnumerable<T> for the Vector
        /// </summary>
        /// <returns>Iterator for the Vector</returns>
        public IEnumerator<T> GetEnumerator() => new Iterator(this);
        
        /// <summary>
        /// Returns the IEnumerable implemented within IEnumerable<T>
        /// </summary>
        /// <returns>Enumerable implemented within IEnumerable</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();     

        /// <summary>
        /// Implementation of the IEnumerator<T> interface to
        /// facilitate iteration over a vector of elements of
        /// type T
        /// </summary>
        private class Iterator : IEnumerator<T>
        {
            private Vector<T> _v;
            private int _currentIndex = -1;
            public Iterator(Vector<T> v) => _v = v;

            public T Current
            {
                get
                {
                    try
                    {
                        return _v.data[_currentIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        return default(T);
                    }
                }
            }

            object IEnumerator.Current 
            {
                get
                {
                    try
                    {
                        return _v.data[_currentIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        return default(T);
                    }
                }
            }

            /// <summary>
            /// Advances the iterator cursor to the next position and
            /// returns whether the iterator has fully 
            /// iterated the vector.
            /// </summary>
            /// <returns>Boolean whether the Vector is fully iterated</returns>
            public bool MoveNext()
            {
                return ++_currentIndex < _v.Count;
            }

            /// <summary>
            /// Returns the iterator cursor to the start to allow another iteration
            /// </summary>
            public void Reset() => _currentIndex = -1;

            /// <summary>
            /// Currently unused. Previously required in the IEnumerator 
            /// implementation, but no longer the case.
            /// </summary>
            public void Dispose() { }
        }
    }
}