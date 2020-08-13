using System;

namespace Task_2_1
{
    public enum Case
    {
        Best,
        Average,
        Worst
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            int runs = 1000000;
            int N = 10;

            BestGenerator bestRand = new BestGenerator();
            AverageGenerator averageRand = new AverageGenerator();
            WorstGenerator worstRand = new WorstGenerator();

            // --------------- Question 1i. --------------- //

            First firstBest = new First(bestRand);
            First firstAverage = new First(averageRand);
            First firstWorst = new First(worstRand);

            double best = firstBest.Execute(runs);
            double average = firstAverage.Execute(runs);
            double worst = firstWorst.Execute(runs);

            Console.WriteLine("Algorithm 1i. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 11); // 11
            Console.WriteLine("Average: {0}", 13); // 13
            Console.WriteLine("Worst: {0}\n", 14); // 14

            // --------------- Question 1ii. --------------- //

            Second secondBest = new Second(bestRand);
            Second secondAverage = new Second(averageRand);
            Second secondWorst = new Second(worstRand);

            best = secondBest.Execute(runs, N);
            average = secondAverage.Execute(runs, N);
            worst = secondWorst.Execute(runs, N);

            Console.WriteLine("Algorithm 1ii. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 4 * N + 3); // 4N + 3
            Console.WriteLine("Average: {0}", 4.5 * N + 3); // 4.5N + 3
            Console.WriteLine("Worst: {0}\n", 5 * N + 3); // 5N + 3

            // --------------- Question 1iii. --------------- //

            Third thirdBest = new Third(bestRand);
            Third thirdAverage = new Third(averageRand);
            Third thirdWorst = new Third(worstRand);

            best = thirdBest.Execute(runs, N, Case.Best); // 
            average = thirdAverage.Execute(runs, N, Case.Average);
            worst = thirdWorst.Execute(runs, N, Case.Worst);

            Console.WriteLine("Algorithm 1iii. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 3 * N + 3); // 3N + 3
            Console.WriteLine("Average: {0}", 0.75 * N * N + 4.5 * N + 3);  // 0.75 N^2 + 4.5N + 3
            Console.WriteLine("Worst: {0}\n", 1.5 * N * N + 6.5 * N + 3); // 1.5 N^2 + 6.5N + 3

            // --------------- Question 1iV. --------------- //

            Fourth fourthBest = new Fourth(bestRand);
            Fourth fourthAverage = new Fourth(averageRand);
            Fourth fourthWorst = new Fourth(worstRand);

            best = fourthBest.Execute(runs, N, Case.Best); 
            average = fourthAverage.Execute(runs, N, Case.Average);
            worst = fourthWorst.Execute(runs, N, Case.Worst);

            Console.WriteLine("Algorithm 1iv. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 3); // 3
            Console.WriteLine("Average: {0}", (int)(1.5 * Math.Log2(N)) + 5); // 1.5log(N) + 5
            Console.WriteLine("Worst: {0}\n", (int)(3 * Math.Log2(N)) + 7); // 3log(N) + 7

            // --------------- Question 1v. --------------- //

            Fifth fifthBest = new Fifth(bestRand);
            Fifth fifthAverage = new Fifth(averageRand);
            Fifth fifthWorst = new Fifth(worstRand);

            best = fifthBest.Execute(runs, N, Case.Best);
            average = fifthAverage.Execute(runs, N, Case.Average);
            worst = fifthWorst.Execute(runs, N, Case.Worst);

            Console.WriteLine("Algorithm 1v. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 4 * N + 6); // 4N + 6
            Console.WriteLine("Average: {0}", 6 * N + 6); // 6N + 6
            Console.WriteLine("Worst: {0}\n", 8 * N + 6); // 8N + 6

            // --------------- Question 1vi. --------------- //

            Sixth sixthBest = new Sixth(bestRand);
            Sixth sixthAverage = new Sixth(averageRand);
            Sixth sixthWorst = new Sixth(worstRand);

            best = sixthBest.Execute(runs, N, Case.Best); // Best is N <= 0
            average = sixthAverage.Execute(runs, N, Case.Average);
            worst = sixthWorst.Execute(runs, N, Case.Worst);

            Console.WriteLine("Algorithm 1vi. Best: {0}, Average: {1}, Worst: {2}", 
                best, average, worst);
            Console.WriteLine("Best: {0}", 1.5 * N * N + 2.5 * N - 2);  // 1.5N^2 + 2.5N - 2 
            Console.WriteLine("Average: {0}", 1.75 * N * N + 2.25 * N - 2);  // 1.75N^2 + 2.25N - 2 
            Console.WriteLine("Worst: {0}\n", 2 * N * N + 2 * N - 2); // 2N^2 + 2N - 2
        }
    }

    public class AverageGenerator : IRandom
    {
        Random rnd = new Random();
        public double rand()
        {
            return rnd.NextDouble();
        }
    }

    public class WorstGenerator : IRandom
    {
        public double rand()
        {
            return 0.000001;
        }
    }

    public class BestGenerator : IRandom
    {
        public double rand()
        {
            return 0.999999;
        }
    }
}
