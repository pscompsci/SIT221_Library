using System;

namespace Task_2_1
{
    class Sixth
    {
        IRandom Random { get; set; }
        public double a { get; set; }
        public double b { get; set; }

        public Sixth(IRandom random)
        {
            Random = random;
        }

        public double Execute(int runs, int N, Case complexity)
        {
            double totalOperations = 0.0;

            for(int r = 0; r < runs; r++)
            {
                int operations = 0;

                operations++; // initialization of outer loop
                for (int i = 0; i < N - 1; i++)
                {
                    operations++; // i < N - 1

                    operations++; // initialization of inner loop
                    for (int j = 0; j < N - i -1; j++)
                    {
                        operations++; // j < N - i - 1

                        switch (complexity)
                        {
                        case Case.Best:
                            a = 1;
                            b = 2;
                            break;
                        case Case.Average:
                            a = Random.rand();
                            b = Random.rand();
                            break;
                        default:
                            a = 2;
                            b = 1;
                            break;
                        }

                        operations++;
                        if (a > b)
                        {
                            operations++;
                        }

                        operations++; // j++
                    }
                    operations++; // j == N - i - 1, end of inner loop 
                    operations++; // i++
                }
                operations++; // i == N - 1, end of outer loop

                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}