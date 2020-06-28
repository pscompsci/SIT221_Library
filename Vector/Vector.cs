using System;
using System.Collections.Generic;

namespace SIT221_Library
{
    /// <summary>
    /// Generic vector class that uses an underlying array structure for
    /// constant time access to array members. The Vector autoscales
    /// capacity increase requirements to accept new elements as
    /// required.
    /// </summary>
    /// <typeparam name="T">Generic type to create the vector instance with</typeparam>
    public class Vector<T>
    {
        private const int DefaultCapacity = 4;
        private T[] _items;
        private int _count;

        public int Capacity { get => _items.Length; set => SetCapacity(value); }

        public T this[int index]
        {
            get
            {
                if(index < 0 || index > (_count - 1))
                    throw new IndexOutOfRangeException(
                        "Index must be in range 0 - " + (Count - 1).ToString());
                return _items[index];
            }
            set
            {
                if(index < 0 || index > (_count - 1))
                    throw new IndexOutOfRangeException(
                        "Index must be in range 0 - " + (Count - 1).ToString());
                _items[index] = value;
            }
        }

        public int Count { get => _count; }

        /// <summary>
        /// Sets the capacity of the vector to the new capacity, if the new
        /// capacity is large enough to accomodate all existing elements
        /// in the Vector.
        /// </summary>
        /// <param name="capacity">New required capacity</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// the new capacity is less than the current count of elements of
        /// the Vector</exception>
        private void SetCapacity(int capacity)
        {
            if (capacity < Count) 
                throw new ArgumentOutOfRangeException("Capacity smaller than current number of elements");
            T[] temp = new T[capacity];
            Array.Copy(_items, temp, Count);
            _items = temp;
        }

        /// <summary>
        /// Creates an empty Vector instance with default capacity of 4.
        /// </summary>
        public Vector()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Creates an empty Vector instance with capacity equal to the
        /// supplied argument.
        /// </summary>
        /// <param name="capacity">The required capacity of the Vector</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// the indicated capacity is less than 0</exception>
        public Vector(int capacity)
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity must be > 0");
            _items = new T[capacity];
            _count = 0;
        }

        /// <summary>
        /// Adds a new element to the Vector, rescaling the vector to
        /// add additional capacity if required.
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if(Count == Capacity)
            {
              SetCapacity(Capacity*2);
            }
            _items[Count] = element;
            ++_count;
        }

        /// <summary>
        /// Creates a new vector with the same capacity as the current
        /// Vector and resets the count of elements to 0. This frees
        /// the elements of the previous Vector to be garbage
        /// collected.
        /// </summary>
        public void Clear()
        {
            _items = new T[_items.Length];
            _count = 0;
        }

        /// <summary>
        /// Identifies whether the target value exists at all in the
        /// Vector.
        /// </summary>
        /// <param name="target">The item to look for in the Vector</param>
        /// <returns>True if the target exists in the Vector, otherwise
        /// false</returns>
        public bool Contains(T target)
        {
            foreach(T value in _items)
            {
                if (value.Equals(target)) return true;
            }
            return false;
        }
    }
}
