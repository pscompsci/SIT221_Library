using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace Task_6_2
{
    public class BoxOfCoins
    {
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

        public static int Solve(int[] boxes)
        {
            int n = boxes.Length;
            // Create a table to store solutions of subproblems 
            int[,] table = new int[n, n]; 
            int gap, i, j, x, y, z; 
    
            // Fill table using above recursive formula. 
            // Note that the table is filled in diagonal 
            // fashion (similar to http:// goo.gl/PQqoS), 
            // from diagonal elements to table[0][n-1] 
            // which is the result. 
            for (gap = 0; gap < n; ++gap) { 
                for (i = 0, j = gap; j < n; ++i, ++j) { 
    
                    // Here x is value of F(i+2, j), 
                    // y is F(i+1, j-1) and z is 
                    // F(i, j-2) in above recursive formula 
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0; 
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0; 
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0; 
    
                    table[i, j] = Math.Max(boxes[i] + Math.Min(x, y), 
                                        boxes[j] + Math.Min(y, z)); 
                } 
            } 

            int total = n % 2 == 0 ? table[0, n - 1] - table[1, n - 1] : table[0, n - 1] - table[0, n - 2]; 
            Console.WriteLine("Total: {0}", total);
            PrintTable(table, n);
            // return table[0, n - 1] - table[0, n - 2]; 
            return Math.Max(table[0, n - 1] - table[1, n - 1], table[0, n - 1] - table[0, n - 2]);
        }        
    }

}