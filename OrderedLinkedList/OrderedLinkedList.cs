using System;

#pragma warning disable 693

namespace SIT221_Library
{
    public class OrderedLinkedList<T> where T : IComparable
    {
        public class Node<T> where T : IComparable
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        public Node<T> Head { get; private set; }
        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("Index must be 0 - " + Count);
                Node<T> current = Head;
                int idx = 0;
                while (idx < index)
                {
                    current = current.Next;
                    idx++;
                }
                return current.Data;
            }
        }

        public OrderedLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void Add(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Head == null) 
            {
                Head = node; 
                ++Count;
                return;
            }
            Node<T> current = Head;
            while (current.Data.CompareTo(element) < 0)
            {
                if (current.Next == null) 
                {
                    current.Next = node;
                    node.Prev = current;
                    ++Count;
                    return;
                }
                current = current.Next;
            }
            node.Prev = current.Prev;
            node.Next = current;
            current.Prev.Next = node;
            current.Prev = node;
            ++Count;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T target)
        {
            if(Head == null) return false;
            Node<T> current = Head;
            if(current.Data.Equals(target)) return true;
            while(!current.Data.Equals(target) && current.Next != null)
            {
                current = current.Next;
                if(current.Data.Equals(target)) return true;
            }
            return false;
        }

        public bool Remove(T target)
        {
            if(Head == null) return false;
            Node<T> current = Head;
            if(current.Data.CompareTo(target) == 0)
            {
                Head = current.Next;
                Head.Prev = null;
                --Count;
                return true;
            }
            while(current.Next != null)
            {
                current = current.Next;
                if(current.Data.CompareTo(target) == 0)
                {
                    if(current.Next == null)
                    {
                        current.Prev.Next = null;
                        current.Prev = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    --Count;
                    return true;
                }
            }
            return false;
        }
    }
}
