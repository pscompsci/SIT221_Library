using System;

namespace Task_6_1
{
    class SumExists
    {
        public static bool Check(int[] numbers, int sum)
        {
            if (numbers is null) throw new ArgumentNullException();    // 1 operation
            Array.Sort(numbers);                                       // O(n log n)
            int i = 0;                                                 // 1 operation
            int j = numbers.Length - 1;                                // 1 operation
            while (i < j)                                              // n in worst case                                       
            {
                if (numbers[i] + numbers[j] == sum) return true;       // n - 1 in worst case
                else if (numbers[i] + numbers[j] < sum) i++;           // 2(n - 1) in worst case
                else j--;                                              // n - 1 in worst case
            }
            return false;                                              // 1 operation
        }
    }
}