using System;

namespace Task_2_1
{
    class Third
    {

        IRandom Random { get; set; }

        public Third(IRandom random)
        {
            Random = random;
        }
        
        public double Execute(int runs, int N, Case complexity)
        {
            double totalOperations = 0.0;
            bool unlucky;

            for(int r = 0; r < runs; r++)
            {
                int operations = 0;

                switch (complexity)
                {
                    case Case.Best:
                        unlucky = false; 
                        break;
                    case Case.Worst:
                        unlucky = true;
                        break;
                    default:
                        unlucky = Random.rand() < 0.5;
                        break;
                }

                int count = 0;
                operations++;

                operations ++; // initialisation
                for(int i = 0; i < N; i++)
                {
                    operations++; // i < N

                    operations++; // unlucky check
                    if (unlucky)
                    {
                        operations ++; // initialisation
                        for(int j = N; j > i; j--)
                        {
                            operations++; // j > i

                            count = count + i + j;
                            operations++;

                            operations++; // j--
                        }
                        operations++; // j == 0 (ie. inner loops ends)
                    }
                    operations++; // i++
                }
                operations++; // i == N (ie. outer loop ends)
                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}