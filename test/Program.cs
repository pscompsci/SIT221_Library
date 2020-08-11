using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            long max = 10000000;

            for (int N = 1; N < max; N++)
            {
                bool unlucky = true;
                int operations = 0;

                long count = 0;
                operations++;

                long i = N;
                operations++;

                operations++;
                if (unlucky)
                {
                    while(i > 0)
                    {
                        operations++;
                        
                        count += i;
                        operations++;

                        i /= 2;
                        operations++;
                    }
                    operations++;
                }

                Console.WriteLine("{0}: {1}, {2}", N, operations, (int)(3 * Math.Log2(N) + 4));
            }
        }
    }
}
