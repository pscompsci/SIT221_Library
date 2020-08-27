using System;

namespace Task_5_1
{
    class Tester
    {

        private static bool CheckIntSequence(int[] certificate, DoublyLinkedList<int> list)
        {
            if (certificate.Length != list.Count) return false;
            INode<int> node = list.First;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != node.Value) return false;
                node = list.After(node);
            }
            return true;
        }

        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = null;
            string result = "";

            // test 1
            try
            {
                Console.WriteLine("\nTest A: Create a new list by calling 'DoublyLinkedList<int> vector = new DoublyLinkedList<int>( );'");
                list = new DoublyLinkedList<int>();
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine("\nTest B: Add a sequence of numbers 2, 6, 8, 5, 1, 8, 5, 3, 5 with list.AddLast( )");
                list.AddLast(2); list.AddLast(6); list.AddLast(8); list.AddLast(5); list.AddLast(1); list.AddLast(8); list.AddLast(5); list.AddLast(3); list.AddLast(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 1, 8, 5, 3, 5 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\nTest C: Remove sequentially 4 last numbers with list.RemoveLast( )");
                list.RemoveLast();
                list.RemoveLast();
                list.RemoveLast();
                list.RemoveLast();
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine("\nTest D: Add a sequence of numbers 10, 20, 30, 40, 50 with list.AddFirst( )");
                list.AddFirst(10); list.AddFirst(20); list.AddFirst(30); list.AddFirst(40); list.AddFirst(50);
                if (!CheckIntSequence(new int[] { 50, 40, 30, 20, 10, 2, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 5
            try
            {
                Console.WriteLine("\nTest E: Remove sequentially 3 last numbers with list.RemoveFirst( )");
                list.RemoveFirst();
                list.RemoveFirst();
                list.RemoveFirst();
                if (!CheckIntSequence(new int[] { 20, 10, 2, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            INode<int> node1 = null;
            // test 6
            try
            {
                Console.WriteLine("\nTest F: Run a sequence of operations: ");

                Console.WriteLine("list.Find(40);");
                if (list.Find(40) == null) Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else throw new Exception("40 must no longer be in the list");

                Console.WriteLine("list.Find(0);");
                if (list.Find(0) == null) Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else throw new Exception("0 must not be in the list");

                Console.WriteLine("list.Find(2);");
                node1 = list.Find(2);
                if (node1 != null && node1.Value == 2) Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else throw new Exception("2 must be in the list, but 'list.Find(2)' does not return the correct result");

                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 7
            try
            {
                Console.WriteLine("\nTest G: Run a sequence of operations: ");

                Console.WriteLine("Add {1} before the node with {0} with list.AddBefore({0},{1})", node1.Value, 100);
                list.AddBefore(node1, 100);
                if (!CheckIntSequence(new int[] { 20, 10, 100, 2, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Add {1} after the node with {0} with list.AddAfter({0},{1})", node1.Value, 200);
                list.AddAfter(node1, 200);
                if (!CheckIntSequence(new int[] { 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Add {0} before node list.First with list.AddBefore(list.First,{0})", 300);
                list.AddBefore(list.First, 300);
                if (!CheckIntSequence(new int[] { 300, 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Add {0} after node list.First with list.AddAfter(list.First,{0})", 400);
                list.AddAfter(list.First, 400);
                if (!CheckIntSequence(new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Add {0} before node list.First with list.AddBefore(list.Last,{0})", 500);
                list.AddBefore(list.Last, 500);
                if (!CheckIntSequence(new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Add {0} after node list.First with list.AddAfter(list.Last,{0})", 600);
                list.AddAfter(list.Last, 600);
                if (!CheckIntSequence(new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1, 600 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 8
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");

                Console.WriteLine("Remove the node list.First with list.Remove(list.First)");
                list.Remove(list.First);
                if (!CheckIntSequence(new int[] { 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1, 600 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Remove the node list.Last with list.Remove(list.Last)");
                list.Remove(list.Last);
                if (!CheckIntSequence(new int[] { 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Remove the node list.Before, which is before the node containing element {0}, with list.Remove(list.Before(...))", node1.Value);
                list.Remove(list.Before(node1));
                if (!CheckIntSequence(new int[] { 400, 20, 10, 2, 200, 6, 8, 5, 500, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Remove the node containing element {0} with list.Remove(...)", node1.Value);
                list.Remove(node1);
                if (!CheckIntSequence(new int[] { 400, 20, 10, 200, 6, 8, 5, 500, 1 }, list)) throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 9
            try
            {
                Console.WriteLine("\nTest I: Remove the node containing element {0}, which has been recently deleted, with list.Remove(...)", node1.Value);
                list.Remove(node1);
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "I";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }

            // test 10
            try
            {
                Console.WriteLine("\nTest J: Clear the content of the vector via calling vector.Clear();");
                list.Clear();
                if (!CheckIntSequence(new int[] { }, list)) throw new Exception("The list stores incorrect data. It must be empty.");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 11
            try
            {
                Console.WriteLine("\nTest K: Remove last element for the empty list with list.RemoveLast()");
                list.RemoveLast();
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "K";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }


            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);

            // Test 12
            // DoublyLinkedList<int> list1 = new DoublyLinkedList<int>();
            // DoublyLinkedList<int> list2 = new DoublyLinkedList<int>();

            // list1.AddLast(1); list1.AddLast(2); list1.AddLast(3);
            // list2.AddLast(4); list2.AddLast(5); list2.AddLast(6);

            // Console.WriteLine("\nBefore remove on list1:");
            // Console.WriteLine(list1.ToString());
            // Console.WriteLine(list2.ToString());

            // INode<int> node = list2.First;
            // try
            // {
            //     list1.Remove(node);
            // }
            // catch (Exception)
            // {
            //     Console.WriteLine("Remove operation is invalid");
            // }

            // Console.WriteLine("\nAfter remove on list1");
            // Console.WriteLine(list1.ToString());
            // Console.WriteLine(list2.ToString());

            // // Test 13
            // DoublyLinkedList<int> list3 = new DoublyLinkedList<int>();
 
            // list3.AddLast(1); list3.AddLast(2); list3.AddLast(3);

            // Console.WriteLine("\nBefore Clear on list3:");
            // Console.WriteLine(list3.ToString());
            
            // INode<int> node2 = list3.First;
            
            // list3.Clear();
            
            // list3.AddLast(4); list3.AddLast(5); list3.AddLast(6);
            // try
            // {
            //     list3.Remove(node2);            
            // }
            // catch (Exception)
            // {
            //     Console.WriteLine("Remove not allowed");
            // }

            // Console.WriteLine("\nAfter Remove on previously Cleared list3:");
            // Console.WriteLine(list3.ToString());
            

            // Console.ReadKey();

        }
    }
}
