using System;
using System.Collections.Generic;

#pragma warning disable 219

namespace Task_8_1
{
    class Tester
    {

        private class IntAscendingComparer : IComparer<int>
        {
            public int Compare(int A, int B)
            {
                return Math.Sign(A - B);
            }
        }

        private class IntDescendingComparer : IComparer<int>
        {
            public int Compare(int A, int B)
            {
                return -1 * Math.Sign(A - B);
            }
        }

        static void Main(string[] args)
        {
            // ------------------------ test instance (begin)
            string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky", "Kevin", "David" };
            int[] IDs = new int[] { 1, 6, 5, 7, 8, 3, 10, 4, 2, 9, 14, 12, 11, 13 };
            int[] certificateAdd = new int[] { 1, 2, 3, 4, 5, 3, 7, 2, 2, 10, 11, 12, 13, 14 };
            int[] certificateDelete = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int[] certificateMinHeapBuild = new int[] { 1, 8, 6, 9, 5, 3, 7, 4, 2, 10, 11, 12, 13, 14 };
            int[] certificateMaxHeapBuild = new int[] { 11, 10, 14, 4, 5, 12, 7, 8, 9, 2, 1, 6, 13, 3 };
            // ------------------------ test instance (end)


            Heap<int, string> minHeap = null;
            Heap<int, string> maxHeap = null;
            IHeapifyable<int, string>[] nodes = null;
            string result = "";

            // test 1
            try
            {
                Console.WriteLine("\n\nTest A: Create a min-heap by calling 'minHeap = new Heap<int, string>(new IntAscendingComparer());'");
                minHeap = new Heap<int, string>(new IntAscendingComparer());
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                result = result + "A";
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine("\n\nTest B: Run a sequence of operations: ");

                for (int i = 0; i < Math.Min(names.Length, IDs.Length); i++)
                {
                    Console.WriteLine("\nInsert a node with name {0} (data) and ID {1} (key).", names[i], IDs[i]);
                    IHeapifyable<int, string> node = minHeap.Insert(IDs[i], names[i]);
                    if (!(node.Position == certificateAdd[i] && minHeap.Count == i + 1)) throw new Exception("The min-heap has a wrong structure");
                    Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                }
                result = result + "B";

            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\n\nTest C: Run a sequence of operations: ");
                for (int i = 0; i < certificateDelete.Length; i++)
                {
                    Console.WriteLine("\nDelete the minimum element from the min-heap.");
                    IHeapifyable<int, string> node = minHeap.Delete();
                    if (node.Key != certificateDelete[i]) throw new Exception("The extracted node has a wrong key");
                    if (minHeap.Count != certificateDelete.Length - i - 1) throw new Exception("The heap has a wrong number of elements");
                    if (certificateDelete.Length - i - 1 > 0)
                    {
                        if ((minHeap.Min().Key != certificateDelete[i + 1]) && (minHeap.Min().Position != 1)) throw new Exception("The min-heap has a wrong structure");
                    }
                    Console.WriteLine(" :: SUCCESS: min-heap's state {0}", minHeap.ToString());
                }
                result = result + "C";
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine("\n\nTest D: Delete the minimum element from the min-heap.");
                IHeapifyable<int, string> node = minHeap.Delete();
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: InvalidOperationException is thrown because the min-heap is empty");
                result = result + "D";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }

            // // test 5
            try
            {
                Console.WriteLine("\n\nTest E: Run a sequence of operations: ");
                Console.WriteLine("\nInsert a node with name {0} (data) and ID {1} (key).", names[0], IDs[0]);
                IHeapifyable<int, string> node = minHeap.Insert(IDs[0], names[0]);
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());

                Console.WriteLine("\nBuild the min-heap for the pair of key-value arrays with \n[{0}] as keys and \n[{1}] as data elements", String.Join(", ", IDs), String.Join(", ", names));
                nodes = minHeap.BuildHeap(IDs, names);
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: InvalidOperationException is thrown because the min-heap is not empty");
                result = result + "E";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString());
                Console.WriteLine("Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification.");
                result = result + "-";
            }

            // // test 6
            try
            {
                Console.WriteLine("\n\nTest F: Run a sequence of operations: ");

                Console.WriteLine("\nClear the min-heap.");
                minHeap.Clear();
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                Console.WriteLine("\nBuild the min-heap for the pair of key-value arrays with \n[{0}] as keys and \n[{1}] as data elements", String.Join(", ", IDs), String.Join(", ", names));
                nodes = minHeap.BuildHeap(IDs, names);
                if (minHeap.Count != certificateMinHeapBuild.Length) throw new Exception("The resulting min-heap has a wrong number of elements.");
                if (nodes.Length != certificateMinHeapBuild.Length) throw new Exception("The size of the resulting array returned by BuildHeap() is incorrect.");
                Console.WriteLine();
                for (int i = 0; i < nodes.Length; i++)
                {
                    // if (nodes[i] is null) continue;
                    // Console.WriteLine("{0,-20}{1,2}", nodes[i].ToString(), certificateMinHeapBuild[i]);
                    if (!(nodes[i].Position == certificateMinHeapBuild[i])) throw new Exception("The min-heap has a wrong structure");
                }
                result = result + "F";
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                // Console.WriteLine("min-heap's state " + minHeap.ToString());
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // // test 7
            try
            {
                Console.WriteLine("\n\nTest G: Run a sequence of operations: ");

                IHeapifyable<int, string> node = nodes[nodes.Length - 1];

                Console.WriteLine("\nDelete the minimum element from the min-heap.");
                minHeap.Delete();
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                Console.WriteLine("\nDelete the minimum element from the min-heap.");
                minHeap.Delete();
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());

                Console.WriteLine("\nRun DecreaseKey(node,0) for node {0} by setting the new value of its key to 0", node);
                minHeap.DecreaseKey(node, 0);

                if (minHeap.Count != certificateMinHeapBuild.Length - 2) throw new Exception("The resulting min-heap has a wrong number of elements");
                if (!((node.Position == 1) && (minHeap.Min().Key == node.Key))) throw new Exception("The min-heap has a wrong structure");
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                result = result + "G";
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // // test 8
            try
            {
                Console.WriteLine("\n\nTest H: Run a sequence of operations: ");
                Console.WriteLine("\nCreate a max-heap by calling 'maxHeap = new Heap<int, string>(new IntDescendingComparer());'");
                maxHeap = new Heap<int, string>(new IntDescendingComparer());
                Console.WriteLine(" :: SUCCESS: max-heap's state " + maxHeap.ToString());
                Console.WriteLine("\nBuild the max-heap for the pair of key-value arrays with \n[{0}] as keys and \n[{1}] as data elements", String.Join(", ", IDs), String.Join(", ", names));
                nodes = maxHeap.BuildHeap(IDs, names);
                if (maxHeap.Count != certificateMaxHeapBuild.Length) throw new Exception("The resulting  max-heap has a wrong number of elements");
                if (nodes.Length != certificateMaxHeapBuild.Length) throw new Exception("The size of the resulting array returned by BuildHeap() is incorrect.");
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (!(nodes[i].Position == certificateMaxHeapBuild[i])) throw new Exception("The  max-heap has a wrong structure");
                }
                result = result + "H";
                Console.WriteLine(" :: SUCCESS: max-heap's state " + maxHeap.ToString());
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL:  max-heap's state " + maxHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // // test 9
            try
            {
                Console.WriteLine("\n\nTest I: Run a sequence of operations: ");

                IHeapifyable<int, string> node = nodes[4];

                Console.WriteLine("\nDelete the Richard element from the min-heap.");
                IHeapifyable<int, string> r = minHeap.DeleteElement(node);

                if (!r.Data.Equals(node.Data)) throw new Exception("The deleted node is the incorrect node.");
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());

                if (minHeap.Count != certificateMinHeapBuild.Length - 3) throw new Exception("The resulting min-heap has a wrong number of elements");
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());
                result = result + "I";
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // // test 10
            try
            {
                Console.WriteLine("\n\nTest J: Run a sequence of operations: ");

                Console.WriteLine("min-heap's state " + minHeap.ToString());

                IHeapifyable<int, string> node = minHeap.KthMinElement(4);

                if (!node.Data.Equals("John")) throw new Exception("The 4th deleted node" + node.ToString() + " is the incorrect node.");
                Console.WriteLine(" :: SUCCESS: 4th Node is " + node.ToString());

                if (minHeap.Count != certificateMinHeapBuild.Length - 3) throw new Exception("The resulting min-heap has a wrong number of elements");
                Console.WriteLine(" :: SUCCESS: min-heap's state " + minHeap.ToString());

                result = result + "J";
            }
            catch (Exception exception)
            {
                try { Console.WriteLine(" :: FAIL: min-heap's state " + minHeap.ToString()); } catch { };
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            // Console.ReadKey();
        }
    }

}