using System;

#pragma warning disable 693

namespace SIT221_Library
{
    /// <summary>
    /// Double linked-list that maintains the order of the elements
    /// in the list. This implementation requires that the type
    /// of data for the list, implements the IComparable interface.
    /// </summary>
    /// <typeparam name="T">The type to set for the list</typeparam>
    public class OrderedLinkedList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Individual data element of the linked list. Stores
        /// a reference to both the next and the previous
        /// elements of the list.
        /// </summary>
        /// <typeparam name="U">The type of data</typeparam>
        public class Node<U> where U : IComparable<U>
        {
            public U Data { get; set; }
            public Node<U> Next { get; set; }
            public Node<U> Prev { get; set; }

            /// <summary>
            /// Creates a node with the data and
            /// sets the next and previous elements
            /// to null.
            /// </summary>
            /// <param name="data">Data to be stored in the node</param>
            public Node(U data)
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

        /// <summary>
        /// Creates a new, empty linked list
        /// </summary>
        public OrderedLinkedList()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Adds an element to the list. If the list is empty,
        /// the element is set as the head of the list
        /// </summary>
        /// <param name="element">The element to add to the list</param>
        public void Add(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Head is null) 
            {
                // First entry into empty list
                Head = node; 
                ++Count;
                return;
            }
            Node<T> current = Head;
            while (current.Data.CompareTo(element) < 0)
            {
                if (current.Next == null) 
                {
                    // Insert at the end of the list
                    current.Next = node;
                    node.Prev = current;
                    ++Count;
                    return;
                }
                current = current.Next;
            }
            node.Prev = current.Prev;
            node.Next = current;
            if (current == Head)
            {
                // Insert as new Head node
                current.Prev = node;
                Head = node;
                ++Count;
                return;
            }
            current.Prev.Next = node;
            current.Prev = node;
            ++Count;
        }

        /// <summary>
        /// Clears the linked list, removing all
        /// references to previous elements.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether the linked list contains any node that stores
        /// the target data value.
        /// </summary>
        /// <param name="target">The value to search for in the list</param>
        /// <returns>True if the target value is in the list and false otherwise</returns>
        public bool Contains(T target)
        {
            if(Head is null) return false;
            Node<T> current = Head;
            if(current.Data.Equals(target)) return true;
            while(current.Next != null)
            {
                if(current.Data.Equals(target)) return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Removes an element from the linked list. If the element to remove is the 
        /// head of the list, the next element in the list is set as the new head.
        /// If there is no second element in the list, the all references of the head
        /// will be null.
        /// If the value is not present in the list, false is returned.
        /// </summary>
        /// <param name="target">The value to remove if present</param>
        /// <returns>True if the element is present and is removed. False 
        /// otherwise</returns>
        public bool Remove(T target)
        {
            if(Head is null) return false;
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

        public override string ToString()
        {
            string result = "";
            if (Head == null) return "";
            Node<T> current = Head;
            while (current.Next != null)
            {
                result += current.Data.ToString() + "\n";
                current = current.Next;
            }
            result += current.Data.ToString() + "\n";
            return result;
        }
    }
}
