using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Longest_Increasing_Subsequence
{
    /// <summary>
    /// Complexity : O(N^2)
    /// Aux. Memory : O(N)
    /// </summary>
    class DPSolver : ISolver
    {
        public int GetLengthOfLongestIncreasingSubSequence(int[] array)
        {
            int n = array.Length;
            
            int[] a = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                a[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[i] > array[j] && a[j] + 1 > a[i])
                    {
                        a[i] = a[j] + 1;
                    }
                }
            }

            return a.Max();
        }
    }
}
