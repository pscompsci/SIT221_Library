using System;
using System.Diagnostics;

namespace Task_6_1
{
    class Tester
    {
        static void Main(string[] args)
        {
            int[] numbers = {10, 5, 6, 8, 2, 19, 9, 11, 15, 1, -8, 50};

            Console.WriteLine(SumExists.Check(numbers, 15));  // true
            Console.WriteLine(SumExists.Check(numbers, 26));  // true
            Console.WriteLine(SumExists.Check(numbers, -2));  // true
            Console.WriteLine(SumExists.Check(numbers, 50));  // false
            Console.WriteLine(SumExists.Check(numbers, 0));   // true
            Console.WriteLine(SumExists.Check(numbers, 42));  // true
            Console.WriteLine(SumExists.Check(numbers, 69));  // true
            Console.WriteLine(SumExists.Check(numbers, -100));// false
            Console.WriteLine(SumExists.Check(numbers, 1));   // true
            Console.WriteLine(SumExists.Check(numbers, 100)); // false
        }
    }
}
