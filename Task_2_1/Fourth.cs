using System;

namespace Task_2_1
{
    class Fourth
    {
         IRandom Random { get; set; }

        public Fourth(IRandom random)
        {
            Random = random;
        }
        public double Execute(int runs, int N, Case complexity)
        {
            double totalOperations = 0.0;
            bool unlucky = false;

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

                int i = N;
                operations++;

                operations++; // unlucky check
                if (unlucky)
                {
                    while (i > 0)
                    {
                        operations++; // i > 0

                        count += i;
                        operations++;

                        i /= 2;
                        operations++;
                    }
                    operations++; // i <= 0
                }

                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}