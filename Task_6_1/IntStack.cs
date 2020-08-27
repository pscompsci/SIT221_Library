using System;
using System.Collections.Generic;

namespace Task_6_1
{
    public class IntStack
    {
        const int DEFAULT_MAX_SIZE = 100;
        private int[] _stack;
        private int _top;
        private int _min;

        public IntStack()
        {
            _stack = new int[DEFAULT_MAX_SIZE];
            _top = -1;
        }

        public IntStack(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException();
            _stack = new int[size];
            _top = -1;
        }   

        private bool IsEmpty() => _top is -1 ? true : false;
        private bool IsFull() => _top == _stack.Length - 1 ? true : false;

        public void Push(int value)
        {
            if (IsFull()) throw new StackOverflowException();
            if (IsEmpty())
            {
                _stack[++_top] = value;
                _min = value;
                return;
            }
            
            if (value < _min)
            {
                _stack[++_top] = (2 * value - _min);
                _min = value;
            }
            else
            {
                _stack[++_top] = value;
            }
        }

        public int Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            int result = _stack[_top];

            if (result < _min)
            {
                int temp = (2 * _min) - result;
                result = _min;
                _min = temp;
            }

            _top --;
            return result;
        }

        public int Min()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            return _min;
        }
    }
}