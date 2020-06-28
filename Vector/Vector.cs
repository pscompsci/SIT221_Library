using System;
using System.Collections.Generic;

namespace SIT221_Library
{
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
                    throw new IndexOutOfRangeException("Index must be in range 0 - " + (Count - 1).ToString());
                return _items[index];
            }
            set
            {
                if(index < 0 || index > (_count - 1))
                    throw new IndexOutOfRangeException("Index must be in range 0 - " + (Count - 1).ToString());
                _items[index] = value;
            }
        }

        public int Count { get => _count; }

        private void SetCapacity(int capacity)
        {
            if (capacity < Count) 
                throw new ArgumentOutOfRangeException("Capacity smaller than current number of elements");
            T[] temp = new T[capacity];
            Array.Copy(_items, temp, Count);
            _items = temp;
        }

        public Vector()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        public Vector(int capacity)
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity must be > 0");
            _items = new T[capacity];
            _count = 0;
        }

        public void Add(T element)
        {
            if(Count == Capacity)
            {
              SetCapacity(Capacity*2);
            }
            _items[Count] = element;
            ++_count;
        }

        public void Clear()
        {
            _items = new T[_items.Length];
            _count = 0;
        }

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
