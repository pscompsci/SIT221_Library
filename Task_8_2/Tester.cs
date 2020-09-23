using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CoinRepresentation
{
    class Tester
    {
        static void Main(string[] args)
        {
            List<int> correct = new List<int>(TestGenerator.Count());
            List<int> incorrect = new List<int>(TestGenerator.Count());
            int scores = 0;

            for (int i = 0; i < TestGenerator.Count(); i++)
            {
                try
                {
                    long sum = 0;
                    long result = TestGenerator.Generate(i, out sum);
                    Console.WriteLine("\nAttempting test instance {0} with {1} as the argument and {2} as the expected answer", i, sum, result);
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    long answer = CoinRepresentation.Solve(sum);

                    if (result == answer)
                    {
                        scores++;
                        correct.Add(i);
                        Console.WriteLine(" :: SUCCESS (Time elapsed {0})", watch.Elapsed);
                    }
                    else
                    {
                        incorrect.Add(i);
                        Console.WriteLine(" :: FAILED with an incorrect answer of {0}",answer);
                    }
                }
                catch (Exception e)
                {
                    incorrect.Add(i);
                    Console.WriteLine(" :: FAILED with the runtime error {1}", i, e.ToString());
                }
            }

            Console.WriteLine("\nSummary: {0} tests out of {1} passed", scores, TestGenerator.Count());
            Console.WriteLine("Tests passed ({1} to {2}): {0}", correct.Count == 0 ? "none" : string.Join(", ", correct), 0, TestGenerator.Count());
            Console.WriteLine("Tests failed ({1} to {2}): {0}", incorrect.Count == 0 ? "none" : string.Join(", ", incorrect), 0, TestGenerator.Count());

            Console.ReadKey();
        }

    }
}
