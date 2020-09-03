using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task_7_1
{
    class Tester
    {

        static void Display(List<int> list)
        {
            Console.Write("[");
            foreach(int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("]");
        }

        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            tree.Insert(20);
            tree.Insert(9);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(25);
            tree.Insert(30);
            tree.Insert(15);
            tree.Insert(6);
            tree.Insert(17);

            List<int> breadth = tree.BreadthFirst();
            Console.Write("{0,-20}", "Breadth First:");
            Display(breadth);

            List<int> preorder = tree.PreOrder();
            Console.Write("{0,-20}", "Pre-Order First:");
            Display(preorder);

            List<int> postorder = tree.PostOrder();
            Console.Write("{0,-20}", "Post-Order First:");
            Display(postorder);

            List<int> inorder = tree.InOrder();
            Console.Write("{0,-20}", "In-Order First:");
            Display(inorder);

            Console.WriteLine("\n\n");

            tree.Remove(20);
            tree.Remove(15);
            tree.Remove(8);
            tree.Remove(25);
            tree.Remove(30);
            tree.Remove(9);
            tree.Remove(17);
            tree.Remove(5);
            tree.Remove(6);
            tree.Remove(3);
            tree.Remove(7);

            Console.ReadKey();
        }
    }
}