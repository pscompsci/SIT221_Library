using System;
using System.Collections.Generic;

namespace Task_6_1
{
    public class Stack<T> where T : IComparable<T>
    {
        private const int MAX_STACK_SIZE = 100;
        private T[] _stack;
        private int _count;
        private T[] _min;
        private int _minCount;

        public Stack()
        {
            _stack = new T[MAX_STACK_SIZE];
            _count = 0;
            _min = new T[MAX_STACK_SIZE];
            _minCount = 0;
        }

        public Stack(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException();
            _stack = new T[size];
            _count = 0;
            _min = new T[size];
            _minCount = 0;
        }

        private bool IsEmpty() => _count is 0 ? true : false;
        private bool isFull() => _count >= _stack.Length - 1 ? true : false;

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            T value = _stack[_count];
            _count--;
            if (_min[_minCount - 1].Equals(value))
            {
                _min[_minCount - 1] = default(T);
                _minCount--;
            }
            return value;
        }

        public void Push(T value)
        {
            if (isFull()) throw new StackOverflowException();
            if (IsEmpty()) _min[_minCount++] = value;
                
            if (value.CompareTo(_min[_minCount - 1]) < 0)
            {
                _min[_minCount++] = value;
            } 
            _stack[++_count] = value;
        }

        public T Min()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            return _min[_minCount - 1];
        }
    }
}