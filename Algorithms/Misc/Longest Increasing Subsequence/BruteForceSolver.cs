using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Longest_Increasing_Subsequence
{
    /// <summary>
    /// Complexity : O(N!)
    /// Aux. Memory : O(N) (because of recursion call stack)
    /// </summary>
    class BruteForceSolver : ISolver
    {
        public int GetLengthOfLongestIncreasingSubSequence(int[] array)
        {
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int k = FindMax(array, i);

                if (k > max) max = k;
            }

            return max;
        }

        private int FindMax(int[] array, int j)
        {
            int max = 1;

            for (int i = j + 1; i < array.Length; i++)
            {
                if (array[i] > array[j])
                {
                    int k = FindMax(array, i);

                    if (k + 1 > max) max = k + 1;
                }
            }

            return max;
        }
    }
}
