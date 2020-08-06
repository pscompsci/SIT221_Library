using System;

namespace Task_2_1
{
    class Fifth
    {
        IRandom Random { get; set; }

        public Fifth(IRandom random)
        {
            Random = random;
        }

        public double Execute(int runs, int N, Case complexity)
        {
            double totalOperations = 0.0;

            for(int r = 0; r < runs; r++)
            {
                int operations = 0;

                int count = 0;
                operations++;

                operations++; // initialization
                for(int i = 0; i < N; i++)
                {
                    operations++; // i < N

                    double num = Random.rand();
                    operations++;

                    operations++;
                    if (num < 0.5)
                    {
                        count += 1;
                        operations++;
                    }

                    operations++; // i++
                }
                operations++; // i == N

                int n = count;
                operations++;

                operations++; // initialization
                for(int j = 0; j < n; j++)
                {
                    operations++; // j < num

                    count = count + j;
                    operations++;

                    operations++; // j++
                }
                operations++; // j == num

                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}