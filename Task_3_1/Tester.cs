using System;
using System.Collections.Generic;

namespace Task_3_1
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ Default Sort ----------------------------------
            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying Default Sort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying Default Sort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying Default Sort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = null;
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ BubbleSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying BubbleSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying BubbleSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying BubbleSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new BubbleSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ SelectionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying SelectionSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest H: Sort integer numbers applying SelectionSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest I: Sort integer numbers applying SelectionSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new SelectionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ InsertionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest J: Sort integer numbers applying InsertionSort with AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest K: Sort integer numbers applying InsertionSort with DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "K";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest L: Sort integer numbers applying InsertionSort with EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                vector.Sorter = new InsertionSort();
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Intital data: " + vector.ToString());
                vector.Sort(new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector)) throw new Exception("Sorted vector has an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "L";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
