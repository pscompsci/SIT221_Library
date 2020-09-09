using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    public class Heap<K, D> where K : IComparable<K>
    {

        // This is a nested Node class whose purpose is to represent a node of a heap.
        private class Node : IHeapifyable<K, D>
        {
            // The Data field represents a payload.
            public D Data { get; set; }
            // The Key field is used to order elements with regard to the Binary Min (Max) Heap Policy, i.e. the key of the parent node is smaller (larger) than the key of its children.
            public K Key { get; set; }
            // The Position field reflects the location (index) of the node in the array-based internal data structure.
            public int Position { get; set; }

            public Node(K key, D value, int position)
            {
                Data = value;
                Key = key;
                Position = position;
            }

            // This is a ToString() method of the Node class.
            // It prints out a node as a tuple ('key value','payload','index')}.
            public override string ToString()
            {
                return "(" + Key.ToString() + "," + Data.ToString() + "," + Position + ")";
            }
        }

        // ---------------------------------------------------------------------------------
        // Here the description of the methods and attributes of the Heap<K, D> class starts

        public int Count { get; private set; }

        // The data nodes of the Heap<K, D> are stored internally in the List collection. 
        // Note that the element with index 0 is a dummy node.
        // The top-most element of the heap returned to the user via Min() is indexed as 1.
        private List<Node> data = new List<Node>();

        // We refer to a given comparer to order elements in the heap. 
        // Depending on the comparer, we may get either a binary Min-Heap or a binary  Max-Heap. 
        // In the former case, the comparer must order elements in the ascending order of the keys, and does this in the descending order in the latter case.
        private IComparer<K> comparer;

        // We expect the user to specify the comparer via the given argument.
        public Heap(IComparer<K> comparer)
        {
            this.comparer = comparer;

            // We use a default comparer when the user is unable to provide one. 
            // This implies the restriction on type K such as 'where K : IComparable<K>' in the class declaration.
            if (this.comparer == null) this.comparer = Comparer<K>.Default;

            // We simplify the implementation of the Heap<K, D> by creating a dummy node at position 0.
            // This allows to achieve the following property:
            // The children of a node with index i have indices 2*i and 2*i+1 (if they exist).
            data.Add(new Node(default(K), default(D), 0));
        }

        // This method returns the top-most (either a minimum or a maximum) of the heap.
        // It does not delete the element, just returns the node casted to the IHeapifyable<K, D> interface.
        public IHeapifyable<K, D> Min()
        {
            if (Count == 0) throw new InvalidOperationException("The heap is empty.");
            return data[1];
        }

        // Insertion to the Heap<K, D> is based on the private UpHeap() method
        public IHeapifyable<K, D> Insert(K key, D value)
        {
            Count++;
            Node node = new Node(key, value, Count);
            data.Add(node);
            UpHeap(Count);
            return node;
        }

        private void UpHeap(int start)
        {
            int position = start;
            while (position != 1)
            {
                if (comparer.Compare(data[position].Key, data[position / 2].Key) < 0) Swap(position, position / 2);
                position = position / 2;
            }
        }

        // This method swaps two elements in the list representing the heap. 
        // Use it when you need to swap nodes in your solution, e.g. in DownHeap() that you will need to develop.
        private void Swap(int from, int to)
        {
            Node temp = data[from];
            data[from] = data[to];
            data[to] = temp;
            data[to].Position = to;
            data[from].Position = from;
        }

        public void Clear()
        {
            for (int i = 0; i<=Count; i++) data[i].Position = -1;
            data.Clear();
            data.Add(new Node(default(K), default(D), 0));
            Count = 0;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            for (int i = 0; i < Count; i++)
            {
                s.Append(data[i + 1]);
                if (i + 1 < Count) s.Append(",");
            }
            s.Append("]");
            return s.ToString();
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.


        /// <summary>
        /// Deletes the root node from the Heap
        /// </summary>
        /// <returns>Node as an IHeapifyable, removed from the heap</returns>
        public IHeapifyable<K, D> Delete()
        {
            if (Count is 0) throw new InvalidOperationException();
            Node result = data[1];
            Swap(1, Count);
            data.RemoveAt(Count);
            Count--;
            DownHeap(1);
            return result;
        }

        // Returns the index of a possible left child of an element in the heap
        private int Left(int start) => start * 2;

        // Returns the index of a possible right child of an element in the heap
        private int Right(int start) => start * 2 + 1;

        // Recursively checks a node against its left and right children and moves the node
        // downward in the heap as necessary, to ensure the heap property is correct
        private void DownHeap(int start)
        {
            int leftChild = Left(start);
            if (leftChild > Count) return;
            
            int rightChild = Right(start);
            int position = leftChild;

            if (rightChild < Count && 
                comparer.Compare(data[leftChild].Key, data[rightChild].Key) >= 0) 
                    position = rightChild;

            if (comparer.Compare(data[start].Key, data[position].Key) < 0) return;

            Swap(start, position);
            DownHeap(position);
        }

        /// <summary>
        /// Builds a binary heap using the specified data according to the bottom-up approach
        /// </summary>
        /// <param name="keys">Array of keys for each item of data</param>
        /// <param name="data">Array of data to be added to the heap</param>
        /// <returns>Array of the items in the heap</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the heap is empty, or if the
        /// number of keys is not the same as the number of data items</exception>
        public IHeapifyable<K, D>[] BuildHeap(K[] keys, D[] data)
        {
            if (Count != 0) throw new InvalidOperationException();
            if (keys.Length != data.Length) throw new InvalidOperationException();

            Node[] result = new Node[keys.Length];

            for(int i = 0; i < keys.Length; i++)
            {
                Node node = new Node(keys[i], data[i], ++Count);
                this.data.Add(node);
                result[i] = node;
            }
            Heapify();

            return result;
        }

        // Ensures correct Heap property for a bottom-up build
        private void Heapify()
        {
            for (int i = Count / 2; i > 0; i--) DownHeap(i);
        }

        /// <summary>
        /// Decreases the key of the provided element to the new key value, if the state of the heap
        /// matches the values in the passed in element
        /// </summary>
        /// <param name="element">IHeapifyable element to change the key of</param>
        /// <param name="new_key">New key to be applied to the element</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the state of the heap, does
        /// not match the key and data of the passed in element</exception>
        public void DecreaseKey(IHeapifyable<K, D> element, K new_key)
        {
            Node result = element as Node;
            if (!result.Equals(data[result.Position])) throw new InvalidOperationException();
            result.Key = new_key;
            UpHeap(result.Position);
        }

        /// <summary>
        /// Deletes a specific node if it exists, no mater where it is in the heap
        /// </summary>
        /// <param name="element">IHeapifyable node to be deleted</param>
        /// <returns>Node deleted</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the element is null, or
        /// if the state of the heap does not match the values contained in the element</exception>
        public IHeapifyable<K, D> DeleteElement(IHeapifyable<K, D> element)
        {
            if (element is null) throw new ArgumentNullException();

            Node node = element as Node;
            if (!data[node.Position].Key.Equals(element.Key)) throw new InvalidOperationException();

            int position = node.Position;

            // O(1) complexity
            Swap(position, Count);

            data.RemoveAt(Count);
            Count--;

            // O(log n) to repair the heap property
            DownHeap(position);

            return node;
        }
        
        /// <summary>
        /// Returns the Kth minimum element of a heap
        /// </summary>
        /// <param name="k">The Kth element to return</param>
        /// <returns>The Kth minimum element</returns>
        public IHeapifyable<K, D> KthMinElement(int k)
        {
            if (Count is) throw new InvalidOperationException();
            if (k <= 0 || k > Count) throw new ArgumentOutOfRangeException();

            IHeapifyable<K, D> kthMin = null;
            List<IHeapifyable<K, D>> temp = new List<IHeapifyable<K, D>>();

            // O(og k) to delete an element, and deleting k elements = O(k log k)
            for (int i = 1; i <= k; i++) 
            {
                if (i == k) kthMin = data[1];
                temp.Add(this.Delete());
            }

            // O(log k) to insert an elemenet, and inserting k elements = O(k log k)
            foreach(var node in temp) this.Insert(node.Key, node.Data);
            
            return kthMin;
        }
    }
}
