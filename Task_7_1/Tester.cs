using System;
using System.Collections.Generic;

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
            Display(breadth);

            List<int> preorder = tree.PreOrder();
            Display(preorder);

            List<int> postorder = tree.PostOrder();
            Display(postorder);

            List<int> inorder = tree.InOrder();
            Display(inorder);
        }
    }
}