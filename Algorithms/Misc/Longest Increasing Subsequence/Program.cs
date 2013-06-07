using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int n = 50;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = r.Next(30);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();

            //array = new int[] { 6, 8, 0, 2, 6, 1 };

            ISolver solver = new BruteForceSolver();
            ISolver dpsolver = new DPSolver();
            ISolver efficientSolver = new EfficientSolver();

            Console.WriteLine(solver.GetLengthOfLongestIncreasingSubSequence(array));
            Console.WriteLine(dpsolver.GetLengthOfLongestIncreasingSubSequence(array));
            Console.WriteLine(efficientSolver.GetLengthOfLongestIncreasingSubSequence(array));
        }
    }
}
