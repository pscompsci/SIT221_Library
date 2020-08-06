using System;

namespace Task_2_1
{
    class First
    {
        IRandom Random { get; set; }

        public First(IRandom random)
        {
            Random = random;
        }

        public double Execute(int runs)
        {
            double totalOperations = 0.0;

            for(int i = 0; i < runs; i++)
            {
                int operations = 0;

                double a = 0;
                operations++;

                a += Random.rand();
                operations++;

                operations++;
                if(a < 0.5) 
                {
                    a += Random.rand();
                    operations++;
                }

                operations++;
                if(a < 1.0) 
                {
                    a += Random.rand();
                    operations++;
                }

                operations++;
                if(a < 1.5) 
                {
                    a += Random.rand();
                    operations++;
                }

                operations++;
                if(a < 2.0) 
                {
                    a += Random.rand();
                    operations++;
                }

                operations++;
                if(a < 2.5) 
                {
                    a += Random.rand();
                    operations++;
                }

                operations++;
                if(a < 3.0) 
                {
                    a += Random.rand();
                    operations++;
                }

                totalOperations += operations;
            }
            return totalOperations / runs;
        }
    }
}