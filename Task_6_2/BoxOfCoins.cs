using System;
using System.Diagnostics;

namespace Task_6_2
{
    public class BoxOfCoins
    {
        /// <summary>
        /// Prints out the table of values used to store the results
        /// of calculations through different pathways
        /// </summary>
        /// <param name="table">2-dimensional array to print</param>
        /// <param name="n">length or height of the square 2d array</param>
        public static void PrintTable(int[,] table, int n)
        {
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,7} ", table[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Calculates the maximum difference possible for alternate
        /// choice of treasure chests, picked from the left or right
        /// end of a line of chest.
        /// </summary>
        /// <param name="boxes">Array or values of the coins in each chest</param>
        /// <returns>The difference between the totals based on the order
        /// of chooisng chests (+ve difference indicates better result for
        /// person chooisng first)</returns>
        /// <exception cref="System.ArgumentNullException">thrown when the 
        /// array of coin values is null</exception>
        public static int Solve(int[] boxes)
        {
            if (boxes is null) throw new ArgumentNullException();
#if DEBUG
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
#endif
            if (boxes.Length is 1)
            {
                int result_1 = boxes[0]; // Nothing to calculate. Alex gets the coins if only 1 chest
#if DEBUG
                stopwatch.Stop();
                Console.WriteLine("Duration: {0}", stopwatch.Elapsed);
#endif
                return result_1;
            }
            int n = boxes.Length;

            // Create a table to store results, allowing re-use
            // if the same result occurs in a later iteration.
            // This saves on time by caching results to be returned.
            // (ie. implementation of memoization)
            // SPace complexity: O(n^2)
            int[,] table = new int[n, n]; 
            int gap;      // starting difference in positions in the table
            int i, j;     // pointers to cells in the table and to chests in the array
            int x, y, z;  // incremental sum of possible coin combinations
    
            // Time complexity: O(n^2)
            // This approach minimises the re-calculation of
            // overlapping solutions.
            for (gap = 0; gap < n; gap++) { 
                for (i = 0, j = gap; j < n; i++, j++) {
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0; 
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0; 
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0; 
    
                    table[i, j] = Math.Max(boxes[i] + Math.Min(x, y), 
                                        boxes[j] + Math.Min(y, z)); 
                } 
            } 

            // Account for different position of final results depending on odd or even number of chests
            int result = Math.Max(table[0, n - 1] - table[1, n - 1], table[0, n - 1] - table[0, n - 2]);
#if DEBUG
            stopwatch.Stop();
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("Duration: {0}", stopwatch.Elapsed);
            PrintTable(table, n);
#endif
            return result;
        }        
    }
}