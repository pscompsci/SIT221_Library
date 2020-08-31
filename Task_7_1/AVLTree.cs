using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#pragma warning disable 693


namespace Task_7_1
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public class Node<T> : INode<T> where T : IComparable<T>
        {
            public T Key { get; set; }
            public Node<T> Right;
            public Node<T> Left;

            public Node (T key)
            {
                Key = key;
                Right = null;
                Left = null;
            }

            public int Height()
            {
                if (Right is null && Left is null) return 1;
                if (Right == null) return Left.Height() + 1;
                if (Left == null) return Right.Height() + 1;
                if (Right.Height() > Left.Height()) return Right.Height() + 1;
                return Left.Height() + 1;
            }

            public int Balance()
            { 
                if (Right is null && Left is null) return 0;
                if (Right is null) return -Left.Height();
                if (Left is null) return Right.Height();
                return Right.Height() - Left.Height();
            }

            public bool IsLessThan(Node<T> node) => Key.CompareTo(node.Key) < 0;

            public Node<T> FindReplacement()
            {
                if(Left is null) return null;
                Node<T> current = Left;
                while(current.Right != null) current = current.Right;
                return current;
            }
        }

        Node<T> Root;
        public int Count;

        public AVLTree()
        {
            Root = null;
            Count = 0;
        }

        public Node<T> FindParent(T key)
        {
            Node<T> previous = null;
            Node<T> current = Root;

            while (current != null)
            {
                if (current.Key.Equals(key)) return previous;
                else if (key.CompareTo(current.Key) > 0)
                {
                    previous = current;
                    current = current.Right;
                }
                else
                {
                    previous = current;
                    current = current.Left;
                }
            }
            return previous;
        }

        public Node<T> Find(T key)
        {
            Node<T> current = Root;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current;
                }
                else if (current.Key.CompareTo(key) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            return null;
        }

        private Node<T> FindParent(Node<T> node)
        {
            Node<T> previous = null;
            Node<T> current = Root;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    return previous;
                }
                else if (node.Key.CompareTo(current.Key) > 0)
                {
                    previous = current;
                    current = current.Right;
                }
                else
                {
                    previous = current;
                    current = current.Left;
                }
            }

            return null;
        }


        public void Insert(T key)
        {
#if DEBUG
            Console.WriteLine("Inserting {0}", key);
#endif
            if (Root == null)
            {
#if DEBUG
                Console.WriteLine("Inserting {0} as Root", key);
#endif
                Root = new Node<T>(key);
                Count++;
                return;
            }
            Count++;
            Insert(key, Root);
        }

        private void Insert(T key, Node<T> current)
        {
#if DEBUG
            Console.WriteLine("Current Node: {1}", key, current.Key);
#endif
            bool shouldInsert = false;
            if (key.CompareTo(current.Key) < 0)
            {
                if (current.Left != null)
                {
                    Insert(key, current.Left);
                }
                else
                {
                    shouldInsert = true;
                }
            }
            else
            {
                if (current.Right != null)
                {
                    Insert(key, current.Right);
                }
                else
                {
                    shouldInsert = true;
                }
            }

            if (shouldInsert)
            {
                if (key.CompareTo(current.Key) < 0)
                {
                    current.Left = new Node<T>(key);
#if DEBUG
                    Console.WriteLine("Inserted to the left");
#endif
                }
                else
                {
                    current.Right = new Node<T>(key);
#if DEBUG
                    Console.WriteLine("Inserted to the right");
#endif
                }
                shouldInsert = false;
            }

            while (Math.Abs(current.Balance()) > 1)
            {
                if (current.Balance() > 1)
                {
                    LeftRotation(current);
                }
                else if (current.Balance() < 1)
                {
                    RightRotation(current);
                }
            }
        }


        private void LeftRotation(Node<T> node)
        {
#if DEBUG
            Console.WriteLine("LeftRotation on {0}", node.Key);
#endif
            Node<T> parentNode = FindParent(node);
            Node<T> newHead = node.Right;
            Node<T> tempHolder;

            if (newHead.Right == null && newHead.Left != null)
            {
                RightRotation(newHead);
                newHead = node.Right;
            }

            if (parentNode != null)
            {
                if (parentNode.Right == node)
                {
                    parentNode.Right = newHead;
                }
                else
                {
                    parentNode.Left = newHead;
                }
            }
            else
            {
                Root = newHead;
            }
            tempHolder = newHead.Left;

            newHead.Left = node;
            node.Right = tempHolder;
#if DEBUG
            Console.WriteLine("Root is now: {0}", Root.Key);
#endif
        }

        private void RightRotation(Node<T> node)
        {
#if DEBUG
            Console.WriteLine("RightRotation on {0}", node.Key);
#endif
            Node<T> parentNode = FindParent(node);
            Node<T> newHead = node.Left;
            Node<T> tempHolder;

            if (newHead.Left == null && newHead.Right != null)
            {
                LeftRotation(newHead);
                newHead = node.Left;
            }

            if (parentNode != null)
            {
                if (parentNode.Left == node)
                {
                    parentNode.Left = newHead;
                }
                else
                {
                    parentNode.Right = newHead;
                }
            }
            else
            {
                Root = newHead;
            }
            tempHolder = newHead.Right;

            newHead.Right = node;
            node.Left = tempHolder;
#if DEBUG
            Console.WriteLine("Root is now: {0}", Root.Key);
#endif
        }

        public bool Remove(T key)
        {
            if (Root == null)
            {
                return false;
            }

            Node<T> node = Find(key);
            if (node == null)
            {
                return false;
            }
            Node<T> current = Root;

            Count--;
            Remove(node, current);
            return true;
        }

        private void Remove(Node<T> node, Node<T> current)
        {
            if (node == current)
            {
                Node<T> LeftMax = node.FindReplacement();
                Node<T> parentNode = FindParent(node);

                if (LeftMax != null)
                {
                    Node<T> replacementNode = new Node<T>(LeftMax.Key);
                    replacementNode.Left = node.Left;
                    replacementNode.Right = node.Right;

                    if (node != Root)
                    {
                        if (node.IsLessThan(parentNode))
                        {
                            parentNode.Left = replacementNode;
                        }
                        else
                        {
                            parentNode.Right = replacementNode;
                        }
                    }
                    else
                    {
                        Root = replacementNode;
                    }
                    current = replacementNode;
                }
                else
                {
                    if (node != Root)
                    {
                        if (node.IsLessThan(parentNode) || node.Key.Equals(parentNode.Key))
                        {
                            parentNode.Left = node.Right;
                        }
                        else
                        {
                            parentNode.Right = node.Right;
                        }
                    }
                    else
                    {
                        Root = node.Right;
                    }
                }

                if (LeftMax != null)
                {
                    Remove(LeftMax, current.Left);
                }
            }
            else if (current.IsLessThan(node))
            {
                Remove(node, current.Right);
            }
            else
            {
                Remove(node, current.Left);
            }

            while (Math.Abs(current.Balance()) > 1)
            {
                if (current.Balance() > 1)
                {
                    LeftRotation(current);
                }
                else
                {
                    RightRotation(current);
                }
            }
        }


        public List<T> InOrder()
        {
            List<T> result = new List<T>();
            InOrder(Root);

            return result;

            void InOrder(Node<T> node)
            {
                if (node.Left != null)
                {
                    InOrder(node.Left);
                }
                result.Add(node.Key);
                if (node.Right != null)
                {
                    InOrder(node.Right);
                }
            }
        }

        public List<T> PostOrder()
        {
            List<T> result = new List<T>();
            PostOrder(Root);

            return result;

            void PostOrder(Node<T> node)
            {
                if(node.Left != null)
                {
                    PostOrder(node.Left);
                }
                if(node.Right != null)
                {
                    PostOrder(node.Right);
                }
                result.Add(node.Key);
            }
        }

        public List<T> PreOrder()
        {
            List<T> result = new List<T>();
            PreOrder(Root);

            return result;

            void PreOrder(Node<T> node)
            {
                result.Add(node.Key);
                if(node.Left != null)
                {
                    PreOrder(node.Left);
                }
                if(node.Right != null)
                {
                    PreOrder(node.Right);
                }
            }
        }

        public List<T> BreadthFirst()
        {
            List<T> result = new List<T>();
            Queue<Node<T>> nodes = new Queue<Node<T>>();
            BreadthFirst(Root);

            return result;

            void BreadthFirst(Node<T> node)
            {
                result.Add(node.Key);
                if (node.Left != null)
                {
                    nodes.Enqueue(node.Left);
                }
                if(node.Right != null)
                {
                    nodes.Enqueue(node.Right);
                }
                if (nodes.Count > 0)
                {
                    BreadthFirst(nodes.Dequeue());
                }
            }
        }
    }
}