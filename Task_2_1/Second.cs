using System;

namespace Task_2_1
{
    class Second
    {
        IRandom Random { get; set; }

        public Second(IRandom random)
        {
            Random = random;
        }

        public double Execute(int runs, int N)
        {
            double totalOperations = 0.0;

            for(int r = 0; r < runs; r++)
            {
                int operations = 0;

                int count = 0;
                operations++;

                operations += 2;   // for initialisation and also for when i >= N
                for(int i = 0; i < N; i++)
                {
                    operations++; // i < N

                    double num = Random.rand();
                    operations++;

                    operations++;
                    if (num < 0.5)
                    {
                        count++;
                        operations++;
                    }

                    operations++; // i++
                }

                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}