using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

        // Here is the the nested Node<K> class 
        private class Node<K> : INode<K>
        {
            public K Value { get; set; }
            public Node<K> Next { get; set; }
            public Node<K> Previous { get; set; }

            public Node(K value, Node<K> previous, Node<K> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            // This is a ToString() method for the Node<K>
            // It represents a node as a tuple {'the previous node's value'-(the node's value)-'the next node's value')}. 
            // 'XXX' is used when the current node matches the First or the Last of the DoublyLinkedList<T>
            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                s.Append("{");
                s.Append(Previous.Previous == null ? "XXX" : Previous.Value.ToString());
                s.Append("-(");
                s.Append(Value);
                s.Append(")-");
                s.Append(Next.Next == null ? "XXX" : Next.Value.ToString());
                s.Append("}");
                return s.ToString();
            }

        }

        // Here is where the description of the methods and attributes of the DoublyLinkedList<T> class starts

        // An important aspect of the DoublyLinkedList<T> is the use of two auxiliary nodes: the Head and the Tail. 
        // The both are introduced in order to significantly simplify the implementation of the class and make insertion functionality reduced just to a AddBetween(...)
        // These properties are private, thus are invisible to a user of the data structure, but are always maintained in it, even when the DoublyLinkedList<T> is formally empty. 
        // Remember about this crucial fact when you design and code other functions of the DoublyLinkedList<T> in this task.
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; } = 0;

        public DoublyLinkedList()
        {
            Head = new Node<T>(default(T), null, null);
            Tail = new Node<T>(default(T), Head, null);
            Head.Next = Tail;
        }

        public INode<T> First
        {
            get
            {
                if (Count == 0) return null;
                else return Head.Next;
            }
        }

        public INode<T> Last
        {
            get
            {
                if (Count == 0) return null;
                else return Tail.Previous;
            }
        }

        public INode<T> After(INode<T> node)
        {
            if (node == null) throw new NullReferenceException();
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) 
                throw new InvalidOperationException("The node referred as 'before' is no longer in the list");
            if (node_current.Next.Equals(Tail)) return null;
            else return node_current.Next;
        }

        public INode<T> AddLast(T value)
        {
            return AddBetween(value, Tail.Previous, Tail);
        }

        // This is a private method that creates a new node and inserts it in between the two given nodes referred as the previous and the next.
        // Use it when you wish to insert a new value (node) into the DoublyLinkedList<T>
        private Node<T> AddBetween(T value, Node<T> previous, Node<T> next)
        {
            Node<T> node = new Node<T>(value, previous, next);
            previous.Next = node;
            next.Previous = node;
            Count++;
            return node;
        }

        public INode<T> Find(T value)
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                if (node.Value.Equals(value)) return node;
                node = node.Next;
            }
            return null;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            int k = 0;
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                s.Append(node.ToString());
                node = node.Next;
                if (k < Count - 1) s.Append(",");
                k++;
            }
            s.Append("]");
            return s.ToString();
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        /// <summary>
        /// Returns the node before the passed in node, if both exist. If the node does not exist, null
        /// is returned.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>The node before the passed in node</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the node is null</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the node to 
        /// return the node of before, does not exist</exception>
        public INode<T> Before(INode<T> node)
        {
            if (node is null) throw new NullReferenceException();
            Node<T> result = node as Node<T>;
            if (result.Previous == null || result.Next == null) 
                throw new InvalidOperationException("The node referred as 'before' is no longer in the list");
            if (result.Previous.Equals(Head)) return null;
            else return result.Previous;
        }

        /// <summary>
        /// Adds a new node at the head of the linked list
        /// </summary>
        /// <param name="value">The value to add as a new node</param>
        /// <returns>The node added to the head of the list</returns>
        public INode<T> AddFirst(T value)
        {
            return AddBetween(value, Head, Head.Next);
        }

        /// <summary>
        /// Adds a node into the linked list before an existing node
        /// </summary>
        /// <param name="before">The node to add before</param>
        /// <param name="value">The value to add as a new node</param>
        /// <returns>Node added to the list</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the node is null</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the node to 
        /// remove does not exist</exception>
        public INode<T> AddBefore(INode<T> before, T value)
        {
            if (before is null) throw new NullReferenceException();
            Node<T> result = before as Node<T>;
            if (result != null || result.Next != null)
                return AddBetween(value, result.Previous, result);
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Inserts a node with the required value, after an existing now
        /// </summary>
        /// <param name="after">The node with value to add after</param>
        /// <param name="value">The value to add as a new node</param>
        /// <returns>Node added to the linked list</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the node is null</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the node to 
        /// remove does not exist</exception>
        public INode<T> AddAfter(INode<T> after, T value)
        {
            if (after is null) throw new ArgumentNullException();
            Node<T> result = after as Node<T>;
            if (result.Previous != null || result.Next != null)
                return AddBetween(value, result, result.Next);
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Clear all nodes from the linked list and returns it's state
        /// back to the same as a new linked list.
        /// </summary>
        public void Clear()
        {
            Head = new Node<T>(default(T), null, null);
            Tail = new Node<T>(default(T), Head, null);
            Head.Next = Tail;
            Count = 0;
        }

        /// <summary>
        /// Removes a node from the linked list if it exists.This will remove the first
        /// instance of a node with the defined value
        /// </summary>
        /// <param name="node">The node to remove if it exists. This will find only
        /// the first occurence of the node with the corresponding value</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the node is null</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the node to 
        /// remove does not exist</exception>
        // public void Remove(INode<T> node)
        // {
        //     if (node is null) throw new ArgumentNullException();
        //     Node<T> result = node as Node<T>;
        //     if (result.Next is null && result.Previous is null)
        //         throw new InvalidOperationException();
        //     result.Previous.Next = result.Next;
        //     result.Next.Previous = result.Previous;
        //     result.Next = null;
        //     result.Previous = null;
        //     Count--;
        // }

        public void Remove(INode<T> node)
        {
            if (!ValidateNode(node)) throw new InvalidOperationException();
            Node<T> result = node as Node<T>;
            result.Previous.Next = result.Next;
            result.Next.Previous = result.Previous;
            InvalidateNode(result);
            Count--;
        }

        private bool ValidateNode(INode<T> node)
        {
            if (node is null) throw new ArgumentNullException();
            Node<T> result = node as Node<T>;
            return result.Next != null && result.Previous != null;
        }

        private void InvalidateNode(Node<T> node)
        {
            node.Next = null;
            node.Previous = null;
        }

        /// <summary>
        /// Removes the Head node in the linked list
        /// </summary>
        public void RemoveFirst()
        {
            if (Count is 0) throw new InvalidOperationException();
            Head = Head.Next;
            Head.Previous = Tail;
            Count--;
        }

        /// <summary>
        /// Removes the Tail node in the linked list
        /// </summary>
        public void RemoveLast()
        {
            if (Count is 0) throw new InvalidOperationException();
            Tail = Tail.Previous;
            Tail.Next = Head;
            Count--;
        }
    }
}
