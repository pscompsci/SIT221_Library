using System;
using System.Collections.Generic;

namespace Task_4_1
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

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int CompareTo(Student s)
        {
            return this.Id - s.Id;
        }

        public override string ToString()
        {
            return Id + "[" + Name + "]";
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
                if (vector[i]%2 > vector[i + 1]%2) return false;
            return true;
        }

        private static bool CheckSequence<T>(T[] certificate, Vector<T> vector) where T : IComparable<T>
        {
            if (vector == null)
            {
                throw new ArgumentNullException(nameof(vector));
            }
            if (certificate.Length != vector.Count) return false;
            int counter = 0;
            foreach (T value in vector)
            {
                if (!value.Equals(certificate[counter])) return false;
                counter++;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100+k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ BinarySearch ----------------------------------
            int[] temp = null; int check;

            // test A
            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest A: Apply BinarySearch searching for number 333 to array of integer numbers sorted in AscendingIntComparer: ");
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test B
            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                Console.WriteLine("\nTest B: Apply BinarySearch searching for number " + (temp[0] - 1) + " to array of integer numbers sorted in AscendingIntComparer: ");
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                Console.WriteLine(data[0] - 1);
                if (vector.BinarySearch(data[0] - 1, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test C
            try
            {
                vector.Sorter = null;

                Console.WriteLine("\nTest C: Apply BinarySearch searching for number " + (temp[problem_size - 1] + 1) + " to array of integer numbers sorted in AscendingIntComparer: ");
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new AscendingIntComparer());
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new AscendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[problem_size - 1] + 1, new AscendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test D
            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest D: Apply BinarySearch searching for number 333 to array of integer numbers sorted in DescendingIntComparer: ");
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, 333, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(333, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test E
            try
            {
                vector.Sorter = null;
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                Console.WriteLine("\nTest E: Apply BinarySearch searching for number " + (temp[0] - 1) + " to array of integer numbers sorted in DescendingIntComparer: ");
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[0] - 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[0] - 1, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test F
            try
            {
                vector.Sorter = null;

                Console.WriteLine("\nTest F: Apply BinarySearch searching for number " + (temp[problem_size - 1] + 1) + " to array of integer numbers sorted in DescendingIntComparer: ");
                temp = new int[problem_size];
                data.CopyTo(temp, 0);
                Array.Sort(temp, new DescendingIntComparer());
                 vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                vector.Sort(new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                check = Array.BinarySearch(temp, temp[problem_size - 1] + 1, new DescendingIntComparer());
                check = check < 0 ? -1 : check;
                if (vector.BinarySearch(data[problem_size - 1] + 1, new DescendingIntComparer()) != check) throw new Exception("The resulting index (or return value) is incorrect.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            

            // test G
            try
            {
                Console.WriteLine("\nTest G: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(5);'");
                vector = new Vector<int>(5);
                Console.WriteLine(" :: SUCCESS");
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5);
                vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test H
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");
                Console.WriteLine("Check whether the interface IEnumerable<T> is implemented for the Vector<T> class");
                if (!(vector is IEnumerable<int>)) throw new Exception("Vector<T> does not implement IEnumerable<T>");
                Console.WriteLine(" :: SUCCESS");
                Console.WriteLine("Check whether GetEnumerator() method is implemented");
                vector.GetEnumerator();
                Console.WriteLine(" :: SUCCESS");
                result = result + "H";
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("GetEnumerator() method is not implemented");
                result = result + "-";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test I
            try
            {
                Console.WriteLine("\nTest I: Run a sequence of operations: ");
                Console.WriteLine("Return the Enumerator of the Vector<T> and check whether it implements IEnumerator<T>");
                if (!(vector.GetEnumerator() is IEnumerator<int>)) throw new Exception("The Enumerator of the Vector<T> does not implement IEnumerator<T>");
                Console.WriteLine("Check the initial value of Current of the Enumerator");
                if (vector.GetEnumerator().Current != default(int)) throw new Exception("The initial Current value of the Enumerator (" + vector.GetEnumerator().Current + ") is incorrect. Must be the value of " + default(int));

                Console.WriteLine("Check the value of Current of the Enumerator after MoveNext() operation");
                IEnumerator<int> enumerator = vector.GetEnumerator();
                enumerator.MoveNext();
                if (enumerator.Current != 2) throw new Exception("The value of Current of the Enumerator after MoveNext() operation is incorrect. Must be the value of " + vector[0]);
                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test J
            try
            {
                Console.WriteLine("\nTest J: Check the content of the Vector<int> by traversing it via 'foreach' statement ");
                if (!CheckSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("The 'foreach' statement produces an incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test K
            int num = 14;
            Student[] certificate_student = new Student[num];
            Vector<Student> students = null;
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Random random = new Random(100);
                Console.WriteLine("\nTest K: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                students = new Vector<Student>();
                for (int i = 0; i < num; i++)
                {
                    Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                    certificate_student[i] = student;
                }
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "K";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test L
            try
            {
                Console.WriteLine("\nTest L: Check the content of the Vector<Student> by traversing it via 'foreach' statement ");
                if (!CheckSequence(certificate_student, students)) throw new Exception("The 'foreach' statement produces an incorrect sequence of students");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            // Console.ReadKey();

        }
    }
}
