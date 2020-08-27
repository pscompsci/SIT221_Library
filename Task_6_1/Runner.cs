using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task_6_1
{
    public class Runner
    {
        const int RUNS = 100;
        const int N = 100000;

        private static Random Rnd { get; set; } = new Random();
        private static Stopwatch Watch { get; set; } = new Stopwatch();

        static int[] Numbers(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = Rnd.Next(n);
            }
            return result;
        }

        static int Max(int[] numbers)
        {
            int max = numbers[0];
            foreach(int n in numbers)
            {
                if (n > max) max = n;
            }
            return max;
        }

        static int Min(int[] numbers)
        {
            int min = numbers[0];
            foreach(int n in numbers)
            {
                if (n < min) min = n;
            }
            return min;
        }

        public static void Main(string[] args)
        {

            // Runner 1: SumExists

            // for(int i = 1; i < N; i += 2000)
            // {
            //     int[] numbers = Numbers(i);
            //     int max = Max(numbers);
            //     int min = Min(numbers);

            //     long totalTime = 0L;

            //     for (int j = 0; j < RUNS; j++)
            //     {
            //         Watch.Start();
            //         SumExists.Check(numbers, (max + min));
            //         Watch.Stop();
            //         totalTime += Watch.ElapsedTicks;
            //     }

            //     Console.WriteLine("{0,3}: {1}", i, totalTime/RUNS);
            // }

            // Runner : IntStack Push
            // IntStack stack = new IntStack(N);
            // for(int i = 0; i < N; i += 2000)
            // {
            //     Stopwatch w = new Stopwatch();
            //     w.Start();
            //     stack.Push(i);
            //     w.Stop();
            //     Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            // }

            // Runner: Stack Pop
            // IntStack stack = new IntStack(N+1);
            // for(int i = 0; i < N; i += 2000)
            // {
            //     stack.Push(i);
            //     Stopwatch w = new Stopwatch();
            //     w.Start();
            //     stack.Pop();
            //     w.Stop();
            //     Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            // }

            // Runner: Stack Min
            IntStack stack = new IntStack(N+1);
            for(int i = 0; i < N; i += 2000)
            {
                stack.Push(i);
                Stopwatch w = new Stopwatch();
                w.Start();
                stack.Min();
                w.Stop();
                Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            }

            // Runner: Stack Push
            // Stack<int> stk = new Stack<int>(N+1);
            // for(int i = 0; i < N; i += 2000)
            // {
            //     Stopwatch w = new Stopwatch();
            //     w.Start();
            //     stk.Push(i);
            //     w.Stop();
            //     Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            // }

            // Runner: Stack Pop
            // stk = new Stack<int>(N+1);
            // for(int i = 0; i < N; i += 2000)
            // {
            //     stk.Push(i);
            //     Stopwatch w = new Stopwatch();
            //     w.Start();
            //     stk.Pop();
            //     w.Stop();
            //     Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            // }

            // Runner: Stack Min
            // stk = new Stack<int>(N+1);
            // for(int i = 0; i < N; i += 2000)
            // {
            //     stk.Push(i);
            //     Stopwatch w = new Stopwatch();
            //     w.Start();
            //     stk.Min();
            //     w.Stop();
            //     Console.WriteLine("{0,3}: {1}", i, w.ElapsedTicks);
            // }
        }
    }
}